using System;
using System.ComponentModel.DataAnnotations; 
using System.ComponentModel.DataAnnotations.Schema;

[Table("TB_CLIENTE")]
public class Cliente : IEndereco
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("ID_CLIENTE")]
    public int IdCliente { get; set; }
    [Column("CNPJ")]
     public string CNPJ  { get; set; }
    [Column("NOME_CLIENTE")]
    public string NomeCliente { get; set; }
    [Column("EMAIL_CLIENTE")]
    public string Email { get; set; }
    [Column("TELEFONE_CLIENTE")]
    public string Telefone { get; set; }
    [Column("SGL_PAIS")]
    public string Pais { get; set; }
    [Column("LOGRADOURO")]
     public string Logradouro { get; set; }
     [Column("NUMERO")]
    public string Numero { get; set; }
    [Column("COMPLEMENTO")]
    public string Complemento { get; set; }
    [Column("BAIRRO")]
    public string Bairro { get; set; }
    [Column("CIDADE")]
    public string Cidade { get; set; }
    [Column("SGL_ESTADO")]
    public string Estado { get; set; }
    [Column("CEP")]
    public string CEP { get; set; }
    [Column("data_criacao")]
    public DateTime?  DataCriacao { get; set; }

    public Cliente() 
    { } 

   private static void ValidarCamposObrigatorios(string[] valores, string[] nomesDosCampos)
    {
        if (valores.Length != nomesDosCampos.Length)
        {
            throw new ArgumentException("O número de valores e nomes de campos não corresponde.");
        }

        for (int i = 0; i < valores.Length; i++)
        {
            if (string.IsNullOrEmpty(valores[i]))
            {
                throw new ArgumentException($"O campo {nomesDosCampos[i]} é obrigatório.");
            }
        }
    }
     public static Cliente NovoCliente(
        string cnpj,
        string nomeCliente,
        string email,
        string telefone,
        string cep,
        string pais,
        string estado,
        string cidade,
        string bairro,
        string logradouro,
        string numero,
        string complemento)
    {
        string[] valores = { cnpj, nomeCliente, telefone, cep, pais, estado, cidade, bairro, logradouro, numero };
        string[] nomesDosCampos = { "CNPJ", "Nome do Cliente", "Telefone", "CEP", "País", "Estado", "Cidade", "Bairro", "Logradouro", "Número" };

        ValidarCamposObrigatorios(valores, nomesDosCampos);

        if (!string.IsNullOrEmpty(email) && !IsValidEmail(email))
        {
            throw new ArgumentException("O email fornecido é inválido.");
        }

        return new Cliente
        {
            CNPJ = cnpj,
            NomeCliente = nomeCliente,
            Email = email,
            Telefone = telefone,
            CEP = cep,
            Pais = pais,
            Estado = estado,
            Cidade = cidade,
            Bairro = bairro,
            Logradouro = logradouro,
            Numero = numero,
            Complemento = complemento,
            DataCriacao = DateTime.Now,
        };
    }
     public void AtualizarCliente(ClienteDTO clienteDTO)
    {
        CNPJ = clienteDTO.CNPJ ?? CNPJ; 
        NomeCliente = clienteDTO.NomeCliente ?? NomeCliente;
        Email = clienteDTO.Email ?? Email;
        Telefone = clienteDTO.Telefone ?? Telefone;
        CEP = clienteDTO.CEP ?? CEP;
        Pais = clienteDTO.Pais ?? Pais;
        Estado = clienteDTO.Estado ?? Estado;
        Cidade = clienteDTO.Cidade ?? Cidade;
        Bairro = clienteDTO.Bairro ?? Bairro;
        Logradouro = clienteDTO.Logradouro ?? Logradouro;
        Numero = clienteDTO.Numero ?? Numero;
        Complemento = clienteDTO.Complemento ?? Complemento;
    }
    private static bool IsValidEmail(string email)
    {
    if (string.IsNullOrEmpty(email))
    {
        return true; 
    }

     return System.Text.RegularExpressions.Regex.IsMatch(email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
    }
}