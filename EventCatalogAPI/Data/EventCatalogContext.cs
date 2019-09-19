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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventCategory>(ConfigureEventCategory);//Action delegate
            modelBuilder.Entity<EventType>(ConfigureEventType);
            modelBuilder.Entity<EventItem>(ConfigureEventItem);
        }

        private void ConfigureEventItem(EntityTypeBuilder<EventItem> builder)
        {
            builder.ToTable("EventCatalog");
            builder.Property(c => c.Id)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("event_catalog_hilo");

            builder.Property(c => c.EventName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.OrganizerName)
                .HasMaxLength(100);

            builder.Property(c => c.EventDescription)
                .IsRequired()
                .HasMaxLength(10000);

            builder.Property(c => c.VenueName)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(c => c.AddressLine1)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(c => c.AddressLine2)
                .HasMaxLength(300);

            builder.Property(c => c.City)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.State)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(c => c.Zip)
                .IsRequired()
                .HasMaxLength(5);

            builder.Property(c => c.Date)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(c => c.Time)
                .IsRequired()
                .HasMaxLength(7);

            builder.Property(c => c.Price)
                .IsRequired();

            builder.HasOne(c => c.EventType)
                .WithMany()
                .HasForeignKey(c => c.EventTypeId);

            builder.HasOne(c => c.EventCategory)
                .WithMany()
                .HasForeignKey(c => c.EventCategoryId);

        }

        private void ConfigureEventType(EntityTypeBuilder<EventType> builder)
        {
            builder.ToTable("EventTypes");//Name of table
            builder.Property(t => t.Id)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("event_type_hilo");

            builder.Property(t => t.Type)
                .IsRequired()
                .HasMaxLength(100);
        }

        private void ConfigureEventCategory(EntityTypeBuilder<EventCategory> builder)
        {
            builder.ToTable("EventCategories");
            builder.Property(b => b.Id)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("event_category_hilo");

            builder.Property(b => b.Category)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
