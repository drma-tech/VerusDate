using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Model.Profile
{
    public class ProfileBasic
    {
        [Display(Name = "Nome / Apelido", Prompt = "Ex: Paulo ou Paulinho")]
        public string NickName { get; set; }

        [Display(Name = "Descrição", Prompt = "Para sua própria segurança, favor não incluir seu celular, email ou quaisquer informações de contato. \n\nOBS: Promover redes sociais de outras plataformas ou conteúdo que viole direitos de terceiros estará sujeito a banimento da plataforma.")]
        public string Description { get; set; }

        [Display(Name = "Longitude")]
        public double? Longitude { get; set; }

        [Display(Name = "Latitude")]
        public double? Latitude { get; set; }

        [Display(Name = "Localização", Prompt = "Favor, liberar o GPS do seu aparelho", Description = "Informação automática (deve-se liberar a opção de GPS)")]
        public string Location { get; set; }

        [Display(Name = "Status de Relacionamento")]
        public MaritalStatus MaritalStatus { get; set; }

        [Display(Name = "Intenção")]
        public IReadOnlyList<Intent> Intent { get; set; } = Array.Empty<Intent>();

        [Display(Name = "Sexo Biológico")]
        public BiologicalSex BiologicalSex { get; set; }

        [Display(Name = "Identidade de Gênero", Description = "Este campo é opcional")]
        public GenderIdentity GenderIdentity { get; set; } = GenderIdentity.Cisgender;

        [Display(Name = "Orientação Sexual", Description = "Este campo é opcional")]
        public SexualOrientation SexualOrientation { get; set; } = SexualOrientation.Heteressexual;
    }
}