using AgendamentoMvc.Domain.Entities;
using AgendamentoMvc.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace AgendamentoMvc.Business.Models;

public class MedicoModel : BaseEntity
{
    [Required(ErrorMessage ="Campo de nome obrigatório")]
    [StringLength(80,ErrorMessage ="Atingiu o limite de 80 caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Campo obrigatório, insira o sobrenome")]
    [StringLength(80,ErrorMessage = "Atingiu o limite de 80 caracteres")]
    public string Sobrenome { get; set; }

    [Required(ErrorMessage ="Campo obriatório, selecione uma especialidade")]
    public EspecialidadesEnum Especialidade { get; set; }

    [Required(ErrorMessage ="Campo obrigaório, insira o CRM do(a) médico(a)")]
    [Range(1,6, ErrorMessage ="Limite de 6 digitos")]
    public int Crm { get; set; }

    [Required(ErrorMessage = "Campo obrigaório, insira o código UF do estado")]
    [StringLength(2,ErrorMessage ="Limite de 2 caracteres")]
    public string Estado { get; set; }

    [Required(ErrorMessage = "Campo obrigaório, insira o o sexo do(a) médico(a)")]
    [StringLength(1)]
    public char Sexo { get; set; }

    [Required(ErrorMessage = "Campo obrigaório,insira a data de nascimento do(a) medico(a)")]
    [DataType(DataType.Date)]
    public DateOnly DataDeNascimento { get; set; }


    public static MedicoModel Mapear(MedicosEntity entity)
    {
        if (entity == null)
            return null;

        return new MedicoModel
        {
            Id = entity.Id,
            Nome = entity.Nome,
            Sobrenome = entity.Sobrenome,
            Especialidade = entity.Especialidade,
            Crm = entity.Crm,
            Estado = entity.Estado,
            Sexo = entity.Sexo,
            DataDeNascimento = entity.DataDeNascimento
        };
    }
}
