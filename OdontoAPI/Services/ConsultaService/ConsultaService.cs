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

        public async Task<ServiceResponse<List<ConsultaModel>>> DeleteConsulta(short id)
        {
            ServiceResponse<List<ConsultaModel>> serviceResponse = new ServiceResponse<List<ConsultaModel>>();
            try
            {
                ConsultaModel consulta = _context.Consultas.FirstOrDefault(x => x.Id == id);
                if (consulta == null)
                {
                    serviceResponse.Mensagem = "Id inválido para deleção de consulta!";
                    serviceResponse.Sucesso = false;
                }
                _context.Consultas.Remove(consulta); 
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Consultas.ToList();
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

        public async Task<ServiceResponse<ConsultaModel>> GetConsultaById(short id)
        {
            ServiceResponse<ConsultaModel> serviceResponse = new ServiceResponse<ConsultaModel>();
            try
            {
                ConsultaModel consulta = _context.Consultas.FirstOrDefault(x => x.Id == id);
                if (consulta == null)
                {
                    serviceResponse.Mensagem = "Não foi possível localizar uma consulta com o Id Informado.";
                    serviceResponse.Sucesso = false;
                }
                serviceResponse.Dados = consulta;
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

        public async Task<ServiceResponse<List<ConsultaModel>>> UpdateConsulta(ConsultaModel consultaEditada)
        {
            ServiceResponse<List<ConsultaModel>> serviceResponse = new ServiceResponse<List<ConsultaModel>>();
            try
            {
                ConsultaModel consulta = _context.Consultas.AsNoTracking().FirstOrDefault(x => x.Id == consultaEditada.Id);
                if (consulta == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informe os dados da consulta para atualização!";
                    serviceResponse.Sucesso = false;
                }
                _context.Consultas.Update(consulta);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Consultas.ToList();
            } catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }
    }
}
