using AgendamentoMvc.Business.Models;

namespace AgendamentoMvc.Business.Service.Interface;

public interface IPacienteService
{
    public Task<List<PacienteModel>> ListarTodos();
    public Task<PacienteModel> ListarPorId(Guid id);
    public Task<bool> CriarPaciente(PacienteModel paciente);
    public Task<bool> EditarPaciente(PacienteModel paciente);
    public Task<bool> ExcluirPaciente(PacienteModel paciente);

}
