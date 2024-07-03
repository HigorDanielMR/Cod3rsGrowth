using Microsoft.AspNetCore.Mvc;
using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servicos.Servicos;

namespace Cod3rsGrowth.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarroController : ControllerBase
    {
        private readonly ServicoCarro _servico;

        public CarroController(ServicoCarro servico)
        {
            _servico = servico;
        }

        [HttpGet]
        public IActionResult ObterTodosCarros([FromQuery] FiltroCarro? filtro)
        {
            return Ok(_servico.ObterTodos(filtro));
        }

        [HttpGet("{Id}")]
        public IActionResult ObterCarroPorId(int Id)
        {
            return Ok(_servico.ObterPorId(Id));
        }

        [HttpPost]
        public IActionResult CriarCarro([FromBody] Carro carro)
        {
            return Ok(_servico.Criar(carro));
        }

        [HttpPut("{Id}")]
        public IActionResult EditarCarro(int Id, [FromBody] Carro carro)
        {
            _servico.Editar(carro);
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult RemoverCarro(int Id)
        {
            _servico.Remover(Id);
            return NoContent();
        }
    }
}
