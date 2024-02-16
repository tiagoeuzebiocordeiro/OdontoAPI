using OdontoAPI.Models;

namespace OdontoAPI.Services.PacienteService
{
    public interface IPacienteInterface
    {
        Task<ServiceResponse<List<PacienteModel>>> GetPacientes();
        Task<ServiceResponse<List<PacienteModel>>> CreatePaciente(PacienteModel paciente);
        Task<ServiceResponse<PacienteModel>> GetPacienteById(short id);
        Task<ServiceResponse<List<PacienteModel>>> InativaStatusPaciente(short id);
        Task<ServiceResponse<List<PacienteModel>>> UpdateFuncionario(PacienteModel pacienteEditado);
        Task<ServiceResponse<List<PacienteModel>>> DeleteFuncionario(short id);

    }
}
