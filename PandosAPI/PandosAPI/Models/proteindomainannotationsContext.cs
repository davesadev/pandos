using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PandosAPI.Models
{
    public partial class proteindomainannotationsContext : DbContext
    {
        public proteindomainannotationsContext()
        {
        }

        public proteindomainannotationsContext(DbContextOptions<proteindomainannotationsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pdb> Pdbs { get; set; } = null!;
        public virtual DbSet<PdbChain> PdbChains { get; set; } = null!;
        public virtual DbSet<Uniprot> Uniprots { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=protein-domain-annotations;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
                entity.HasKey(e => new { e.PdbId, e.PdbChainId });

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
