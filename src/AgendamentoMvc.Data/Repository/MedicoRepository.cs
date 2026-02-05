using AgendamentoMvc.Data.Context;
using AgendamentoMvc.Data.Repository.Interface;
using AgendamentoMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgendamentoMvc.Data.Repository;

public class  MedicoRepository : IMedicoRepository
{
    private readonly AgendamentoMvcDbContext _db;

    public MedicoRepository(AgendamentoMvcDbContext db)
    {
        _db = db;
    }

    public async Task<List<MedicosEntity>> ListarTodos(){
        return await _db.Medicos.AsNoTracking().ToListAsync();
    }

    public async Task<MedicosEntity> GetById(Guid id){
        return await _db.Medicos.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task Create(MedicosEntity medicos){
        await _db.Medicos.AddAsync(medicos);
    }

    public async Task Commit(){
        await _db.SaveChangesAsync();
    }

    public void Delete(MedicosEntity medico)
    {
        _db.Remove(medico);
    }

}
