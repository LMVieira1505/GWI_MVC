USE [GWINEWS]
GO

---------------------------------------------------------------
------  Inserir Usuários
---------------------------------------------------------------

INSERT INTO tb_niveis
	(nv_nivel, nv_funcao, nv_descricao)
VALUES
	(0, 'Administrador', 'Resolve pepino e administra editores'),
	(1, 'Editor', 'Corrige e pode retirar notícias e adiciona autores'),
	(2, 'Autor', 'Cria e adiciona notícias'),
	(3, 'Usuario', 'Acessa notícias publicadas e pode criar currículos');

INSERT INTO tb_pessoas 
	(p_nome, p_sobrenome, p_telefone, p_email, p_senha, p_username, p_ativo, p_nv_id) 
VALUES
	('Ademir', 'Pereira Santos', '16998877665', 'ademiro@gwinews.com', 'ademir123', 'Admir', 0, 1),
	('Judit', 'Silva e Silva', '16889966775', 'juju@gmail.com', 'judit123', 'Jujuzinha', 0, 2),
	('Marcos', 'Paulo Selva', '16443322771', 'marquin@outlook.com', 'marco123', 'Marcão', 0, 3),
	('Úrsula', 'Carvalho Pinheiro', '16223311442', 'ursula@hotmail.com', 'ursula123', 'Úrsula', 0, 4);

---------------------------------------------------------------
------  Inserir Notícias
---------------------------------------------------------------

INSERT INTO tb_categorias 
	(cat_nome, cat_ativo)
VALUES
	('Empregos', 0),
	('Educação', 0),
	('Esportes', 0),
	('Entretenimento', 0),
	('Economia', 0);

INSERT INTO tb_subcategorias
	(sct_nome, sct_ativo, sct_cat_id)
VALUES
	('Estágio', 0, 1),
	('Período Integral', 0, 1),
	('Jovem Aprendiz', 0, 1),
	('Curso Técnico', 0, 2),
	('Tecnólogo', 0, 2),
	('Licenciatura', 0, 2),
	('Futebol', 0, 3),
	('Vôlei', 0, 3),
	('Basquete', 0, 3),
	('Música', 0, 4),
	('Cinema', 0, 4),
	('Teatro', 0, 4),
	('Imóveis', 0, 5),
	('Investimentos', 0, 5),
	('Bolsa de Valores', 0, 5);

INSERT INTO tb_noticias 
	(nt_titulo, nt_subtitulo, nt_texto, nt_data_publicacao, nt_ativo, nt_cat_id, nt_p_id)
VALUES
	('Fatec Matao Luiz Marchesan Abre Vestibular', 'Fatec Matão Luiz Marchesan oferece cursos de excelência e prepara os estudantes para o mercado de trabalho', 'A Fatec Matão Luiz Marchesan, renomada instituição de ensino técnico, está com as inscrições abertas para o vestibular. Os estudantes interessados em ingressar em cursos de excelência e se preparar para o mercado de trabalho têm uma grande oportunidade pela frente. A instituição é conhecida por oferecer uma formação sólida e atualizada, preparando os alunos para os desafios da área técnica. Com uma infraestrutura moderna e professores altamente capacitados, a Fatec Matão Luiz Marchesan oferece uma variedade de cursos em diferentes áreas, como tecnologia da informação, gestão empresarial, logística, mecânica e muito mais. Os estudantes têm a oportunidade de adquirir conhecimentos teóricos e práticos, aplicando o que aprendem em projetos e atividades realistas. Além disso, a Fatec Matão Luiz Marchesan mantém parcerias com empresas da região, proporcionando aos alunos a chance de vivenciar o ambiente profissional e estabelecer contatos no mercado de trabalho. Essas parcerias também podem levar a oportunidades de estágio e emprego após a formação, tornando a instituição uma porta de entrada para uma carreira de sucesso. As inscrições para o vestibular estão abertas e podem ser feitas através do site oficial da Fatec Matão Luiz Marchesan. É importante ficar atento aos prazos e requisitos necessários para participar do processo seletivo. Os candidatos aprovados terão a oportunidade de estudar em uma instituição renomada, reconhecida pela qualidade de seus cursos e pelo alto índice de empregabilidade de seus formandos. Se você busca uma formação técnica de excelência e deseja se destacar no mercado de trabalho, não perca a chance de se inscrever no vestibular da Fatec Matão Luiz Marchesan. A instituição está pronta para receber os futuros profissionais e auxiliá-los em sua jornada acadêmica e profissional.', '2023-05-12 13:21:05.000', 2, 1, 3),
	('Setor de Aviação: Novas Oportunidades', 'Com o crescimento do setor, empresas aéreas e indústria de aviação abrem vagas e impulsionam o mercado de trabalho na área', ' O setor de aviação está decolando com força total, trazendo excelentes oportunidades de emprego para profissionais apaixonados pelo mundo dos aviões. Com a retomada das viagens aéreas e o crescimento da indústria, empresas aéreas e organizações relacionadas estão ampliando suas operações e abrindo vagas em diferentes áreas, impulsionando o mercado de trabalho na área de aviação. Companhias aéreas renomadas estão anunciando a contratação de pilotos, comissários de bordo, mecânicos de aeronaves e profissionais de manutenção. O aumento da demanda por voos e a renovação das frotas de aeronaves têm impulsionado a busca por talentos qualificados, oferecendo oportunidades de carreira empolgantes para aqueles que desejam trabalhar no setor. Além das empresas aéreas, a indústria de aviação também está aquecida, proporcionando chances de emprego em fabricantes de aeronaves, empresas de manutenção e reparo, empresas de tecnologia aeronáutica e muito mais. Os avanços tecnológicos e a necessidade de inovação têm impulsionado a contratação de engenheiros aeronáuticos, projetistas, especialistas em segurança aérea e profissionais de pesquisa e desenvolvimento. A formação de parcerias estratégicas entre instituições de ensino e empresas do setor tem contribuído para a qualificação dos profissionais e a formação de mão de obra especializada. Cursos técnicos, programas de treinamento e parcerias de estágio têm preparado os candidatos para as demandas específicas da indústria da aviação, aumentando suas chances de empregabilidade. Com o mercado de trabalho em expansão e a retomada das atividades no setor de aviação, é um momento oportuno para aqueles que desejam seguir uma carreira emocionante e desafiadora na área. Fique atento às oportunidades e esteja preparado para decolar rumo a um futuro promissor na indústria aeronáutica.', '2023-05-12 08:13:21.000', 1, 1, 3), 
	('Banco do Brasil anuncia Abertura de Novas Vagas', 'Com planos de expansão, Banco do Brasil oferece vagas em diversas áreas e impulsiona o mercado de trabalho no setor bancário', ' O Banco do Brasil está anunciando a abertura de novas vagas, trazendo excelentes oportunidades de emprego para profissionais interessados em fazer parte de uma das maiores instituições financeiras do país. Com planos de expansão e inovação, o Banco do Brasil está impulsionando o mercado de trabalho no setor bancário, oferecendo vagas em diversas áreas. Com a retomada da economia e a necessidade de atender às demandas dos clientes, o Banco do Brasil está em busca de profissionais qualificados para preencher posições estratégicas em áreas como atendimento ao cliente, gerenciamento financeiro, tecnologia da informação, análise de crédito, investimentos, entre outras. Além das oportunidades para profissionais com experiência no setor bancário, o Banco do Brasil também está abrindo espaço para jovens talentos por meio de programas de trainee e estágio, visando desenvolver e preparar a próxima geração de bancários. O banco tem investido em capacitação e treinamentos para seus colaboradores, promovendo um ambiente de trabalho estimulante e oferecendo oportunidades de crescimento profissional. Com uma cultura organizacional focada em valores como ética, transparência e inovação, o Banco do Brasil busca atrair e reter os melhores talentos do mercado. Os interessados em fazer parte dessa equipe podem ficar atentos às oportunidades divulgadas no site oficial do Banco do Brasil e em plataformas de recrutamento. É importante ressaltar que o banco valoriza a diversidade e a inclusão, buscando candidatos de diferentes formações e experiências. Se você está em busca de uma carreira no setor bancário, esta é uma excelente oportunidade para se juntar a uma instituição sólida, reconhecida e com um papel fundamental no desenvolvimento econômico do país.', '2023-05-12 14:20:15.000', 1, 1, 3),
	('Ambev Expande Produção e Abre Vagas', 'Com o aumento da demanda, Ambev oferece vagas em sua fábrica de cerveja e impulsiona o mercado de trabalho no setor', ' A Ambev, uma das maiores empresas do setor de bebidas, está expandindo sua produção de cerveja e abrindo novas oportunidades de emprego em sua fábrica. Com o crescimento da demanda e o sucesso de suas marcas, a Ambev está impulsionando o mercado de trabalho na indústria cervejeira, oferecendo vagas em diferentes áreas. A fábrica de cerveja da Ambev está em busca de profissionais qualificados para atuar em posições como produção, logística, controle de qualidade, manutenção, engenharia de processos e muito mais. A empresa valoriza a dedicação, a paixão pela indústria e o comprometimento com a excelência. Com um ambiente de trabalho dinâmico e colaborativo, a Ambev oferece oportunidades de crescimento e desenvolvimento profissional, além de benefícios atrativos para seus colaboradores. A empresa investe em treinamentos e programas de capacitação, buscando aprimorar as habilidades e conhecimentos de seus funcionários. A Ambev é conhecida por sua cultura de inovação e sustentabilidade, buscando constantemente melhorias nos processos produtivos e na redução do impacto ambiental. Fazer parte da equipe da Ambev significa contribuir para uma empresa que está em constante evolução e se adaptando às demandas do mercado. Os interessados em fazer parte dessa equipe cervejeira de sucesso podem ficar atentos às oportunidades divulgadas no site oficial da Ambev e em plataformas de recrutamento. A empresa valoriza a diversidade e a inclusão, buscando candidatos com diferentes experiências e formações. Se você é apaixonado pelo mundo cervejeiro e está em busca de uma carreira na indústria de bebidas, essa é uma excelente oportunidade para se juntar a uma empresa líder e influente no mercado.', '2023-05-12 11:20:50.000', 1, 1, 3), 
	('Baldan Procura Gerente de Marketing', 'Com foco em inovação e qualidade, Baldan oferece vagas para profissionais de design e impulsiona o mercado de trabalho no setor agrícola', ' A Baldan, empresa reconhecida no segmento de máquinas agrícolas, está anunciando a abertura de vagas no setor de design, oferecendo oportunidades de emprego para profissionais talentosos e apaixonados por inovação. Com o compromisso de desenvolver soluções eficientes e de alta qualidade para o setor agrícola, a Baldan está impulsionando o mercado de trabalho no segmento, trazendo novas oportunidades para o setor de design. A empresa busca por profissionais qualificados e criativos para atuar em projetos de design de máquinas agrícolas, desenvolvimento de novos produtos, criação de interfaces digitais, entre outras áreas relacionadas ao design industrial. A Baldan valoriza a excelência e o pensamento inovador, buscando constantemente aprimorar seus produtos e processos. Com uma história de sucesso e reconhecimento no mercado agrícola, a Baldan oferece um ambiente de trabalho estimulante e oportunidades de crescimento profissional. A empresa investe em capacitação e desenvolvimento de seus colaboradores, visando o aprimoramento de suas habilidades e conhecimentos no setor. A Baldan é reconhecida por sua cultura de inovação e qualidade, buscando sempre oferecer soluções que atendam às necessidades dos agricultores e contribuam para o aumento da produtividade no campo. Fazer parte da equipe Baldan significa fazer parte de uma empresa que está na vanguarda da tecnologia agrícola. Os interessados em fazer parte da equipe de design da Baldan podem ficar atentos às oportunidades divulgadas no site oficial da empresa e em plataformas de recrutamento. A Baldan valoriza a diversidade e a inclusão, buscando candidatos com diferentes formações e experiências. Se você é apaixonado por design e está em busca de uma carreira no setor agrícola, essa é uma excelente oportunidade para se juntar a uma empresa renomada e contribuir com soluções inovadoras para o campo.', '2023-05-12 13:30:12.000', 1, 1, 3),
	('NBA Inicia a Temporada com Grande Expectativa', 'Abertura da temporada da NBA promete jogos eletrizantes e rivalidades renovadas nas quadras', '  A temporada da NBA está prestes a começar e a expectativa é enorme entre os fãs de basquete ao redor do mundo. Os melhores times do basquete mundial se preparam para entrar em quadra e disputar o tão cobiçado título da NBA. Os astros do esporte estão prontos para mostrar suas habilidades e proporcionar momentos de pura emoção aos espectadores. Com o retorno de grandes estrelas e a chegada de novos talentos, a abertura da temporada da NBA promete ser repleta de jogos eletrizantes e rivalidades renovadas. Os fãs poderão acompanhar confrontos entre equipes históricas, como Los Angeles Lakers, Brooklyn Nets, Golden State Warriors, entre outros, além de presenciar o surgimento de novos aspirantes ao título. A NBA é conhecida por sua competitividade e alto nível técnico, e a temporada que se inicia não será diferente. As equipes investiram em reforços e estratégias para buscar a glória e conquistar o troféu de campeão. Os jogadores estão empenhados em mostrar seu melhor desempenho, buscando impressionar os torcedores com suas habilidades e jogadas incríveis. Além dos jogos, a temporada da NBA traz consigo uma série de eventos paralelos que aumentam ainda mais o clima de festa e expectativa. All-Star Game, competições de enterradas, arremessos de três pontos e habilidades são alguns dos momentos marcantes que os fãs poderão desfrutar ao longo da temporada. Os amantes do basquete podem se preparar para vivenciar meses de pura emoção e torcida intensa. A NBA está pronta para abrir as cortinas de mais uma temporada recheada de jogos emocionantes, dribles desconcertantes e cestas incríveis. Então, pegue seu lugar nas arquibancadas ou acompanhe os jogos pela televisão e prepare-se para mergulhar no universo apaixonante da NBA.', '2023-05-12 18:54:37.000', 3, 1, 3), 
	('USP em Matão Traz Insights Valiosos', 'Universidade de São Paulo (USP) compartilha insights preciosos para impulsionar a inovação e o progresso científico em diversas áreas do conhecimento acadêmico, abrindo caminhos para um futuro promissor', '  A Universidade de São Paulo (USP), reconhecida como uma das instituições de ensino e pesquisa mais renomadas do país, está compartilhando insights valiosos para impulsionar a inovação e a pesquisa científica. Por meio de estudos e descobertas de ponta, pesquisadores da USP estão oferecendo novas perspectivas e conhecimentos para enfrentar os desafios atuais e futuros em áreas como ciências, tecnologia, medicina, humanidades e muito mais. Com suas diversas unidades e centros de pesquisa, a USP tem desempenhado um papel fundamental no avanço do conhecimento e no desenvolvimento de soluções para problemas complexos da sociedade. Seus pesquisadores, especialistas em suas respectivas áreas, estão constantemente buscando respostas para questões científicas e promovendo descobertas que têm impacto direto em diversas esferas da vida humana. Ao compartilhar esses insights valiosos, a USP desempenha um papel essencial na disseminação do conhecimento científico e no fomento à colaboração entre pesquisadores e instituições de todo o mundo. Essas descobertas não apenas contribuem para a evolução da ciência, mas também têm o potencial de gerar avanços significativos em diversos setores, como saúde, energia, meio ambiente, tecnologia, economia e muito mais. Com seu compromisso com a excelência acadêmica e o avanço do conhecimento, a USP continua a desempenhar um papel crucial na formação de profissionais qualificados e na produção de pesquisas inovadoras. Ao compartilhar seus insights valiosos, a universidade fortalece o ambiente acadêmico, inspirando novas gerações de pesquisadores e contribuindo para o progresso científico e tecnológico do país e do mundo.', '2023-05-12 00:00:00.000', 5, 3, 3),
	('Conheça o Tucanismo', 'Aluna da Fatec Matão Luiz Marchesan cria religião inovadora', ' Você com certeza já ouviu falar dos belos pássaros que habitam nosso páis, os tucanos. Conhecidos pela coloração variada de seus bicos em conjunto com sua pelugem negra. Diante desta formosura, uma aluna da Fatec Matão Luiz Marchesan, ao observar alguns desses animais no trajeto para a faculdade, ficou surpresa após observar ocasiões de sorte atreladas a tais encontros, Criando assim a religião que revencia e abençoa os tucanos, denominada de TUCANISMO. A criadora se chama Livia Marins Fioraneli e já retém diversos fiéis como a grande líder do movimento religioso. Seus seguidores dizem ficar admirados com os efeitos positivos de adotar e seguir a religião. Entretanto, existem aqueles que afirmam o contrário, como pelas se vê palavras de outro que viaja com a líder religiosa em questão: "Eu nunca vi nenhum tucano na estrada, do nada ela tá dirigindo e quase bate o carro gritando que viu tucano, eu acho que ela é esquizofrênica!!!". A aluna ficou conhecida por conceder diversas entrevistas a um jornal da cidade Matão, levando consigo, de forma oculta, a religião recém criada.', '2023-05-12T00:00:00.000', 2, 1, 3),
	('Djonga: O Rapper Mineiro Conquista o País com sua Música Autêntica e Letras Impactantes', 'Djonga se destaca no cenário musical brasileiro e promove reflexões através de suas composições', '  Djonga, o talentoso rapper mineiro, tem conquistado o coração do público brasileiro com sua música autêntica e letras impactantes. Com uma carreira ascendente, ele vem se destacando no cenário musical do país, trazendo sua mensagem poderosa e promovendo reflexões sobre questões sociais e políticas. Nascido e criado em Belo Horizonte, Djonga vem ganhando cada vez mais reconhecimento pelo seu estilo único e sua forma de expressão. Suas composições abordam temas como desigualdade, racismo, violência e outros problemas enfrentados pela sociedade. Com rimas afiadas e uma poesia crua, ele cria um diálogo com seu público, levando-os a refletir sobre as questões mais urgentes do país. Djonga também é conhecido por suas performances cativantes e sua presença de palco marcante. Seus shows são verdadeiros espetáculos, nos quais ele transmite sua energia e paixão pela música diretamente para o público. Com uma base de fãs fiel e em constante crescimento, ele tem lotado casas de shows e festivais por onde passa. Além de seu sucesso musical, Djonga também é um ativista e defensor dos direitos humanos. Ele utiliza sua voz e influência para promover debates e conscientizar sobre as desigualdades sociais, a importância da representatividade e a luta por igualdade racial. Seu engajamento vai além da música, sendo uma fonte de inspiração para muitos jovens que encontram em suas letras uma forma de expressão e empoderamento. Com seu talento inegável, Djonga se tornou uma das vozes mais relevantes do rap nacional, conquistando prêmios e reconhecimentos ao longo de sua carreira. Sua autenticidade e originalidade têm cativado não apenas os fãs de rap, mas também pessoas de diferentes gêneros musicais, tornando-o um dos artistas mais influentes da atualidade. Djonga é um exemplo de como a música pode ser uma ferramenta poderosa para promover mudanças e despertar consciências. Seu compromisso com a arte e sua mensagem impactante continuam a conquistar novos ouvintes, mostrando que a música tem o poder de transformar e inspirar. O rapper mineiro está escrevendo sua história e deixando sua marca indelével no cenário musical brasileiro.', '2023-05-12 00:00:00.000', 4, 5, 3);

---------------------------------------------------------------
------  Inserir Imagens
---------------------------------------------------------------

INSERT INTO tb_imagens
	(im_url)
VALUES
	('img/educacao/fatec.jpg'),
	('img/educacao/livia.png'),
	('img/economia/biousp.jpg'),
	('img/economia/consturcao-civil.jpg'),
	('img/economia/construtora.jpg'),
	('img/economia/crisefinanceira.jpg'),
	('img/economia/eletrica.jpg'),
	('img/economia/esportacoes.jpg'),
	('img/economia/frango.jpg'),
	('img/economia/imobiliaria.jpg'),
	('img/economia/investimentologistica.webp'),
	('img/economia/investimentos.jpg'),
	('img/economia/marketing.jpg'),
	('img/economia/marvelveiculos.jpg'),
	('img/economia/renault.jpg'),
	('img/empregos/aviao.jpg'),
	('img/empregos/banco.jpg'),
	('img/empregos/cerveja.jpg'),
	('img/empregos/designer.jpg'),
	('img/esportes/nba.jpg'),
	('img/economia/biousp.jpg'),
	('img/entretenimento/djonga.png');

INSERT INTO tb_img_not
	(imn_capa, imn_im_id, imn_nt_id)
VALUES
	(1, 1, 1),
	(1, 16, 2),
	(1, 17, 3),
	(1, 18, 4),
	(1, 19, 5),
	(1, 20, 6),
	(1, 21, 7),
	(1, 2, 8),
	(1, 22, 9);

--DELETE FROM tb_pessoas
--WHERE p_id > 4;
--DBCC CHECKIDENT ('tb_pessoas', RESEED, 4);