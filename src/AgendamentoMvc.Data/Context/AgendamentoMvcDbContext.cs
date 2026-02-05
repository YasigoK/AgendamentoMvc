using AgendamentoMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgendamentoMvc.Data.Context;

public class AgendamentoMvcDbContext :DbContext
{
    public AgendamentoMvcDbContext(DbContextOptions options) : base(options) { }

    public DbSet<MedicosEntity>Medicos{ get; set;}
    public DbSet<AgendamentosEntity>Agendamentos{ get;set;}
    public DbSet<PacientesEntity>Pacientes{ get; set;}


}
