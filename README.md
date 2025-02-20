## Projeto backend .net com Entity Framework e banco PostgreSQL  

### Tecnologia utilizada   

* SDK .net 5   
* C#
* Entity Framework   
* PostgreSQL   

### PostgreSQL

##### String de conexao adicionada no appsettings.json  
```json
  "ConnectionStrings": {
    "PostgreConnection": "Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=*****;"
  },
```

##### Script de criação da tabela
```sql
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
```

### Execucao do app (para subir a aplicação)
```dotnet
dotnet run
```   

### Swagger   

##### Para testar os endpoints, abrir no browser a seguinte URL:   

* (https://localhost:5001/swagger)


### Postman   

##### Criar um cliente:   

POST para (http://localhost:5000/cadastrar-cliente)

Exemplo de Json Request
```json
{
  "idCliente": 0,
  "cnpj": "string",
  "nomeCliente": "string",
  "email": "user@example.com",
  "telefone": "string",
  "cep": "string",
  "pais": "string",
  "estado": "string",
  "cidade": "string",
  "bairro": "string",
  "logradouro": "string",
  "numero": "string",
  "complemento": "string"
}
```

##### Listar todos os clientes:   

GET para (http://localhost:5000/listar-todos)


##### Alterar um cliente por ID:   

PUT para (http://localhost:5000/alterar-cliente/{IdCliente})

Exemplo de Json Request
```json
{
  "idCliente": 0,
  "cnpj": "string",
  "nomeCliente": "string",
  "email": "user@example.com",
  "telefone": "string",
  "cep": "string",
  "pais": "string",
  "estado": "string",
  "cidade": "string",
  "bairro": "string",
  "logradouro": "string",
  "numero": "string",
  "complemento": "string"
}
```


##### Remover um cliente por ID:   

DELETE para (http://localhost:5000/excluir-cliente/{IdCliente})


##### Recuperar um cliente por ID:   

GET para (http://localhost:5000/pesquisa-por-id/{IdCliente})


