using EFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Data.Configurations;

public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.HasIndex(t => t.Name).IsUnique();

        builder
            .HasMany(t => t.AwayMatches)
            .WithOne(m => m.AwayTeam)
            .HasForeignKey(m => m.AwayTeamId);
        builder
            .HasMany(t => t.HomeMatches)
            .WithOne(m => m.HomeTeam)
            .HasForeignKey(m=> m.HomeTeamId);

        var startDate = new DateTime(2024, 08, 27, 12, 0, 0, DateTimeKind.Local);
        builder.HasData(
            new Team
            {
                Id = 1,
                Name = "Crystal Palace",
                CoachId = 1,
                LeagueId = 1,
                CreatedDate = startDate,
            },
            new Team
            {
                Id = 2,
                Name = "Arsenal",
                CoachId = 2,
                LeagueId = 1,
                CreatedDate = startDate,
            },
            new Team
            {
                Id = 3,
                Name = "Manchester United",
                CoachId = 3,
                LeagueId = 1,
                CreatedDate = startDate,
            },
            new Team
            {
                Id = 4,
                Name = "Manchester City",
                CoachId = 4,
                LeagueId = 1,
                CreatedDate = startDate,
            },
            new Team
            {
                Id = 5,
                Name = "Chelsea",
                CoachId = 5,
                LeagueId = 1,
                CreatedDate = startDate,
            },
            new Team
            {
                Id = 6,
                Name = "Liverpool",
                CoachId = 6,
                LeagueId = 1,
                CreatedDate = startDate,
            },
            new Team
            {
                Id = 7,
                Name = "Tottenham",
                CoachId = 7,
                LeagueId = 1,
                CreatedDate = startDate,
            },
            new Team
            {
                Id = 8,
                Name = "Aston Villa",
                CoachId = 8,
                LeagueId = 1,
                CreatedDate = startDate,
            },
            new Team
            {
                Id = 9,
                Name = "Newcastle United",
                CoachId = 9,
                LeagueId = 1,
                CreatedDate = startDate,
            },
            new Team
            {
                Id = 10,
                Name = "Leicester City",
                CoachId = 10,
                LeagueId = 1,
                CreatedDate = startDate,
            });
    }
}