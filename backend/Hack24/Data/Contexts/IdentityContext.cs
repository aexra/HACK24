using Hack24.Data.Model;
using Hack24.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web.Data.Models;

namespace Web.Data.Contexts;
public class IdentityContext : IdentityDbContext<User>
{
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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql($"Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=1234");
}
