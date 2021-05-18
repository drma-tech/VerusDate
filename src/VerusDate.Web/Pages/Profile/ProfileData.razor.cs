using BrowserInterop.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;
using VerusDate.Shared;
using VerusDate.Shared.Enum;
using VerusDate.Shared.Helper;
using VerusDate.Shared.Model;
using VerusDate.Web.Api;
using VerusDate.Web.Core;

namespace VerusDate.Web.Pages.Profile
{
    public partial class ProfileData
    {
        private ProfileModel profile = new();
        private GeoLocation GPS = new();
        protected bool IsShortTerm { get { return !profile.Basic.Intent.IsLongTerm(); } }

        protected override async Task LoadData()
        {
            profile = await Http.Profile_Get(SessionStorage);

            if (profile == null) //para novos usuários
            {
                profile = new();

                profile.Basic = new();
                profile.Bio = new();
                profile.Lifestyle = new();
                profile.Interest = new();

                profile.Basic.GenderIdentity = GenderIdentity.Cisgender;
                profile.Basic.SexualOrientation = SexualOrientation.Heteressexual;
                profile.Bio.BirthDate = DateTime.UtcNow.AddYears(-18).AddDays(1).Date;
                profile.Lifestyle.Diet = Diet.Omnivore;
            }
        }

        private async Task SetLocation(ProfileModel profile)
        {
            if (profile != null && profile.Basic != null /*&& !profile.Basic.Longitude.HasValue*/)
            {
                var window = await JsRuntime.Window();
                var navigator = await window.Navigator();
                var position = await navigator.Geolocation.GetCurrentPosition();

                if (position.Error != null)
                {
                    Toast.ShowWarning("", position.Error.Message);
                }
                else if (position.Location != null)
                {
                    GPS.Latitude = position.Location.Coords.Latitude;
                    GPS.Longitude = position.Location.Coords.Longitude;
                    GPS.Accuracy = position.Location.Coords.Accuracy;

                    //TODO: chamar código da api
                    var here = await Http.Map_GetLocation(SessionStorage, GPS.Latitude, GPS.Longitude);
                    if (here.items.Any())
                    {
                        var address = here.items[0].address;
                        profile.Basic.Location = address.GetLocation();

                        AddLanguages((Country)System.Enum.Parse(typeof(Country), address.countryCode));
                    }
                    else
                    {
                        profile.Basic.Location = "Localização Desconhecida";
                    }

                    profile.Basic.Longitude = GPS.Longitude;
                    profile.Basic.Latitude = GPS.Latitude;

                    if (GPS.Accuracy > 500)
                    {
                        Toast.ShowWarning("", $"A posição do GPS foi recuperada, mas a precisão é de apenas: {Math.Round(GPS.Accuracy / 1000, 1)} km. Tente novamente mais tarde ou use um dispositivo mais preciso.");
                    }
                }
                else
                {
                    Toast.ShowWarning("", $"Não foi possível detectar um sistema GPS no seu dispositivo. Favor, tentar novamente ou liberar acesso ao GPS do seu dispositivo.");
                }
            }
        }

        private void AddLanguages(Country country)
        {
            //https://pt.wikipedia.org/wiki/Lista_de_l%C3%ADnguas_oficiais
            if (profile.Basic.Languages.Any()) return;

            switch (country)
            {
                case Country.BRA:
                    profile.Basic.Languages = new Language[] { Language.Portuguese };
                    break;

                default:
                    break;
            }
        }

        private async Task HandleValidSubmit()
        {
            try
            {
                profile.ClearSimpleView();

                profile.Bio.Zodiac = profile.Bio.BirthDate.GetZodiac();

                if (profile.GetDataStatus() == DataStatus.New)
                {
                    await Http.Profile_Add(profile, SessionStorage, Toast);
                }
                else
                {
                    await Http.Profile_Update(profile, SessionStorage, Toast);
                }

                profile = await Http.Profile_Get(SessionStorage);
            }
            catch (Exception ex)
            {
                ex.ProcessException(Toast, Logger);
            }
        }

        private void HandleInvalidSubmit()
        {
            Toast.ShowWarning("", "Foram detectados erros de validação");
        }
    }
}