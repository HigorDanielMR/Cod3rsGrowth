using Microsoft.AspNetCore.Mvc;
using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servicos.Servicos;

namespace Cod3rsGrowth.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private readonly ServicoVenda _servicoVenda;

        public VendasController(ServicoVenda servicoVenda)
        {
            _servicoVenda = servicoVenda;
        }

        [HttpGet]
        public IActionResult ObterTodos([FromQuery] FiltroVenda? filtro)
        {
            return Ok(_servicoVenda.ObterTodos(filtro));
        }

        [HttpGet("{Id}")]
        public IActionResult ObterPorId(int Id)
        {
            return Ok(_servicoVenda.ObterPorId(Id));
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Venda venda)
        {
            var vendaNova = _servicoVenda.Criar(venda);
            return Created($"api/Venda/{vendaNova.Id}", vendaNova);
        }

        [HttpPatch("{Id}")]
        public IActionResult Editar([FromBody] Venda venda)
        {
            return Ok(_servicoVenda.Editar(venda));
        }

        [HttpDelete("{Id}")]
        public IActionResult Remover(int Id)
        {
            _servicoVenda.Remover(Id);
            return NoContent();
        }
    }
}
