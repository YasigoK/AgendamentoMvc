using AgendamentoMvc.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace AgendamentoMvc.Business.Models;

public class PacienteModel : BaseEntity
{
    [Required(ErrorMessage = "Campo obrigaório, insira o nome do(a) paciente")]
    [StringLength(80,ErrorMessage ="Limite de 80 caracteres")]
    public string Nome { get;set; }

    [Required(ErrorMessage = "Campo obrigaório, insira o sobrenome do(a) paciente")]
    [StringLength(80,ErrorMessage ="Limite de 80 caracteres")]
    public string Sobrenome { get;set; }

    [Required(ErrorMessage = "Campo obrigaório, insira o cpf do(a) paciente")]
    [StringLength(14,ErrorMessage ="Limite de 14 caracteres")]
    public string Cpf { get;set; }

    [Required(ErrorMessage = "Campo obrigaório, insira a data de nascimento do(a) paciente")]
    [DataType(DataType.Date)]
    public DateOnly DataNascimento { get;set; }

    public string? NomeCompleto { get;set; }
    public PacienteModel()
    {
        
    }

    public static PacienteModel Mapear(PacientesEntity entity)
    {
        if (entity == null)
            return null;
        return new PacienteModel
        {
            Id = entity.Id,
            Nome = entity.Nome,
            Sobrenome = entity.Sobrenome,
            Cpf = entity.Cpf,
            DataNascimento = entity.DataNascimento,
        };
    }

}
