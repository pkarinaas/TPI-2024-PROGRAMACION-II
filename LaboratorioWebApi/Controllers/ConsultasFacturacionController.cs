using LaboratorioWebApi.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LaboratorioWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasFacturacionController : ControllerBase
    {
        private readonly ILaboratorioDbContextProceduresRepository _laboratorioDbContextProceduresRepository;
        public ConsultasFacturacionController(ILaboratorioDbContextProceduresRepository laboratorioDbContextProceduresRepository)
        {
            _laboratorioDbContextProceduresRepository = laboratorioDbContextProceduresRepository;
        }


        [HttpGet("GetCostoDerivPorLaboratorio")]
        public async Task<IActionResult> GetCostoDerivPorLaboratorio([FromQuery] DateTime fechaDesde, [FromQuery] DateTime fechaHasta)
        {
            try
            {
                var resultados = await _laboratorioDbContextProceduresRepository.sp_costo_deriv_por_laboratorioAsync(fechaDesde, fechaHasta);
                return Ok(resultados);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno.");
            }
        }

        [HttpGet("GetCostoTotalDerivaciones")]
        public async Task<IActionResult> GetCostoTotalDerivaciones([FromQuery] DateTime fechaDesde, [FromQuery] DateTime fechaHasta)
        {
            try
            {
                var resultados = await _laboratorioDbContextProceduresRepository.sp_costo_total_derivacionesAsync(fechaDesde, fechaHasta);
                return Ok(resultados);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno.");
            }
        }
    }

}
