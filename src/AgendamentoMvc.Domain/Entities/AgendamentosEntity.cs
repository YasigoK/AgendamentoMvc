using AgendamentoMvc.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendamentoMvc.Domain.Entities;

public class AgendamentosEntity : BaseEntity
{
    public string Nome { get; protected set; }
    public string Descricao { get; protected set; }
    public Guid FK_ID_Medico { get; protected set; }
    public Guid FK_ID_Paciente { get; protected set; }
    public DateTime DataAgendamento { get; protected set; }
    public DateTime DataCriacao { get; protected set; }
    public StatusEnum Status { get; protected set; }
    [ForeignKey("FK_ID_Medico")]
    public virtual MedicosEntity Medico { get; set; } //lazy loading

    [ForeignKey("FK_ID_Paciente")]
    public virtual PacientesEntity Paciente { get; set; }

    public AgendamentosEntity()
    {
        
    }

    public AgendamentosEntity(string nome, string descricao,Guid FK_1,Guid FK_2, DateTime agendamento)
    {
        Nome = nome;
        Descricao = descricao;
        FK_ID_Medico = FK_1;
        FK_ID_Paciente = FK_2;
        DataAgendamento = agendamento;
        DataCriacao = DateTime.Now;
        Status = (StatusEnum)1;
        
    }

    public void AtualizarAgendamento(string nome, string descricao, Guid FK_1, Guid FK_2, DateTime agendamento,StatusEnum status)
    {
        Nome = nome;
        Descricao = descricao;
        FK_ID_Medico = FK_1;
        FK_ID_Paciente = FK_2;
        DataAgendamento = agendamento;
        Status =status;
    }
}
