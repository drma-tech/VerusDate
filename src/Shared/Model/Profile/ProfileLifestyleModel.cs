using System;
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

        [Display(Name = "Dieta", Description = "Alteração opcional (opção mais comum selecionada automaticamente)")]
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

        [Display(Name = "Personalidade Financeira")]
        public MoneyPersonality? MoneyPersonality { get; set; }

        [Display(Name = "Personalidade no Relacionamento")]
        public RelationshipPersonality? RelationshipPersonality { get; set; }

        [Display(Name = "Personalidade MBTI", Description = "Este campo é opcional (é necessário fazer um teste em site de terceiros / multi-idiomas)")]
        public MyersBriggsTypeIndicator? MyersBriggsTypeIndicator { get; set; }

        [Display(Name = "Personalidade Sexual", Description = "Caso tenha dúvidas, poderá fazer um teste no site original (somente em inglês)")]
        public SexPersonality? SexPersonality { get; set; }
    }
}