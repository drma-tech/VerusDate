using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Model
{
    public class ProfileBasicModel
    {
        [Display(Name = "Nome / Apelido", Prompt = "Ex: Paulo ou Paulinho")]
        public string NickName { get; set; }

        [Display(Name = "Descrição", Prompt = "Para sua própria segurança, favor não incluir seu celular, email ou quaisquer informações de contato. \n\nOBS: Promover redes sociais de outras plataformas ou conteúdo que viole direitos de terceiros estará sujeito a banimento da plataforma.")]
        public string Description { get; set; }

        [Display(Name = "Longitude")]
        public double? Longitude { get; set; }

        [Display(Name = "Latitude")]
        public double? Latitude { get; set; }

        [Display(Name = "Localização", Prompt = "Favor clicar no botão ao lado", Description = "Informação automática (deve-se liberar acesso a localização do aparelho)")]
        public string Location { get; set; }

        [Display(Name = "Status de Relacionamento")]
        public MaritalStatus MaritalStatus { get; set; }

        [Display(Name = "Intenção")]
        public IReadOnlyList<Intent> Intent { get; set; } = Array.Empty<Intent>();

        [Display(Name = "Sexo Biológico")]
        public BiologicalSex BiologicalSex { get; set; }

        [Display(Name = "Identidade de Gênero", Description = "Alteração opcional")]
        public GenderIdentity GenderIdentity { get; set; }

        [Display(Name = "Orientação Sexual", Description = "Alteração opcional")]
        public SexualOrientation SexualOrientation { get; set; }
    }
}