namespace AgendamentoMvc.Domain.Entities;

public class PacientesEntity : BaseEntity
{
    public string Nome { get; protected set; }
    public string Sobrenome { get; protected set;  }
    public string Cpf { get; protected set; }
    public DateOnly DataNascimento { get; protected set; }

    public PacientesEntity()
    {
        
    }

    public PacientesEntity(string nome, string sobre, string cpf, DateOnly datal )
    {
        Nome = nome;
        Sobrenome = sobre;
        Cpf = cpf;
        DataNascimento = datal;
    }

    public void AtualizarPaciente(string nome, string sobre, string cpf, DateOnly datal)
    {
        Nome = nome;
        Sobrenome = sobre;
        Cpf = cpf;
        DataNascimento = datal;
    }
}
