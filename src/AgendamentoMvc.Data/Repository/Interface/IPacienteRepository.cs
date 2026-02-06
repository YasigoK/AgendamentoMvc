using AgendamentoMvc.Domain.Entities;

namespace AgendamentoMvc.Data.Repository.Interface;

public interface IPacienteRepository
{
    Task<List<PacientesEntity>> ListarTodos();
    Task<PacientesEntity> GetById(Guid id);
    Task Commit();
    void CreatePaciente(PacientesEntity paciente);
    void DeletePaciente(PacientesEntity paciente);

}
