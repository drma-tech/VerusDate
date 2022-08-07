using System;
using System.Collections.Generic;
using VerusDate.Shared.Core;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Model
{
    public enum LocationType
    {
        Full,
        Country,
        State,
        City
    }

    public class ProfileBasicModel
    {
        [Custom(Name = "NickName_Name", Prompt = "NickName_Prompt", ResourceType = typeof(Resources.Model.ProfileBasicModel))]
        public string NickName { get; set; }

        [Custom(Name = "Description_Name", Prompt = "Description_Prompt", ResourceType = typeof(Resources.Model.ProfileBasicModel))]
        public string Description { get; set; }

        [Custom(Name = "Longitude")]
        public double? Longitude { get; set; }

        [Custom(Name = "Latitude")]
        public double? Latitude { get; set; }

        [Custom(Name = "Location_Name", Prompt = "Location_Prompt", Description = "Location_Description", ResourceType = typeof(Resources.Model.ProfileBasicModel))]
        public string Location { get; set; }

        [Custom(Name = "Languages_Name", Description = "Languages_Description", ResourceType = typeof(Resources.Model.ProfileBasicModel))]
        public IReadOnlyList<Language> Languages { get; set; } = Array.Empty<Language>();

        [Custom(Name = "CurrentSituation_Name", ResourceType = typeof(Resources.Model.ProfileBasicModel))]
        public CurrentSituation? CurrentSituation { get; set; }

        [Custom(Name = "Intentions_Name", Description = "Intentions_Description", ResourceType = typeof(Resources.Model.ProfileBasicModel))]
        public IReadOnlyList<Intentions> Intentions { get; set; } = Array.Empty<Intentions>();

        [Custom(Name = "BiologicalSex_Name", ResourceType = typeof(Resources.Model.ProfileBasicModel))]
        public BiologicalSex? BiologicalSex { get; set; }

        [Custom(Name = "GenderIdentity_Name", Description = "GenderIdentity_Description", ResourceType = typeof(Resources.Model.ProfileBasicModel))]
        public GenderIdentity? GenderIdentity { get; set; }

        [Custom(Name = "SexualOrientation_Name", Description = "SexualOrientation_Description", ResourceType = typeof(Resources.Model.ProfileBasicModel))]
        public SexualOrientation? SexualOrientation { get; set; }

        public string GetLocation(LocationType type)
        {
            var parts = Location.Split(" - ");

            switch (type)
            {
                case LocationType.Full:
                    return Location;

                case LocationType.Country:
                    return parts[0];

                case LocationType.State:
                    return parts[1];

                case LocationType.City:
                    if (parts.Length == 4)
                        return parts[2] + " - " + parts[3]; //county - city
                    else
                        return parts[2];

                default:
                    return null;
            }
        }
    }
}