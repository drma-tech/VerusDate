using VerusDate.Shared.Core;

namespace VerusDate.Shared.Enum
{
    public enum Zodiac
    {
        [Custom(Name = "Aries", Description = "Pontos fortes: corajoso, determinado, confiante, entusiasmado, otimista, honesto, apaixonado; Fraquezas: impaciente, temperamental, mal humorado, impulsivo, agressivo.")]
        Aries = 1,

        [Custom(Name = "Touro", Description = "Pontos fortes: confiável, paciente, prático, dedicado, responsável, estável; Fraquezas: teimoso, possessivo, intransigente.")]
        Taurus = 2,

        [Custom(Name = "Gêmeos", Description = "Pontos fortes: gentil, afetuoso, curioso, adaptável, capacidade de aprender rápido e trocar ideias; Fraquezas: nervoso, inconsistente, indeciso.")]
        Gemini = 3,

        [Custom(Name = "Câncer", Description = "Pontos fortes: tenaz, altamente imaginativo, leal, emocional, simpático, persuasivo; Fraquezas: temperamental, pessimista, desconfiado, manipulador, inseguro.")]
        Cancer = 4,

        [Custom(Name = "Leão", Description = "Pontos fortes: criativo, apaixonado, generoso, caloroso, alegre, bem-humorado; Fraquezas: arrogante, teimoso, egocêntrico, preguiçoso, inflexível.")]
        Leo = 5,

        [Custom(Name = "Virgem", Description = "Pontos fortes: leal, analítico, gentil, trabalhador, prático; Fraquezas: timidez, preocupação, excessivamente crítica consigo mesmo e com os outros, tudo é trabalho e não se diverte.")]
        Virgo = 6,

        [Custom(Name = "Libra", Description = "Pontos fortes: cooperativo, diplomático, gracioso, justo, social; Fraquezas: indeciso, evita confrontos, carrega rancor, autopiedade.")]
        Libra = 7,

        [Custom(Name = "Escorpião", Description = "Pontos fortes: engenhoso, corajoso, apaixonado, teimoso, um verdadeiro amigo; Fraquezas: desconfiado, ciumento, reservado, violento.")]
        Scorpio = 8,

        [Custom(Name = "Sagitário", Description = "Pontos fortes: generoso, idealista, ótimo senso de humor; Fraquezas: promete mais do que pode entregar, muito impaciente, dirá qualquer coisa, não importa o quão pouco diplomático seja.")]
        Sagittarius = 9,

        [Custom(Name = "Capricórnio", Description = "Pontos fortes: responsável, disciplinado, autocontrole, bons gerentes; Fraquezas: sabe-tudo, implacável, condescendente, esperando o pior.")]
        Capricorn = 10,

        [Custom(Name = "Aquário", Description = "Pontos fortes: Progressivo, original, independente, humanitário; Fraquezas: decorre da expressão emocional, temperamental, intransigente, indiferente.")]
        Aquarius = 11,

        [Custom(Name = "Peixes", Description = "Pontos fortes: Compassivo, artístico, intuitivo, gentil, sábio, musical; Fraquezas: Medo, excessivamente confiante, triste, desejo de escapar da realidade, pode ser uma vítima ou um mártir.")]
        Pisces = 12
    }
}