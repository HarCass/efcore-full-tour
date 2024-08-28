using EFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Data.Configurations;
internal class CoachConfiguration : IEntityTypeConfiguration<Coach>
{
    public void Configure(EntityTypeBuilder<Coach> builder)
    {
        builder.Property(c => c.Version).IsConcurrencyToken();

        var startDate = new DateTime(2024, 08, 27, 12, 0, 0, DateTimeKind.Local);
        builder.HasData(
            new Coach
            {
                Id = 1,
                Name = "Oliver Glasner",
                CreatedDate = startDate,
            },
            new Coach
            {
                Id = 2,
                Name = "Mikel Arteta",
                CreatedDate = startDate,
            },
            new Coach
            {
                Id = 3,
                Name = "Erik ten Hag",
                CreatedDate = startDate,
            },
            new Coach
            {
                Id = 4,
                Name = "Pep Guardiola",
                CreatedDate = startDate,
            },
            new Coach
            {
                Id = 5,
                Name = "Enzo Maresca",
                CreatedDate = startDate,
            },
            new Coach
            {
                Id = 6,
                Name = "Arne Slot",
                CreatedDate = startDate,
            },
            new Coach
            {
                Id = 7,
                Name = "Ange Postecoglou",
                CreatedDate = startDate,
            },
            new Coach
            {
                Id = 8,
                Name = "Unai Emery",
                CreatedDate = startDate,
            },
            new Coach
            {
                Id = 9,
                Name = "Eddie Howe",
                CreatedDate = startDate,
            },
            new Coach
            {
                Id = 10,
                Name = "Steve Cooper",
                CreatedDate = startDate,
            });
    }
}
