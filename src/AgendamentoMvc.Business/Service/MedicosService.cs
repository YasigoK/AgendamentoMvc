using AgendamentoMvc.Business.Models;
using AgendamentoMvc.Business.Service.Interface;
using AgendamentoMvc.Data.Repository.Interface;
using AgendamentoMvc.Domain.Entities;

namespace AgendamentoMvc.Business.Service;

public class MedicosService:IMedicosService
{
    private readonly IMedicoRepository _medicoRepository;

    public MedicosService(IMedicoRepository medicoRepository)
    {
        _medicoRepository = medicoRepository;
    }

    public async Task<List<MedicoModel>> ListarTodos(){
        var entity = await _medicoRepository.ListarTodos();
        return entity.Select(x =>
        {
            return MedicoModel.Mapear(x);
        }).ToList();
    }

    public async Task<MedicoModel> BuscarId(Guid id)
    {
        var entity = await _medicoRepository.GetById(id);
        return MedicoModel.Mapear(entity);
    }
    public async Task<bool> CriarMedico(MedicoModel model)
    {
        var novoMedico = new MedicosEntity(
            model.Nome,
            model.Sobrenome,
            model.Especialidade,
            model.Crm,
            model.Estado,
            model.Sexo,
            model.DataDeNascimento

            );
        await _medicoRepository.Create(novoMedico);
        await _medicoRepository.Commit();
        return true;

    }
    public async Task<bool> EditarMedico(MedicoModel model)
    {
        var entity = await _medicoRepository.GetById(model.Id);
        if (entity != null)
        {
            entity.AtualizarMedico(
                model.Nome,
                model.Sobrenome,
                model.Especialidade,
                model.Crm,
                model.Estado,
                model.Sexo,
                model.DataDeNascimento

                );

            await _medicoRepository.Commit();
            return true;
        }
        else
            return false;
    }
    public async Task<bool> DeletarMedico(MedicoModel model) 
    {
        var entity = await _medicoRepository.GetById(model.Id);
        if (entity != null)
        {
            _medicoRepository.Delete(entity);
            await _medicoRepository.Commit();
            return true;
        }
        else
            return false;
    }
}
