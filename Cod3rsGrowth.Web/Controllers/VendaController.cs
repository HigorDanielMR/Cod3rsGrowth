using Microsoft.AspNetCore.Mvc;
using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servicos.Servicos;

namespace Cod3rsGrowth.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        private FiltroVenda _filtro = new();
        private readonly ServicoVenda _servico;

        public VendaController(ServicoVenda servico)
        {
            _servico = servico;
        }

        [HttpGet]
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

        [HttpGet("{Id}")]
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

        [HttpPost]
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

        [HttpPut("{Id}")]
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

        [HttpDelete("{Id}")]
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
