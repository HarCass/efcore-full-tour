using EFCore.Data;
using EFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder()
    .AddJsonFile("env.json", false, true)
    .Build();

await using var context = new FootballLeagueDbContext(new DbContextOptions<FootballLeagueDbContext>(), config["ConnectionString"]);

//await GetLeagueRelations();

//await GetTeams();

//await GetTeam();

//await GetFilteredTeams();

//await GetFilteredTeamsViaSQL();

await AddNewCoach();

await UpdateCoachName();

await GetCoach();

await DeleteCoach();

await GetCoaches();

return;

async Task GetLeagueRelations()
{
    var league = await context.Leagues
        .Include(l => l.Teams)
        .ThenInclude(t => t.Coach)
        .AsNoTracking()
        .FirstOrDefaultAsync();

    if (league == null)
    {
        return;
    }

    Console.WriteLine(league.Name);

    foreach (var team in league.Teams)
    {
        Console.WriteLine($"{team.Name} - {team.Coach.Name}");
    }
}

async Task GetTeams()
{
    var teams = await context.Teams.AsNoTracking().ToListAsync();

    foreach (var team in teams)
    {
        Console.WriteLine(team.Name);
    }
}

async Task GetTeam()
{
    Console.WriteLine("Please enter a Team Id");
    var input = Console.ReadLine();

    if (!int.TryParse(input, out var teamId))
    {
        Console.WriteLine("Invalid id");
        return;
    }

    context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    var team = await context.Teams.FindAsync(teamId);
    context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;

    if (team == null)
    {
        Console.WriteLine("Team not found");
        return;
    }

    Console.WriteLine(team.Name);
}

async Task GetFilteredTeams()
{
    Console.WriteLine("Please enter a search term");
    var term = Console.ReadLine() ?? "";

    var filteredTeams = await context.Teams
        .Where(t => EF.Functions.Like(t.Name, $"%{term}%"))
        .AsNoTracking()
        .ToListAsync();

    foreach (var team in filteredTeams)
    {
        Console.WriteLine(team.Name);
    }
}

async Task GetFilteredTeamsViaSQL()
{
    Console.WriteLine("Please enter a search term");
    var term = Console.ReadLine()?.ToLower() ?? "";

    var teams = await context.Teams
        .FromSqlRaw("SELECT * FROM teams WHERE LOWER(name) LIKE CONCAT('%', {0}, '%')", term)
        .AsNoTracking()
        .ToListAsync();

    var team = await context.Teams
        .FromSql($"SELECT * FROM teams WHERE LOWER(name) LIKE CONCAT('%', {term}, '%')")
        .AsNoTracking()
        .ToListAsync();

    Console.WriteLine("Raw SQL");
    foreach (var t in teams)
    {
        Console.Write($"{t.Name}\n");
    }

    Console.WriteLine("\nFormatted SQL");
    foreach (var t in team)
    {
        Console.WriteLine(t.Name);
    }
}

async Task GetCoach()
{
    Console.WriteLine("Please enter a Coach Id");
    var input = Console.ReadLine();

    if (!int.TryParse(input, out var coachId))
    {
        Console.WriteLine("Invalid id");
        return;
    }

    context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    var coach = await context.Coaches.FindAsync(coachId);
    context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;

    if (coach == null)
    {
        Console.WriteLine("Coach not found");
        return;
    }

    Console.WriteLine(coach.Name);
}

async Task GetCoaches()
{
    var coaches = await context.Coaches.ToListAsync();

    foreach (var c in coaches)
    {
        Console.WriteLine(c.Name);
    }
}

async Task AddNewCoach()
{
    Console.WriteLine("Please enter a coach name");
    var name = Console.ReadLine() ?? "";

    var coach = new Coach
    {
        Name = name
    };

    context.Coaches.Add(coach);
    await context.SaveChangesAsync();

    Console.WriteLine($"Coach added successfully with Id {coach.Id}");
}

async Task UpdateCoachName()
{
    Console.WriteLine("Please enter a Coach Id");
    var input = Console.ReadLine();
    if (!int.TryParse(input, out var coachId))
    {
        Console.WriteLine("Invalid Id");
        return;
    }

    Console.WriteLine("Please enter new coach name");
    var name = Console.ReadLine() ?? "";

    var coach = await context.Coaches.FindAsync(coachId);

    if (coach is null)
    {
        Console.WriteLine("Coach not found");
        return;
    }

    coach.Name = name;
    await context.SaveChangesAsync();

    Console.WriteLine($"Coach {coachId} updated with name {name}");
}

async Task DeleteCoach()
{
    Console.WriteLine("Please enter a Coach Id");
    var input = Console.ReadLine();

    if (!int.TryParse(input, out var coachId))
    {
        Console.WriteLine("Invalid Id");
        return;
    };

    await context.Coaches.Where(c => c.Id == coachId).ExecuteDeleteAsync();

    Console.WriteLine($"Coach {coachId} deleted successfully");
}

async Task TransactionExamples()
{
    var transaction = await context.Database.BeginTransactionAsync();
    var league = new League
    {
        Name = "Transaction League"
    };

    await context.AddAsync(league);
    await context.SaveChangesAsync();
    await transaction.CreateSavepointAsync("CreatedLeague");

    var coach = new Coach
        {
            Name = "Transaction Coach"
        };

    context.Add(coach);
    context.SaveChanges();

    var teams = new List<Team>
    {
        new Team
        {
            Name = "Transaction Team",
            LeagueId = league.Id,
            CoachId = coach.Id
        }
    };

    await context.AddRangeAsync(teams);
    await context.SaveChangesAsync();

    try
    {
        await transaction.CommitAsync();
    }
    catch (Exception)
    {
        await transaction.RollbackToSavepointAsync("CreatedLeague");
        throw;
    }
}

async Task GlobalQueryFilters()
{
    var leagues = await context.Leagues.ToListAsync();
    Console.WriteLine("List all leagues");
    foreach (var l in leagues)
    {
        Console.WriteLine(l.Name);
    }

    var league = await context.Leagues.FindAsync(1);
    if (league == null)
    {
        Console.WriteLine("League not found");
        return;
    }
    league.IsDeleted = true;
    Console.WriteLine("Soft Delete league with the id 1");
    await context.SaveChangesAsync();

    Console.WriteLine("List all leagues - global filter ignores 'deleted' record");
    leagues = await context.Leagues.ToListAsync();
    foreach (var l in leagues)
    {
        Console.WriteLine(l.Name);
    }

    Console.WriteLine("List all leagues - global filter is ignored in the query");
    leagues = await context.Leagues
        .IgnoreQueryFilters()
        .ToListAsync();
    foreach (var l in leagues)
    {
        Console.WriteLine(l.Name);
    }
}

async Task ConcurrencyChecks()
{
    var team = await context.Teams.FindAsync(1);

    if (team == null)
    {
        Console.WriteLine("Team Not Found");
        return;
    }

    team.Name = "New Team With Concurrency Check 1";

    try
    {
        await context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException ex)
    {
        Console.WriteLine(ex.Message);
    }
}
