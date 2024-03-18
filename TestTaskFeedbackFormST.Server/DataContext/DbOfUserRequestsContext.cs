using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TestTaskFeedbackFormST.Server.Models;

namespace TestTaskFeedbackFormST.Server.DataContext;

public partial class DbOfUserRequestsContext : DbContext
{
    public DbOfUserRequestsContext()
    {
    }

    public DbOfUserRequestsContext(DbContextOptions<DbOfUserRequestsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<DirectoryOfMessageTopic> DirectoryOfMessageTopics { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contacts__3214EC07A7A814DA");

            entity.HasIndex(e => new { e.Email, e.Phone }, "UQ_Email_Phone").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Phone)
                .HasMaxLength(13)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DirectoryOfMessageTopic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Director__3214EC07597076B1");

            entity.HasIndex(e => e.Topic, "UQ__Director__1CC389DF4169D82D").IsUnique();

            entity.Property(e => e.Topic).HasMaxLength(100);
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Messages__3214EC07C0AA32FB");

            entity.Property(e => e.ContactId).HasColumnName("ContactID");
            entity.Property(e => e.TopicId).HasColumnName("TopicID");

            entity.HasOne(d => d.Contact).WithMany(p => p.Messages)
                .HasForeignKey(d => d.ContactId)
                .HasConstraintName("FK__Messages__Contac__1DB06A4F");

            entity.HasOne(d => d.Topic).WithMany(p => p.Messages)
                .HasForeignKey(d => d.TopicId)
                .HasConstraintName("FK__Messages__TopicI__1EA48E88");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
