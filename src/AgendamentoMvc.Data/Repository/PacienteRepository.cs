using AgendamentoMvc.Data.Context;
using AgendamentoMvc.Data.Repository.Interface;
using AgendamentoMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgendamentoMvc.Data.Repository;

public class PacienteRepository : IPacienteRepository
{
    private readonly AgendamentoMvcDbContext _db;

    public PacienteRepository(AgendamentoMvcDbContext db)
    {
        _db = db;
    }

    public async Task<List<PacientesEntity>> ListarTodos()
    {
        return await _db.Pacientes.AsNoTracking().ToListAsync();
    }
    public async Task<PacientesEntity> GetById(Guid id)
    {
        return await _db.Pacientes.FirstOrDefaultAsync(x=>x.Id == id);
    }
    public async Task Commit()
    {
        await _db.SaveChangesAsync();

    }
    public void CreatePaciente(PacientesEntity paciente)
    {
        _db.Pacientes.Add(paciente);
    }
    public void DeletePaciente(PacientesEntity paciente)
    {
        _db.Pacientes.Remove(paciente);
    }
}
