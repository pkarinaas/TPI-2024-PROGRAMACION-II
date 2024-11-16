using LaboratorioWebApi.Data.Entities;
using LaboratorioWebApi.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LaboratorioWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallesMuestrasController : ControllerBase
    {
        private readonly IDetallesMuestrasRepository _detallesMuestrasRepository;

        public DetallesMuestrasController(IDetallesMuestrasRepository detallesMuestrasRepository)
        {
            _detallesMuestrasRepository = detallesMuestrasRepository;
        }

        [HttpGet("GetDetallesMuestras")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_detallesMuestrasRepository.GetDetallesMuestras());
            }
            catch (Exception)
            {

                return StatusCode(500, "Ha ocurrido un error interno.");
            }
        }

        [HttpGet("detalles")]
        public async Task<IActionResult> GetDetallesMuestras()
        {
            try
            {
                var resultados = await _detallesMuestrasRepository.GetDetallesMuestrasAsync();
                return Ok(resultados);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los detalles de muestras: {ex.Message}");
            }
        }

        [HttpPost("detalles")]
        public IActionResult CreateDetalleMuestra([FromBody] DetallesMuestras detalle)
        {
            if (detalle == null)
            {
                return BadRequest("El detalle de muestra no puede ser nulo.");
            }

            var creado = _detallesMuestrasRepository.CreateDetalleMuestra(detalle);

            if (!creado)
            {
                return StatusCode(500, "Error al crear el detalle de muestra.");
            }

            return CreatedAtAction(nameof(CreateDetalleMuestra), new { id = detalle.IdDetallesMuestras }, detalle);
        }
    }


    //[HttpPut("detalles/{id}")]
    //public async Task<IActionResult> UpdateDetallesMuestras(int id, [FromBody] DetallesMuestras muestra)
    //{
    //    if (id != muestra.IdDetallesMuestras)
    //    {
    //        return BadRequest("El ID en la URL no coincide con el ID del objeto.");
    //    }

    //    var actualizado = await _detallesMuestrasRepository.UpdateDetallesMuestrasAsync(muestra);

    //    if (!actualizado)
    //    {
    //        return NotFound("No se encontró la muestra especificada.");
    //    }

    //    return NoContent();
    //}


}
