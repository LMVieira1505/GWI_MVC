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
SELECT * FROM tb_form_exp;
SELECT * FROM tb_areas;


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
WHERE p_id = 4;