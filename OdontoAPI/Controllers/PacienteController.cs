using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OdontoAPI.Models;
using OdontoAPI.Services.PacienteService;

namespace OdontoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteInterface _pacienteInterface;
        public PacienteController(IPacienteInterface pacienteInterface)
        {
            _pacienteInterface = pacienteInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<PacienteModel>>>> GetPacientes()
        {
            return Ok(await _pacienteInterface.GetPacientes());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PacienteModel>> GetPacienteById(short id)
        {
            return Ok(await _pacienteInterface.GetPacienteById(id));
        }
    }
}
