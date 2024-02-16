using OdontoAPI.DataContext;
using OdontoAPI.Models;

namespace OdontoAPI.Services.PacienteService
{
    public class PacienteService : IPacienteInterface
    {
        private readonly ApplicationDbContext _context;
        public PacienteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<ServiceResponse<List<PacienteModel>>> CreatePaciente(PacienteModel paciente)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<PacienteModel>>> DeleteFuncionario(short id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<PacienteModel>> GetPacienteById(short id)
        {
            ServiceResponse<PacienteModel> serviceResponse = new ServiceResponse<PacienteModel>();
            try
            {
                PacienteModel paciente = _context.Pacientes.FirstOrDefault(x => x.Id == id);
                if (paciente == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Nenhum paciente foi encontrado com o Id fornecido!";
                    serviceResponse.Sucesso = false;
                }
                serviceResponse.Dados = paciente;
            } catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<PacienteModel>>> GetPacientes()
        {
            ServiceResponse<List<PacienteModel>> serviceResponse = new ServiceResponse<List<PacienteModel>>();
            try
            {
                serviceResponse.Dados = _context.Pacientes.ToList();
                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado foi encontrado no banco de dados!";
                }
            } catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public Task<ServiceResponse<List<PacienteModel>>> InativaStatusPaciente(short id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<PacienteModel>>> UpdateFuncionario(PacienteModel pacienteEditado)
        {
            throw new NotImplementedException();
        }
    }
}
