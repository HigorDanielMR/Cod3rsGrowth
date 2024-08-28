using Microsoft.AspNetCore.Mvc;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servicos.Servicos;

namespace Cod3rsGrowth.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrosController : ControllerBase
    {
        private readonly ServicoCarro _servicoCarro;
        private readonly ServicoVenda _servicoVenda;

        public CarrosController(ServicoCarro servicoCarro, ServicoVenda servicoVenda)
        {
            _servicoCarro = servicoCarro;
            _servicoVenda = servicoVenda;
        }

        [HttpGet]
        public IActionResult ObterTodos([FromQuery] FiltroCarro? filtro)
        {
            return Ok(_servicoCarro.ObterTodos(filtro));
        }   

        [HttpGet("{Id}")]
        public IActionResult ObterPorId(int Id)
        {
            var carroDesejado = _servicoCarro.ObterPorId(Id);
            return Ok(carroDesejado);
        }

        [HttpGet("Cores")]
        public IActionResult ObterDescricaoCores()
        {
            var cores = ObterEnums.ObterDescricaoEnums<Cores>();
            return Ok(cores);
        }

        [HttpGet("Marcas")]
        public IActionResult ObterDescricaoMarcas()
        {
            var marcas = ObterEnums.ObterDescricaoEnums<Marcas>();
            return Ok(marcas);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Carro carro)
        {
             var carroNovo = _servicoCarro.Criar(carro);
            return Created($"api/Carro/{carroNovo.Id}", carroNovo);

        }

        [HttpPatch("{Id}")]
        public IActionResult Editar([FromBody] Carro carro)
        {
            return Ok(_servicoCarro.Editar(carro));
        }

        [HttpDelete("{Id}")]
        public IActionResult Remover(int Id)
        {
            _servicoCarro.Remover(Id);
            return NoContent();
        }
    }
}
