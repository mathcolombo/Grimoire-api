namespace Grimoire.Domain.Shared.Abstractions;

public abstract class Entity
{
    public int Id { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public DateTime UpdatedAt { get; protected set; }
    public DateTime? DeletedAt { get; protected set; }
    public bool IsDeleted => DeletedAt != null;

    protected Entity() => CreatedAt = DateTime.Now;

    public void UpdateTimestamp() => UpdatedAt = DateTime.Now;
    
    public void SoftDelete()
    {
        DeletedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public void UndoDelete()
    {
        DeletedAt = null;
        UpdatedAt = DateTime.Now;
    }
}