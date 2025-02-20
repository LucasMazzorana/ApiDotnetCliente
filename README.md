# ApiDotnetCliente
Api de clientes: 
, .net 5.0
, Entity Framework
, Banco de dados postgree
,Segue Script para rodar no postgree

-- Table: public.TB_CLIENTE

-- DROP TABLE IF EXISTS public."TB_CLIENTE";

CREATE TABLE IF NOT EXISTS public."TB_CLIENTE"
(
    "ID_CLIENTE" numeric NOT NULL DEFAULT nextval('tb_cliente_id_seq'::regclass),
    "NOME_CLIENTE" character varying(100) COLLATE pg_catalog."default" NOT NULL,
    "CNPJ" character varying(14) COLLATE pg_catalog."default" NOT NULL,
    "CEP" character varying(100) COLLATE pg_catalog."default" NOT NULL,
    "SGL_PAIS" character(2) COLLATE pg_catalog."default" NOT NULL,
    "SGL_ESTADO" character(2) COLLATE pg_catalog."default" NOT NULL,
    "CIDADE" character varying(50) COLLATE pg_catalog."default" NOT NULL,
    "BAIRRO" character varying(50) COLLATE pg_catalog."default" NOT NULL,
    "LOGRADOURO" character varying(100) COLLATE pg_catalog."default" NOT NULL,
    "NUMERO" character varying(10) COLLATE pg_catalog."default" NOT NULL,
    "COMPLEMENTO" character varying(100) COLLATE pg_catalog."default" NOT NULL,
    "EMAIL_CLIENTE" character varying(50) COLLATE pg_catalog."default" NOT NULL,
    "TELEFONE_CLIENTE" character varying(20) COLLATE pg_catalog."default" NOT NULL,
    data_criacao date,
    CONSTRAINT "PK_TABELA" PRIMARY KEY ("ID_CLIENTE"),
    CONSTRAINT "UK_CNPJ" UNIQUE ("CNPJ")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."TB_CLIENTE"
    OWNER to postgres;

COMMENT ON TABLE public."TB_CLIENTE"
    IS 'TABELA DE CLIENTES';

COMMENT ON COLUMN public."TB_CLIENTE"."ID_CLIENTE"
    IS 'identificação do cliente';

COMMENT ON COLUMN public."TB_CLIENTE"."NOME_CLIENTE"
    IS 'nome do cliente';

COMMENT ON COLUMN public."TB_CLIENTE"."CNPJ"
    IS 'documento da empresa';

COMMENT ON COLUMN public."TB_CLIENTE"."CEP"
    IS 'cep do endereço';

COMMENT ON COLUMN public."TB_CLIENTE"."SGL_PAIS"
    IS 'sigla do pais';

COMMENT ON COLUMN public."TB_CLIENTE"."SGL_ESTADO"
    IS 'sigla do estado';

COMMENT ON COLUMN public."TB_CLIENTE"."CIDADE"
    IS 'cidade da empresa';

COMMENT ON COLUMN public."TB_CLIENTE"."BAIRRO"
    IS 'bairro da empresa';

COMMENT ON COLUMN public."TB_CLIENTE"."LOGRADOURO"
    IS 'rua da empresa';

COMMENT ON COLUMN public."TB_CLIENTE"."NUMERO"
    IS 'número em que fica a empresa';

COMMENT ON COLUMN public."TB_CLIENTE"."COMPLEMENTO"
    IS 'complemento do endereço';

COMMENT ON COLUMN public."TB_CLIENTE"."EMAIL_CLIENTE"
    IS 'e-mail do cleinte';

COMMENT ON COLUMN public."TB_CLIENTE"."TELEFONE_CLIENTE"
    IS 'telefone do cliente';

COMMENT ON COLUMN public."TB_CLIENTE".data_criacao
    IS 'data da criação do cliente';
