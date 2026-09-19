using Microsoft.EntityFrameworkCore;
using SMART_EVENT_MANAGEMENT_SYSTEM.Models;

namespace SMART_EVENT_MANAGEMENT_SYSTEM.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Registration> Registrations { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Organizer>().HasMany(e => e.Events).WithOne(o => o.Organizer).HasForeignKey(e=>e.OrganizerId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Venue>().HasMany(e => e.Events).WithOne(o => o.Venue).HasForeignKey(e=>e.VenueId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Event>().HasMany(e => e.Registrations).WithOne(o => o.Event).HasForeignKey(e=>e.EventId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Attendee>().HasMany(e => e.Registrations).WithOne(o => o.Attendee).HasForeignKey(e=>e.AttendeeId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Event>().HasKey(e => e.EventId);
            modelBuilder.Entity<Organizer>().HasKey(e => e.OrganizerId);
            modelBuilder.Entity<Attendee>().HasKey( e => e.AttendeeId);
            modelBuilder.Entity<Venue>().HasKey( e => e.VenueId);
            modelBuilder.Entity<Registration>().HasKey( e => e.RegistrationId);

            modelBuilder.Entity<Registration>().HasIndex(e => new { e.EventId, e.AttendeeId }).IsUnique();

            modelBuilder.Entity<Organizer>().HasIndex(e => e.Email).IsUnique();
            modelBuilder.Entity<Attendee>().HasIndex(e => e.Email).IsUnique();
            modelBuilder.Entity<Venue>().HasIndex(e => e.Name).IsUnique();

            // If you are reading this the data seeding is done by AI becuase there is no way I'm doing it manually, Thank you.

            modelBuilder.Entity<Organizer>().HasData(
                new Organizer
                {
                    OrganizerId = 1,
                    FullName = "Ahmed Hassan",
                    Email = "ahmed.hassan@example.com",
                    Phone = "+201001234567"
                },
                new Organizer
                {
                    OrganizerId = 2,
                    FullName = "Sara Mohamed",
                    Email = "sara.mohamed@example.com",
                    Phone = "+201112345678"
                },
                new Organizer
                {
                    OrganizerId = 3,
                    FullName = "Omar Ali",
                    Email = "omar.ali@example.com",
                    Phone = "+201223456789"
                }
            );

            modelBuilder.Entity<Venue>().HasData(
                new Venue 
                {                
                    VenueId = 1,
                    Name = "Cairo Convention Center",
                    Location = "Nasr City, Cairo",
                    Capacity = 5000
                },
                new Venue
                {
                    VenueId = 2,
                    Name = "Alexandria Cultural Hall",
                    Location = "Alexandria, Egypt",
                    Capacity = 2500
                },
                new Venue
                {
                    VenueId = 3,
                    Name = "Nile Conference Hall",
                    Location = "Maadi, Cairo",
                    Capacity = 1000
                }
            );

            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    EventId = 1,
                    Title = "Tech Innovation Summit",
                    Description = "A conference about technology and innovation.",
                    EventDate = new DateTime(2026, 10, 10),
                    StartTime = new TimeSpan(10, 0, 0),
                    EndTime = new TimeSpan(16, 0, 0),
                    Category = "Technology",
                    Capacity = 3000,
                    OrganizerId = 1,
                    VenueId = 1
                },
                new Event
                {
                    EventId = 2,
                    Title = "Business Leadership Forum",
                    Description = "A forum for young business leaders.",
                    EventDate = new DateTime(2026, 10, 15),
                    StartTime = new TimeSpan(11, 0, 0),
                    EndTime = new TimeSpan(17, 0, 0),
                    Category = "Business",
                    Capacity = 1500,
                    OrganizerId = 2,
                    VenueId = 2
                },
                 new Event
                 {
                     EventId = 3,
                     Title = "Digital Marketing Workshop",
                     Description = "A practical workshop about digital marketing.",
                     EventDate = new DateTime(2026, 11, 5),
                     StartTime = new TimeSpan(9, 0, 0),
                     EndTime = new TimeSpan(14, 0, 0),
                     Category = "Marketing",
                     Capacity = 500,
                     OrganizerId = 3,
                     VenueId = 3
                 },
                 new Event
                 {
                     EventId = 4,
                     Title = "AI and Future Technologies",
                     Description = "Exploring artificial intelligence and future technologies.",
                     EventDate = new DateTime(2026, 11, 20),
                     StartTime = new TimeSpan(10, 0, 0),
                     EndTime = new TimeSpan(15, 0, 0),
                     Category = "Technology",
                     Capacity = 2000,
                     OrganizerId = 1,
                     VenueId = 2
                 },
                 new Event
                 {
                     EventId = 5,
                     Title = "Entrepreneurship Meetup",
                     Description = "An event connecting entrepreneurs and startups.",
                     EventDate = new DateTime(2026, 12, 1),
                     StartTime = new TimeSpan(12, 0, 0),
                     EndTime = new TimeSpan(18, 0, 0),
                     Category = "Entrepreneurship",
                     Capacity = 800,
                     OrganizerId = 2,
                     VenueId = 1
                 }
            );

            modelBuilder.Entity<Attendee>().HasData(
                new Attendee
                {
                    AttendeeId = 1,
                    FullName = "Mai Mohamed",
                    Email = "mai.mohamed@example.com",
                    Phone = "+201000111222"
                },
                new Attendee
                {
                    AttendeeId = 2,
                    FullName = "Youssef Ahmed",
                    Email = "youssef.ahmed@example.com",
                    Phone = "+201011222333"
                },
                new Attendee
                {
                    AttendeeId = 3,
                    FullName = "Mariam Khaled",
                    Email = "mariam.khaled@example.com",
                    Phone = "+201022333444"
                },
                new Attendee
                {
                    AttendeeId = 4,
                    FullName = "Karim Mostafa",
                    Email = "karim.mostafa@example.com",
                    Phone = "+201033444555"
                },
                new Attendee
                {
                    AttendeeId = 5,
                    FullName = "Lina Omar",
                    Email = "lina.omar@example.com",
                    Phone = "+201044555666"
                },
                new Attendee
                {
                    AttendeeId = 6,
                    FullName = "Adam Hassan",
                    Email = "adam.hassan@example.com",
                    Phone = "+201055666777"
                }
            );

            modelBuilder.Entity<Registration>().HasData(
                new Registration
                {
                    RegistrationId = 1,
                    RegistrationDate = new DateTime(2026, 9, 18),
                    Status = "Confirmed",
                    EventId = 1,
                    AttendeeId = 1
                },
                new Registration
                {
                    RegistrationId = 2,
                    RegistrationDate = new DateTime(2026, 9, 18),
                    Status = "Confirmed",
                    EventId = 1,
                    AttendeeId = 2
                },
                new Registration
                {
                    RegistrationId = 3,
                    RegistrationDate = new DateTime(2026, 9, 18),
                    Status = "Pending",
                    EventId = 2,
                    AttendeeId = 3
                },
                new Registration
                {
                    RegistrationId = 4,
                    RegistrationDate = new DateTime(2026, 9, 18),
                    Status = "Confirmed",
                    EventId = 2,
                    AttendeeId = 4
                },
                new Registration
                {
                    RegistrationId = 5,
                    RegistrationDate = new DateTime(2026, 9, 18),
                    Status = "Confirmed",
                    EventId = 3,
                    AttendeeId = 1
                },
                new Registration
                {
                    RegistrationId = 6,
                    RegistrationDate = new DateTime(2026, 9, 18),
                    Status = "Cancelled",
                    EventId = 4,
                    AttendeeId = 5
                },
                new Registration
                {
                    RegistrationId = 7,
                    RegistrationDate = new DateTime(2026, 9, 18),
                    Status = "Confirmed",
                    EventId = 5,
                    AttendeeId = 6
                },
                new Registration
                {
                    RegistrationId = 8,
                    RegistrationDate = new DateTime(2026, 9, 18),
                    Status = "Pending",
                    EventId = 4,
                    AttendeeId = 3
                }
            );


        }
    }
}