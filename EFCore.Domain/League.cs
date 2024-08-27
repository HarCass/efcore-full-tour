namespace EFCore.Domain;

public class League : BaseDomainModel
{
    public required string Name { get; set; }
    public List<Team> Teams { get; set; } = new ();
}