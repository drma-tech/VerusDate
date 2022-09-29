using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VerusDate.Shared.Core;
using VerusDate.Shared.Enum;
using static VerusDate.Shared.Helper.ImageHelper;

namespace VerusDate.Shared.Model
{
    public class ProfileModel : CosmosBase
    {
        public ProfileModel() : base(CosmosType.Profile)
        {
        }

        //public DateTime? DtTopList { get; set; } = DateTime.UtcNow;
        public DateTime? DtLastLogin { get; set; } = DateTime.UtcNow;

        #region BASIC

        [Custom(Name = "Modality_Name", ResourceType = typeof(Resources.Model.ProfileBasicModel))]
        public Modality? Modality { get; set; }

        [Custom(Name = "NickName_Name", Prompt = "NickName_Prompt", ResourceType = typeof(Resources.Model.ProfileBasicModel))]
        public string NickName { get; set; }

        [Custom(Name = "Description_Name", Prompt = "Description_Prompt", ResourceType = typeof(Resources.Model.ProfileBasicModel))]
        public string Description { get; set; }

        [Custom(Name = "Location_Name", Prompt = "Location_Prompt", Description = "Location_Description", ResourceType = typeof(Resources.Model.ProfileBasicModel))]
        public string Location { get; set; }

        [Custom(Name = "Languages_Name", Description = "Languages_Description", FieldInfo = "Dizem que uma boa comunicação é a chave para qualquer relacionamento duradouro e bem-sucedido. É absolutamente essencial que duas pessoas compartilhem seus sentimentos, expressem seus pensamentos e, talvez o mais importante, ouçam atentamente uma à outra. Infelizmente, no mundo acelerado e agitado de hoje, muitos casais não encontram tempo para sentar e ter uma conversa significativa um com o outro. Telefonemas e mensagens de texto substituíram os bate-papos pessoais entre duas pessoas. A falta de comunicação adequada é uma das principais razões pelas quais muitos relacionamentos não duram tanto quanto deveriam. Tendo tudo isso em mente, é realmente uma boa ideia você namorar uma pessoa que não fala a mesma língua que você?", ResourceType = typeof(Resources.Model.ProfileBasicModel))]
        public IReadOnlyList<Language> Languages { get; set; } = Array.Empty<Language>();

        [Custom(Name = "CurrentSituation_Name", ResourceType = typeof(Resources.Model.ProfileBasicModel))]
        public CurrentSituation? CurrentSituation { get; set; }

        [Custom(Name = "Intentions_Name", Description = "Intentions_Description", FieldInfo = "De acordo com a psicoterapeuta e conselheira de casais de Sydney, Annie Gurton, ser honesto e claro sobre o que você está procurando em um relacionamento é para o benefício de ambos. E para a melhor chance de sucesso, ela acredita que vocês dois devem ter as mesmas intenções. \"É tudo uma questão de fazer um jogo\", explica ela. \"Algumas pessoas querem um relacionamento casual, talvez com outros parceiros ou talvez sem qualquer conversa de compromisso, e eles são melhores com alguém que pensa da mesma maneira e não com alguém que procura um compromisso de longo prazo.\"", ResourceType = typeof(Resources.Model.ProfileBasicModel))]
        public IReadOnlyList<Intentions> Intentions { get; set; } = Array.Empty<Intentions>();

        [Custom(Name = "BiologicalSex_Name", ResourceType = typeof(Resources.Model.ProfileBasicModel))]
        public BiologicalSex? BiologicalSex { get; set; }

        [Custom(Name = "GenderIdentity_Name", Description = "GenderIdentity_Description", ResourceType = typeof(Resources.Model.ProfileBasicModel))]
        public GenderIdentity? GenderIdentity { get; set; }

        [Custom(Name = "SexualOrientation_Name", Description = "SexualOrientation_Description", ResourceType = typeof(Resources.Model.ProfileBasicModel))]
        public SexualOrientation? SexualOrientation { get; set; }

        #endregion BASIC

        #region BIO

        [Custom(Name = "RaceCategory_Name",
            Description = "RaceCategory_Description",
            //FieldInfo = "É muito gratificante amar alguém que é diferente de você em termos de raça, cultura, identidade, religião e muito mais. Quando estamos abertos uns com os outros, podemos ampliar as perspectivas uns dos outros, abordar o mundo de maneiras diferentes e até descobrir que há uma conexão em nossas diferenças. Infelizmente, os casais inter-raciais ainda podem enfrentar dificuldades às vezes em virtude do fato de que o racismo existe em nossa sociedade em um nível profundo. Idealmente, o amor não deve ter limites a esse respeito. No entanto, na realidade, outras pessoas podem abrigar negatividade ou julgamento sobre um casal interracial. Os parceiros em um casamento inter-racial devem enfrentar essas questões juntos, mantendo empatia e apoio às experiências um do outro.", 
            ResourceType = typeof(Resources.Model.ProfileBioModel))]
        public RaceCategory? RaceCategory { get; set; }

        [Custom(Name = "BodyMass_Name", ResourceType = typeof(Resources.Model.ProfileBioModel))]
        public BodyMass? BodyMass { get; set; }

        [Custom(Name = "BirthDate_Name", ResourceType = typeof(Resources.Model.ProfileBioModel))]
        public DateTime BirthDate { get; set; }

        [Custom(Name = "Zodiac_Name",
            FieldInfo = "Primeiramente, precisamos deixar claro que não existe embasamento científico, portanto pode variar de pessoa para pessoa ou das fontes pesquisadas. Apesar disso, sabemos que astrologia é uma área muito popular no dia a dia das pessoas.",
            ResourceType = typeof(Resources.Model.ProfileBioModel))]
        public Zodiac Zodiac { get; set; }

        [Custom(Name = "Height_Name", ResourceType = typeof(Resources.Model.ProfileBioModel))]
        public Height? Height { get; set; }

        //https://www.gottman.com/blog/two-different-brains-in-love-conflict-resolution-in-neurodiverse-relationships/
        [Custom(
            Name = "Neurodiversity_Name",
            FieldInfo = " Relacionamentos românticos neurodiversos incluem pelo menos um ou mais parceiros neurodivergentes. A neurodiversidade refere-se à variação nas diferenças neurológicas que ocorrem naturalmente em todos os humanos, com 15-20% das pessoas caindo na categoria de neurodivergentes. Os maiores conflitos nos relacionamentos neurodiversos se resumem à dificuldade que os indivíduos têm em entender as diferenças na forma como cada parceiro processa as informações. Para que seus relacionamentos neurodiversos prosperem, é importante se concentrar em entender as diferenças em como você e seu parceiro processam informações e como isso afeta sua capacidade de entender um ao outro.",
            Tips = "Compreenda e honre as diferenças|Consulte o seu médico ou terapeuta. É importante que você e seu parceiro aprendam como ambos processam informações, honram essas diferenças e aprendem a definir expectativas realistas em torno delas.|Faça um inventário|Faça um inventário com seu parceiro sobre as coisas com as quais vocês dois lutam. Está interrompendo? Tirar conclusões precipitadas? Sobrecarga sensorial? Desligar? Faça um plano sobre como lidar com isso antes que eles apareçam. Talvez um parceiro possa tentar ouvir com mais atenção, enquanto o outro trabalha para entender que isso pode ser difícil para o parceiro.|Trabalhe em uma comunicação clara e não defensiva|Estabeleça como meta se comunicar direta e claramente quando se trata de tópicos que podem se transformar em conflito. Implemente start-ups suaves e dê ao seu parceiro o benefício da dúvida. Algumas pessoas se saem melhor com conversas telefônicas com tempo limitado, videochamadas ou cartas escritas em vez de conversas cara a cara. Lembre-se de que, desde que o relacionamento não seja abusivo, não há “jeito certo” ou “jeito errado”, simplesmente duas maneiras diferentes de ver as coisas.|Compreender o papel das questões sensoriais|Se você é o parceiro neurodivergente, reconheça suas próprias sensibilidades à luz, som, toque, cheiro, sabor e sentido para poder comunicá-las ao seu parceiro. Se você é o parceiro neurotípico, entenda como isso pode afetar o sistema nervoso do seu parceiro e como sua capacidade de gerenciá-los está comprometida. Honrar e atender a essas necessidades básicas de regulação do sistema nervoso pode desempenhar um papel enorme no desenvolvimento da intimidade e na aproximação do relacionamento.",
            ResourceType = typeof(Resources.Model.ProfileBioModel))]
        public Neurodiversity? Neurodiversity { get; set; }

        //https://medium.com/@emily_rj/10-things-to-know-before-dating-someone-with-a-disability-6bf6eb8ae196
        [Custom(Name = "Disabilities_Name",
            FieldInfo = "Todos nós desejamos e merecemos ter relacionamentos significativos onde nos sentimos amados e apreciados. Essa necessidade também é sentida por pessoas com deficiência. Algumas pessoas podem se surpreender com isso porque assumem que pessoas com deficiência não namoram, casam ou desejam relacionamentos íntimos. Mas, isso não é verdade. De fato, não há diferença entre a necessidade e o desejo de pessoas com deficiência por relacionamentos saudáveis e felizes e os de pessoas sem deficiência.",
            Tips = "Compartilhe seus sentimentos e preocupações|Qualquer deficiência pode ter um impacto emocional significativo em uma pessoa. Mas isso pode ser particularmente o caso se o parceiro for fisicamente apto e não puder se relacionar totalmente com o que está passando.|Esteja ciente dos efeitos emocionais em seu parceiro|As responsabilidades adicionais que vêm com viver ou namorar uma pessoa com deficiência podem sobrecarregar seu parceiro às vezes. Isso também é completamente normal.|Fale sobre suas finanças|Além dos efeitos emocionais de uma deficiência, é provável que tenha um impacto em suas finanças. Contas médicas, adaptações em sua casa e equipamentos para deficientes não são baratos.|Seja íntimo de qualquer maneira que puder|Uma deficiência ou condição de saúde pode alterar a forma como você faz sexo ou é íntimo. Também pode significar que você tem preocupações com a imagem corporal ou falta de confiança. Mas nada disso significa que você não pode desfrutar de uma vida sexual, seja lá o que for para você.|Encontre coisas para fazer juntos|Nenhum relacionamento pode sobreviver se você não puder se adaptar a uma situação e um ao outro. Sejamos fisicamente aptos ou deficientes, nossas circunstâncias de vida estão mudando constantemente.|Não desista|Mesmo quando você estiver se sentindo deprimido, deprimido ou com dor, ou quase pronto para desistir de tudo, tenha certeza de que dias melhores virão.",
            ResourceType = typeof(Resources.Model.ProfileBioModel))]
        public IReadOnlyList<Disability> Disabilities { get; set; } = Array.Empty<Disability>();

        #endregion BIO

        #region LIFESTYLE

        [Custom(Name = "Drink_Name", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public Drink? Drink { get; set; }

        [Custom(Name = "Smoke_Name", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public Smoke? Smoke { get; set; }

        [Custom(Name = "Diet_Name", Description = "Diet_Description", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public Diet? Diet { get; set; }

        [Custom(Name = "HaveChildren_Name", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public HaveChildren? HaveChildren { get; set; }

        [Custom(Name = "WantChildren_Name", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public WantChildren? WantChildren { get; set; }

        [Custom(Name = "EducationLevel_Name",
            FieldInfo = "A intenção deste campo não é julgar os caminhos escolhidos por cada um ou as oportunidades que tiveram na vida, mas estatisticamente falando, os parceiros que possuem níveis de escolaridade semelhantes tendem a ter os mesmos potenciais de crescimento na vida pessoal/profissional ou até mesmo ter um estilo de vida semelhante (para quem decidiu dedicar-se exclusivamente aos estudos/pesquisa). Ou, no caso de terem niveis de escolaridade diferentes, um dos parceiros poderá se sentir intimidado em relação ao outro.",
            ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public EducationLevel? EducationLevel { get; set; }

        [Custom(Name = "CareerCluster_Name",
            FieldInfo = "Primeiramente, vamos deixar claro que ter carreiras diferentes, não significa que poderão existir conflitos no relacionamento, mas a idéia é que na maioria das vezes esses conflitos poderão ser amenizados justamente porque ambos os parceiros entendem melhor o contexto da situação. Podendo ser: horários de trabalho irregulares, pressão no trabalho para entregar resultados, ser uma pessoa pública, necessidade de viajar constantemente ou se mudar de estado/país (é mais fácil terem acesso as mesmas oportunidades), etc.",
            ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public CareerCluster? CareerCluster { get; set; }

        [Custom(Name = "Religion_Name",
            FieldInfo = "Apesar de que algumas pesquisas indiquem que crenças religiosas não é um fator chave no sucesso do relacionamento, isso pode diminuir bastante conflitos na comunicação/forma de pensar dos parceiros ou até mesmo no relacionamento com amigos e familiares. A depender do país/religião/cultura, poderá existir muitas restrições quanto a relacionamentos entre pessoas de religiões diferentes.",
            ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public Religion? Religion { get; set; }

        [Custom(Name = "TravelFrequency_Name", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public TravelFrequency? TravelFrequency { get; set; }

        #endregion LIFESTYLE

        #region PERSONALITY

        //https://www.pnc.com/insights/personal-finance/spend/money-differences-in-relationships.html
        [Custom(Name = "MoneyPersonality_Name",
            Description = "MoneyPersonality_Description",
            FieldInfo = "Todo casal discute sobre dinheiro. Não importa se você está casado há 40 anos ou namorando há 4 meses, o dinheiro afeta todas as decisões que você toma como casal. E quando vocês dois não concordam sobre quanto gastar ou quanto economizar, é aí que as discussões se transformam em brigas feias e tóxicas que deixam as duas pessoas magoadas e com raiva. É por isso que o dinheiro se tornou a causa número 1 de divórcio nos EUA. Obviamente, algo precisa mudar. A razão pela qual esta crise não foi abordada é porque ela nunca foi identificada, definida ou nomeada.",
            Tips = "Aceite suas diferenças.|Embora você não precise necessariamente aceitar um mau comportamento financeiro, como manter segredo sobre dinheiro, você precisa aceitar que você e seu parceiro são duas pessoas diferentes, com dois pontos de vista diferentes sobre o dinheiro.|Comunique-se.|Sem dúvida, a comunicação é a chave para fazer um relacionamento funcionar quando você não está na mesma página sobre dinheiro. Vocês dois devem se sentir à vontade para comunicar um ao outro o que sentem sobre o dinheiro e como gerenciá-lo no relacionamento. Falar regularmente sobre dinheiro pode ajudá-lo a entender de onde a outra pessoa está vindo e o que está impulsionando suas crenças sobre dinheiro.|Seja respeitoso com as metas e prioridades financeiras de seu parceiro.|O respeito é essencial para qualquer relacionamento, mesmo quando o dinheiro não é uma preocupação. Ser respeitoso, em vez de apontar o dedo ou dar sermão, pode ajudar a manter as linhas de comunicação abertas para que vocês possam continuar trabalhando juntos para melhorar sua imagem financeira.|Crie limites.|Quando você não adota a mesma abordagem com o dinheiro, é preciso haver algumas regras básicas para gerenciá-lo. Por exemplo, você pode decidir manter suas contas bancárias separadas em vez de misturar dinheiro. Ou você pode configurar uma conta conjunta para a qual ambos contribuem com um valor acordado para suas contas compartilhadas. Ter limites com os quais você se sente confortável pode reduzir as chances de se deparar com desentendimentos financeiros.|Seja justo.|Se você estiver dividindo as despesas como um casal, certifique-se de que está fazendo isso de forma justa. Por exemplo, se um de vocês ganhar significativamente mais dinheiro, em vez de dividir as despesas em 50/50, você pode concordar em dividi-las com base em quanto cada um ganha.",
            ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public MoneyPersonality? MoneyPersonality { get; set; }

        //https://www.wikihow.com/Split-Expenses-As-a-Couple
        [Custom(Name = "SplitTheBill_Name",
            FieldInfo = "Falar sobre finanças em um relacionamento pode ser complicado – mesmo quando vocês estão juntos há muito tempo, falar sobre dinheiro pode tornar as pessoas estranhas e defensivas. Mas se vocês moram juntos e querem construir uma vida juntos, isso surge – em parte porque, em um nível básico, você precisará descobrir como dividir as contas com seu parceiro. A resposta se resume a como você vê seu relacionamento.",
            Tips = "Determine quais despesas se qualificam como compartilhadas.|Às vezes é fácil identificar uma despesa compartilhada. Por exemplo, aquecimento, água e eletricidade são despesas de toda a casa e ambos, presumivelmente, desfrutarão de seu uso em quantidades aproximadamente iguais. Mas pode ser mais difícil justificar o compartilhamento de outras despesas. Se você tem serviço de TV em sua casa, por exemplo, mas apenas um de vocês assiste TV, faz pouco sentido dividir essa despesa específica.|Divida as despesas uniformemente.|Ao dividir todas as despesas igualmente, você e seu parceiro têm uma forma de igualdade no relacionamento. Esta é provavelmente a maneira mais lógica de dividir as despesas para casais que têm rendas iguais ou aproximadamente iguais.|Divida suas despesas de acordo com a receita.|Essa técnica de divisão de despesas exige que a pessoa com maior renda pague uma parcela maior das despesas domésticas. Em outras palavras, a igualdade é alcançada através de cada pessoa na relação pagando as despesas de acordo com sua capacidade.|Divida as despesas de forma desigual.|Neste método, uma pessoa pagará a maioria das despesas domésticas. Essa é a escolha natural a ser feita quando uma pessoa no relacionamento tem muito mais renda do que a outra. No entanto, se você e seu parceiro ganharem muito dinheiro, qualquer um de vocês pode optar por um acordo de divisão de despesas como esse.|Esteja disposto a negociar tempo e dinheiro.|Se você trabalha e seu parceiro não ou se seu parceiro trabalha, mas você não, existem outras maneiras de chegar a um acordo justo pensando no trabalho (assim como no dinheiro) necessário para administrar uma casa. O trabalho doméstico – limpar, cozinhar e lavar a roupa – é crucial para manter a casa funcionando. Faz pouco sentido que uma pessoa complete todas essas tarefas e também forneça estabilidade financeira para vocês como casal.",
            ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public SplitTheBill? SplitTheBill { get; set; }

        //https://www.oprah.com/relationships/finding-your-soul-mate-helen-fishers-formula-for-romance/all
        [Custom(Name = "RelationshipPersonality_Name",
            Description = "RelationshipPersonality_Description",
            FieldInfo = "Você já se perguntou por que os opostos às vezes se atraem? E como outras vezes são as semelhanças que as pessoas compartilham que as levam a ficarem juntas romanticamente? A antropóloga biológica, pesquisadora sexual e conselheira científica chefe do Match.com Helen Fisher, PhD, tem uma teoria sobre essa discrepância na atração, especificamente por que algumas pessoas preferem encontrar equilíbrio com uma personalidade oposta, enquanto outras concordam com a noção de pássaros da mesma plumagem voam juntas.",
            Tips = "Se você é um Explorador:|Meu conselho é ir devagar. Porque você é tão impulsivo, você pode se envolver romanticamente muito rápido. E porque você odeia o confronto, corre o risco de fugir de um relacionamento que pode ser fantástico. Se você encontrar alguém em quem esteja genuinamente interessado, verifique sua inclinação para sair com outras pessoas e concentre sua energia nessa pessoa.|Se o seu parceiro é um Explorador:|Esteja preparado para viver esse romance um dia de cada vez. Permaneça flexível e saiba que, para seu parceiro, \"a estupidez é uma contravenção\", como a romancista Ethel Wilson disse astutamente.|Se você é um Construtor:|Não deixe seu gosto por planos e horários atrapalhar a tentativa de coisas novas em um encontro – a menos que você esteja saindo com outro Construtor. Se gabe um pouco (os construtores podem ser muito modestos) e, apesar de seu amor por socializar com a turma, reserve um tempo para ficar sozinho com seu interesse romântico. Sua tendência a ser protetora será apreciada, mas certifique-se de não parecer controladora.|Se o seu parceiro é um Construtor:|Lembre-se de que os Construtores gostam de ser concretos e deleitar-se com os detalhes. Eles são atraídos por outros que são ordeiros e calmos, então quando você faz planos, mantenha-os. De acordo com minha pesquisa, os Construtores são os mais propensos a buscar um parceiro para toda a vida.|Se você é um diretor:|você gosta de estar no controle e tende a namorar com determinação, mas se puder ser paciente e deixar as coisas acontecerem naturalmente, isso o ajudará a evitar assustar um possível romance. E embora você possa considerar a expressão de suas emoções como uma fraqueza, a outra pessoa provavelmente entenderá sua restrição como um sinal de que você é frio, reservado ou desinteressado. Então compartilhe seus sentimentos.|Se o seu parceiro for um Diretor:|Lembre-se de que ele responderá melhor se você for lógico, preciso e claro. Não se critique (muitos diretores consideram isso patético) e, se quiser intrigar seu parceiro, busque tópicos de substância em vez de conversa fiada.|Se você é um negociador:|Cuidado com sua inclinação a ser tão diplomático que pareça covarde. E evite afogar seu par em um dilúvio verbal. Se você conheceu alguém de quem gosta, não pense demais na situação, analisando interminavelmente os prós e os contras. Em última análise, é importante para você não se contentar com nada além de um relacionamento profundamente significativo e autêntico.|Se o seu parceiro é um Negociador:|Tenha em mente que os Negociadores nem sempre são diretos, então leia nas entrelinhas. Evite ser competitivo com eles. E não hesite em falar sobre você: essas pessoas adoram ouvir sobre o que você está pensando e sentindo. Acima de tudo, eles vão se apaixonar por você se você estimular a imaginação deles.",
            ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public RelationshipPersonality? RelationshipPersonality { get; set; }

        //https://www.psychologyjunkie.com/2017/09/05/myers-briggs-type-needs-relationship/
        [Custom(Name = "MBTI_Name",
            Description = "MBTI_Description",
            FieldInfo = "Um equívoco comum que todos cometemos em um ponto ou outro no jogo do namoro é supor que as necessidades de relacionamento do nosso parceiro estão perfeitamente alinhadas com as nossas. Na realidade, todo mundo está procurando algo um pouco diferente de um relacionamento. Uma parceria que faz uma pessoa se sentir sufocada pode fazer outra se sentir liberada. O que uma pessoa vê como uma aventura, outra pode ver como potencial de casamento. Nossas preferências de relacionamento estão altamente entrelaçadas com nossas preferências de personalidade. Cada tipo de personalidade procura algo um pouco diferente em um relacionamento. Aqui está exatamente em qual tipo de parceria você provavelmente prosperará com base no seu tipo de personalidade Myers-Briggs.",
            Tips = "Necessidades de Relacionamento do ISTJ - Dedicação e Honestidade|Os ISTJs são pessoas trabalhadoras e responsáveis que levam seus compromissos muito a sério. Eles geralmente não estão procurando por uma noite, aventuras ou compromissos discretos. Isso não significa que eles vão te oferecer um anel de casamento no primeiro encontro! Mas isso significa que eles não estão interessados no superficial. Eles querem saber que seu parceiro está lá para eles, à queima-roupa. Eles querem saber que podem contar com eles para manter sua palavra e cumprir seus compromissos. Eles também querem apoio mútuo e um parceiro que tenha tempo para realmente ouvi-los. Os ISTJs geralmente são indivíduos muito intelectuais, mas tendem a ser privados. Eles podem não compartilhar todos os seus interesses e ideias imediatamente, mas com tempo e confiança, eles gostam de ter discussões aprofundadas sobre qualquer coisa, desde tecnologia até política, psicologia e muito mais.|Necessidades de Relacionamento ISFJ - Segurança e Atenção|Os ISFJs são indivíduos generosos e dedicados que levam seus relacionamentos muito a sério. São pessoas muito compassivas que querem fazer a diferença em suas famílias e comunidades. Eles querem um parceiro que compartilhe seus valores e também se preocupe com a comunidade em que vivem. Eles querem saber que esse relacionamento tem força para durar e segurança a longo prazo. Outro desejo que os ISFJs têm é encontrar alguém que realmente os escute. Eles tendem a ser pessoas privadas e esperam encontrar alguém que os “quebre de sua concha”. Esses “caras/garotas legais” têm muitos interesses e paixões que estão esperando para compartilhar com a pessoa certa!|Necessidades de Relacionamento ESTJ – Responsabilidade e Amizade|ESTJs são indivíduos trabalhadores e comprometidos que esperam encontrar alguém com a mesma determinação e poder de permanência que eles têm. Eles geralmente não estão interessados em encontros casuais ou relacionamentos discretos; eles querem algo que realmente dure e seja seguro. Eles querem saber que podem contar com seu parceiro para cumprir seus compromissos e planos. Eles querem saber que quando seu parceiro diz “eu te amo” eles querem dizer isso e que não é apenas uma reação emocional fugaz. Eles querem saber que podem confiar em seu parceiro. O comportamento insosso irá rapidamente dissuadi-los de um relacionamento. Eles querem que seu parceiro cumpra suas promessas e mostre um compromisso em melhorar o mundo ao seu redor. Eles também querem um companheiro que possa rir com eles e ser um verdadeiro amigo.|Necessidades de Relacionamento ESFJ – Companheirismo e Compromisso|Os ESFJs são indivíduos generosos e de natureza amigável que farão de tudo para deixar seus parceiros felizes. Como os outros tipos de Sensores Introvertidos (SJ), os ESFJs valorizam o compromisso e a segurança. Eles querem saber que seus parceiros estão com eles a longo prazo. Eles também desejam profundamente companheirismo e apoio mútuo. Eles querem atividades divertidas com seu parceiro; seja indo a uma peça de teatro ou participando de uma festa com seus amigos. O ESFJ vê seu parceiro como seu potencial “melhor amigo”; alguém que vai estar com eles até o fim, dedicado, honesto e fiel. O ESFJ, em troca, proporcionará experiências positivas, generosidade e comprometimento altruísta.|Necessidades de Relacionamento ISTP - Compreensão e Independência|ISTPs são indivíduos extremamente independentes e engenhosos que desejam amizade e confiança reais em seus relacionamentos. Eles precisam de um parceiro que entenda que sua necessidade de espaço não significa que eles não se importam, significa apenas que eles precisam de tempo sozinhos para ganhar energia e processar informações. Se há algo que os ISTPs odeiam, é ser pressionado a se adequar ao estilo de vida e à linha do tempo de outra pessoa. Eles precisam de um parceiro que aceite sua independência, mas também goste do apoio, diversão e humor que eles dão. ISTPs podem ser indivíduos muito fiéis, generosos e de mente aberta; eles só precisam de um parceiro que possa ver isso e reconhecê-lo, mesmo quando estão precisando de um tempo sozinhos.|Necessidades de Relacionamento ISFP - Intimidade e Liberdade|ISFPs são indivíduos extremamente sinceros, compassivos e de espírito livre. Essas almas generosas precisam de um parceiro que aprecie sua natureza gentil, sua criatividade e sua abordagem prática da vida. Os ISFPs querem estar com alguém que realmente ouça e tente entender suas emoções e valores profundos. Eles também querem alguém que não os sufoque ou os force a se conformar com uma imagem pré-ordenada de como um parceiro “deveria” ser. Os ISFPs precisam de tempo sozinhos e também precisam de aventura e experiência. Eles se cansam rapidamente de um parceiro que fala com eles, os faz se sentir enjaulados ou não ouve seus pensamentos e sentimentos. Um parceiro realista, divertido e atencioso é o ideal para esse tipo.|Necessidades de Relacionamento ESTP - Experiência e Entusiasmo|ESTPs são divertidos, otimistas e perspicazes. Esses tipos querem um parceiro que possa acompanhar seus caminhos aventureiros e não tente prendê-los. Embora tenham a reputação de odiar o compromisso, a maioria dos ESTPs pode ser incrivelmente leal quando finalmente se apaixona por alguém. Eles não têm medo de desafios e não fogem quando as coisas ficam difíceis. Eles querem um parceiro que acredite neles, os encoraje e admire suas habilidades. Eles também querem um parceiro que se divirta, saiba ver o lado positivo e que tenha a mente aberta para novas oportunidades e aventuras. A vida raramente é chata com um companheiro ESTP, então aproveite o passeio!|Necessidades de Relacionamento ESFP - Aventura e Autenticidade|Os ESFPs são conhecidos por sua natureza animada, otimista e generosa. Esses tipos querem experimentar tudo o que o mundo tem a oferecer e querem um parceiro que possa se juntar a eles na aventura! Seja caminhando pelo Himalaia ou explorando a culinária local de sua cidade natal, os ESFPs sabem como explorar e aproveitar cada visão, som, sabor e textura. Eles querem um parceiro que aprecie seu entusiasmo e um parceiro que tenha compaixão. Os ESFPs se cansarão rapidamente de um parceiro desonesto, manipulador ou controlador. Eles também querem um parceiro que não confunda seu entusiasmo gregário pela vida como “voo”. Os ESFPs são realistas que geralmente são pessoas incrivelmente conhecedoras e capazes.|Necessidades de Relacionamento INTJ - Senso Comum e Curiosidade|Os INTJs são conhecidos por sua natureza lógica, visão geral e independência. Esses tipos querem um parceiro que esteja pronto para ter discussões profundas e explorar ideias e teorias inovadoras em profundidade. Eles querem alguém que busque crescimento pessoal e estímulo intelectual tanto quanto eles. Embora os INTJs possam ser extremamente cuidadosos, eles tendem a ter dificuldade em expressar suas emoções. Eles precisam de um parceiro que possa ter uma discussão direta sem jogar jogos mentais emocionais. Manipulação quase nunca funciona em um INTJ; eles parecem farejá-lo imediatamente e instantaneamente os desativa. Eles querem um parceiro que seja honesto com eles, que aprecie seus conselhos e que busque ampliar sua mente todos os dias. INTJs levam seus relacionamentos muito a sério e geralmente não estão interessados ​​em aventuras casuais ou relacionamentos discretos. Sempre há exceções a essa regra, é claro, mas os INTJs geralmente não buscam um relacionamento a menos que tenham pensado e considerado bastante.|Necessidades de Relacionamento INFJ - Compreensão e Aspiração|Os INFJs são conhecidos por sua empatia, perspicácia e originalidade. Para a maioria dos conhecidos casuais, eles parecerão amigáveis e de fala mansa, mas há mais nesse tipo do que sorrisos e palavras gentis. Eles querem um parceiro que tenha visão, que seja curioso sobre o futuro, que não desconsidere seus insights e que realmente escute. Os INFJs geralmente se sentem incompreendidos ou desconectados de outras pessoas porque geralmente não são capazes de compartilhar suas ideias sem serem recebidos com ceticismo. Um parceiro que reserve um tempo para realmente conhecê-los, juntar-se a eles em seus esforços e confiar em seus palpites será muito apreciado. Os INFJs geralmente não estão interessados em relacionamentos casuais ou aventuras; eles realmente não veem sentido em entrar em um relacionamento, a menos que sintam uma conexão verdadeiramente profunda. Obviamente, existem variedades dentro de um tipo; mas na maioria das vezes, os INFJs estão interessados em relacionamentos sérios.|Necessidades de Relacionamento ENTJ – Respeito e Estimulação Intelectual|Os ENTJs são indivíduos confiantes, decisivos e lógicos que procuram um parceiro que realmente acredite neles. Eles querem um relacionamento onde possam passar noites conversando sobre teorias, o futuro, metas e planos. Eles querem um parceiro que lhes faça perguntas e venha até eles para pedir conselhos. Um parceiro que confia que sabe o que está fazendo e não menospreza ou tenta controlá-lo. Eles também querem um parceiro que trabalhe duro e cumpra seus compromissos. Preguiça, reclamações e reações emocionais exageradas são uma maneira certa de arruinar um relacionamento com um ENTJ. Eles querem um parceiro que esteja disposto a ficar com eles em todos os momentos e não recuar sempre que houver um desafio.|Necessidades de Relacionamento ENFJ - Empatia e Conexão|ENFJs são indivíduos exuberantes, empáticos e orientados para objetivos. Eles querem um relacionamento onde se sintam apreciados, compreendidos e inspirados para alcançar seus objetivos. Eles querem saber que podem expressar suas emoções livremente e não serem recebidos com condescendência ou repressão. Eles se cansarão rapidamente de parceiros que tentam sufocar seus sentimentos profundos ou que não têm ambição ou visão para o futuro. Eles querem estar com alguém que queira fazer uma grande diferença no mundo ao seu redor, alguém que se importe com as pessoas e esteja disposto a trabalhar duro para ajudar os outros. Eles querem desfrutar de uma mistura de discussão intelectual e socializar com bons amigos e familiares. ENFJs geralmente desejam relacionamentos comprometidos e muitas vezes não gostam de relacionamentos casuais ou aventuras.|Necessidades de Relacionamento INTP - Independência e Atenção|INTPs são conhecidos por serem indivíduos privados, analíticos e inovadores. Eles buscam um relacionamento onde possam ter a liberdade de perseguir suas muitas ideias, mas também compartilhar calor, lealdade e amizade. Eles querem se sentir compreendidos e apreciados por sua engenhosidade, e também querem um parceiro que tenha uma mente aberta e possa explorar vários tópicos intelectuais com eles. INTPs não são naturalmente sintonizados com as emoções de outras pessoas e podem ficar frustrados em relacionamentos em que seu parceiro espera que eles apenas “saibam” como se sentem. Eles podem perder rapidamente o interesse se seu parceiro for extremamente reativo emocionalmente ou tentar fazê-los se conformar a uma estrutura rígida ou a um conjunto tradicional de expectativas. INTPs gostam de pensar fora da caixa e gostam de um parceiro que pode fazer isso com eles.|Necessidades de Relacionamento INFP - Sinceridade e Valores Compartilhados|INFPs são conhecidos por serem compassivos, imaginativos e autênticos. Eles buscam um relacionamento em que possam ser uma “equipe” com seu parceiro e buscar causas em que ambos acreditam. e compartilhar idéias e perspectivas alternativas com eles. INFPs são indivíduos muito particulares, mas em um relacionamento, eles querem alguém com quem possam compartilhar seus pensamentos e sentimentos mais profundos. Eles querem conhecer seu parceiro intimamente; honestidade é um dos maiores atrativos para um INFP. Eles têm uma tolerância muito baixa para manipulação, bullying ou mente fechada.|Necessidades de Relacionamento ENTP - Imaginação e Diversão|Os ENTPs são conhecidos por serem enérgicos, inovadores e analíticos. Esses indivíduos desejam explorar um vasto mundo de conceitos e ideias com seu parceiro. Eles querem questionar o status quo, desafiar a norma e explorar o potencial de centenas de possibilidades. Eles gostam de um bom debate e precisam de um parceiro que possa lidar com o cerne de uma ideia, mesmo que isso signifique estar disposto a pensar fora das regras e limites tradicionais. Os ENTPs se cansarão rapidamente de um relacionamento em que são forçados a fazer tudo “pelo livro” ou seu pensamento inovador é sufocado. Eles querem compartilhar experiências divertidas e criativas com seu parceiro e para eles, isso significa estar disposto a correr alguns riscos e ultrapassar alguns limites.|Necessidades de Relacionamento ENFP - Incentivo e Mente Aberta|Os ENFPs são conhecidos por serem imaginativos, compassivos e insaciavelmente curiosos. Eles buscam um relacionamento onde possam explorar um vasto campo de possibilidades com seu parceiro. Eles querem discutir a natureza da realidade, questionar regras e tradições pré-estabelecidas e encontrar maneiras inovadoras de melhorar o mundo para os outros. Os ENFPs querem ser inspirados e encorajados em seus muitos sonhos e empreendimentos. A vida é cheia de possibilidades emocionantes e eles querem um parceiro que possa se juntar a eles para o passeio. Os ENFPs podem ser privados sobre suas emoções mais profundas, mas querem um parceiro que possa realmente ouvir seus valores e tentar entendê-los. Eles são rápidos em perceber o comportamento manipulador, então mentir é um grande não-não nesse relacionamento.",
            ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public MyersBriggsTypeIndicator? MBTI { get; set; }

        //https://thehoneycombers.com/singapore/5-love-languages/
        [Custom(Name = "LoveLanguage_Name",
            Description = "LoveLanguage_Description",
            FieldInfo = "As cinco linguagens do amor descrevem cinco maneiras pelas quais as pessoas recebem e expressam amor em um relacionamento. Conhecer a linguagem de amor do seu parceiro e deixá-lo conhecer a sua é uma maneira de ajudá-lo a se sentir amado e apreciado. O autor e pastor Gary Chapman descreve como usar essas linguagens do amor para mostrar ao seu parceiro que você se importa com ele de uma maneira que fala ao coração dele.",
            Tips = "Se o toque físico é a linguagem de amor do seu parceiro:|Faça biquinho: crie o hábito de beijar como uma expressão física do seu amor. Você pode banhar-se com beijos de manhã, pouco antes de dormir ou mesmo quando está fazendo uma pausa no trabalho;\r\nSegure as mãos em todos os lugares: este pequeno gesto significa sua conexão e libera endorfinas que melhoram o humor;\r\nAfago na cama: seu parceiro pode preferir ser a “grande” ou a “pequena” colher, então tente trocar de papéis ou ficar de frente um para o outro para ver como se sente;\r\nFaça sexo regularmente: embora o sexo não seja tudo, é uma das maneiras preferidas de dar e receber amor por qualquer pessoa cuja linguagem de amor seja o toque físico;|Se palavras de afirmação são a linguagem de amor do seu parceiro:|Mostre apreço: o amor deve ser expresso através da forma falada. Não se trata de bajulação, mas de agradecimento sincero;\r\nPreste atenção ao seu tom: as pessoas auditivas tendem a ser sensíveis ao que é dito e à maneira como está sendo dito. Seu tom deve ser de amor e curiosidade, não de acusação;\r\nSeja específico: não fique repetindo as mesmas frases todos os dias. Passe algum tempo elaborando por que eles significam tanto para você;|Se o tempo de qualidade é a linguagem do amor do seu parceiro:|Fique longe de aparelhos eletrônicos: deixe de lado os celulares e outros aparelhos durante o encontro ou o tempo a sós com seu parceiro. Para alguém cuja linguagem de amor é tempo de qualidade, nada o irrita mais do que sua atenção dividida;\r\nAgende uma conversa íntima: há hora e lugar para tudo. Lançar tópicos sensíveis ou difíceis para discussão espontânea não vai cair bem com eles. Em vez disso, agende seu tempo de discussão de casal (digamos, uma vez por semana) e deixe tudo para fora;\r\nFaça memórias: eles adoram companheirismo e interesses compartilhados. Certifique-se de ter mais momentos bons juntos do que negativos;|Se atos de serviço são a linguagem de amor do seu parceiro:|Receba com um coração agradecido: quando eles fazem algo por você, eles o fazem por amor – não apenas por hábito. Sempre receba seus pequenos gestos como expressões de amor;\r\nDê de bom grado: eles podem não perceber que também adoram receber o mesmo de você em troca. O que eles fazem com você, faça com eles, e veja o que acontece!;\r\nEntenda que pequenas coisas importam: já que seu parceiro acredita que o amor é demonstrado em ação (não apenas palavras vazias), faça pequenas coisas por ele diariamente. Isso pode incluir cozinhar seus pratos favoritos ou ajudar em casa;|Se presentes são a linguagem de amor do seu parceiro:|Concentre-se em pequenos presentes: abandone a suposição de que os presentes precisam ser caros. Você pode facilmente dar-lhes uma flor como uma demonstração física de seu amor, desde que seja um presente atencioso;\r\nValorize as memórias: pense nos presentes que você compra para o seu parceiro como lembranças – são objetos preciosos associados a pessoas ou eventos memoráveis. Eles também são um lembrete de que você pensou neles em um local e hora específicos;\r\nEconomize: claro, você sempre pode reservar suas moedas para itens caros que duram a vida toda;",
            ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public LoveLanguage? LoveLanguage { get; set; }

        //https://www.bustle.com/articles/59610-17-sex-tips-for-couples-in-long-term-relationships-because-keeping-it-fresh-takes-more-than-a
        [Custom(Name = "SexPersonality_Name",
            Description = "SexPersonality_Description",
            FieldInfo = "A compatibilidade sexual é primordial para relacionamentos saudáveis. Nós tendemos a deixar isso de lado em favor de outras qualidades pessoais positivas, como gentileza, bom senso de humor, etc. Para ser claro, sexo não é a coisa mais importante em um relacionamento, mas pesquisas nos dizem que casais são mais felizes com sua vida sexual são mais felizes com seu relacionamento em geral. Quando os seus interesses sexuais não se alinham com os do seu parceiro e uma vida sexual satisfatória é difícil de alcançar juntos, você não terá uma parceria muito feliz.",
            Tips = "Faça sexo matinal pelo menos uma vez por semana|Na verdade, foi cientificamente comprovado que o sexo matinal é ótimo para você. Entre ser menos autoconsciente e o fato de seu parceiro já estar ali, é uma ótima maneira de começar o dia.|Não tenha medo de surpreender seu parceiro|Mesmo aquelas pessoas que são inflexíveis sobre não gostar de surpresas gostam de surpresas quando se trata de sexo.|Tire uma noite para compartilhar suas melhores fantasias|Uma vez que você está em um relacionamento há muito tempo, você lida com as coisas estranhas e pode realmente se abrir – especialmente quando se trata de compartilhar suas fantasias.|Flerte como se você quisesse dizer isso|Muitas pessoas pensam que flertar é o que você faz para atrair o objeto de sua afeição para suas garras – mas é mais do que isso. Flertar é divertido e divertido, então dar uma piscadela para o seu parceiro é um lembrete amigável de que você ainda está com tesão por ele, mesmo quando não está no quarto.|Faça um plano para experimentar uma nova posição sexual por mês.|O Kama Sutra existe por uma razão - e não é para dar a Cosmo mais ração para posições sexuais impossíveis que \"seu homem vai adorar!\" Embora inclua 64 atos sexuais, também é um guia sobre todas as coisas amorosas, incluindo alcançar a intimidade máxima durante essas posições. Claro, você não será capaz de dominar todos eles (e, além disso, quem realmente quer ficar de cabeça para baixo durante o sexo), mas experimentar alguns, especialmente esses, pode ser divertido.|Estimule seu parceiro em algum lugar público|Há tantos lugares onde você pode ter momentos sensuais com seu parceiro, então mantê-lo apenas no quarto não é uma opção. Tempere-o! Não estou sugerindo que você vá a um banco público para que todos vejam, mas com discrição e criatividade, você pode fazer isso acontecer em mais lugares do que imagina.|Conheça uns aos outros pela primeira vez - novamente|Embora essa coisa de interpretar papéis de garotas da escola acabou, é interessante conhecer seu parceiro em um bar e fingir que são estranhos. Finjam ser vocês mesmos, apenas que ainda não se conhecem. Não há nada melhor do que se encontrar pela primeira vez novamente e lembrar por que você se apaixonou um pelo outro em primeiro lugar.|Dê uns amassos. Muitas vezes.|Dar uns amassos é tão subestimado. Pense desta forma: você provavelmente está com seu parceiro agora porque tudo começou com um beijo, então por que você deixaria passar agora? Não pense apenas em dar uns amassos como algo que deve levar ao sexo – tente apreciá-los por conta própria e ver aonde isso leva.|Take Advantage Of Technology|Sexting, se você ainda não fez, é, em uma palavra, fantástico. É basicamente a versão tecnológica das preliminares e uma maneira perfeita de deixar você e seu parceiro no clima. É também uma ótima maneira de animar seu dia de trabalho tão longo e exaustivo.|Assistir pornô juntos|Ao contrário da desinformação de décadas, as mulheres estão assistindo pornografia tanto quanto os homens, e também estão adorando. Embora possam ter coisas diferentes que as excitam do que os homens, você pode, se olhar ao redor, encontrar algo que ambos gostem. Se a pornografia visual não é sua praia, então escrita erótica, é algo para definitivamente tentar.|Provoque um ao outro|Provocar é incrível. Quer você faça isso com expressões faciais ou de uma maneira mais prática, isso dá combustível ao fogo sexual.|Acabe com todas as discussões com sexo de reconcialiação|Às vezes, você pode deliberadamente provocar seu parceiro, inconscientemente, apenas para que possam fazer sexo de reconciliação. Porque mesmo quando é uma discussão legítima, como quem comeu a última fatia de pizza, sempre se certifique de terminar com uma brincadeira.|Jogue 'Tudo, menos sexo'|Por mais que você ame sexo, o jogo de fazer tudo, menos a relação sexual, é uma ótima maneira de explorar outros caminhos para se excitar. Você também pode acabar se surpreendendo e apreciando mais a relação sexual.|Comunique o que é bom (e o que precisa ser melhorado)|A parte mais importante de ter um bom sexo é a comunicação. Se o seu parceiro cair em cima de você e claramente sabe o que está fazendo, é seu trabalho dar direção. Você absolutamente tem que compartilhar o que é bom e o que não é se quiser tirar o máximo proveito de sua vida sexual.|Adicione brinquedos sexuais|Não há problema em trazer um pouco de ajuda externa na forma de brinquedos – eles realmente contribuem para a experiência sexual.|Abrace a magia das preliminares|As preliminares são incríveis! E quanto mais tempo você puder estender, melhor. Enquanto uma rapidinha às vezes é divertida, dedicar muito e muito tempo para a construção do grande final é realmente quente.",
            ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public SexPersonality? SexPersonality { get; set; }

        #endregion PERSONALITY

        #region INTEREST

        [Custom(Name = "Comidas")]
        public IReadOnlyList<Food> Food { get; set; } = Array.Empty<Food>();

        [Custom(Name = "Férias")]
        public IReadOnlyList<Vacation> Vacation { get; set; } = Array.Empty<Vacation>();

        [Custom(Name = "Esportes")]
        public IReadOnlyList<Sports> Sports { get; set; } = Array.Empty<Sports>();

        [Custom(Name = "Lazer")]
        public IReadOnlyList<LeisureActivities> LeisureActivities { get; set; } = Array.Empty<LeisureActivities>();

        [Custom(Name = "Música")]
        public IReadOnlyList<MusicGenre> MusicGenre { get; set; } = Array.Empty<MusicGenre>();

        [Custom(Name = "Filme")]
        public IReadOnlyList<MovieGenre> MovieGenre { get; set; } = Array.Empty<MovieGenre>();

        [Custom(Name = "TV")]
        public IReadOnlyList<TVGenre> TVGenre { get; set; } = Array.Empty<TVGenre>();

        [Custom(Name = "Leitura")]
        public IReadOnlyList<ReadingGenre> ReadingGenre { get; set; } = Array.Empty<ReadingGenre>();

        #endregion INTEREST

        public ProfilePreferenceModel Preference { get; set; }

        //public ProfileGamificationModel Gamification { get; set; }
        //public ProfileBadgeModel Badge { get; set; }

        public ProfilePhotoModel Photo { get; set; }
        //public ProfileReportModel[] Reports { get; set; } = Array.Empty<ProfileReportModel>();

        //public string[] ActiveInteractions { get; set; } = Array.Empty<string>();
        //public string[] PassiveInteractions { get; set; } = Array.Empty<string>();

        public List<Partner> Partners { get; set; } = new();

        private readonly string BlobPath = "https://storageverusdate.blob.core.windows.net";

        //public void UpList()
        //{
        //    DtTopList = DateTime.UtcNow;
        //}

        public void Login()
        {
            DtLastLogin = DateTime.UtcNow;
        }

        public void UpdateData(ProfileModel profile)
        {
            //BASIC
            Modality = profile.Modality;
            NickName = profile.NickName;
            Description = profile.Description;
            Location = profile.Location;
            Languages = profile.Languages;
            CurrentSituation = profile.CurrentSituation;
            Intentions = profile.Intentions;
            BiologicalSex = profile.BiologicalSex;
            GenderIdentity = profile.GenderIdentity;
            SexualOrientation = profile.SexualOrientation;

            //BIO
            BirthDate = profile.BirthDate;
            Zodiac = profile.Zodiac;
            Height = profile.Height;
            RaceCategory = profile.RaceCategory;
            BodyMass = profile.BodyMass;

            //LIFESTYLE
            Drink = profile.Drink;
            Smoke = profile.Smoke;
            Diet = profile.Diet;
            HaveChildren = profile.HaveChildren;
            WantChildren = profile.WantChildren;
            EducationLevel = profile.EducationLevel;
            CareerCluster = profile.CareerCluster;
            Religion = profile.Religion;
            TravelFrequency = profile.TravelFrequency;

            //PERSONALITY
            MoneyPersonality = profile.MoneyPersonality;
            SplitTheBill = profile.SplitTheBill;
            RelationshipPersonality = profile.RelationshipPersonality;
            MBTI = profile.MBTI;
            LoveLanguage = profile.LoveLanguage;
            SexPersonality = profile.SexPersonality;

            //INTEREST
            Food = profile.Food;
            Vacation = profile.Vacation;
            Sports = profile.Sports;
            LeisureActivities = profile.LeisureActivities;
            MusicGenre = profile.MusicGenre;
            MovieGenre = profile.MovieGenre;
            TVGenre = profile.TVGenre;
            ReadingGenre = profile.ReadingGenre;

            //OTHERS
            Neurodiversity = profile.Neurodiversity;
            Disabilities = profile.Disabilities;

            Partners = profile.Partners;

            DtUpdate = DateTime.UtcNow;
        }

        public void UpdateLooking(ProfilePreferenceModel obj)
        {
            Preference = obj;

            DtUpdate = DateTime.UtcNow;
        }

        public void UpdatePartner(string userId, string email)
        {
            var partner = Partners.FirstOrDefault(w => w.Email == email);
            if (partner != null)
            {
                partner.Id = userId;

                DtUpdate = DateTime.UtcNow;
            }
        }

        //public void UpdateGamification(ProfileGamificationModel obj)
        //{
        //    Gamification = obj;

        //    DtUpdate = DateTime.UtcNow;
        //}

        //public void UpdateBadge(ProfileBadgeModel obj)
        //{
        //    Badge = obj;

        //    DtUpdate = DateTime.UtcNow;
        //}

        public void UpdatePhoto(ProfilePhotoModel obj)
        {
            Photo = obj;

            DtUpdate = DateTime.UtcNow;
        }

        public string GetMainPhoto()
        {
            if (Photo == null || string.IsNullOrEmpty(Photo.Main))
                return GetNoUserPhoto;
            else
                return $"{BlobPath}/{GetPhotoContainer(PhotoType.PhotoFace)}/{Photo.Main}";
        }

        public string[] GetGalleryPhotos()
        {
            if (Photo == null || !Photo.Gallery.Any())
                return Array.Empty<string>();
            else
                return Photo.Gallery.Select(s => $"{BlobPath}/{GetPhotoContainer(PhotoType.PhotoGallery)}/{s}").ToArray();
        }

        public override void SetIds(string IdLoggedUser)
        {
            this.SetId(IdLoggedUser);
            this.SetPartitionKey(IdLoggedUser);
        }

        public enum LocationType
        {
            Full,
            Country,
            State,
            City
        }

        public string GetLocation(LocationType type)
        {
            if (string.IsNullOrEmpty(Location)) return null;

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

    public class ProfileView : ProfileModel
    {
        public ActivityStatus ActivityStatus { get; set; }

        [Custom(Name = "Age_Name", ResourceType = typeof(Resources.Model.ProfileBioModel))]
        public int Age { get; set; }
    }

    public class Partner
    {
        [Required]
        [EmailAddress]
        [Custom(Name = "Convidar Parceiro", Prompt = "Email do parceiro", Description = "Precisa ser o mesmo e-mail que será usado no cadastro")]
        public string Email { get; set; }

        public string Id { get; set; }
    }
}