using System.Collections.Generic;
using System.Linq;
using Api.Models;
using Api.Utils;
public class ClienteService
{
     private readonly ClienteContext _context; 

    public ClienteService(ClienteContext context)
    {
        _context = context;
    }

       public Cliente CriarCliente(ClienteDTO clienteDTO)
    {
        var novoCliente = Cliente.NovoCliente(
            clienteDTO.CNPJ,
            clienteDTO.NomeCliente,
            clienteDTO.Email,
            clienteDTO.Telefone,
            clienteDTO.CEP,
            clienteDTO.Pais,
            clienteDTO.Estado,
            clienteDTO.Cidade,
            clienteDTO.Bairro,
            clienteDTO.Logradouro,
            clienteDTO.Numero,
            clienteDTO.Complemento
        );
        if (!CnpjUtils.ValidarCNPJ(clienteDTO.CNPJ))         
        {
             throw new KeyNotFoundException("Cnpj inválido.");
        }

        _context.Clientes.Add(novoCliente);
        _context.SaveChanges();
        return novoCliente;
    }

     public Cliente AtualizarCliente(int idCliente, ClienteDTO clienteDTO)
    {
        var clienteExistente = _context.Clientes.FirstOrDefault(c => c.IdCliente == idCliente);

        if (clienteExistente == null)
        {
            throw new KeyNotFoundException("Cliente não encontrado.");
        }
        if (!CnpjUtils.ValidarCNPJ(clienteDTO.CNPJ))         
        {
             throw new KeyNotFoundException("Cnpj inválido.");
        }
        clienteExistente.CNPJ = clienteDTO.CNPJ ?? clienteExistente.CNPJ;
        clienteExistente.NomeCliente = clienteDTO.NomeCliente ?? clienteExistente.NomeCliente;
        clienteExistente.Email = clienteDTO.Email ?? clienteExistente.Email;
        clienteExistente.Telefone = clienteDTO.Telefone ?? clienteExistente.Telefone;
        clienteExistente.CEP = clienteDTO.CEP ?? clienteExistente.CEP;
        clienteExistente.Pais = clienteDTO.Pais ?? clienteExistente.Pais;
        clienteExistente.Estado = clienteDTO.Estado ?? clienteExistente.Estado;
        clienteExistente.Cidade = clienteDTO.Cidade ?? clienteExistente.Cidade;
        clienteExistente.Bairro = clienteDTO.Bairro ?? clienteExistente.Bairro;
        clienteExistente.Logradouro = clienteDTO.Logradouro ?? clienteExistente.Logradouro;
        clienteExistente.Numero = clienteDTO.Numero ?? clienteExistente.Numero;
        clienteExistente.Complemento = clienteDTO.Complemento ?? clienteExistente.Complemento;
    
        _context.SaveChanges();
        return clienteExistente;
    }

}