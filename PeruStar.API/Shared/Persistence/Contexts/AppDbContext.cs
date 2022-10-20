using Microsoft.EntityFrameworkCore;
using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Domain.Models.Status;
using PeruStar.API.Security.Domain.Models;
using PeruStar.API.Shared.Extensions;

namespace PeruStar.API.Shared.Persistence.Contexts;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    // Declare DbSet of the entity
    public DbSet<Artist> Artists { get; set; } = null!;
    public DbSet<Artwork> Artworks { get; set; } = null!;
    public DbSet<ClaimTicket> ClaimTickets { get; set; } = null!;
    public DbSet<EventAssistance> EventAssistances { get; set; } = null!;
    public DbSet<Event> Events { get; set; } = null!;
    public DbSet<FavoriteArtwork> FavoriteArtworks { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    public DbSet<Specialty> Specialties { get; set; } = null!;
    public DbSet<Hobbyist> Hobbyists { get; set; } = null!;

    public DbSet<Follower> Followers { get; set; } = null!;

    // Structure of the database
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Follower entity
        builder.Entity<Follower>().ToTable("Followers");
        builder.Entity<Follower>().Property(p => p.HobbyistId).IsRequired();
        //builder.Entity<Follower>()
        //    .HasMany(p => p.Hobbyist)
        //    .WithOne(p => p.Follower)
        //    .HasForeignKey(p => p.HobbyistId);


        //  Person entity
        builder.Entity<Person>().ToTable("Persons");
        builder.Entity<Person>().HasKey(p => p.Id);
        builder.Entity<Person>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Person>().Property(p => p.Firstname).IsRequired().HasMaxLength(100);
        builder.Entity<Person>().Property(p => p.Lastname).IsRequired().HasMaxLength(100);
        // Relationships
        
        //  Artist entity
        builder.Entity<Artist>().ToTable("Artists");
        builder.Entity<Artist>().Property(p => p.BrandName).IsRequired().HasMaxLength(100);
        builder.Entity<Artist>().Property(p => p.SpecialtyId).IsRequired();
        builder.Entity<Artist>().Property(p => p.Description).IsRequired().HasMaxLength(1000);
        builder.Entity<Artist>().Property(p => p.Phrase).IsRequired().HasMaxLength(100);
        builder.Entity<Artist>().Property(p => p.SocialMediaLink).HasConversion(
            links => string.Join(',', links.ToArray()),                                         //Como se guarda en la base de datos: Links = "Link1,Link2,Link3"
            links => links.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());         //Come se lee de la base de datos Links=e[0],e[1],e[2]
        // Relationships
        
        builder.Entity<Artist>() 
            .HasMany(p => p.Artworks)
            .WithOne(p => p.Artist)
            .HasForeignKey(p => p.ArtistId);
        
        builder.Entity<Artist>()
            .HasMany(p => p.Events)
            .WithOne(p => p.Artist)
            .HasForeignKey(p => p.ArtistId);

        builder.Entity<Artist>()
            .HasOne(p => p.SpecialtyArt)
            .WithMany(p => p.Artists)
            .HasForeignKey(p => p.SpecialtyId);

        // Artwork entity
        builder.Entity<Artwork>().ToTable("Artworks");
        builder.Entity<Artwork>().HasKey(p => p.ArtworkId);
        builder.Entity<Artwork>().Property(p => p.ArtworkId).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Artwork>().Property(p => p.ArtTitle).IsRequired().HasMaxLength(100);
        builder.Entity<Artwork>().Property(p => p.ArtDescription).IsRequired().HasMaxLength(250);
        builder.Entity<Artwork>().Property(p => p.ArtCost);
        builder.Entity<Artwork>().Property(p => p.LinkInfo);
        // Relationships
        
        //FavoriteArtwork entity
        builder.Entity<FavoriteArtwork>().ToTable("FavoriteArtworks");
        builder.Entity<FavoriteArtwork>().HasKey(p => p.ArtworkId);
        builder.Entity<FavoriteArtwork>().Property(p => p.ArtworkId).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<FavoriteArtwork>().HasKey(p => p.HobbyistId);
        builder.Entity<FavoriteArtwork>().Property(p => p.HobbyistId).IsRequired().ValueGeneratedOnAdd();
       // builder.Entity<FavoriteArtwork>().HasKey(pt => new { pt.HobyyistId, pt.ArtworkId });

        // Relationships
        
        builder.Entity<FavoriteArtwork>()
            .HasOne(pt => pt.Hobbyist)
            .WithMany(p => p.FavoriteArtworks)
            .HasForeignKey(pt => pt.HobbyistId);
        
        builder.Entity<FavoriteArtwork>()
            .HasOne(pt => pt.Artwork)
            .WithMany(p => p.FavoriteArtworks)
            .HasForeignKey(pt => pt.ArtworkId);

        
        // ClaimTicket entity
        builder.Entity<ClaimTicket>().ToTable("ClaimTickets");
        builder.Entity<ClaimTicket>().HasKey(p => p.ClaimId);
        builder.Entity<ClaimTicket>().Property(p => p.ClaimId).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<ClaimTicket>().Property(p => p.ClaimSubject).IsRequired().HasMaxLength(40);
        builder.Entity<ClaimTicket>().Property(p => p.ClaimDescription).IsRequired().HasMaxLength(300);
        builder.Entity<ClaimTicket>().Property(p => p.IncidentDate).IsRequired();
        // Relationships
        
        builder.Entity<ClaimTicket>()
            .HasOne(c => c.ReportedPerson)
            .WithMany(p => p.ReportsClaimTickets)
            .HasForeignKey(c => c.ReportedPersonId);

        builder.Entity<ClaimTicket>()
            .HasOne(c => c.ReportMadeBy)
            .WithMany(p => p.ClaimTickets)
            .HasForeignKey(c => c.ReportMadeById);
        
        // EventAssistance entity
        
        builder.Entity<EventAssistance>().ToTable("EventAssistances");
        builder.Entity<EventAssistance>().HasKey(pt => new { pt.HobbyistId, pt.EventId });
        builder.Entity<EventAssistance>().Property(pt => pt.AttendanceDay);
        // Relationships
        
        builder.Entity<EventAssistance>()
            .HasOne(pt => pt.Hobbyist)
            .WithMany(p => p.Assistance)
            .HasForeignKey(pt => pt.HobbyistId);

        builder.Entity<EventAssistance>()
            .HasOne(pt => pt.Event)
            .WithMany(p => p.Assistance)
            .HasForeignKey(pt => pt.EventId);
        
        // Event entity
        builder.Entity<Event>().ToTable("Events");

        builder.Entity<Event>().HasKey(p => p.EventId);
        builder.Entity<Event>().Property(p => p.EventId).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Event>().Property(p => p.EventTitle).IsRequired().HasMaxLength(100);
        builder.Entity<Event>().Property(p => p.EventType).IsRequired().HasConversion(
            type => type.ToString(),                                                        //convert enum to string
            type => (ETypeOfEvent)Enum.Parse(typeof(ETypeOfEvent), type));                  //convert string to enum
        builder.Entity<Event>().Property(p => p.DateStart).IsRequired();
        builder.Entity<Event>().Property(p => p.DateEnd).IsRequired();
        builder.Entity<Event>().Property(p => p.EventDescription).IsRequired().HasMaxLength(250);
        builder.Entity<Event>().Property(p => p.EventAditionalInfo);
        
        // Relationships
        
        // User entity
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(u => u.Username).IsRequired();
        builder.Entity<User>().Property(u => u.Email).IsRequired();
        builder.Entity<User>().Property(u => u.PasswordHash).IsRequired();
        
        // Hobbyist entity

        //Specialty Entity
        builder.Entity<Specialty>().ToTable("Specialties");
        builder.Entity<Specialty>().HasKey(s => s.SpecialtyId);
        builder.Entity<Specialty>().Property(s => s.SpecialtyId).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Specialty>().Property(s => s.Name).IsRequired().HasMaxLength(50);

        //Relationships
        //Falta Interest

        // Relationships

        builder.UseSnakeCaseNamingConvention();
        
    }
}