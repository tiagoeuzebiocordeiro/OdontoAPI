using OdontoAPI.Models;

namespace OdontoAPI.Services.DentistaService
{
    public interface IDentistaInterface
    {
        Task<ServiceResponse<List<DentistaModel>>> GetDentistas();
        Task<ServiceResponse<List<DentistaModel>>> CreateDentista(DentistaModel dentistaNovo);
        Task<ServiceResponse<DentistaModel>> GetDentistaById(short id);
        Task<ServiceResponse<List<DentistaModel>>> UpdateDentista(DentistaModel dentistaEditado);
        Task<ServiceResponse<List<DentistaModel>>> DeleteDentista(short id);
        Task<ServiceResponse<List<DentistaModel>>> InativaDentista(short id);
    }
}
