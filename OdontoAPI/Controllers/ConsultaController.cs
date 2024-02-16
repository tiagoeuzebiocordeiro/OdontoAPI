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

        [HttpPost]
        public async Task<ActionResult<List<ConsultaModel>>> CreateConsulta(ConsultaModel consultaNova)
        {
            return Ok(await _consultaInterface.CreateConsulta(consultaNova));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ConsultaModel>> GetConsultaById(short id)
        {
            return Ok(await _consultaInterface.GetConsultaById(id));
        }

        [HttpPut]
        public async Task<ActionResult<List<ConsultaModel>>> UpdateConsulta(ConsultaModel consultaAtualizada)
        {
            return Ok(await _consultaInterface.UpdateConsulta(consultaAtualizada));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ConsultaModel>>> DeleteConsulta(short id)
        {
            return Ok(await _consultaInterface.DeleteConsulta(id));
        }
    }
}
