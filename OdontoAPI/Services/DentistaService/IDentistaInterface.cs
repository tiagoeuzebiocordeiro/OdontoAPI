using OdontoAPI.Models;

namespace OdontoAPI.Services.DentistaService
{
    public interface IDentistaInterface
    {
        Task<ServiceResponse<List<DentistaModel>>> GetDentistas();
    }
}
