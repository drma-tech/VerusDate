using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum CareerCluster
    {
        [Display(GroupName = "Agricultura de recursos naturais", Name = "Agricultura, Alimentação e Recursos Naturais", Description = "produção, processamento, distribuição, financiamento e comercialização de produtos agrícolas, incluindo alimentos, plantas, fibras, animais, madeira e outros recursos vegetais e animais (Veterinário, oficial ambiental, manipulador de materiais perigosos, etc.)")]
        Agriculture_Food_NaturalResources = 1,

        [Display(GroupName = "Tecnologia Industrial e de Engenharia", Name = "Arquitetura e Construção", Description = "projetar, planejar, gerenciar, construir e manter um ambiente de construção (Arquiteto, encanador, paisagista etc.)")]
        Architecture_Construction = 2,

        [Display(GroupName = "Artes e Comunicação", Name = "Artes, tecnologia de áudio / vídeo e comunicações", Description = "projetar, produzir, exibir, executar, escrever e publicar conteúdo multimídia, incluindo artes visuais e cênicas e serviços de design, jornalismo e entretenimento (Ator, assistente de produção, fotógrafo, etc.)")]
        Arts_AudioVideoTechnology_Communications = 3,

        [Display(GroupName = "Negócios, Gestão e Tecnologia", Name = "Gestão e Administração de Negócios", Description = "planejar, organizar, dirigir e avaliar funções de negócios essenciais para operações de negócios eficazes e produtivas (Gerente de desenvolvimento de negócios, gerente de recursos humanos, assistente de marketing, etc.)")]
        BusinessManagement_Administration = 4,

        [Display(GroupName = "Serviços Humanos", Name = "Educação e treinamento", Description = "planejar, gerenciar e fornecer serviços de educação e treinamento e serviços de suporte à aprendizagem relacionados, incluindo serviços de administração e biblioteca (Professor pré-escolar, auxiliar do professor, conselheiro escolar, etc.)")]
        Education_Training = 5,

        [Display(GroupName = "Negócios, Gestão e Tecnologia", Name = "Finanças", Description = "planejamento financeiro e de investimentos, bancos, seguros e gestão financeira de negócios (Caixa de banco, contador, consultor financeiro, etc.)")]
        Finance = 6,

        [Display(GroupName = "Serviços Humanos", Name = "Governo e Administração Pública", Description = "planejar e fornecer serviços governamentais nos níveis federal, estadual e local, incluindo serviços relacionados à segurança nacional, legislação, serviço externo, receita e tributação e regulamentos (Controlador financeiro, comissário de bordo, funcionário administrativo, etc.)")]
        Government_PublicAdministration = 7,

        [Display(GroupName = "Serviços de saúde", Name = "Ciência da Saúde", Description = "planejamento, gerenciamento e prestação de serviços terapêuticos, serviços de diagnóstico, informática em saúde, serviços de suporte e pesquisa e desenvolvimento biotecnológico (Diretor de Enfermagem, Anestesiologista, Dentista, etc)")]
        Health_Science = 8,

        [Display(GroupName = "Serviços Humanos", Name = "Hospitalidade e Turismo", Description = "gerenciamento, marketing e operações de restaurantes e outros serviços de alimentação, hospedagem, atrações, eventos recreativos e serviços relacionados a viagens (Recepcionista de hotel, gerente de restaurante, agente de viagens, etc.)")]
        Hospitality_Tourism = 9,

        [Display(GroupName = "Serviços Humanos", Name = "Serviços Humanos", Description = "fornecer serviços familiares e individuais, como aconselhamento e saúde mental, cuidados pessoais e aconselhamento ao consumidor (Psicólogo, assistente social, cabeleireiro, etc.)")]
        HumanServices = 10,

        [Display(GroupName = "Negócios, Gestão e Tecnologia", Name = "Tecnologia da informação", Description = "design, desenvolvimento, suporte e gerenciamento de serviços de hardware, software, Internet, multimídia e integração de sistemas (Engenheiro de computação, desenvolvedor de software, web designer, etc.)")]
        InformationTechnology = 11,

        [Display(GroupName = "Serviços Humanos", Name = "Direito, Segurança Pública, Correções e Segurança", Description = "planejar, gerenciar e fornecer segurança jurídica, pública, correções, serviços de proteção e segurança nacional, incluindo suporte técnico e profissional (Advogado, assistente jurídico, policial, etc.)")]
        Law_PublicSafety_Corrections_Security = 12,

        [Display(GroupName = "Tecnologia Industrial e de Engenharia", Name = "Manufatura", Description = "planejar, gerenciar e executar o processamento de materiais em produtos intermediários ou finais e atividades de suporte técnico e profissional relacionadas, como planejamento e controle de produção, manutenção e engenharia de fabricação/processo (Engenheiro de manufatura, trabalhador de produção, eletricista, etc.)")]
        Manufacturing = 13,

        [Display(GroupName = "Negócios, Gestão e Tecnologia", Name = "Marketing, Vendas e Serviços", Description = "planejar, gerenciar e executar atividades de marketing/vendas para atingir os objetivos organizacionais (Representante de vendas, diretor de marketing, agente imobiliário, etc.)")]
        Marketing_Sales_Service = 14,

        [Display(GroupName = "Tecnologia Industrial e de Engenharia", Name = "Ciência, Tecnologia, Engenharia e Matemática", Description = "planejar, gerenciar e fornecer pesquisa científica e serviços profissionais e técnicos (por exemplo, ciências físicas, ciências sociais, engenharia), incluindo serviços de laboratório e testes e serviços de pesquisa e desenvolvimento (Técnico de laboratório, cientista de dados, assistente de pesquisa, etc.)")]
        Science_Technology_Engineering_Mathematics = 15,

        [Display(GroupName = "Tecnologia Industrial e de Engenharia", Name = "Transporte, Distribuição e Logística", Description = "planejar e gerenciar o movimento de pessoas, materiais e mercadorias por estrada, oleoduto, ar, ferrovia e água. Serviços de suporte profissional, como serviços de logística e manutenção de equipamentos e instalações móveis, também fazem parte desse cluster (Motorista de caminhão, gerente de logística, piloto, etc.)")]
        Transportation_Distribution_Logistics = 16,

        [Display(Name = "Sem carreira consolidada", Description = "Pode estar em início de carreira, estagiando, apenas estudando ou até sem estar trabalhando no momento.")]
        Student = 99
    }
}