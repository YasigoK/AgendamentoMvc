using AgendamentoMvc.Domain.Entities;

namespace AgendamentoMvc.Data.Repository.Interface;

public interface IAgendamentoRepository
{
    public Task<List<AgendamentosEntity>> GetAll();
    public Task<AgendamentosEntity> GetById(Guid id);
    public Task Commit();
    public void CreateAgendamento(AgendamentosEntity agendamento);
    public void DeleteAgendamento(AgendamentosEntity agendamento);
}
