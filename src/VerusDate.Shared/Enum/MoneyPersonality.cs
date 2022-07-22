using VerusDate.Shared.Core;

namespace VerusDate.Shared.Enum
{
    /// <summary>
    /// https://empower.me/quiz/
    /// https://empower.me/quiz/start/
    /// </summary>
    public enum MoneyPersonality
    {
        [Custom(Name = "Idealist_Name", Description = "Idealist_Description", ResourceType = typeof(Resources.Enum.MoneyPersonality))]
        Idealist = 1,

        [Custom(Name = "Stockpiler_Name", Description = "Stockpiler_Description", ResourceType = typeof(Resources.Enum.MoneyPersonality))]
        Stockpiler = 2,

        [Custom(Name = "Hedonist_Name", Description = "Hedonist_Description", ResourceType = typeof(Resources.Enum.MoneyPersonality))]
        Hedonist = 3,

        [Custom(Name = "Celebrity_Name", Description = "Celebrity_Description", ResourceType = typeof(Resources.Enum.MoneyPersonality))]
        Celebrity = 4,

        [Custom(Name = "Nurturer_Name", Description = "Nurturer_Description", ResourceType = typeof(Resources.Enum.MoneyPersonality))]
        Nurturer = 5,

        [Custom(Name = "Conqueror_Name", Description = "Conqueror_Description", ResourceType = typeof(Resources.Enum.MoneyPersonality))]
        Conqueror = 6
    }

    public enum MoneyPersonalityOld
    {
        [Custom(Name = "Devedora", Description = "Os devedores enfrentam problemas financeiros tão graves que levam muito tempo para tomar a maioria das decisões de compra. Entre as dificuldades estão: perda de empregos, desastres naturais, doenças e excedentes de gastos anteriores, que mantêm a dívida alta e a poupança baixa.")]
        Debtor = 1,

        [Custom(Name = "Materialista", Description = "Os materialistas adoram bons carros, novos gadgets e roupas de marca. Os materialistas não são compradores de barganha; eles estão na moda e sempre procurando fazer uma declaração. Isso geralmente significa o desejo de ter o melhor e mais recente telefone celular, a maior televisão 4K e uma bela casa.")]
        BigSpender = 2,

        [Custom(Name = "Desligada", Description = "Os desligados não prestam muita atenção ao dinheiro, acreditando ou esperando que a vida dê certo; eles podem se sentir incompetentes ou sobrecarregados com tarefas financeiras.")]
        Avoider = 3,

        [Custom(Name = "Poupadora", Description = "Os poupadores são exatamente o oposto dos materialistas. Apagam as luzes ao sair da sala, fecham a porta da geladeira rapidamente para manter o frio, fazem compras apenas quando necessário e raramente fazem compras com cartão de crédito. Eles geralmente não têm dívidas e são frequentemente vistos como pão duros.")]
        Saver = 4,

        [Custom(Name = "Investidor", Description = "Os investidores estão cientes do poder do dinheiro. Eles entendem suas situações financeiras e tentam colocar seu dinheiro para trabalhar para eles.")]
        Investor = 5
    }
}