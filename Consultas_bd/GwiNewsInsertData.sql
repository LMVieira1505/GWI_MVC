USE [GWINEWS]
GO

---------------------------------------------------------------
------  Inserir Usu�rios
---------------------------------------------------------------

INSERT INTO tb_niveis
	(nv_nivel, nv_funcao, nv_descricao)
VALUES
	(0, 'Administrador', 'Resolve pepino e administra editores'),
	(1, 'Editor', 'Corrige e pode retirar not�cias e adiciona autores'),
	(2, 'Autor', 'Cria e adiciona not�cias'),
	(3, 'Usuario', 'Acessa not�cias publicadas e pode criar curr�culos');

INSERT INTO tb_pessoas 
	(p_nome, p_sobrenome, p_telefone, p_email, p_senha, p_username, p_ativo, p_nv_id) 
VALUES
	('Ademir', 'Pereira Santos', '16998877665', 'ademiro@gwinews.com', 'ademir123', 'Admir', 0, 1),
	('Judit', 'Silva e Silva', '16889966775', 'juju@gmail.com', 'judit123', 'Jujuzinha', 0, 2),
	('Marcos', 'Paulo Selva', '16443322771', 'marquin@outlook.com', 'marco123', 'Marc�o', 0, 3),
	('�rsula', 'Carvalho Pinheiro', '16223311442', 'ursula@hotmail.com', 'ursula123', '�rsula', 0, 4);

---------------------------------------------------------------
------  Inserir Not�cias
---------------------------------------------------------------

INSERT INTO tb_categorias 
	(cat_nome, cat_ativo)
VALUES
	('Empregos', 0),
	('Educa��o', 0),
	('Esportes', 0),
	('Entretenimento', 0),
	('Economia', 0);

INSERT INTO tb_subcategorias
	(sct_nome, sct_ativo, sct_cat_id)
VALUES
	('Est�gio', 0, 1),
	('Per�odo Integral', 0, 1),
	('Jovem Aprendiz', 0, 1),
	('Curso T�cnico', 0, 2),
	('Tecn�logo', 0, 2),
	('Licenciatura', 0, 2),
	('Futebol', 0, 3),
	('V�lei', 0, 3),
	('Basquete', 0, 3),
	('M�sica', 0, 4),
	('Cinema', 0, 4),
	('Teatro', 0, 4),
	('Im�veis', 0, 5),
	('Investimentos', 0, 5),
	('Bolsa de Valores', 0, 5);

INSERT INTO tb_noticias 
	(nt_titulo, nt_subtitulo, nt_texto, nt_data_publicacao, nt_ativo, nt_cat_id, nt_p_id)
VALUES
	('Fatec Matao Luiz Marchesan Abre Vestibular', 'Fatec Mat�o Luiz Marchesan oferece cursos de excel�ncia e prepara os estudantes para o mercado de trabalho', 'A Fatec Mat�o Luiz Marchesan, renomada institui��o de ensino t�cnico, est� com as inscri��es abertas para o vestibular. Os estudantes interessados em ingressar em cursos de excel�ncia e se preparar para o mercado de trabalho t�m uma grande oportunidade pela frente. A institui��o � conhecida por oferecer uma forma��o s�lida e atualizada, preparando os alunos para os desafios da �rea t�cnica. Com uma infraestrutura moderna e professores altamente capacitados, a Fatec Mat�o Luiz Marchesan oferece uma variedade de cursos em diferentes �reas, como tecnologia da informa��o, gest�o empresarial, log�stica, mec�nica e muito mais. Os estudantes t�m a oportunidade de adquirir conhecimentos te�ricos e pr�ticos, aplicando o que aprendem em projetos e atividades realistas. Al�m disso, a Fatec Mat�o Luiz Marchesan mant�m parcerias com empresas da regi�o, proporcionando aos alunos a chance de vivenciar o ambiente profissional e estabelecer contatos no mercado de trabalho. Essas parcerias tamb�m podem levar a oportunidades de est�gio e emprego ap�s a forma��o, tornando a institui��o uma porta de entrada para uma carreira de sucesso. As inscri��es para o vestibular est�o abertas e podem ser feitas atrav�s do site oficial da Fatec Mat�o Luiz Marchesan. � importante ficar atento aos prazos e requisitos necess�rios para participar do processo seletivo. Os candidatos aprovados ter�o a oportunidade de estudar em uma institui��o renomada, reconhecida pela qualidade de seus cursos e pelo alto �ndice de empregabilidade de seus formandos. Se voc� busca uma forma��o t�cnica de excel�ncia e deseja se destacar no mercado de trabalho, n�o perca a chance de se inscrever no vestibular da Fatec Mat�o Luiz Marchesan. A institui��o est� pronta para receber os futuros profissionais e auxili�-los em sua jornada acad�mica e profissional.', '2023-05-12 13:21:05.000', 2, 1, 3),
	('Setor de Avia��o: Novas Oportunidades', 'Com o crescimento do setor, empresas a�reas e ind�stria de avia��o abrem vagas e impulsionam o mercado de trabalho na �rea', ' O setor de avia��o est� decolando com for�a total, trazendo excelentes oportunidades de emprego para profissionais apaixonados pelo mundo dos avi�es. Com a retomada das viagens a�reas e o crescimento da ind�stria, empresas a�reas e organiza��es relacionadas est�o ampliando suas opera��es e abrindo vagas em diferentes �reas, impulsionando o mercado de trabalho na �rea de avia��o. Companhias a�reas renomadas est�o anunciando a contrata��o de pilotos, comiss�rios de bordo, mec�nicos de aeronaves e profissionais de manuten��o. O aumento da demanda por voos e a renova��o das frotas de aeronaves t�m impulsionado a busca por talentos qualificados, oferecendo oportunidades de carreira empolgantes para aqueles que desejam trabalhar no setor. Al�m das empresas a�reas, a ind�stria de avia��o tamb�m est� aquecida, proporcionando chances de emprego em fabricantes de aeronaves, empresas de manuten��o e reparo, empresas de tecnologia aeron�utica e muito mais. Os avan�os tecnol�gicos e a necessidade de inova��o t�m impulsionado a contrata��o de engenheiros aeron�uticos, projetistas, especialistas em seguran�a a�rea e profissionais de pesquisa e desenvolvimento. A forma��o de parcerias estrat�gicas entre institui��es de ensino e empresas do setor tem contribu�do para a qualifica��o dos profissionais e a forma��o de m�o de obra especializada. Cursos t�cnicos, programas de treinamento e parcerias de est�gio t�m preparado os candidatos para as demandas espec�ficas da ind�stria da avia��o, aumentando suas chances de empregabilidade. Com o mercado de trabalho em expans�o e a retomada das atividades no setor de avia��o, � um momento oportuno para aqueles que desejam seguir uma carreira emocionante e desafiadora na �rea. Fique atento �s oportunidades e esteja preparado para decolar rumo a um futuro promissor na ind�stria aeron�utica.', '2023-05-12 08:13:21.000', 1, 1, 3), 
	('Banco do Brasil anuncia Abertura de Novas Vagas', 'Com planos de expans�o, Banco do Brasil oferece vagas em diversas �reas e impulsiona o mercado de trabalho no setor banc�rio', ' O Banco do Brasil est� anunciando a abertura de novas vagas, trazendo excelentes oportunidades de emprego para profissionais interessados em fazer parte de uma das maiores institui��es financeiras do pa�s. Com planos de expans�o e inova��o, o Banco do Brasil est� impulsionando o mercado de trabalho no setor banc�rio, oferecendo vagas em diversas �reas. Com a retomada da economia e a necessidade de atender �s demandas dos clientes, o Banco do Brasil est� em busca de profissionais qualificados para preencher posi��es estrat�gicas em �reas como atendimento ao cliente, gerenciamento financeiro, tecnologia da informa��o, an�lise de cr�dito, investimentos, entre outras. Al�m das oportunidades para profissionais com experi�ncia no setor banc�rio, o Banco do Brasil tamb�m est� abrindo espa�o para jovens talentos por meio de programas de trainee e est�gio, visando desenvolver e preparar a pr�xima gera��o de banc�rios. O banco tem investido em capacita��o e treinamentos para seus colaboradores, promovendo um ambiente de trabalho estimulante e oferecendo oportunidades de crescimento profissional. Com uma cultura organizacional focada em valores como �tica, transpar�ncia e inova��o, o Banco do Brasil busca atrair e reter os melhores talentos do mercado. Os interessados em fazer parte dessa equipe podem ficar atentos �s oportunidades divulgadas no site oficial do Banco do Brasil e em plataformas de recrutamento. � importante ressaltar que o banco valoriza a diversidade e a inclus�o, buscando candidatos de diferentes forma��es e experi�ncias. Se voc� est� em busca de uma carreira no setor banc�rio, esta � uma excelente oportunidade para se juntar a uma institui��o s�lida, reconhecida e com um papel fundamental no desenvolvimento econ�mico do pa�s.', '2023-05-12 14:20:15.000', 1, 1, 3),
	('Ambev Expande Produ��o e Abre Vagas', 'Com o aumento da demanda, Ambev oferece vagas em sua f�brica de cerveja e impulsiona o mercado de trabalho no setor', ' A Ambev, uma das maiores empresas do setor de bebidas, est� expandindo sua produ��o de cerveja e abrindo novas oportunidades de emprego em sua f�brica. Com o crescimento da demanda e o sucesso de suas marcas, a Ambev est� impulsionando o mercado de trabalho na ind�stria cervejeira, oferecendo vagas em diferentes �reas. A f�brica de cerveja da Ambev est� em busca de profissionais qualificados para atuar em posi��es como produ��o, log�stica, controle de qualidade, manuten��o, engenharia de processos e muito mais. A empresa valoriza a dedica��o, a paix�o pela ind�stria e o comprometimento com a excel�ncia. Com um ambiente de trabalho din�mico e colaborativo, a Ambev oferece oportunidades de crescimento e desenvolvimento profissional, al�m de benef�cios atrativos para seus colaboradores. A empresa investe em treinamentos e programas de capacita��o, buscando aprimorar as habilidades e conhecimentos de seus funcion�rios. A Ambev � conhecida por sua cultura de inova��o e sustentabilidade, buscando constantemente melhorias nos processos produtivos e na redu��o do impacto ambiental. Fazer parte da equipe da Ambev significa contribuir para uma empresa que est� em constante evolu��o e se adaptando �s demandas do mercado. Os interessados em fazer parte dessa equipe cervejeira de sucesso podem ficar atentos �s oportunidades divulgadas no site oficial da Ambev e em plataformas de recrutamento. A empresa valoriza a diversidade e a inclus�o, buscando candidatos com diferentes experi�ncias e forma��es. Se voc� � apaixonado pelo mundo cervejeiro e est� em busca de uma carreira na ind�stria de bebidas, essa � uma excelente oportunidade para se juntar a uma empresa l�der e influente no mercado.', '2023-05-12 11:20:50.000', 1, 1, 3), 
	('Baldan Procura Gerente de Marketing', 'Com foco em inova��o e qualidade, Baldan oferece vagas para profissionais de design e impulsiona o mercado de trabalho no setor agr�cola', ' A Baldan, empresa reconhecida no segmento de m�quinas agr�colas, est� anunciando a abertura de vagas no setor de design, oferecendo oportunidades de emprego para profissionais talentosos e apaixonados por inova��o. Com o compromisso de desenvolver solu��es eficientes e de alta qualidade para o setor agr�cola, a Baldan est� impulsionando o mercado de trabalho no segmento, trazendo novas oportunidades para o setor de design. A empresa busca por profissionais qualificados e criativos para atuar em projetos de design de m�quinas agr�colas, desenvolvimento de novos produtos, cria��o de interfaces digitais, entre outras �reas relacionadas ao design industrial. A Baldan valoriza a excel�ncia e o pensamento inovador, buscando constantemente aprimorar seus produtos e processos. Com uma hist�ria de sucesso e reconhecimento no mercado agr�cola, a Baldan oferece um ambiente de trabalho estimulante e oportunidades de crescimento profissional. A empresa investe em capacita��o e desenvolvimento de seus colaboradores, visando o aprimoramento de suas habilidades e conhecimentos no setor. A Baldan � reconhecida por sua cultura de inova��o e qualidade, buscando sempre oferecer solu��es que atendam �s necessidades dos agricultores e contribuam para o aumento da produtividade no campo. Fazer parte da equipe Baldan significa fazer parte de uma empresa que est� na vanguarda da tecnologia agr�cola. Os interessados em fazer parte da equipe de design da Baldan podem ficar atentos �s oportunidades divulgadas no site oficial da empresa e em plataformas de recrutamento. A Baldan valoriza a diversidade e a inclus�o, buscando candidatos com diferentes forma��es e experi�ncias. Se voc� � apaixonado por design e est� em busca de uma carreira no setor agr�cola, essa � uma excelente oportunidade para se juntar a uma empresa renomada e contribuir com solu��es inovadoras para o campo.', '2023-05-12 13:30:12.000', 1, 1, 3),
	('NBA Inicia a Temporada com Grande Expectativa', 'Abertura da temporada da NBA promete jogos eletrizantes e rivalidades renovadas nas quadras', '  A temporada da NBA est� prestes a come�ar e a expectativa � enorme entre os f�s de basquete ao redor do mundo. Os melhores times do basquete mundial se preparam para entrar em quadra e disputar o t�o cobi�ado t�tulo da NBA. Os astros do esporte est�o prontos para mostrar suas habilidades e proporcionar momentos de pura emo��o aos espectadores. Com o retorno de grandes estrelas e a chegada de novos talentos, a abertura da temporada da NBA promete ser repleta de jogos eletrizantes e rivalidades renovadas. Os f�s poder�o acompanhar confrontos entre equipes hist�ricas, como Los Angeles Lakers, Brooklyn Nets, Golden State Warriors, entre outros, al�m de presenciar o surgimento de novos aspirantes ao t�tulo. A NBA � conhecida por sua competitividade e alto n�vel t�cnico, e a temporada que se inicia n�o ser� diferente. As equipes investiram em refor�os e estrat�gias para buscar a gl�ria e conquistar o trof�u de campe�o. Os jogadores est�o empenhados em mostrar seu melhor desempenho, buscando impressionar os torcedores com suas habilidades e jogadas incr�veis. Al�m dos jogos, a temporada da NBA traz consigo uma s�rie de eventos paralelos que aumentam ainda mais o clima de festa e expectativa. All-Star Game, competi��es de enterradas, arremessos de tr�s pontos e habilidades s�o alguns dos momentos marcantes que os f�s poder�o desfrutar ao longo da temporada. Os amantes do basquete podem se preparar para vivenciar meses de pura emo��o e torcida intensa. A NBA est� pronta para abrir as cortinas de mais uma temporada recheada de jogos emocionantes, dribles desconcertantes e cestas incr�veis. Ent�o, pegue seu lugar nas arquibancadas ou acompanhe os jogos pela televis�o e prepare-se para mergulhar no universo apaixonante da NBA.', '2023-05-12 18:54:37.000', 3, 1, 3), 
	('USP em Mat�o Traz Insights Valiosos', 'Universidade de S�o Paulo (USP) compartilha insights preciosos para impulsionar a inova��o e o progresso cient�fico em diversas �reas do conhecimento acad�mico, abrindo caminhos para um futuro promissor', '  A Universidade de S�o Paulo (USP), reconhecida como uma das institui��es de ensino e pesquisa mais renomadas do pa�s, est� compartilhando insights valiosos para impulsionar a inova��o e a pesquisa cient�fica. Por meio de estudos e descobertas de ponta, pesquisadores da USP est�o oferecendo novas perspectivas e conhecimentos para enfrentar os desafios atuais e futuros em �reas como ci�ncias, tecnologia, medicina, humanidades e muito mais. Com suas diversas unidades e centros de pesquisa, a USP tem desempenhado um papel fundamental no avan�o do conhecimento e no desenvolvimento de solu��es para problemas complexos da sociedade. Seus pesquisadores, especialistas em suas respectivas �reas, est�o constantemente buscando respostas para quest�es cient�ficas e promovendo descobertas que t�m impacto direto em diversas esferas da vida humana. Ao compartilhar esses insights valiosos, a USP desempenha um papel essencial na dissemina��o do conhecimento cient�fico e no fomento � colabora��o entre pesquisadores e institui��es de todo o mundo. Essas descobertas n�o apenas contribuem para a evolu��o da ci�ncia, mas tamb�m t�m o potencial de gerar avan�os significativos em diversos setores, como sa�de, energia, meio ambiente, tecnologia, economia e muito mais. Com seu compromisso com a excel�ncia acad�mica e o avan�o do conhecimento, a USP continua a desempenhar um papel crucial na forma��o de profissionais qualificados e na produ��o de pesquisas inovadoras. Ao compartilhar seus insights valiosos, a universidade fortalece o ambiente acad�mico, inspirando novas gera��es de pesquisadores e contribuindo para o progresso cient�fico e tecnol�gico do pa�s e do mundo.', '2023-05-12 00:00:00.000', 5, 3, 3),
	('Conhe�a o Tucanismo', 'Aluna da Fatec Mat�o Luiz Marchesan cria religi�o inovadora', ' Voc� com certeza j� ouviu falar dos belos p�ssaros que habitam nosso p�is, os tucanos. Conhecidos pela colora��o variada de seus bicos em conjunto com sua pelugem negra. Diante desta formosura, uma aluna da Fatec Mat�o Luiz Marchesan, ao observar alguns desses animais no trajeto para a faculdade, ficou surpresa ap�s observar ocasi�es de sorte atreladas a tais encontros, Criando assim a religi�o que revencia e aben�oa os tucanos, denominada de TUCANISMO. A criadora se chama Livia Marins Fioraneli e j� ret�m diversos fi�is como a grande l�der do movimento religioso. Seus seguidores dizem ficar admirados com os efeitos positivos de adotar e seguir a religi�o. Entretanto, existem aqueles que afirmam o contr�rio, como pelas se v� palavras de outro que viaja com a l�der religiosa em quest�o: "Eu nunca vi nenhum tucano na estrada, do nada ela t� dirigindo e quase bate o carro gritando que viu tucano, eu acho que ela � esquizofr�nica!!!". A aluna ficou conhecida por conceder diversas entrevistas a um jornal da cidade Mat�o, levando consigo, de forma oculta, a religi�o rec�m criada.', '2023-05-12T00:00:00.000', 2, 1, 3),
	('Djonga: O Rapper Mineiro Conquista o Pa�s com sua M�sica Aut�ntica e Letras Impactantes', 'Djonga se destaca no cen�rio musical brasileiro e promove reflex�es atrav�s de suas composi��es', '  Djonga, o talentoso rapper mineiro, tem conquistado o cora��o do p�blico brasileiro com sua m�sica aut�ntica e letras impactantes. Com uma carreira ascendente, ele vem se destacando no cen�rio musical do pa�s, trazendo sua mensagem poderosa e promovendo reflex�es sobre quest�es sociais e pol�ticas. Nascido e criado em Belo Horizonte, Djonga vem ganhando cada vez mais reconhecimento pelo seu estilo �nico e sua forma de express�o. Suas composi��es abordam temas como desigualdade, racismo, viol�ncia e outros problemas enfrentados pela sociedade. Com rimas afiadas e uma poesia crua, ele cria um di�logo com seu p�blico, levando-os a refletir sobre as quest�es mais urgentes do pa�s. Djonga tamb�m � conhecido por suas performances cativantes e sua presen�a de palco marcante. Seus shows s�o verdadeiros espet�culos, nos quais ele transmite sua energia e paix�o pela m�sica diretamente para o p�blico. Com uma base de f�s fiel e em constante crescimento, ele tem lotado casas de shows e festivais por onde passa. Al�m de seu sucesso musical, Djonga tamb�m � um ativista e defensor dos direitos humanos. Ele utiliza sua voz e influ�ncia para promover debates e conscientizar sobre as desigualdades sociais, a import�ncia da representatividade e a luta por igualdade racial. Seu engajamento vai al�m da m�sica, sendo uma fonte de inspira��o para muitos jovens que encontram em suas letras uma forma de express�o e empoderamento. Com seu talento ineg�vel, Djonga se tornou uma das vozes mais relevantes do rap nacional, conquistando pr�mios e reconhecimentos ao longo de sua carreira. Sua autenticidade e originalidade t�m cativado n�o apenas os f�s de rap, mas tamb�m pessoas de diferentes g�neros musicais, tornando-o um dos artistas mais influentes da atualidade. Djonga � um exemplo de como a m�sica pode ser uma ferramenta poderosa para promover mudan�as e despertar consci�ncias. Seu compromisso com a arte e sua mensagem impactante continuam a conquistar novos ouvintes, mostrando que a m�sica tem o poder de transformar e inspirar. O rapper mineiro est� escrevendo sua hist�ria e deixando sua marca indel�vel no cen�rio musical brasileiro.', '2023-05-12 00:00:00.000', 4, 5, 3);

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