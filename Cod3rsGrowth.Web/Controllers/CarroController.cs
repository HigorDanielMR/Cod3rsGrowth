using Microsoft.AspNetCore.Mvc;
using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servicos.Servicos;

namespace Cod3rsGrowth.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarroController : ControllerBase
    {
        private FiltroCarro _filtro = new();
        private readonly ServicoCarro _servico;

        public CarroController(ServicoCarro servico)
        {
            _servico = servico;
        }

        [HttpGet]
        public IActionResult ObterTodosCarros()
        {
            try
            {
                var carros = _servico.ObterTodos(_filtro);
                return Ok(carros);
            }
            catch (FluentValidation.ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet ("{Id}")]
        public IActionResult ObterCarroPorId(int Id)
        {
            try
            {
                var carro = _servico.ObterPorId(Id);

                if (carro == null)
                {
                    return NotFound();
                }

                return Ok(carro);
            }
            catch(FluentValidation.ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CriarCarro([FromBody]Carro carro)
        {
            try
            {
                if (carro == null)
                {
                    return BadRequest();
                }

                _servico.Criar(carro);
                return CreatedAtRoute(new { }, carro);
            }
            catch(FluentValidation.ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id}")]
        public IActionResult EditarCarro(int Id, [FromBody]Carro carro)
        {
            try
            {
                if(carro == null ||  carro.Id != Id)
                {
                    return BadRequest();
                }

                _servico.Editar(carro);
                return NoContent();
            }
            catch(FluentValidation.ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        public IActionResult RemoverCarro(int Id)
        {
            try
            {
                var carro = _servico.ObterPorId(Id);

                if(carro == null)
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
