using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MusicPianoData;

public partial class PianoLessonContext : DbContext
{
    public PianoLessonContext(DbContextOptions<PianoLessonContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Lesson> Lessons { get; set; }

    public virtual DbSet<LessonPrerequisite> LessonPrerequisites { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserLesson> UserLessons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.ToTable("Lesson");

            entity.Property(e => e.Answers).HasMaxLength(500);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Questions).HasMaxLength(500);
        });

        modelBuilder.Entity<LessonPrerequisite>(entity =>
        {
            entity.HasKey(e => new { e.IdLesson, e.PrerequisiteLessonId }).HasName("PK_LessonPrerequisites_1");

            entity.Property(e => e.IdLesson).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdLessonNavigation).WithMany(p => p.LessonPrerequisites)
                .HasForeignKey(d => d.IdLesson)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LessonPrerequisites_Lesson");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
        });

        modelBuilder.Entity<UserLesson>(entity =>
        {
            entity.HasKey(e => new { e.IdUser, e.IdLesson }).HasName("PK_UserLesson_1");

            entity.ToTable("UserLesson");

            entity.Property(e => e.IdUser).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdLessonNavigation).WithMany(p => p.UserLessons)
                .HasForeignKey(d => d.IdLesson)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserLesson_Lesson1");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.UserLessons)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserLesson_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
