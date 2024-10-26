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
    public DbSet<ImageForRequestToCompleteSoloChallenge> ImagesForRequestToCompleteSoloChallenge { get; set; }
    public DbSet<Level> Levels { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<RepeatForSoloChallenge> RepeatsForSoloChallenge { get; set; }
    public DbSet<RepeatForSoloSelfChallenge> RepeatsForSoloSelfChallenge { get; set; }
    public DbSet<RequestToCompleteSoloChallenge> RequestsToCompleteSoloChallenge { get; set; }
    public DbSet<SoloChallenge> SoloChallenges { get; set; }
    public DbSet<SoloChallengeExpPerPlace> SoloChallengeExpsPerPlace { get; set; }
    public DbSet<SoloSelfChallenge> SoloSelfChallenges { get; set; }
    public DbSet<SoloSelfChallengeCatalog> SoloSelfChallengeCatalogs { get; set; }


    public string DbPath { get; }

    public IdentityContext()
    {
        DbPath = "Data/Databases/Identity.db";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql($"Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=1234");
}
