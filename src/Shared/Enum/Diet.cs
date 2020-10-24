using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum Diet
    {
        [Display(Name = "Onívora", Description = "A dieta onívora consiste em produtos de origem animal e carne, além de frutas e legumes. Significa essencialmente que se pode comer tudo e nada se limita a eles.")]
        Omnivore = 1,

        [Display(Name = "Flexitária", Description = "A dieta flexitária está entre onívora e vegetariana. É alguém que segue uma dieta principalmente vegetariana, com exceção de algumas carnes de animais. Também é chamada de dieta semi-vegetariana.")]
        Flexitarian = 2,

        [Display(Name = "Cegetariana", Description = "A dieta vegetariana não consiste em carne de animal, mas inclui outros produtos de origem animal, como laticínios, como leite, queijo, iogurte, e pode até incluir ovos ou não.")]
        Vegetarian = 3,

        [Display(Name = "Vegana", Description = "A dieta vegana é semelhante à dieta vegetariana, pois não inclui carne animal. Mas também não inclui produtos de origem animal.")]
        Vegan = 4,

        [Display(Name = "Alimentos Crus", Description = "A dieta de alimentos crus consiste apenas de frutas frescas, não cozidas, legumes, nozes e/ou sementes. Em outras palavras, é puramente cru e não contém alimentos processados que geralmente perdem seu valor nutricional.")]
        RawFood = 5,

        [Display(Name = "Sem Glúten", Description = "A dieta sem glúten está essencialmente ligado a eliminação de glúten dos alimentos. O glúten é um tipo de proteína comumente encontrada no trigo e outros grãos.")]
        GlutenFree = 6,

        [Display(Name = "Orgânica / Totalmente Natural / Local", Description = "Uma dieta alimentar orgânica, totalmente natural e/ou local consiste em todos ou principalmente alimentos orgânicos e/ou produzidos localmente, geralmente por pequenas empresas ou fazendas.")]
        OrganicAllnaturalLocal = 7,

        [Display(Name = "Desintoxicação / Perda de Peso", Description = "Finalmente, a dieta de desintoxicação e/ou perda de peso pode ser combinada com outras dietas para desintoxicar o corpo de toxinas e/ou perder peso.")]
        DetoxWwightLoss = 8
    }
}