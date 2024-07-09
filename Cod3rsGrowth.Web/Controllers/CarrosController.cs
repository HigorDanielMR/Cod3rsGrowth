using Microsoft.AspNetCore.Mvc;
using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servicos.Servicos;

namespace Cod3rsGrowth.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrosController : ControllerBase
    {
        private readonly ServicoCarro _servico;

        public CarrosController(ServicoCarro servico)
        {
            _servico = servico;
        }

        [HttpGet]
        public IActionResult ObterTodos([FromQuery] FiltroCarro? filtro)
        {
            return Ok(_servico.ObterTodos(filtro));
        }

        [HttpGet("{Id}")]
        public IActionResult ObterPorId(int Id)
        {
            return Ok(_servico.ObterPorId(Id));
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Carro carro)
        {
             var carroNovo = _servico.Criar(carro);
            return Created($"api/Carro/{carroNovo.Id}", carroNovo);

        }

        [HttpPatch("{Id}")]
        public IActionResult Editar([FromBody] Carro carro)
        {
            _servico.Editar(carro);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public IActionResult Remover(int Id)
        {
            _servico.Remover(Id);
            return NoContent();
        }
    }
}
