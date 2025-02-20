using System.ComponentModel.DataAnnotations;

public class ClienteDTO    
{
    public int IdCliente { get; set; }
    
    [Required(ErrorMessage = "O CNPJ é obrigatório.")] 
    [StringLength(14, ErrorMessage = "O CNPJ deve ter 14 caracteres.")]
    public string CNPJ { get; set; }

    [Required(ErrorMessage = "O Nome do Cliente é obrigatório.")]
    [StringLength(200, ErrorMessage = "O Nome do Cliente deve ter no máximo 200 caracteres.")]
    public string NomeCliente { get; set; }

    [EmailAddress(ErrorMessage = "O Email é inválido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O Telefone é obrigatório.")]
    [StringLength(20, ErrorMessage = "O Telefone deve ter no máximo 20 caracteres.")]
    public string Telefone { get; set; }

    [Required(ErrorMessage = "O CEP é obrigatório.")]
    [StringLength(8, ErrorMessage = "O CEP deve ter 8 caracteres.")]
    public string CEP { get; set; }

    [Required(ErrorMessage = "O País é obrigatório.")]
    [StringLength(100, ErrorMessage = "O País deve ter no máximo 100 caracteres.")]
    public string Pais { get; set; }

    [Required(ErrorMessage = "O Estado é obrigatório.")]
    [StringLength(2, ErrorMessage = "O Estado deve ter 2 caracteres.")]
    public string Estado { get; set; }

    [Required(ErrorMessage = "A Cidade é obrigatória.")]
    [StringLength(100, ErrorMessage = "A Cidade deve ter no máximo 100 caracteres.")]
    public string Cidade { get; set; }

    [Required(ErrorMessage = "O Bairro é obrigatório.")]
    [StringLength(100, ErrorMessage = "O Bairro deve ter no máximo 100 caracteres.")]
    public string Bairro { get; set; }

    [Required(ErrorMessage = "O Logradouro é obrigatório.")]
    [StringLength(200, ErrorMessage = "O Logradouro deve ter no máximo 200 caracteres.")]
    public string Logradouro { get; set; }

    [Required(ErrorMessage = "O Número é obrigatório.")]
    [StringLength(10, ErrorMessage = "O Número deve ter no máximo 10 caracteres.")]
    public string Numero { get; set; }

    [StringLength(200, ErrorMessage = "O Complemento deve ter no máximo 200 caracteres.")]
    public string Complemento { get; set; }
}