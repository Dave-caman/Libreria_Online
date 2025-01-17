using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Libreria_Online.Models;

public partial class LibreriaOnlineContext : DbContext
{
    public LibreriaOnlineContext()
    {
    }

    public LibreriaOnlineContext(DbContextOptions<LibreriaOnlineContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-5V0K83GS\\SQL2022; Database=LibreriaOnline; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__Books__3DE0C207B0D4434C");

            entity.Property(e => e.BookAuthor).HasMaxLength(100);
            entity.Property(e => e.BookDigitalPath)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.BookImageCover)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.BookTitle).HasMaxLength(100);

            entity.HasOne(d => d.BookGenre).WithMany(p => p.Books)
                .HasForeignKey(d => d.BookGenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Books__BookGenre__3E52440B");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.GenresId).HasName("PK__Genres__1F6A92B41034F3EA");

            entity.HasIndex(e => e.GenresName, "UQ__Genres__C087192EE3AC08DB").IsUnique();

            entity.Property(e => e.GenresName).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4CFB6422CE");

            entity.HasIndex(e => e.UserEmail, "UQ__Users__08638DF8D8D17679").IsUnique();

            entity.Property(e => e.UserCreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserEmail).HasMaxLength(100);
            entity.Property(e => e.UserLastname).HasMaxLength(100);
            entity.Property(e => e.UserName).HasMaxLength(100);
            entity.Property(e => e.UserPassword).HasMaxLength(200);
            entity.Property(e => e.UserRol).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
