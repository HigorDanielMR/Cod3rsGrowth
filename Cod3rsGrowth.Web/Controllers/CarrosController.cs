using Microsoft.AspNetCore.Mvc;
using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Servicos.Servicos;
using System.Net.Http;
using Cod3rsGrowth.Servicos.ExtensaoDeEnum;

namespace Cod3rsGrowth.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrosController : ControllerBase
    {
        private readonly ServicoCarro _servico;
        private readonly ServicoVenda _servicoVenda;

        public CarrosController(ServicoCarro servico, ServicoVenda servicoVenda)
        {
            _servico = servico;
            _servicoVenda = servicoVenda;
        }

        [HttpGet]
        public IActionResult ObterTodos([FromQuery] FiltroCarro? filtro)
        {
            return Ok(_servico.ObterTodos(filtro));
        }

        [HttpGet("Disponiveis")]
        public IActionResult ObterTodos()
        {
            var vendas = _servicoVenda.ObterTodos();
            var carros = _servico.ObterTodos();
            List<Carro> carrosDisponiveis = new List<Carro>();

            vendas.ForEach(x => {
                carros = carros
                .Where(c => c.Id != x.IdDoCarroVendido)
                .ToList();
            });

            return Ok(carros);
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

        [HttpGet("Cor")]
        public IActionResult ObterDescricaoEnum(Cores cor)
        {
            var description = cor.ObterDescricaoEnum();
            return Ok(new { description });
        }

        [HttpGet("Marca")]
        public IActionResult ObterDescricaoEnum(Marcas marca)
        {
            var description = marca.ObterDescricaoEnum();
            return Ok(new { description });
        }
    }
}
