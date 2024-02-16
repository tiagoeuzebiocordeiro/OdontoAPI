using OdontoAPI.Models;

namespace OdontoAPI.Services.ConsultaService
{
    public interface IConsultaInterface
    {
        Task<ServiceResponse<List<ConsultaModel>>> GetConsultas();
        Task<ServiceResponse<List<ConsultaModel>>> CreateConsulta(ConsultaModel consultaNova);
        Task<ServiceResponse<ConsultaModel>> GetConsultaById(short id);
        Task<ServiceResponse<List<ConsultaModel>>> UpdateConsulta(ConsultaModel consultaEditada);
        Task<ServiceResponse<List<ConsultaModel>>> DeleteConsulta(short id);
    }
}
