using AgendamentoMvc.Business.Models;
using AgendamentoMvc.Business.Service.Interface;
using AgendamentoMvc.Data.Repository.Interface;
using AgendamentoMvc.Domain.Entities;
using System.Threading.Tasks;

namespace AgendamentoMvc.Business.Service;

public class PacienteService : IPacienteService
{
    private readonly IPacienteRepository _pacienteRepository;

    public PacienteService(IPacienteRepository pacienteRepository)
    {
        _pacienteRepository = pacienteRepository;
    }

    public async Task<List<PacienteModel>> ListarTodos()
    {
        var entity = await _pacienteRepository.ListarTodos();
        return entity.Select(x =>
        {
            return PacienteModel.Mapear(x);
        }).ToList();
    }
    public async Task<PacienteModel> ListarPorId(Guid id)
    {
        var entity = await _pacienteRepository.GetById(id);
        return PacienteModel.Mapear(entity);
    }
    public async Task<bool> CriarPaciente(PacienteModel paciente)
    {
        var novoPaciente = new PacientesEntity(
            paciente.Nome,
            paciente.Sobrenome,
            paciente.Cpf,
            paciente.DataNascimento
            );

        _pacienteRepository.CreatePaciente(novoPaciente);
        await _pacienteRepository.Commit();
        return true;
    }
    public async Task<bool> EditarPaciente(PacienteModel paciente)
    {
        var entity = await _pacienteRepository.GetById(paciente.Id);
        if (entity != null)
        {
            entity.AtualizarPaciente
                (
                    paciente.Nome,
                    paciente.Sobrenome,
                    paciente.Cpf,
                    paciente.DataNascimento
                );
            await _pacienteRepository.Commit();
            return true;
        }
        return false;
    }
    public async Task<bool> ExcluirPaciente(PacienteModel paciente)
    {
        var entity = await _pacienteRepository.GetById(paciente.Id);
        if (entity != null)
        {
            _pacienteRepository.DeletePaciente(entity);
            await _pacienteRepository.Commit();
            return true;
        }
        return false;

    }


}
