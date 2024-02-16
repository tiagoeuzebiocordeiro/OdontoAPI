using Microsoft.EntityFrameworkCore;
using OdontoAPI.DataContext;
using OdontoAPI.Models;

namespace OdontoAPI.Services.ConsultaService
{
    public class ConsultaService : IConsultaInterface
    {
        private readonly ApplicationDbContext _context;

        public ConsultaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<ConsultaModel>>> CreateConsulta(ConsultaModel consultaNova)
        {
            ServiceResponse<List<ConsultaModel>> serviceResponse = new ServiceResponse<List<ConsultaModel>>();
            try
            {
                if (consultaNova == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informe os dados!";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }
                _context.Consultas.Add(consultaNova);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Consultas.ToList();
            } catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ConsultaModel>>> GetConsultas()
        {
            ServiceResponse<List<ConsultaModel>> serviceResponse = new ServiceResponse<List<ConsultaModel>>();
            try
            {
                serviceResponse.Dados = _context.Consultas.ToList();
                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Nenhum dado foi encontrado no banco de dados!";
                    serviceResponse.Sucesso = false;
                }

            } catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }
    }
}
