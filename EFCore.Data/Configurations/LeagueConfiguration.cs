using EFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Data.Configurations;
internal class LeagueConfiguration : IEntityTypeConfiguration<League>
{
    public void Configure(EntityTypeBuilder<League> builder)
    {
        builder.HasIndex(l => l.Name).IsUnique();

        var startDate = new DateTime(2024, 08, 27, 12, 0, 0, DateTimeKind.Local);
        builder.HasData(
            new League
            {
                Id = 1,
                Name = "Premier League",
                CreatedDate = startDate
            },
            new League
            {
                Id = 2,
                Name = "Bundesliga",
                CreatedDate = startDate
            });
    }
}
