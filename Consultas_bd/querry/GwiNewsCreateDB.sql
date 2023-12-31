CREATE DATABASE GWINEWS
GO


USE GWINEWS
GO


CREATE TABLE tb_imagens (
	im_id int IDENTITY PRIMARY KEY NOT NULL,
	im_url varchar(255) NOT NULL
);


CREATE TABLE tb_categorias (
	cat_id int PRIMARY KEY IDENTITY NOT NULL,
	cat_nome varchar(20) NOT NULL,
	cat_ativo bit NOT NULL
);


CREATE TABLE tb_subcategorias (
	sct_id int PRIMARY KEY IDENTITY NOT NULL,
	sct_nome varchar(35) NOT NULL,
	sct_ativo bit NOT NULL,
	sct_cat_id int FOREIGN KEY REFERENCES tb_categorias(cat_id)
);


CREATE TABLE tb_niveis (
	nv_id int IDENTITY PRIMARY KEY NOT NULL,
	nv_nivel int NOT NULL,
	nv_funcao varchar(55) NOT NULL,
	nv_descricao varchar(510) NOT NULL,
);


CREATE TABLE tb_pessoas (
	p_id int IDENTITY PRIMARY KEY NOT NULL,
	p_nome varchar(255) NOT NULL,
	p_sobrenome varchar(510) NOT NULL,
	p_telefone varchar(11) NOT NULL,
	p_email varchar(255) NOT NULL,
	p_senha varchar(55) NOT NULL,
	p_userName varchar(255) NOT NULL,
	p_ativo bit NOT NULL,
	p_cpf char(11),
	p_cnpj char(14),
	p_nv_id int FOREIGN KEY REFERENCES tb_niveis(nv_id),
	p_im_id int FOREIGN KEY REFERENCES tb_imagens(im_id)
);


CREATE TABLE tb_cat_propagandas (
	pcat_id INT IDENTITY PRIMARY KEY NOT NULL,
	pcat_tipo int NOT NULL,
	pcat_nome varchar(55) NOT NULL,
	pcat_descricao varchar(510) NOT NULL
);


CREATE TABLE tb_propagandas (
	pro_id INT IDENTITY PRIMARY KEY NOT NULL,
	pro_acesso int NOT NULL,
	pro_pcat_id INT FOREIGN KEY REFERENCES tb_cat_propagandas(pcat_id) NOT NULL,
	pro_img_id INT FOREIGN KEY REFERENCES tb_imagens(im_id) NOT NULL
);


CREATE TABLE tb_noticias (
	nt_id int IDENTITY PRIMARY KEY NOT NULL, 
	nt_titulo varchar(255) NOT NULL,
	nt_subtitulo varchar(510) NOT NULL,
	nt_texto text NOT NULL,
	nt_data_publicacao datetime NOT NULL,
	nt_ativo bit NOT NULL,
	nt_cat_id int FOREIGN KEY REFERENCES tb_categorias(cat_id),
	nt_p_id int FOREIGN KEY REFERENCES tb_pessoas(p_id)
);


CREATE TABLE tb_sctnt (
	sctnt_id int IDENTITY PRIMARY KEY NOT NULL,
	sctnt_nt_id int FOREIGN KEY REFERENCES tb_noticias(nt_id) NOT NULL,
	sbtnt_sct_id int FOREIGN KEY REFERENCES tb_subcategorias(sct_id) NOT NULL
);


CREATE TABLE tb_img_not (
	imn_id INT IDENTITY PRIMARY KEY NOT NULL,
	imn_capa bit NOT NULL,
	imn_nt_id INT FOREIGN KEY REFERENCES tb_noticias(nt_id),
	imn_im_id INT FOREIGN KEY REFERENCES tb_imagens(im_id)
);


CREATE TABLE tb_servicos (
	sv_id int PRIMARY KEY IDENTITY NOT NULL,
	sv_t�tulo varchar(50) NOT NULL, 
	sv_imagem varchar(255) NOT NULL,
	sv_descri��o varchar(300) NOT NULL,
	sv_im_id INT FOREIGN KEY REFERENCES tb_imagens(im_id)
);


CREATE TABLE tb_cnh (
	cnh_id int PRIMARY KEY IDENTITY NOT NULL,
	cnh_tipo varchar(3) NOT NULL
);


CREATE TABLE tb_habilidades (
	hb_id int PRIMARY KEY IDENTITY NOT NULL,
	hb_tipo varchar(55) NOT NULL,
	hb_nome varchar(55) NOT NULL
);

 
CREATE TABLE tb_areas(
	ar_id int PRIMARY KEY IDENTITY NOT NULL,
	ar_tipo varchar(50) NOT NULL,
	ar_nome varchar(50) NOT NULL
);


CREATE TABLE tb_form_exp (
	fe_id int PRIMARY KEY IDENTITY NOT NULL,
	fe_tipo bit NOT NULL,
	fe_nome varchar(255) NOT NULL,
	fe_instituicao varchar(110) NOT NULL,
	fe_ano_ini int NOT NULL,
	fe_ano_ter int NOT NULL,
	fe_descricao varchar(200) NOT NULL,
	fe_ar_id int FOREIGN KEY REFERENCES tb_areas(ar_id),
	fe_p_id int FOREIGN KEY REFERENCES tb_pessoas(p_id)
);


CREATE TABLE tb_pessoas_curriculos (
	cr_id int IDENTITY PRIMARY KEY NOT NULL,
	cr_endereco varchar(255) NOT NULL,
	cr_objetivos varchar(200) NOT NULL,
	cr_p_id int FOREIGN KEY REFERENCES tb_pessoas(p_id)
);


CREATE TABLE tb_hbcr (
	hbcr_id INT IDENTITY PRIMARY KEY NOT NULL,
	hbcr_hb_id INT FOREIGN KEY REFERENCES tb_habilidades(hb_id) NOT NULL,
	hbcr_cr_id INT FOREIGN KEY REFERENCES tb_pessoas_curriculos(cr_id) NOT NULL
);


CREATE TABLE tb_cnhcr (
	hbtcr_id INT IDENTITY PRIMARY KEY NOT NULL,
	cnhcr_hbt_id INT FOREIGN KEY REFERENCES tb_cnh(cnh_id) NOT NULL,
	hbtcr_cr_id INT FOREIGN KEY REFERENCES tb_pessoas_curriculos(cr_id) NOT NULL
);


CREATE TABLE tb_fecr (
	fecr_id int IDENTITY PRIMARY KEY NOT NULL,
	fecr_fe_id int FOREIGN KEY REFERENCES tb_form_exp(fe_id),
	fecr_cr_id int FOREIGN KEY REFERENCES tb_pessoas_curriculos(cr_id)
);



---------------------------------------------------------------
------  Comando �teis
---------------------------------------------------------------

--ALTER TABLE tb_pessoas_curriculos
--DROP COLUMN cr_nome;
--ALTER TABLE tb_pessoas_curriculos
--DROP COLUMN cr_data_nasc;
--ALTER TABLE tb_pessoas_curriculos
--DROP COLUMN cr_estado_civil;
--ALTER TABLE tb_pessoas_curriculos
--DROP COLUMN cr_telefone_opc;
--ALTER TABLE tb_pessoas_curriculos
--DROP COLUMN cr_email_opc;


--ALTER TABLE tb_form_exp
--ADD fe_descricao varchar(200);

--DELETE FROM tb_cnh;
--DBCC CHECKIDENT ('tb_cnh', RESEED, 0);