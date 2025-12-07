using Grimoire.Domain.Campaigns.Entities;
using Grimoire.Domain.Characters.Entities;
using Grimoire.Domain.Shared.Abstractions;
using Grimoire.Domain.Shared.ValueObjects;

namespace Grimoire.Domain.Users.Entities;

public class User : Entity
{
    public string Name { get; private set; }
    public Email Email { get; private set; }
    public string? ExternalId { get; private set; }

    #region Relations

    public ICollection<Campaign>  CampaignsMastered { get; private set; } = new List<Campaign>();
    public ICollection<Character>  Characters { get; private set; } = new List<Character>();

    #endregion
    
    protected User() { }

    public User(string name,
        string email,
        string? externalId = null)
    {
        Name = name;
        Email = Email.Create(email);
        ExternalId = externalId;
    }
}