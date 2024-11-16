using LaboratorioWebApi.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LaboratorioWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController : ControllerBase
    {
        private readonly IEstadosRepository _estadosRepository;
        public EstadosController(IEstadosRepository estadosRepository)
        {
            _estadosRepository = estadosRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerEstados()
        {
            var estados = await _estadosRepository.ObtenerNombresEstadosAsync();
            return Ok(estados);
        }

    }
}
