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

        public async Task<ServiceResponse<List<DentistaModel>>> CreateDentista(DentistaModel dentistaNovo)
        {
            ServiceResponse<List<DentistaModel>> serviceResponse = new ServiceResponse<List<DentistaModel>>();

            if (dentistaNovo == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Informe os dados do dentista!";
                serviceResponse.Sucesso = false;
                return serviceResponse;
            }
            try
            {
                _context.Add(dentistaNovo);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Dentistas.ToList();
            } catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public Task<ServiceResponse<List<DentistaModel>>> DeleteDentista(short id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<DentistaModel>> GetDentistaById(short id)
        {
            ServiceResponse<DentistaModel> serviceResponse = new ServiceResponse<DentistaModel>();

            try
            {
                DentistaModel dentista = _context.Dentistas.FirstOrDefault(x => x.Id == id);
                if (dentista == null)
                {
                    serviceResponse.Mensagem = "Não foi possível encontrar um dentista com o Id informado.";
                    serviceResponse.Sucesso= false;
                }

                serviceResponse.Dados = dentista;

            } catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<DentistaModel>>> GetDentistas()
        {
            ServiceResponse<List<DentistaModel>> serviceResponse = new ServiceResponse<List<DentistaModel>>();
            try
            {
                serviceResponse.Dados = _context.Dentistas.ToList();
                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado foi localizado no banco de dados.";
                }
            }catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<DentistaModel>>> InativaDentista(short id)
        {
            ServiceResponse<List<DentistaModel>> serviceResponse = new ServiceResponse<List<DentistaModel>>();
            try
            {
                DentistaModel dentista = _context.Dentistas.FirstOrDefault(x => x.Id == id);
                if (dentista == null)
                {
                    serviceResponse.Mensagem = "Não foi possível encontrar um dentista com o Id informado.";
                    serviceResponse.Sucesso = false;
                }

                dentista.Status = false;
                
                _context.Dentistas.Update(dentista);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Dentistas.ToList();

            } catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;

        }

        public Task<ServiceResponse<List<DentistaModel>>> UpdateDentista(DentistaModel dentistaEditado)
        {
            throw new NotImplementedException();
        }
    }
}
