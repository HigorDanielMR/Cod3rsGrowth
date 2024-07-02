using Microsoft.AspNetCore.Mvc;
using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servicos.Servicos;

namespace Cod3rsGrowth.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        private readonly ServicoVenda _servico;

        public VendaController(ServicoVenda servico)
        {
            _servico = servico;
        }

        [HttpGet]
        public IActionResult ObterTodasAsVendas([FromQuery] FiltroVenda? filtro)
        {
            return Ok(_servico.ObterTodos(filtro));
        }

        [HttpGet("{Id}")]
        public IActionResult ObterVendaPorId(int Id)
        {
            return Ok(_servico.ObterPorId(Id));
        }

        [HttpPost]
        public IActionResult CriarVenda([FromBody] Venda venda)
        {
            _servico.Criar(venda);
            return CreatedAtRoute(new { }, venda);
        }

        [HttpPut("{Id}")]
        public IActionResult EditarVenda(int Id, [FromBody] Venda venda)
        {
            _servico.Editar(venda);
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult RemoverVenda(int Id)
        {
            _servico.Remover(Id);
            return NoContent();
        }
    }
}
