using AgendamentoMvc.Domain.Entities;

namespace AgendamentoMvc.Data.Repository.Interface;

public interface IMedicoRepository
{
    Task<List<MedicosEntity>> ListarTodos();
    Task<MedicosEntity> GetById(Guid id);
    Task Create(MedicosEntity medicos);
    void Delete(MedicosEntity medicos);
    Task Commit();
}
