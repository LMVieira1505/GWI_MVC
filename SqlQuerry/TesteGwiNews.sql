CREATE DATABASE TesteGwiNews
GO

USE TesteGwiNews
GO

CREATE TABLE Noticias (
	NT_id INT PRIMARY KEY IDENTITY NOT NULL,
	NT_titulo VARCHAR(255) NOT NULL,
	NT_subtitulo VARCHAR(510) NOT NULL,
	NT_texto TEXT NOT NULL,
	);

INSERT INTO Noticias
	(NT_titulo, NT_subtitulo, NT_texto)
VALUES
	('Descoberta cient�fica revoluciona a produ��o de energia sustent�vel, prometendo um futuro mais verde e acess�vel para todos!',
	'Cientistas desenvolvem tecnologia inovadora de reciclagem de res�duos para produ��o de energia limpa, reduzindo drasticamente a pegada de carbono e democratizando o acesso a fontes sustent�veis.',
	'Em um avan�o cient�fico not�vel, pesquisadores de todo o mundo se uniram para desenvolver uma tecnologia inovadora que tem o potencial de transformar o cen�rio da produ��o de energia sustent�vel. Essa descoberta promete tornar o sonho de um futuro mais verde e acess�vel uma realidade palp�vel.

	A chave para esse avan�o � a cria��o de uma abordagem altamente eficiente para a reciclagem de res�duos, que converte uma variedade de materiais descartados em fontes de energia limpa. A tecnologia envolve processos de reciclagem aprimorados que permitem a convers�o de res�duos em combust�veis renov�veis e eletricidade de baixa emiss�o de carbono.

	At� agora, a produ��o de energia sustent�vel tem enfrentado desafios significativos, desde a depend�ncia de recursos naturais limitados at� a falta de infraestrutura adequada. No entanto, a nova tecnologia oferece uma solu��o abrangente para esses problemas.

	O processo come�a com a coleta de res�duos s�lidos, res�duos agr�colas e at� mesmo pl�sticos descartados. Esses materiais, que antes seriam enviados para aterros sanit�rios ou incinerados, agora s�o tratados em instala��es de reciclagem avan�adas. Durante esse processo, os res�duos s�o transformados em gases sint�ticos, que podem ser usados para gerar eletricidade de maneira eficiente.

	Al�m disso, os res�duos s�lidos org�nicos s�o convertidos em biocombust�veis de pr�xima gera��o, que podem ser usados em ve�culos ou em usinas de energia. Esse m�todo inovador de reciclagem de res�duos n�o apenas elimina a necessidade de aterros sanit�rios, mas tamb�m reduz significativamente a pegada de carbono.

	A acessibilidade � uma parte fundamental dessa revolu��o energ�tica. A tecnologia foi projetada para ser implementada em comunidades de todos os tamanhos, desde �reas urbanas densamente povoadas at� regi�es rurais remotas. Isso significa que a produ��o de energia limpa est� ao alcance de todos, independentemente de sua localiza��o geogr�fica.

	"Essa descoberta tem o potencial de redefinir a forma como pensamos sobre energia sustent�vel", afirmou a Dra. Maria Silva, uma das principais cientistas envolvidas no projeto. "Estamos abrindo as portas para um futuro mais limpo e acess�vel, onde todos podem contribuir para a redu��o das emiss�es de carbono."

	A tecnologia j� est� sendo testada em escala piloto em v�rias partes do mundo, e os resultados iniciais s�o muito promissores. Os governos e organiza��es ambientais est�o expressando grande entusiasmo em rela��o a essa abordagem revolucion�ria.

	� medida que a conscientiza��o sobre as mudan�as clim�ticas e a necessidade de reduzir as emiss�es de carbono continua a crescer, a descoberta dessa tecnologia de reciclagem de res�duos para produ��o de energia limpa representa um marco significativo. Ela oferece a esperan�a de um futuro mais verde e sustent�vel, onde a produ��o de energia n�o apenas reduz o impacto ambiental, mas tamb�m promove a inclus�o e a acessibilidade para todos.'
	);

SELECT NT_titulo, NT_subtitulo, NT_texto
FROM Noticias
WHERE NT_id = 1;