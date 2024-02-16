using Microsoft.EntityFrameworkCore;
using OdontoAPI.DataContext;
using OdontoAPI.Models;
using System.Linq.Expressions;

namespace OdontoAPI.Services.PacienteService
{
    public class PacienteService : IPacienteInterface
    {
        private readonly ApplicationDbContext _context;
        public PacienteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<PacienteModel>>> CreatePaciente(PacienteModel paciente)
        {
            ServiceResponse<List<PacienteModel>> serviceResponse = new ServiceResponse<List<PacienteModel>>();
            try
            {
                if (paciente == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informe os dados do Paciente!";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }
                _context.Add(paciente);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Pacientes.ToList();
            } catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<PacienteModel>>> DeletePaciente(short id)
        {
            ServiceResponse<List<PacienteModel>> serviceResponse = new ServiceResponse<List<PacienteModel>>();
            try
            {
                PacienteModel paciente = _context.Pacientes.FirstOrDefault(x => x.Id == id);
                if (paciente == null)
                {
                    serviceResponse.Mensagem = "Não foi possível encontrar um paciente com o Id informado.";
                    serviceResponse.Sucesso = false;
                }
                _context.Pacientes.Remove(paciente);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Pacientes.ToList();
                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Você deletou com sucesso o único dado que o banco de dados tinha!";
                }
            } catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
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

        public async Task<ServiceResponse<List<PacienteModel>>> InativaStatusPaciente(short id)
        {
            ServiceResponse<List<PacienteModel>> serviceResponse = new ServiceResponse<List<PacienteModel>>();
            try
            {
                PacienteModel paciente = _context.Pacientes.FirstOrDefault(x => x.Id == id);
                if (paciente == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Paciente não localizado com o Id informado!";
                    serviceResponse.Sucesso = false;
                }
                _context.Pacientes.Update(paciente);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Pacientes.ToList();
            } catch (Exception ex)
            {
                serviceResponse.Mensagem= ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<PacienteModel>>> UpdatePaciente(PacienteModel pacienteEditado)
        {
            ServiceResponse<List<PacienteModel>> serviceResponse = new ServiceResponse<List<PacienteModel>>();
            try
            {
                PacienteModel paciente = _context.Pacientes.AsNoTracking().FirstOrDefault(x => x.Id == pacienteEditado.Id);
                if (paciente == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Paciente não foi encontrado com o Id informado!";
                    serviceResponse.Sucesso = false;
                }
                _context.Pacientes.Update(paciente);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Pacientes.ToList();
            } catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }
    }
}
