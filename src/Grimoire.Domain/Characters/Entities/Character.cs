using Grimoire.Domain.Campaigns.Entities;
using Grimoire.Domain.Shared.Abstractions;
using Grimoire.Domain.Users.Entities;

namespace Grimoire.Domain.Characters.Entities;

public class Character : Entity
{
    public string Name { get; private set; }
    public string System { get; private set; }
    public string Class { get; private set; }
    public int Level { get; private set; }
    public string Bio { get; private set; }
    public Dictionary<string, int> Attributes { get; private set; } = new();
    public int PlayerId { get; private set; }
    public int? CampaignId { get; private set; }
    
    #region Relations
    
    public User Player { get; private set; } = null!;

    public Campaign? Campaign { get; private set; }
    
    #endregion

    protected Character() { }

    public Character(string name,
        string system,
        string @class,
        int level,
        int playerId)
    {
        Name = name;
        System = system;
        Class = @class;
        Level = level;
        PlayerId = playerId;
        Bio = string.Empty;
    }

    public void SetAttribute(string key, int value) => Attributes[key] = value;
    
    public void JoinCampaign(int campaignId) => CampaignId = campaignId;
}