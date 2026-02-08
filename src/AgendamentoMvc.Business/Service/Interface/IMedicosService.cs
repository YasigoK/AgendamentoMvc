using AgendamentoMvc.Business.Models;

namespace AgendamentoMvc.Business.Service.Interface;

public interface IMedicosService
{
    Task<List<MedicoModel>> ListarTodos();
    Task<MedicoModel> BuscarId(Guid id);
    Task<bool> CriarMedico(MedicoModel model);
    Task<bool> EditarMedico(MedicoModel model);
    Task<bool> DeletarMedico(MedicoModel model);
}
