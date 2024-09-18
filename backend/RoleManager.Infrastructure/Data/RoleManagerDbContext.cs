namespace RoleManager.Infrastructure.Data;

public class RoleManagerDbContext : DbContext
{
    public RoleManagerDbContext(DbContextOptions<RoleManagerDbContext> options) : base(options)
    {
    }

    // Entidades
    public DbSet<Campaign> Campaigns { get; set; }

    public DbSet<Character> Characters { get; set; }
    public DbSet<CharacterEpic> CharacterEpics { get; set; }
    public DbSet<CharacterNpc> CharacterNpcs { get; set; }
    public DbSet<Domain> Domains { get; set; }
    public DbSet<Faction> Factions { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Quest> Quests { get; set; }
    public DbSet<QuestStage> QuestStages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Relación muchos a muchos para aliados entre personajes
        modelBuilder.Entity<Character>()
            .HasMany(c => c.Allies)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "CharacterAlly",
                j => j.HasOne<Character>().WithMany().HasForeignKey("AllyId"),
                j => j.HasOne<Character>().WithMany().HasForeignKey("CharacterId")
            );

        // Relación muchos a muchos para rivales entre personajes
        modelBuilder.Entity<Character>()
            .HasMany(c => c.Rivals)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "CharacterRival",
                j => j.HasOne<Character>().WithMany().HasForeignKey("RivalId"),
                j => j.HasOne<Character>().WithMany().HasForeignKey("CharacterId")
            );

        // Relación muchos a muchos para aliados entre facciones
        modelBuilder.Entity<Faction>()
            .HasMany(f => f.Allies)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "FactionAlly",
                j => j.HasOne<Faction>().WithMany().HasForeignKey("AllyId"),
                j => j.HasOne<Faction>().WithMany().HasForeignKey("FactionId")
            );

        // Relación muchos a muchos para enemigos entre facciones
        modelBuilder.Entity<Faction>()
            .HasMany(f => f.Enemies)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "FactionEnemy",
                j => j.HasOne<Faction>().WithMany().HasForeignKey("EnemyId"),
                j => j.HasOne<Faction>().WithMany().HasForeignKey("FactionId")
            );

        // Configuración de la relación entre Character y Faction
        modelBuilder.Entity<Character>()
            .HasOne(c => c.Faction)
            .WithMany(f => f.Members)
            .HasForeignKey(c => c.FactionId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configuración de la relación entre Faction y Character
        modelBuilder.Entity<Faction>()
            .HasMany(f => f.Members)
            .WithOne(c => c.Faction)
            .HasForeignKey(c => c.FactionId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configuración de la relación entre Leader y Faction
        modelBuilder.Entity<Faction>()
            .HasOne(f => f.Leader)
            .WithOne()
            .HasForeignKey<Faction>(f => f.LeaderId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}