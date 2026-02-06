using AgendamentoMvc.Business.Models;

namespace AgendamentoMvc.Business.Service.Interface;
public interface IAgendamentoService
{
    public Task<List<AgendamentoModel>> ListarTodos();
    public Task<AgendamentoModel> ListarPorId(Guid id);
    public Task<bool> CriarAgendamento(AgendamentoModel agenda);
    public Task<bool> EditarAgendamento(AgendamentoModel agenda);
    public Task<bool> ExcluirAgendamento(AgendamentoModel agenda);
}
