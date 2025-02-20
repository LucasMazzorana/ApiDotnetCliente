public interface IEndereco
{
    string Logradouro { get; set; }
    string Numero { get; set; }
    string Complemento { get; set; }
    string Bairro { get; set; }
    string Cidade { get; set; }
    string Estado { get; set; }
    string CEP { get; set; }
    string Pais {get; set;}
}