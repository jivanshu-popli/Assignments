using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace flightproject2.Models;

public partial class Ace52024Context : DbContext
{
    public Ace52024Context()
    {
    }

    public Ace52024Context(DbContextOptions<Ace52024Context> options)
        : base(options)
    {
    }

    public virtual DbSet<BookingsJivanshu> BookingsJivanshus { get; set; }

    public virtual DbSet<CustomersJivanshu> CustomersJivanshus { get; set; }

    public virtual DbSet<FlightsJivanshu> FlightsJivanshus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DEVSQL.Corp.local;Database=ACE 5- 2024;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookingsJivanshu>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Bookings__73951AEDFEB3804F");

            entity.ToTable("BookingsJivanshu");

            entity.Property(e => e.BookingDate).HasColumnType("datetime");
            entity.Property(e => e.TotalCost).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Customer).WithMany(p => p.BookingsJivanshus)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__BookingsJ__Custo__125EB334");

            entity.HasOne(d => d.Flight).WithMany(p => p.BookingsJivanshus)
                .HasForeignKey(d => d.FlightId)
                .HasConstraintName("FK__BookingsJ__Total__116A8EFB");
        });

        modelBuilder.Entity<CustomersJivanshu>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D81464005F");

            entity.ToTable("CustomersJivanshu");

            entity.Property(e => e.CustomerLocation)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FlightsJivanshu>(entity =>
        {
            entity.HasKey(e => e.FlightId).HasName("PK__FlightsJ__8A9E14EE23F80A95");

            entity.ToTable("FlightsJivanshu");

            entity.Property(e => e.Airline)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DestinationCity)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.SourceCity)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
