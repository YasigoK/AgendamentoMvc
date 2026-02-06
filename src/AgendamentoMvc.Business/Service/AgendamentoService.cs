using AgendamentoMvc.Business.Models;
using AgendamentoMvc.Business.Service.Interface;
using AgendamentoMvc.Data.Repository.Interface;
using AgendamentoMvc.Domain.Entities;
using System.Net.NetworkInformation;

namespace AgendamentoMvc.Business.Service;

public class AgendamentoService : IAgendamentoService
{
    private readonly IAgendamentoRepository _agendamentoRepository;

    public AgendamentoService(IAgendamentoRepository agendamentoRepository)
    {
        _agendamentoRepository = agendamentoRepository;
    }

    public async Task<List<AgendamentoModel>> ListarTodos()
    {
        var entity = await _agendamentoRepository.GetAll();
        return entity.Select(x =>
        {
            return AgendamentoModel.Mapear(x);
        }).ToList();
    }
    public async Task<AgendamentoModel> ListarPorId(Guid id)
    {
        var entity = await _agendamentoRepository.GetById(id);
        return AgendamentoModel.Mapear(entity);
    }
    public async Task<bool> CriarAgendamento(AgendamentoModel agenda)
    {
        var novoAgendamento = new AgendamentosEntity(
            agenda.Nome,
            agenda.Descricao,
            agenda.FK_ID_Medico,
            agenda.FK_ID_Paciente,
            agenda.DataAgendamento
            );
        _agendamentoRepository.CreateAgendamento(novoAgendamento);
        await _agendamentoRepository.Commit();
        return true;

    }
    public async Task<bool> EditarAgendamento(AgendamentoModel agenda)
    {
        var entity = await _agendamentoRepository.GetById(agenda.Id);
        if (entity != null)
        {
            entity.AtualizarAgendamento(
                agenda.Nome,
                agenda.Descricao,
                agenda.FK_ID_Medico,
                agenda.FK_ID_Paciente,
                agenda.DataAgendamento,
                agenda.Status
                );

            await _agendamentoRepository.Commit();
            return true;
        }
        
        return false;
    }
    public async Task<bool> ExcluirAgendamento(AgendamentoModel agenda)
    {
        var entity = await _agendamentoRepository.GetById(agenda.Id);
        if (entity != null)
        {
            _agendamentoRepository.DeleteAgendamento(entity);
            await _agendamentoRepository.Commit();
            return true;
        }
        return false;
    }

}
