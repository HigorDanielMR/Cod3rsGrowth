using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servicos.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace Cod3rsGrowth.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendaController : ControllerBase
    {
        private readonly ServicoVenda _servico;
        private FiltroVenda _filtro = new();
        public VendaController(ServicoVenda servico)
        {
            _servico = servico;
        }

        [HttpGet("Vendas")]
        public IActionResult ObterTodasAsVendas()
        {
            try
            {
                var vendas = _servico.ObterTodos(_filtro);

                return Ok(vendas);
            }
            catch(FluentValidation.ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Vendas/{Id}")]
        public IActionResult ObterVendaPorId(int Id)
        {
            try
            {
                var venda = _servico.ObterPorId(Id);

                if (venda == null)
                {
                    return NotFound();
                }

                return Ok(venda);
            }
            catch(FluentValidation.ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Vendas")]
        public IActionResult CriarVenda([FromBody] Venda venda)
        {
            try
            {
                if (venda == null)
                {
                    return BadRequest();
                }

                _servico.Criar(venda);
                return CreatedAtRoute(new { }, venda);
            }
            catch(FluentValidation.ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Vendas/{Id}")]
        public IActionResult EditarVenda(int Id, [FromBody] Venda venda)
        {
            try
            {
                if (venda == null || venda.Id != Id)
                {
                    return BadRequest();
                }

                _servico.Editar(venda);
                return NoContent();
            }
            catch(FluentValidation.ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Vendas/{Id}")]
        public IActionResult RemoverVenda(int Id)
        {
            try
            {
                var venda = _servico.ObterPorId(Id);
                if (venda == null)
                {
                    return NotFound();
                }

                _servico.Remover(Id);

                return NoContent();
            }
            catch(FluentValidation.ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
