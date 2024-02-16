using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OdontoAPI.Models;
using OdontoAPI.Services.DentistaService;

namespace OdontoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DentistaController : ControllerBase
    {
        private readonly IDentistaInterface _dentistaInterface;
        public DentistaController(IDentistaInterface dentistaInterface)
        {
            _dentistaInterface = dentistaInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<DentistaModel>>>> GetDentistas()
        {
            return Ok(await _dentistaInterface.GetDentistas());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<DentistaModel>>>> CreateDentista(DentistaModel dentista)
        {
            return Ok(await _dentistaInterface.CreateDentista(dentista));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<DentistaModel>>> GetDentistaById(short id)
        {
            return Ok(await _dentistaInterface.GetDentistaById(id));
        }

        [HttpPut("inativaStatusDentista/{id}")]
        public async Task<ActionResult<ServiceResponse<List<DentistaModel>>>> InativaStatusDentista (short id)
        {
            return Ok(await _dentistaInterface.InativaDentista(id));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<DentistaModel>>>> UpdateDentista(DentistaModel dentistaEditado)
        {
            return Ok(await _dentistaInterface.UpdateDentista(dentistaEditado));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<DentistaModel>>>> DeleteDentista(short id)
        {
            return Ok(await _dentistaInterface.DeleteDentista(id));
        }
    }
}
