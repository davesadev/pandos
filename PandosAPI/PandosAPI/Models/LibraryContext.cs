using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PandosAPI.Models
{
    public partial class LibraryContext : DbContext
    {
        public LibraryContext()
        {
        }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<Checkout> Checkouts { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<ReadingLevel> ReadingLevels { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.AuthorId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.BookId).ValueGeneratedNever();

                entity.HasOne(d => d.AuthorNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_Books_Author");
            });

            modelBuilder.Entity<Checkout>(entity =>
            {
                entity.Property(e => e.CheckoutId).ValueGeneratedNever();

                entity.Property(e => e.BookTitle).IsFixedLength();

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Checkouts)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_Checkout_Author");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Checkouts)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK_Checkout_Books");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Checkouts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Checkout_User");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.Genre1).IsFixedLength();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
