using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MusicPianoData;

public partial class PianoLessonContext : DbContext
{
    public PianoLessonContext()
    {
    }

    public PianoLessonContext(DbContextOptions<PianoLessonContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Lesson> Lessons { get; set; }

    public virtual DbSet<LessonPrerequisite> LessonPrerequisites { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserLesson> UserLessons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-JC5GAB0\\SQLEXPRESS;Initial Catalog=PianoLesson;TrustServerCertificate=True;User ID=SA;Password=1235;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.ToTable("Lesson");

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(50);
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
