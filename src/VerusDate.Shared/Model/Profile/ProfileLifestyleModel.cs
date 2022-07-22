using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Model
{
    public class ProfileLifestyleModel
    {
        [Display(Name = "Bebe")]
        public Drink? Drink { get; set; }

        [Display(Name = "Fuma")]
        public Smoke? Smoke { get; set; }

        [Display(Name = "Dieta", Description = "Opção mais comum selecionada automaticamente")]
        public Diet? Diet { get; set; }

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

        [Display(Name = "Personalidade Financeira", Description = "Caso tenha dúvidas, poderá fazer um teste no site original (somente em inglês)")]
        public MoneyPersonality? MoneyPersonality { get; set; }

        [Display(Name = "Dividindo as Contas")]
        public SplitTheBill? SplitTheBill { get; set; }

        [Display(Name = "Personalidade na Relação", Description = "Caso tenha dúvidas, poderá fazer um teste em site de terceiros (somente em inglês)")]
        public RelationshipPersonality? RelationshipPersonality { get; set; }

        [Display(Name = "Personalidade MBTI", Description = "Este campo é opcional (é necessário fazer um teste em site de terceiros / multi-idiomas)")]
        public MyersBriggsTypeIndicator? MyersBriggsTypeIndicator { get; set; }

        [Display(Name = "Linguagem do Amor", Description = "Caso tenha dúvidas, poderá fazer um teste no site original (somente em inglês)")]
        public LoveLanguage? LoveLanguage { get; set; }

        [Display(Name = "Personalidade Sexual", Description = "Caso tenha dúvidas, poderá fazer um teste no site original (somente em inglês)")]
        public SexPersonality? SexPersonality { get; set; }

        [Display(Name = "Person. Sexual (Preferências)", Description = "Diferentemente das outras personalidades, a compatibilidade desta é uma preferência pessoal")]
        public IReadOnlyList<SexPersonality> SexPersonalityPreferences { get; set; } = Array.Empty<SexPersonality>();
    }
}