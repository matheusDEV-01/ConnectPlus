using ConnectPlus.WebAPI.DTO;
using ConnectPlus.WebAPI.Interfaces;
using ConnectPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConnectPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContatoController : ControllerBase
{
    private readonly IContatoRepository _contatoRepository;

    public ContatoController(IContatoRepository contatoRepository)
    {
        _contatoRepository = contatoRepository;
    }

    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_contatoRepository.Listar());
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    [HttpGet("{id}")]

    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_contatoRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }

    }

    [HttpPost]
    public IActionResult Cadastrar(ContatoDTO contato)
    {
        try
        {
            var novoContato = new Contato
            {
                Nome = contato.Nome,
                Formadecontato = contato.Formadecontato,
                IdTipoDeContato = contato.IdTipoDeContato,
                Tipodecontato = contato.Tipodecontato
            };

            
            if (contato.Imagem != null && contato.Imagem.Length > 0)
            {
                var extensao = Path.GetExtension(contato.Imagem.FileName);
                var nomeArquivo = $"{Guid.NewGuid()}{extensao}";

                var pastaRelativa = "wwwroot/imagens";
                var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), pastaRelativa);

                if (!Directory.Exists(caminhoPasta))
                    Directory.CreateDirectory(caminhoPasta);

                var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);

                using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    contato.Imagem.CopyTo(stream);
                }

               
                novoContato.Imagem = nomeArquivo;
            }

            
            _contatoRepository.Cadastrar(novoContato);

            return StatusCode(201, novoContato);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, ContatoDTO contato)
    {
        try
        {
            var contatoAtualizado = new Contato
            {
                Nome = contato.Nome,
                Formadecontato = contato.Formadecontato,
                IdTipoDeContato = contato.IdTipoDeContato,
                Tipodecontato = contato.Tipodecontato
            };
            _contatoRepository.Atualizar(id, contatoAtualizado);
            return NoContent();  // Retorna status code 204 para indicar que a operação foi bem-sucedida, mas não há conteúdo para retornar
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Deletar(Guid id)
    {
        try
        {
            _contatoRepository.Delete(id);
            return NoContent();  // Retorna status code 204 para indicar que a operação foi bem-sucedida, mas não há conteúdo para retornar
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
}
