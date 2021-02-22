using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum Zodiac
    {
        [Display(Name = "Aries", Description = "Pontos fortes: corajoso, determinado, confiante, entusiasmado, otimista, honesto, apaixonado; Fraquezas: impaciente, temperamental, mal humorado, impulsivo, agressivo (não tem qualquer embasamento científico, portanto pode variar de pessoa para pessoa ou das fontes pesquisadas)")]
        Aries = 1,

        [Display(Name = "Touro", Description = "Pontos fortes: confiável, paciente, prático, dedicado, responsável, estável; Fraquezas: teimoso, possessivo, intransigente (não tem qualquer embasamento científico, portanto pode variar de pessoa para pessoa ou das fontes pesquisadas)")]
        Taurus = 2,

        [Display(Name = "Gêmeos", Description = "Pontos fortes: gentil, afetuoso, curioso, adaptável, capacidade de aprender rápido e trocar ideias; Fraquezas: nervoso, inconsistente, indeciso (não tem qualquer embasamento científico, portanto pode variar de pessoa para pessoa ou das fontes pesquisadas)")]
        Gemini = 3,

        [Display(Name = "Câncer", Description = "Pontos fortes: tenaz, altamente imaginativo, leal, emocional, simpático, persuasivo; Fraquezas: temperamental, pessimista, desconfiado, manipulador, inseguro (não tem qualquer embasamento científico, portanto pode variar de pessoa para pessoa ou das fontes pesquisadas)")]
        Cancer = 4,

        [Display(Name = "Leão", Description = "Pontos fortes: criativo, apaixonado, generoso, caloroso, alegre, bem-humorado; Fraquezas: arrogante, teimoso, egocêntrico, preguiçoso, inflexível (não tem qualquer embasamento científico, portanto pode variar de pessoa para pessoa ou das fontes pesquisadas)")]
        Leo = 5,

        [Display(Name = "Virgem", Description = "Pontos fortes: leal, analítico, gentil, trabalhador, prático; Fraquezas: timidez, preocupação, excessivamente crítica consigo mesmo e com os outros, tudo é trabalho e não se diverte (não tem qualquer embasamento científico, portanto pode variar de pessoa para pessoa ou das fontes pesquisadas)")]
        Virgo = 6,

        [Display(Name = "Libra", Description = "Pontos fortes: cooperativo, diplomático, gracioso, justo, social; Fraquezas: indeciso, evita confrontos, carrega rancor, autopiedade (não tem qualquer embasamento científico, portanto pode variar de pessoa para pessoa ou das fontes pesquisadas)")]
        Libra = 7,

        [Display(Name = "Escorpião", Description = "Pontos fortes: engenhoso, corajoso, apaixonado, teimoso, um verdadeiro amigo; Fraquezas: desconfiado, ciumento, reservado, violento (não tem qualquer embasamento científico, portanto pode variar de pessoa para pessoa ou das fontes pesquisadas)")]
        Scorpio = 8,

        [Display(Name = "Sagitário", Description = "Pontos fortes: generoso, idealista, ótimo senso de humor; Fraquezas: promete mais do que pode entregar, muito impaciente, dirá qualquer coisa, não importa o quão pouco diplomático seja (não tem qualquer embasamento científico, portanto pode variar de pessoa para pessoa ou das fontes pesquisadas)")]
        Sagittarius = 9,

        [Display(Name = "Capricórnio", Description = "Pontos fortes: responsável, disciplinado, autocontrole, bons gerentes; Fraquezas: sabe-tudo, implacável, condescendente, esperando o pior (não tem qualquer embasamento científico, portanto pode variar de pessoa para pessoa ou das fontes pesquisadas)")]
        Capricorn = 10,

        [Display(Name = "Aquário", Description = "Pontos fortes: Progressivo, original, independente, humanitário; Fraquezas: decorre da expressão emocional, temperamental, intransigente, indiferente (não tem qualquer embasamento científico, portanto pode variar de pessoa para pessoa ou das fontes pesquisadas)")]
        Aquarius = 11,

        [Display(Name = "Peixes", Description = "Pontos fortes: Compassivo, artístico, intuitivo, gentil, sábio, musical; Fraquezas: Medo, excessivamente confiante, triste, desejo de escapar da realidade, pode ser uma vítima ou um mártir (não tem qualquer embasamento científico, portanto pode variar de pessoa para pessoa ou das fontes pesquisadas)")]
        Pisces = 12
    }
}