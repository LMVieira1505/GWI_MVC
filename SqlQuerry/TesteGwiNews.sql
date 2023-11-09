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
	('Descoberta científica revoluciona a produção de energia sustentável, prometendo um futuro mais verde e acessível para todos!',
	'Cientistas desenvolvem tecnologia inovadora de reciclagem de resíduos para produção de energia limpa, reduzindo drasticamente a pegada de carbono e democratizando o acesso a fontes sustentáveis.',
	'Em um avanço científico notável, pesquisadores de todo o mundo se uniram para desenvolver uma tecnologia inovadora que tem o potencial de transformar o cenário da produção de energia sustentável. Essa descoberta promete tornar o sonho de um futuro mais verde e acessível uma realidade palpável.

	A chave para esse avanço é a criação de uma abordagem altamente eficiente para a reciclagem de resíduos, que converte uma variedade de materiais descartados em fontes de energia limpa. A tecnologia envolve processos de reciclagem aprimorados que permitem a conversão de resíduos em combustíveis renováveis e eletricidade de baixa emissão de carbono.

	Até agora, a produção de energia sustentável tem enfrentado desafios significativos, desde a dependência de recursos naturais limitados até a falta de infraestrutura adequada. No entanto, a nova tecnologia oferece uma solução abrangente para esses problemas.

	O processo começa com a coleta de resíduos sólidos, resíduos agrícolas e até mesmo plásticos descartados. Esses materiais, que antes seriam enviados para aterros sanitários ou incinerados, agora são tratados em instalações de reciclagem avançadas. Durante esse processo, os resíduos são transformados em gases sintéticos, que podem ser usados para gerar eletricidade de maneira eficiente.

	Além disso, os resíduos sólidos orgânicos são convertidos em biocombustíveis de próxima geração, que podem ser usados em veículos ou em usinas de energia. Esse método inovador de reciclagem de resíduos não apenas elimina a necessidade de aterros sanitários, mas também reduz significativamente a pegada de carbono.

	A acessibilidade é uma parte fundamental dessa revolução energética. A tecnologia foi projetada para ser implementada em comunidades de todos os tamanhos, desde áreas urbanas densamente povoadas até regiões rurais remotas. Isso significa que a produção de energia limpa está ao alcance de todos, independentemente de sua localização geográfica.

	"Essa descoberta tem o potencial de redefinir a forma como pensamos sobre energia sustentável", afirmou a Dra. Maria Silva, uma das principais cientistas envolvidas no projeto. "Estamos abrindo as portas para um futuro mais limpo e acessível, onde todos podem contribuir para a redução das emissões de carbono."

	A tecnologia já está sendo testada em escala piloto em várias partes do mundo, e os resultados iniciais são muito promissores. Os governos e organizações ambientais estão expressando grande entusiasmo em relação a essa abordagem revolucionária.

	À medida que a conscientização sobre as mudanças climáticas e a necessidade de reduzir as emissões de carbono continua a crescer, a descoberta dessa tecnologia de reciclagem de resíduos para produção de energia limpa representa um marco significativo. Ela oferece a esperança de um futuro mais verde e sustentável, onde a produção de energia não apenas reduz o impacto ambiental, mas também promove a inclusão e a acessibilidade para todos.'
	);

SELECT NT_titulo, NT_subtitulo, NT_texto
FROM Noticias
WHERE NT_id = 1;