using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OdontoAPI.Models;
using OdontoAPI.Services.ConsultaService;

namespace OdontoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaInterface _consultaInterface;
        public ConsultaController(IConsultaInterface consultaInterface)
        {
            _consultaInterface = consultaInterface;
        }

        [HttpGet]
        public async Task<ActionResult<List<ConsultaModel>>> GetConsultas()
        {
            return Ok(await _consultaInterface.GetConsultas());
        }

    }
}
