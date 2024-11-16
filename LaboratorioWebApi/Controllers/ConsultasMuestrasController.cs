using LaboratorioWebApi.Data.Extensions;
using LaboratorioWebApi.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LaboratorioWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasMuestrasController : ControllerBase
    {
        private readonly ILaboratorioDbContextProceduresRepository _laboratorioDbContextProceduresRepository;

        public ConsultasMuestrasController(ILaboratorioDbContextProceduresRepository laboratorioDbContextProceduresRepository)
        {
            _laboratorioDbContextProceduresRepository = laboratorioDbContextProceduresRepository;
        }



        [HttpGet("GetEstadoMuestras")]
        public async Task<IActionResult> GetEstadoMuestras([FromQuery] string estado)
        {
            try
            {
                var resultados = await _laboratorioDbContextProceduresRepository.sp_estado_muestrasAsync(estado);
                return Ok(resultados);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno.");
            }
        }


        [HttpGet("muestras-para-informar")]
        public async Task<IActionResult> GetMuestrasParaInformar(CancellationToken cancellationToken)
        {
            var returnValue = new OutputParameter<int>();
            var results = await _laboratorioDbContextProceduresRepository.sp_muestras_para_informarAsync
                (returnValue, cancellationToken);

            if (returnValue.Value != 0)
            {
                return StatusCode(500, "Ha ocurrido un error interno.");
            }

            return Ok(results);
        }
    }   
}
