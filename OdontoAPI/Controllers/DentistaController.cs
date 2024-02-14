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
    }
}
