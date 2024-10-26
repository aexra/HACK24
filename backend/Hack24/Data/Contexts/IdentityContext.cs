using Hack24.Data.Model;
using Hack24.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hack24.Data.Contexts;
public class IdentityContext : IdentityDbContext<User>
{
    public DbSet<AcceptedSoloChallenge> AcceptedSoloChallenges { get; set; }
    public DbSet<AcceptedTeamChallenge> AcceptedTeamChallenges { get; set; }
    public DbSet<ChallengeType> ChallengeTypes { get; set; }
    public DbSet<CompletedSoloChallenge> CompletedSoloChallenges { get; set; }
    public DbSet<CompletedTeamChallenge> CompletedTeamChallenges { get; set; }
    public DbSet<ImageForRequestToCompleteSoloChallenge> ImagesForRequestToCompleteSoloChallenge { get; set; }
    public DbSet<ImageForRequestToCompleteTeamChallenge> ImagesForRequestToCompleteTeamChallenge { get; set; }
    public DbSet<Level> Levels { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<RepeatForSoloChallenge> RepeatsForSoloChallenge { get; set; }
    public DbSet<RepeatForSoloSelfChallenge> RepeatsForSoloSelfChallenge { get; set; }
    public DbSet<RepeatForTeamChallenge> RepeatsForTeamChallenge { get; set; }
    public DbSet<RepeatForTeamSelfChallenge> RepeatsForTeamSelfChallenge { get; set; }
    public DbSet<RequestToCompleteSoloChallenge> RequestsToCompleteSoloChallenge { get; set; }
    public DbSet<RequestToCompleteTeamChallenge> RequestsToCompleteTeamChallenge { get; set; }
    public DbSet<SoloChallenge> SoloChallenges { get; set; }
    public DbSet<SoloChallengeCatalog> SoloChallengeCatalogs { get; set; }
    public DbSet<SoloChallengeExpPerPlace> SoloChallengeExpsPerPlace { get; set; }
    public DbSet<SoloSelfChallenge> SoloSelfChallenges { get; set; }
    public DbSet<SoloSelfChallengeCatalog> SoloSelfChallengeCatalogs { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<TeamChallenge> TeamChallenges { get; set; }
    public DbSet<TeamChallengeCatalog> TeamChallengeCatalogs { get; set; }
    public DbSet<TeamChallengeExpPerPlace> TeamChallengeExps { get; set; }
    public DbSet<TeamSelfChallenge> TeamSelfChallenges { get; set; }
    public DbSet<TeamSelfChallengeCatalog> TeamSelfChallengeCatalogs { get; set; }
    public DbSet<TeamType> TeamTypes { get; set; }
    public DbSet<UserTeam> UserTeams { get; set; }

    public string DbPath { get; }

    public IdentityContext()
    {
        DbPath = "Data/Databases/Identity.db";
    }

    public async Task SeedDataAsync(IServiceProvider serviceProvider)
    {
        string[] posts = ["HR", "Frontender", "Backender", "Envelope Developer", "Coffee Maker", "NotSelected"];
        string[] roles = ["User", "Admin", "FamilyMember", "Employee"];

        // ENSURE POSTS
        foreach (var postName in posts)
        {
            if (!(await Posts.ToListAsync()).Exists(p => p.Title == postName))
            {
                await Posts.AddAsync(new Post() { Title = postName });
            }
        }

        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        // ENSURE ROLES
        foreach (var roleName in roles)
        {
            if (!roleManager.Roles.ToList().Exists(r => r.Name == roleName))
            {
                await roleManager.CreateAsync(new IdentityRole { Name = roleName });
            }
        }

        // ENSURE ADMIN
        if (!(await Users.ToListAsync()).Exists(u => u.UserName == "admin"))
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            var userName = "admin";
            var password = "Admin1_";

            var user = new User()
            {
                UserName = userName
            };

            var createdUser = await userManager.CreateAsync(user, password);

            await userManager.AddToRoleAsync(user, "Admin");
        }

        SaveChanges();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql($"Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=1234;Include Error Detail=True");
}
