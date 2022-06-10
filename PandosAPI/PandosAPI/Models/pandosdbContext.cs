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
