USE [GWINEWS]
GO

SELECT * FROM tb_categorias;
SELECT * FROM tb_subcategorias;
SELECT * FROM tb_sctnt;
SELECT * FROM tb_imagens;
SELECT * FROM tb_img_not;
SELECT * FROM tb_noticias;

SELECT * FROM tb_pessoas;
SELECT * FROM tb_niveis;


SELECT * FROM tb_pessoas_curriculos;
SELECT * FROM tb_hbcr;
SELECT * FROM tb_habilidades;
SELECT * FROM tb_cnhcr;
SELECT * FROM tb_cnh;
SELECT * FROM tb_fecr;
SELECT * FROM tb_areas;

SELECT * FROM tb_form_exp;


SELECT * FROM tb_servicos;
SELECT * FROM tb_propagandas;
SELECT * FROM tb_cat_propagandas;

---------------------------------------------------------------
------  Retornar Notícia
---------------------------------------------------------------

SELECT nt_titulo, nt_subtitulo, nt_texto, nt_data_publicacao, p_username, imn_capa, im_url
FROM tb_noticias 
INNER JOIN tb_pessoas
	ON tb_noticias.nt_p_id = tb_pessoas.p_id 
INNER JOIN tb_img_not 
	ON tb_noticias.nt_id = tb_img_not.imn_nt_id 
INNER JOIN tb_imagens 
	ON tb_img_not.imn_im_id = tb_imagens.im_id;

---------------------------------------------------------------
------  Retornar Pessoa
---------------------------------------------------------------

SELECT p_id, p_userName, p_nome, p_sobrenome, p_email, p_telefone
FROM tb_pessoas
WHERE p_id = 5;

---------------------------------------------------------------
------  Update Pessoa
---------------------------------------------------------------

--UPDATE tb_pessoas
--SET p_nome = 'Junin', p_sobrenome = 'Filho Neto', p_telefone = '16999888777', p_email = 'juniorfilho@email.com', p_senha = 'junin123', p_username = 'juninBoladao'
--WHERE p_id = 5;

---------------------------------------------------------------
------  Retornar Todas For_Exps de uma Pessoa
---------------------------------------------------------------

SELECT fe_tipo, fe_nome, fe_instituicao, fe_ano_ini, fe_ano_ter, fe_descricao, ar_nome, ar_tipo
FROM tb_form_exp 
INNER JOIN tb_pessoas 
	ON tb_form_exp.fe_p_id = tb_pessoas.p_id
INNER JOIN tb_areas 
	ON tb_form_exp.fe_ar_id = tb_areas.ar_id
WHERE p_id = 4;

---------------------------------------------------------------
------  Update For_Exp
---------------------------------------------------------------

--UPDATE tb_form_exp 
--SET fe_tipo = 0, fe_nome = 'DSM', fe_instituicao = 'Fatec Aqa', fe_ano_ini = 2023, fe_ano_ter = 2025, fe_descricao = 'Curso Legal', fe_ar_id = 50 
--WHERE fe_id = 1;

---------------------------------------------------------------
------  Delete For Exp
---------------------------------------------------------------

--DELETE FROM tb_form_exp WHERE fe_id = 5;
--DBCC CHECKIDENT ('tb_form_exp', RESEED, 4);

---------------------------------------------------------------
------  Retorno de Categorias
---------------------------------------------------------------

SELECT cat_id, cat_nome, cat_ativo 
FROM tb_categorias;

---------------------------------------------------------------
------  Retorno de Subcategorias
---------------------------------------------------------------

SELECT sct_id, sct_nome, sct_ativo, sct_cat_id
FROM tb_subcategorias;