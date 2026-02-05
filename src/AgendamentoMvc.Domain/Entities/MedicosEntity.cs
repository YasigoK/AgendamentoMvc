using AgendamentoMvc.Domain.Enums;

namespace AgendamentoMvc.Domain.Entities;

public class MedicosEntity : BaseEntity
{
    public string Nome { get; protected set; }
    public string Sobrenome { get; protected set; }
    public EspecialidadesEnum Especialidade { get; protected set; }
    public int Crm { get; protected set; }
    public string Estado { get; protected set; }
    public char Sexo {  get; protected set; }
    public DateOnly DataDeNascimento { get; set; }
    public MedicosEntity()
    {
        
    }

    public MedicosEntity(string nome, string sobre,EspecialidadesEnum esp ,int crm, string est,char sexo, DateOnly dataN)
    {
        Nome = nome;
        Sobrenome = sobre;
        Especialidade = esp;
        Crm = crm;
        Estado = est;
        Sexo= sexo;
        DataDeNascimento = dataN; 
    }

    public void AtualizarMedico(string nome, string sobre, EspecialidadesEnum esp, int crm, string est, char sexo, DateOnly dataN)
    {
        Nome = nome;
        Sobrenome = sobre;
        Especialidade = esp;
        Crm = crm;
        Estado = est;
        Sexo = sexo;
        DataDeNascimento = dataN;
    }


}
