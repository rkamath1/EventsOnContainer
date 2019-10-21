using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Data
{
    public class EventCatalogContext: DbContext
    {
        public EventCatalogContext(DbContextOptions options): base(options)
        {//What type of database (SQLserver, MongoDB, etc.) and how tp connect
        }//Dependancy injection (receiver)

        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<EventItem> EventItems { get; set; }
        public DbSet<EventLocation> EventLocations { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventCategory>(ConfigureEventCategory);//Action delegate
            modelBuilder.Entity<EventType>(ConfigureEventType);
            modelBuilder.Entity<EventItem>(ConfigureEventItem);
            modelBuilder.Entity<EventLocation>(ConfigureEventLocation);
        }

        private void ConfigureEventLocation(EntityTypeBuilder<EventLocation> builder)
        {
            builder.ToTable("EventLocations");
            builder.Property(l => l.Id).IsRequired().ForSqlServerUseSequenceHiLo("event_location_hilo");
            builder.Property(l => l.City).IsRequired().HasMaxLength(100);
            builder.Property(l => l.State).IsRequired().HasMaxLength(100);
        }

        private void ConfigureEventItem(EntityTypeBuilder<EventItem> builder)
        {
            builder.ToTable("EventCatalog");
            builder.Property(c => c.Id).IsRequired().ForSqlServerUseSequenceHiLo("event_hilo");
            builder.Property(c => c.EventName).IsRequired().HasMaxLength(100);
            builder.Property(c => c.OrganizerName).IsRequired().HasMaxLength(100);
            builder.Property(c => c.VenueName).IsRequired().HasMaxLength(100);
            builder.Property(c => c.TicketPrice).IsRequired();
            builder.Property(c => c.EventDescription).HasMaxLength(100);
            builder.Property(c => c.Date).IsRequired();
            builder.Property(c => c.Time).IsRequired();

            builder.HasOne(c => c.EventType).WithMany().HasForeignKey(c => c.EventTypeId);
            builder.HasOne(c => c.EventLocation).WithMany().HasForeignKey(c => c.EventLocationId);
            builder.HasOne(c => c.EventCategory).WithMany().HasForeignKey(c => c.EventCategoryId);

        }

        private void ConfigureEventType(EntityTypeBuilder<EventType> builder)
        {
            builder.ToTable("EventTypes");//Name of table
            builder.Property(t => t.Id).IsRequired().ForSqlServerUseSequenceHiLo("event_type_hilo");
            builder.Property(t => t.Type).IsRequired().HasMaxLength(100);
        }

        private void ConfigureEventCategory(EntityTypeBuilder<EventCategory> builder)
        {
            builder.ToTable("EventCategories");
            builder.Property(b => b.Id).IsRequired().ForSqlServerUseSequenceHiLo("event_category_hilo");
            builder.Property(b => b.Category).IsRequired().HasMaxLength(100);
        }
    }
}
