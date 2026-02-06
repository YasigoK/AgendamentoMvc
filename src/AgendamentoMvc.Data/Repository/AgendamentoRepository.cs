using AgendamentoMvc.Data.Context;
using AgendamentoMvc.Data.Repository.Interface;
using AgendamentoMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgendamentoMvc.Data.Repository;

public class AgendamentoRepository : IAgendamentoRepository
{
    private readonly AgendamentoMvcDbContext _db;

    public AgendamentoRepository(AgendamentoMvcDbContext db)
    {
        _db = db;
    }

    public async Task<List<AgendamentosEntity>> GetAll()
    {
        return await _db.Agendamentos.AsNoTracking().ToListAsync();
    }
    public async Task<AgendamentosEntity> GetById(Guid id)
    {
        return await _db.Agendamentos.FirstOrDefaultAsync(x => x.Id == id);

    }
    public async Task Commit()
    {
        await _db.SaveChangesAsync();
    }
    public void CreateAgendamento(AgendamentosEntity agendamento)
    {
        _db.Agendamentos.Add(agendamento);
    }
    public void DeleteAgendamento(AgendamentosEntity agendamento)
    {
        _db.Agendamentos.Remove(agendamento);
    }
}
