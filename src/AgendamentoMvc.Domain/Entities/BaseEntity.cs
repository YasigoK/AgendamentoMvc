namespace AgendamentoMvc.Domain.Entities;

public abstract class BaseEntity
{
    public Guid Id {get;set;}

    protected BaseEntity()
    {
        
    }

    protected BaseEntity(Guid id)
    {
        Id = Guid.NewGuid();
    }
}
