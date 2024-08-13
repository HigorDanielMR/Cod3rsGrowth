using Microsoft.AspNetCore.Mvc;
using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servicos.Servicos;

namespace Cod3rsGrowth.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private readonly ServicoVenda _servico;

        public VendasController(ServicoVenda servico)
        {
            _servico = servico;
        }

        [HttpGet]
        public IActionResult ObterTodos([FromQuery] FiltroVenda? filtro)
        {
            return Ok(_servico.ObterTodos(filtro));
        }

        [HttpGet("{Id}")]
        public IActionResult ObterPorId(int Id)
        {
            return Ok(_servico.ObterPorId(Id));
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Venda venda)
        {
            var vendaNova = _servico.Criar(venda);
            return Created($"api/Venda/{vendaNova.Id}", vendaNova);
        }

        [HttpPatch("{Id}")]
        public IActionResult Editar([FromBody] Venda venda)
        {
            return Ok(_servico.Editar(venda));
        }

        [HttpDelete("{Id}")]
        public IActionResult Remover(int Id)
        {
            _servico.Remover(Id);
            return NoContent();
        }
    }
}
