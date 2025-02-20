using System;
using Microsoft.AspNetCore.Mvc;
using Api.Models;
using System.Linq;

[ApiController]
[Route("api/[controller]")] 
public class ClienteController : ControllerBase
{
    private readonly ClienteContext _context;
    private readonly ClienteService _clienteService; 
    public ClienteController(ClienteService clienteService, ClienteContext context) 
    {
        _clienteService = clienteService;
          _context = context;
    }


    [HttpPost("/cadastrar-cliente")]
    public IActionResult CadastrarCliente([FromBody] ClienteDTO clienteDTO) 
    {
        if (!ModelState.IsValid) 
        {
            return BadRequest(ModelState); 
        }

        try
        {
            var novoCliente = Cliente.NovoCliente(
                clienteDTO.CNPJ, clienteDTO.NomeCliente, clienteDTO.Email, clienteDTO.Telefone,
                clienteDTO.CEP, clienteDTO.Pais, clienteDTO.Estado, clienteDTO.Cidade,
                clienteDTO.Bairro, clienteDTO.Logradouro, clienteDTO.Numero, clienteDTO.Complemento);

            _context.Clientes.Add(novoCliente);
            _context.SaveChanges();

            return CreatedAtAction(nameof(ObterClientePorId), new { IdCliente = novoCliente.IdCliente }, novoCliente); 
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { mensagem = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensagem = "Erro interno no servidor: " + ex.Message }); 
        }
    }
    [HttpPut("/alterar-cliente/{IdCliente}")]
    public IActionResult AtualizarCliente(int  IdCliente, [FromBody] ClienteDTO clienteDTO)
    {
       if (IdCliente != clienteDTO.IdCliente)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                var clienteExistente = _context.Clientes.Find(IdCliente); 

            if (clienteExistente == null)
            {
                 return NotFound(); 
            }
            
            if (!string.IsNullOrEmpty(clienteDTO.NomeCliente))
            {
                clienteExistente.NomeCliente = clienteDTO.NomeCliente;
            }

            if (!string.IsNullOrEmpty(clienteDTO.Email))
            {
                clienteExistente.Email = clienteDTO.Email;
            }

            if (!string.IsNullOrEmpty(clienteDTO.Telefone))
            {
                clienteExistente.Telefone = clienteDTO.Telefone;
            }

            if (!string.IsNullOrEmpty(clienteDTO.CEP))
            {
                clienteExistente.CEP = clienteDTO.CEP;
            }

            if (!string.IsNullOrEmpty(clienteDTO.Pais))
            {
                clienteExistente.Pais = clienteDTO.Pais;
            }

            if (!string.IsNullOrEmpty(clienteDTO.Estado))
            {
                clienteExistente.Estado = clienteDTO.Estado;
            }

            if (!string.IsNullOrEmpty(clienteDTO.Cidade))
            {
                clienteExistente.Cidade = clienteDTO.Cidade;
            }

            if (!string.IsNullOrEmpty(clienteDTO.Bairro))
            {
                clienteExistente.Bairro = clienteDTO.Bairro;
            }

            if (!string.IsNullOrEmpty(clienteDTO.Logradouro))
            {
                clienteExistente.Logradouro = clienteDTO.Logradouro;
            }

            if (!string.IsNullOrEmpty(clienteDTO.Numero))
            {
                clienteExistente.Numero = clienteDTO.Numero;
            }

            if (!string.IsNullOrEmpty(clienteDTO.Complemento))
            {
                clienteExistente.Complemento = clienteDTO.Complemento;
            }
                
                    _context.Clientes.Update(clienteExistente);
                    _context.SaveChanges();

                    return NoContent();
            }
    

    [HttpGet("/pesquisa-por-id/{IdCliente}")] 
    public IActionResult ObterClientePorId(int IdCliente)
    {
        var cliente = _context.Clientes.Find(IdCliente);
        if (cliente == null)
        {
            return NotFound(); 
        }
        return Ok(cliente);
    }

    [HttpGet("/listar-todos")]
    public IActionResult ListarTodos()
    {
        return Ok(_context.Clientes.ToList());
    }
   
    [HttpDelete("/excluir-cliente/{IdCliente}")]
    public IActionResult Remover(int IdCliente)
    {
        var cliente = _context.Clientes.Find(IdCliente);
        if (cliente == null)
        {
            return NotFound();
        }

        _context.Clientes.Remove(cliente);
        _context.SaveChanges();

        return NoContent();
    }

    
}