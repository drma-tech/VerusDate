﻿using System;
using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Model.Profile
{
    public class ProfileLifestyle
    {
        [Display(Name = "Bebe")]
        public Drink Drink { get; set; }

        [Display(Name = "Fuma")]
        public Smoke Smoke { get; set; }

        [Display(Name = "Dieta", Description = "Este campo é opcional")]
        public Diet Diet { get; set; } = Diet.Omnivore;

        [Display(Name = "Tem Filho(s)")]
        public HaveChildren? HaveChildren { get; set; }

        [Display(Name = "Quer Filho(s)")]
        public WantChildren? WantChildren { get; set; }

        [Display(Name = "Educação")]
        public EducationLevel? EducationLevel { get; set; }

        [Display(Name = "Carreira")]
        public CareerCluster? CareerCluster { get; set; }

        [Display(Name = "Religião")]
        public Religion? Religion { get; set; }

        [Display(Name = "Personalidade Financeira")]
        public MoneyPersonality? MoneyPersonality { get; set; }

        [Display(Name = "Personalidade no Relacionamento")]
        public RelationshipPersonality? RelationshipPersonality { get; set; }

        [Display(Name = "Personalidade MBTI")]
        public MyersBriggsTypeIndicator? MyersBriggsTypeIndicator { get; set; }

        [Display(Name = "Hobbies")]
        public string[] Hobbies { get; set; } = Array.Empty<string>();
    }
}