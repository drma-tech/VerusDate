using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum CareerCluster
    {
        [Display(Name = "Agricultura, Alimentação e Recursos Naturais", Description = "produção, processamento, distribuição, financiamento e comercialização de produtos agrícolas, incluindo alimentos, plantas, fibras, animais, madeira e outros recursos vegetais e animais")]
        Agriculture_Food_NaturalResources = 1,

        [Display(Name = "Arquitetura e Construção", Description = "projetar, planejar, gerenciar, construir e manter um ambiente de construção")]
        Architecture_Construction = 2,

        [Display(Name = "Artes, tecnologia de áudio / vídeo e comunicações", Description = "projetar, produzir, exibir, executar, escrever e publicar conteúdo multimídia, incluindo artes visuais e cênicas e serviços de design, jornalismo e entretenimento")]
        Arts_AudioVideoTechnology_Communications = 3,

        [Display(Name = "Gestão e Administração de Negócios", Description = "planejar, organizar, dirigir e avaliar funções de negócios essenciais para operações de negócios eficazes e produtivas")]
        BusinessManagement_Administration = 4,

        [Display(Name = "Educação e treinamento", Description = "planejar, gerenciar e fornecer serviços de educação e treinamento e serviços de suporte à aprendizagem relacionados, incluindo serviços de administração e biblioteca")]
        Education_Training = 5,

        [Display(Name = "Finanças", Description = "planejamento financeiro e de investimentos, bancos, seguros e gestão financeira de negócios")]
        Finance = 6,

        [Display(Name = "Governo e Administração Pública", Description = "planejar e fornecer serviços governamentais nos níveis federal, estadual e local, incluindo serviços relacionados à segurança nacional, legislação, serviço externo, receita e tributação e regulamentos")]
        Government_PublicAdministration = 7,

        [Display(Name = "Ciência da Saúde", Description = "planejamento, gerenciamento e prestação de serviços terapêuticos, serviços de diagnóstico, informática em saúde, serviços de suporte e pesquisa e desenvolvimento biotecnológico")]
        Health_Science = 8,

        [Display(Name = "Hospitalidade e Turismo", Description = "gerenciamento, marketing e operações de restaurantes e outros serviços de alimentação, hospedagem, atrações, eventos recreativos e serviços relacionados a viagens")]
        Hospitality_Tourism = 9,

        [Display(Name = "Serviços Humanos", Description = "fornecer serviços familiares e individuais, como aconselhamento e saúde mental, cuidados pessoais e aconselhamento ao consumidor")]
        HumanServices = 10,

        [Display(Name = "Tecnologia da informação", Description = "design, desenvolvimento, suporte e gerenciamento de serviços de hardware, software, Internet, multimídia e integração de sistemas")]
        InformationTechnology = 11,

        [Display(Name = "Direito, Segurança Pública, Correções e Segurança", Description = "planejar, gerenciar e fornecer segurança jurídica, pública, correções, serviços de proteção e segurança nacional, incluindo suporte técnico e profissional")]
        Law_PublicSafety_Corrections_Security = 12,

        [Display(Name = "Fabricação", Description = "planejar, gerenciar e executar o processamento de materiais em produtos intermediários ou finais e atividades de suporte técnico e profissional relacionadas, como planejamento e controle de produção, manutenção e engenharia de fabricação/processo")]
        Manufacturing = 13,

        [Display(Name = "Marketing, Vendas e Serviços", Description = "planejar, gerenciar e executar atividades de marketing/vendas para atingir os objetivos organizacionais")]
        Marketing_Sales_Service = 14,

        [Display(Name = "Ciência, Tecnologia, Engenharia e Matemática", Description = "planejar, gerenciar e fornecer pesquisa científica e serviços profissionais e técnicos (por exemplo, ciências físicas, ciências sociais, engenharia), incluindo serviços de laboratório e testes e serviços de pesquisa e desenvolvimento")]
        Science_Technology_Engineering_Mathematics = 15,

        [Display(Name = "Transporte, Distribuição e Logística", Description = "planejar e gerenciar o movimento de pessoas, materiais e mercadorias por estrada, oleoduto, ar, ferrovia e água. Serviços de suporte profissional, como serviços de logística e manutenção de equipamentos e instalações móveis, também fazem parte desse cluster")]
        Transportation_Distribution_Logistics = 16,
    }
}