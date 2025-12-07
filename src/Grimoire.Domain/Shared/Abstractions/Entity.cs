namespace Grimoire.Domain.Shared.Abstractions;

public abstract class Entity
{
    public int Id { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public DateTime UpdatedAt { get; protected set; }

    protected Entity() => CreatedAt = DateTime.Now;

    public void UpdateTimestamp() => UpdatedAt = DateTime.Now;
}