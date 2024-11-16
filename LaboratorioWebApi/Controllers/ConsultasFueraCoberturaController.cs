using LaboratorioWebApi.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LaboratorioWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasFueraCoberturaController : ControllerBase
    {

        private readonly ILaboratorioDbContextProceduresRepository _laboratorioDbContextProceduresRepository;
        public ConsultasFueraCoberturaController(ILaboratorioDbContextProceduresRepository laboratorioDbContextProceduresRepository)
        {
            _laboratorioDbContextProceduresRepository = laboratorioDbContextProceduresRepository;
        }

        [HttpGet("fuera-cobertura")]
        public async Task<IActionResult> GetPracticasFueraCobertura()
        {
            try
            {
                var resultados = await _laboratorioDbContextProceduresRepository.GetPracticasFueraCoberturaAsync();
                return Ok(resultados);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener prácticas fuera de cobertura: {ex.Message}");
            }
        }

    }
}
