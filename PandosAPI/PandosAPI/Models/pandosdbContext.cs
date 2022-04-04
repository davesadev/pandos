using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PandosAPI.Models
{
    public partial class pandosdbContext : DbContext
    {
        public pandosdbContext()
        {
        }

        public pandosdbContext(DbContextOptions<pandosdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; } = null!;
        public virtual DbSet<Pdb> Pdbs { get; set; } = null!;
        public virtual DbSet<PdbChain> PdbChains { get; set; } = null!;
        public virtual DbSet<Uniprot> Uniprots { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=pandosdb;user=root;password=admin", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.7.3-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<Pdb>(entity =>
            {
                entity.HasOne(d => d.Uniprot)
                    .WithMany(p => p.Pdbs)
                    .HasForeignKey(d => d.UniprotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pdb_uniprot");
            });

            modelBuilder.Entity<PdbChain>(entity =>
            {
                entity.HasKey(e => new { e.PdbId, e.PdbChainId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.HasOne(d => d.Pdb)
                    .WithMany(p => p.PdbChains)
                    .HasForeignKey(d => d.PdbId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pdb_chain_pdb");

                entity.HasOne(d => d.Uniprot)
                    .WithMany(p => p.PdbChains)
                    .HasForeignKey(d => d.UniprotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pdb_chain_uniprot");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
