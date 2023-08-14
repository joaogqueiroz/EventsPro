using EventsPro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace EventsPro.Persistence.Data
{
    public class EventsProContext : DbContext
    {

        public EventsProContext(DbContextOptions<EventsProContext> options) 
        : base(options)
        {

        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Batch> Batchs { get; set; }
        public DbSet<SocialNetwork> SocialNetworks { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<SpeakerEvent> SpeakersEvents { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SpeakerEvent>().HasKey(SE => new {SE.EventId, SE.SpeakerId});
    }
    
    }
}