using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Nome / Apelido", Prompt = "Ex: Paulo ou Paulinho")]
        public string NickName { get; set; }

        [Display(Name = "Descrição", Prompt = "Para sua própria segurança, favor não incluir seu celular, email ou quaisquer informações de contato. \n\nOBS: Promover redes sociais, produtos, serviços e/ou conteúdos que violem direitos de terceiros estará sujeito a banimento da plataforma.")]
        public string Description { get; set; }

        [Display(Name = "Longitude")]
        public double? Longitude { get; set; }

        [Display(Name = "Latitude")]
        public double? Latitude { get; set; }

        [Display(Name = "Localização", Prompt = "Favor clicar no botão ao lado", Description = "Informação automática (deve-se liberar acesso a localização do aparelho)")]
        public string Location { get; set; }

        [Display(Name = "Status de Relacionamento")]
        public MaritalStatus MaritalStatus { get; set; }

        [Display(Name = "Intenções", Description = "De acordo com a seleção, poderá alterar os campos disponíveis e/ou obrigatórios (escolha até 2 opções)")]
        public IReadOnlyList<Intent> Intent { get; set; } = Array.Empty<Intent>();

        [Display(Name = "Sexo Biológico")]
        public BiologicalSex BiologicalSex { get; set; }

        [Display(Name = "Identidade de Gênero", Description = "Alteração opcional (opção mais comum selecionada automaticamente)")]
        public GenderIdentity GenderIdentity { get; set; }

        [Display(Name = "Orientação Sexual", Description = "Alteração opcional (opção mais comum selecionada automaticamente)")]
        public SexualOrientation SexualOrientation { get; set; }

        [Display(Name = "Idiomas", Description = "Escolhido automaticamente de acordo com os idiomas oficiais do pais (caso disponível)")]
        public IReadOnlyList<Language> Languages { get; set; } = Array.Empty<Language>();

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