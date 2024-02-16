using OdontoAPI.Models;

namespace OdontoAPI.Services.ConsultaService
{
    public interface IConsultaInterface
    {
        Task<ServiceResponse<List<ConsultaModel>>> GetConsultas();
        Task<ServiceResponse<List<ConsultaModel>>> CreateConsulta(ConsultaModel consultaNova);
    }
}
