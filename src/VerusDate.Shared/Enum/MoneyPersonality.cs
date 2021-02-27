using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum MoneyPersonality
    {
        [Display(Name = "Devedora", Description = "Os devedores enfrentam problemas financeiros tão graves que levam muito tempo para tomar a maioria das decisões de compra. Entre as dificuldades estão: perda de empregos, desastres naturais, doenças e excedentes de gastos anteriores, que mantêm a dívida alta e a poupança baixa.")]
        Debtor = 1,

        [Display(Name = "Materialista", Description = "Os materialistas adoram bons carros, novos gadgets e roupas de marca. Os materialistas não são compradores de barganha; eles estão na moda e sempre procurando fazer uma declaração. Isso geralmente significa o desejo de ter o melhor e mais recente telefone celular, a maior televisão 4K e uma bela casa.")]
        BigSpender = 2,

        [Display(Name = "Desligada", Description = "Os desligados não prestam muita atenção ao dinheiro, acreditando ou esperando que a vida dê certo; eles podem se sentir incompetentes ou sobrecarregados com tarefas financeiras.")]
        Avoider = 3,

        [Display(Name = "Poupadora", Description = "Os poupadores são exatamente o oposto dos materialistas. Apagam as luzes ao sair da sala, fecham a porta da geladeira rapidamente para manter o frio, fazem compras apenas quando necessário e raramente fazem compras com cartão de crédito. Eles geralmente não têm dívidas e são frequentemente vistos como pão duros.")]
        Saver = 4,

        [Display(Name = "Investidor", Description = "Os investidores estão cientes do poder do dinheiro. Eles entendem suas situações financeiras e tentam colocar seu dinheiro para trabalhar para eles.")]
        Investor = 5
    }
}