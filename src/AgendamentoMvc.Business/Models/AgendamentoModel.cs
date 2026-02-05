using AgendamentoMvc.Domain.Entities;
using AgendamentoMvc.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace AgendamentoMvc.Business.Models;

public class AgendamentoModel : BaseEntity
{
    [Required(ErrorMessage = "Campo obrigatório, insira o nome do agendamento")]
    [StringLength(80,ErrorMessage ="Limite de 80 caracteres")]
    public string Nome { get;  set; }

    [Required(ErrorMessage = "Campo obrigatório, insira a descrição do agendamento")]
    [StringLength(200,ErrorMessage ="Limite de 200 caracteres")]
    public string Descricao { get;  set; }

    [Required(ErrorMessage = "Campo obrigatório, selecione o nome do médico")]
    public Guid FK_ID_Medico { get;  set; }

    [Required(ErrorMessage = "Campo obrigatório, selecione o nome do paciente")]
    public Guid FK_ID_Paciente { get;  set; }

    [Required(ErrorMessage = "Campo obrigatório, selecione a data do agendamento")]
    [DataType(DataType.DateTime)]
    public DateTime DataAgendamento { get;  set; }
    public DateTime DataCriacao { get;  set; }
    public StatusEnum Status { get; set; }

    public AgendamentoModel()
    {
        
    }

    public static AgendamentoModel Mapear(AgendamentosEntity entity)
    {
        if (entity == null)
            return null;

        return new AgendamentoModel
        {
            Id = entity.Id,
            Nome = entity.Nome ,
            Descricao = entity.Descricao ,
            FK_ID_Medico = entity.FK_ID_Medico ,
            FK_ID_Paciente = entity.FK_ID_Paciente ,
            DataAgendamento = entity.DataAgendamento ,
            DataCriacao = entity.DataCriacao ,
            Status = entity.Status ,
        };
    }

}
