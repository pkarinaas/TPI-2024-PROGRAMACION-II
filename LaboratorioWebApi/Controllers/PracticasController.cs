using LaboratorioWebApi.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LaboratorioWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PracticasController : ControllerBase
    {

        private readonly IPracticaRepository _practicaRepository;
        public PracticasController(IPracticaRepository practicaRepository)
        {
            _practicaRepository = practicaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerPracticas()
        {
            var practicas = await _practicaRepository.ObtenerNombresPracticasActivasAsync();
            return Ok(practicas); // Esto devuelve un JSON con los nombres de las prácticas
        }


    }
}
