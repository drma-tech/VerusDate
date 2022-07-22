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

        protected bool IsShortTerm
        { get { return !profile.Basic.Intentions.IsLongTerm(); } }

        protected override async Task LoadData()
        {
            profile = await Http.Profile_Get(SessionStorage);

            if (profile == null) //para novos usuários
            {
                profile = new()
                {
                    Basic = new(),
                    Bio = new(),
                    Lifestyle = new(),
                    Interest = new()
                };

                profile.Basic.GenderIdentity = GenderIdentity.Cisgender;
                profile.Basic.SexualOrientation = SexualOrientation.Heterosexual;
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

                        AddLanguages((Country)Enum.Parse(typeof(Country), address.countryCode));
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
            //https://en.wikipedia.org/wiki/List_of_official_languages
            //https://en.wikipedia.org/wiki/List_of_official_languages_by_country_and_territory
            if (profile.Basic.Languages.Any()) return;

            switch (country)
            {
                case Country.CHN:
                    profile.Basic.Languages = new Language[] { Language.StandardChinese };
                    break;

                case Country.IND:
                    profile.Basic.Languages = new Language[] { Language.HindiUrdu };
                    break;

                case Country.USA:
                    profile.Basic.Languages = new Language[] { Language.English };
                    break;

                case Country.IDN:
                    profile.Basic.Languages = new Language[] { Language.Malay }; //Indonesian = It is a standardized variety of Malay
                    break;

                case Country.PAK:
                    profile.Basic.Languages = new Language[] { Language.HindiUrdu };
                    break;

                case Country.NGA:
                    profile.Basic.Languages = new Language[] { Language.English };
                    break;

                case Country.BRA:
                    profile.Basic.Languages = new Language[] { Language.Portuguese };
                    break;

                case Country.BGD:
                    //profile.Basic.Languages = new Language[] { Language.Bengali };
                    break;

                case Country.RUS:
                    profile.Basic.Languages = new Language[] { Language.Russian };
                    break;

                case Country.MEX:
                    profile.Basic.Languages = new Language[] { Language.Spanish };
                    break;

                case Country.JPN:
                    //profile.Basic.Languages = new Language[] { Language.Japanese };
                    break;

                case Country.ETH:
                    //Oromo, Amharic
                    break;

                case Country.PHL:
                    //Filipino (Tagalog)
                    break;

                case Country.EGY:
                    profile.Basic.Languages = new Language[] { Language.Arabic };
                    break;

                case Country.VNM:
                    //profile.Basic.Languages = new Language[] { Language.Vietnamese };
                    break;

                case Country.COD:
                    profile.Basic.Languages = new Language[] { Language.French };
                    break;

                case Country.IRN:
                    profile.Basic.Languages = new Language[] { Language.Persian };
                    break;

                case Country.TUR:
                    profile.Basic.Languages = new Language[] { Language.Turkish };
                    break;

                case Country.DEU:
                    profile.Basic.Languages = new Language[] { Language.German };
                    break;

                case Country.FRA:
                    profile.Basic.Languages = new Language[] { Language.French };
                    break;

                case Country.GBR:
                    profile.Basic.Languages = new Language[] { Language.English };
                    break;

                case Country.THA:
                    //Thai
                    break;

                case Country.ZAF:
                    //Zulu, Xhosa, Afrikaans, English
                    break;

                case Country.TZA:
                    profile.Basic.Languages = new Language[] { Language.Swahili, Language.English };
                    break;

                case Country.ITA:
                    profile.Basic.Languages = new Language[] { Language.Italian };
                    break;

                case Country.MMR:
                    //Burmese
                    break;

                case Country.KOR:
                    profile.Basic.Languages = new Language[] { Language.Korean };
                    break;

                case Country.COL:
                    profile.Basic.Languages = new Language[] { Language.Spanish };
                    break;

                case Country.KEN:
                    profile.Basic.Languages = new Language[] { Language.Swahili, Language.English };
                    break;

                case Country.ESP:
                    profile.Basic.Languages = new Language[] { Language.Spanish };
                    break;

                case Country.ARG:
                    profile.Basic.Languages = new Language[] { Language.Spanish };
                    break;

                case Country.DZA:
                    profile.Basic.Languages = new Language[] { Language.Arabic };
                    break;

                case Country.SDN:
                    profile.Basic.Languages = new Language[] { Language.Arabic };
                    break;

                case Country.UGA:
                    profile.Basic.Languages = new Language[] { Language.English };
                    break;

                case Country.IRQ:
                    profile.Basic.Languages = new Language[] { Language.Arabic };
                    break;

                case Country.UKR:
                    //Ukrainian
                    break;

                case Country.CAN:
                    profile.Basic.Languages = new Language[] { Language.English };
                    break;

                case Country.POL:
                    //Polish
                    break;

                case Country.MAR:
                    profile.Basic.Languages = new Language[] { Language.Arabic };
                    break;

                case Country.UZB:
                    //Uzbek
                    break;

                case Country.SAU:
                    profile.Basic.Languages = new Language[] { Language.Arabic };
                    break;

                case Country.PER:
                    profile.Basic.Languages = new Language[] { Language.Spanish };
                    break;

                case Country.AGO:
                    profile.Basic.Languages = new Language[] { Language.Portuguese };
                    break;

                case Country.AFG:
                    profile.Basic.Languages = new Language[] { Language.Persian }; //Dari, which is a variety of and mutually intelligible with Persian
                    //Pashto, Dari
                    break;

                case Country.MYS:
                    profile.Basic.Languages = new Language[] { Language.Malay };
                    break;

                case Country.MOZ:
                    profile.Basic.Languages = new Language[] { Language.Portuguese };
                    break;

                case Country.GHA:
                    profile.Basic.Languages = new Language[] { Language.English };
                    break;

                case Country.YEM:
                    profile.Basic.Languages = new Language[] { Language.Arabic };
                    break;

                case Country.NPL:
                    //Nepali
                    break;

                case Country.VEN:
                    profile.Basic.Languages = new Language[] { Language.Spanish };
                    break;

                case Country.CIV:
                    profile.Basic.Languages = new Language[] { Language.French };
                    break;

                case Country.MDG:
                    //Malagasy (official, and national language), French (official).
                    break;

                case Country.AUS:
                    profile.Basic.Languages = new Language[] { Language.English };
                    break;

                case Country.PRK:
                    profile.Basic.Languages = new Language[] { Language.Korean };
                    break;

                case Country.CMR:
                    profile.Basic.Languages = new Language[] { Language.French };
                    break;

                case Country.NER:
                    profile.Basic.Languages = new Language[] { Language.French };
                    break;

                case Country.TWN:
                    profile.Basic.Languages = new Language[] { Language.StandardChinese };
                    break;

                case Country.LKA:
                    //Sinhala
                    break;

                case Country.BFA:
                    profile.Basic.Languages = new Language[] { Language.French };
                    break;

                case Country.MWI:
                    profile.Basic.Languages = new Language[] { Language.English };
                    break;

                case Country.MLI:
                    profile.Basic.Languages = new Language[] { Language.French };
                    break;

                case Country.CHL:
                    profile.Basic.Languages = new Language[] { Language.Spanish };
                    break;

                case Country.KAZ:
                    //Kazakh, Russian
                    break;

                case Country.ROU:
                    profile.Basic.Languages = new Language[] { Language.Romanian };
                    break;

                case Country.ZMB:
                    profile.Basic.Languages = new Language[] { Language.English };
                    break;

                case Country.SYR:
                    profile.Basic.Languages = new Language[] { Language.Arabic };
                    break;

                case Country.ECU:
                    profile.Basic.Languages = new Language[] { Language.Spanish };
                    break;

                case Country.NLD:
                    profile.Basic.Languages = new Language[] { Language.Dutch };
                    break;

                case Country.SEN:
                    profile.Basic.Languages = new Language[] { Language.French };
                    break;

                case Country.GTM:
                    profile.Basic.Languages = new Language[] { Language.Spanish };
                    break;

                case Country.TCD:
                    profile.Basic.Languages = new Language[] { Language.French, Language.Arabic };
                    break;

                case Country.SOM:
                    profile.Basic.Languages = new Language[] { Language.Somali };
                    break;

                case Country.ZWE:
                    //Shona, English
                    break;

                case Country.KHM:
                    //Khmer
                    break;

                case Country.SSD:
                    profile.Basic.Languages = new Language[] { Language.English };
                    break;

                case Country.RWA:
                    //Kinyarwanda
                    break;

                case Country.GIN:
                    profile.Basic.Languages = new Language[] { Language.French };
                    break;

                case Country.BDI:
                    //Kirundi
                    break;

                case Country.BEN:
                    profile.Basic.Languages = new Language[] { Language.French };
                    break;

                case Country.BOL:
                    profile.Basic.Languages = new Language[] { Language.Spanish };
                    break;

                case Country.TUN:
                    profile.Basic.Languages = new Language[] { Language.Arabic };
                    break;

                case Country.HTI:
                    profile.Basic.Languages = new Language[] { Language.French };
                    break;

                case Country.BEL:
                    profile.Basic.Languages = new Language[] { Language.Dutch };
                    break;

                case Country.JOR:
                    profile.Basic.Languages = new Language[] { Language.Arabic };
                    break;

                case Country.CUB:
                    profile.Basic.Languages = new Language[] { Language.Spanish };
                    break;

                case Country.GRC:
                    profile.Basic.Languages = new Language[] { Language.Greek };
                    break;

                case Country.DOM:
                    profile.Basic.Languages = new Language[] { Language.Spanish };
                    break;

                case Country.CZE:
                    //Czech
                    break;

                case Country.SWE:
                    profile.Basic.Languages = new Language[] { Language.Swedish };
                    break;

                case Country.PRT:
                    profile.Basic.Languages = new Language[] { Language.Portuguese };
                    break;

                case Country.AZE:
                    //Azerbaijani
                    break;

                case Country.HUN:
                    //Hungarian
                    break;

                case Country.HND:
                    profile.Basic.Languages = new Language[] { Language.Spanish };
                    break;

                case Country.ISR:
                    //Hebrew
                    break;

                case Country.TJK:
                    profile.Basic.Languages = new Language[] { Language.Russian };
                    break;

                case Country.BLR:
                    profile.Basic.Languages = new Language[] { Language.Russian };
                    break;

                case Country.ARE:
                    profile.Basic.Languages = new Language[] { Language.Arabic };
                    break;

                case Country.PNG:
                    profile.Basic.Languages = new Language[] { Language.English };
                    break;

                case Country.AUT:
                    profile.Basic.Languages = new Language[] { Language.German };
                    break;

                case Country.CHE:
                    profile.Basic.Languages = new Language[] { Language.German };
                    break;

                case Country.SLE:
                    profile.Basic.Languages = new Language[] { Language.English };
                    break;

                case Country.TGO:
                    profile.Basic.Languages = new Language[] { Language.French };
                    break;

                case Country.HKG:
                    //Cantonese
                    break;

                case Country.PRY:
                    profile.Basic.Languages = new Language[] { Language.Spanish };
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