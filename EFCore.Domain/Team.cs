namespace EFCore.Domain;

public class Team : BaseDomainModel
{
    public required string Name { get; set; }
    public int LeagueId { get; set; }
    public League League { get; set; }
    public int CoachId { get; set; }
    public Coach Coach { get; set; }
    public List<Match> HomeMatches { get; set; }
    public List<Match> AwayMatches { get; set; }
}