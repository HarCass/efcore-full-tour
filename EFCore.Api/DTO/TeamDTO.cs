using EFCore.Domain;

namespace EFCore.Api.DTO;

public class TeamDTO(Team team)
{
    public int Id { get; set; } = team.Id;
    public string Name { get; set; } = team.Name;
    public int LeagueId { get; set; } = team.LeagueId;
    public string League { get; set; } = team.League.Name;
    public int CoachId { get; set; } = team.CoachId;
    public string Coach { get; set; } = team.Coach.Name;
}