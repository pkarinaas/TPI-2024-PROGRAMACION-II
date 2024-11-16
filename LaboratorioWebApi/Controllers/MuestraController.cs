using LaboratorioWebApi.Data.Entities;
using LaboratorioWebApi.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LaboratorioWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MuestraController : ControllerBase
    {
        private readonly IMuestrasRepository _muestrasRepository;
        public MuestraController(IMuestrasRepository muestrasRepository)
        {
            _muestrasRepository = muestrasRepository;
        }


        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_muestrasRepository.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(500, "Ha ocurrido un error interno.");
            }
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var found = _muestrasRepository.GetById(id);
                if (found == null)
                {
                    return NotFound($"Muestra Id: {id} no encontrada!");
                }
                return Ok(found);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno.");
            }
        }

        [HttpGet("GetByEstado/{idTipoEstado}")]
        public IActionResult GetByEstado(int idTipoEstado)
        {
            try
            {
                var found = _muestrasRepository.GetByEstado(idTipoEstado);
                if (!found.Any())
                {
                    return NotFound($"Muestra Estado: {idTipoEstado} no encontrada!");
                }
                return Ok(found);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno.");
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody] Muestras value)
        {
            try
            {
                if (_muestrasRepository.Create(value))
                    return Ok("Muestra registrada!");
                return StatusCode(400, "Datos de la muestra incorrectos!");

            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno.");
            }
        }


        [HttpPut("UpdateEstado/{id}")]
        public IActionResult UpdateEstado(int id, [FromBody] int nuevoEstado)
        {
            try
            {
                var result = _muestrasRepository.Update(id, nuevoEstado);

                if (!result)
                {
                    return NotFound($"No se encontró una muestra con ID: {id} para actualizar.");
                }

                return Ok("Estado de la muestra actualizado con éxito.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno.");
            }
        }
    }
}
