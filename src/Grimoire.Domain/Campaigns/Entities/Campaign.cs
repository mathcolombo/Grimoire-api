using Grimoire.Domain.Characters.Entities;
using Grimoire.Domain.Shared.Abstractions;
using Grimoire.Domain.Users.Entities;

namespace Grimoire.Domain.Campaigns.Entities;

public class Campaign : Entity
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string System { get; private set; }
    public int DungeonMasterId { get; private set; }

    #region Relations

    public User DungeonMaster { get; private set; } = null!;
    public ICollection<Character> Characters { get; private set; } = new List<Character>();

    #endregion
    
    protected Campaign() { }

    public Campaign(string title, string description, string system, int dungeonMasterId)
    {
        Title = title;
        Description = description;
        System = system;
        DungeonMasterId = dungeonMasterId;
    }
}