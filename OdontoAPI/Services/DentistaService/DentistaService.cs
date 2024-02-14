using OdontoAPI.DataContext;
using OdontoAPI.Models;

namespace OdontoAPI.Services.DentistaService
{
    public class DentistaService : IDentistaInterface
    {
        private readonly ApplicationDbContext _context;
        public DentistaService(ApplicationDbContext context) 
        { 
            _context = context;
        }

        public async Task<ServiceResponse<List<DentistaModel>>> GetDentistas()
        {
            ServiceResponse <List<DentistaModel>> serviceResponse = new ServiceResponse<List<DentistaModel>>();
            try 
            { 
                serviceResponse.dados = _context.Dentistas.ToList();
            }catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }
    }
}
