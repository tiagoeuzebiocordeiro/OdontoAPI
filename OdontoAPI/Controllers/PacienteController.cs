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

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<PacienteModel>>>> CreatePaciente(PacienteModel paciente)
        {
            return Ok(await _pacienteInterface.CreatePaciente(paciente));
        }

        [HttpPut("inativaStatusPaciente/{id}")]
        public async Task<ActionResult<ServiceResponse<List<PacienteModel>>>> InativaPaciente(short id)
        {
            return Ok(await _pacienteInterface.InativaStatusPaciente(id));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<PacienteModel>>>> UpdatePaciente(PacienteModel pacienteEditado)
        {
            return Ok(await _pacienteInterface.UpdatePaciente(pacienteEditado));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<PacienteModel>>>> DeletePaciente(short id)
        {
            return Ok(await _pacienteInterface.DeletePaciente(id));
        }

    }
}
