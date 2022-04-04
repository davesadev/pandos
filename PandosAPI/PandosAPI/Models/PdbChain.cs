using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PandosAPI.Models
{
    [Table("pdb_chain")]
    [Index("UniprotId", Name = "IX_pdb_chain_uniprot_id")]
    public partial class PdbChain
    {
        [Key]
        [Column("pdb_id")]
        [StringLength(50)]
        public string PdbId { get; set; } = null!;
        [Key]
        [Column("pdb_chain_id")]
        [StringLength(10)]
        public string PdbChainId { get; set; } = null!;
        [Column("uniprot_id")]
        [StringLength(20)]
        public string UniprotId { get; set; } = null!;
        [Column("pdb_sequence")]
        [StringLength(200)]
        public string? PdbSequence { get; set; }
        [Column("head_domain")]
        [StringLength(100)]
        public string? HeadDomain { get; set; }
        [Column("hinge_domain")]
        [StringLength(100)]
        public string? HingeDomain { get; set; }
        [Column("stalk_domain")]
        [StringLength(100)]
        public string? StalkDomain { get; set; }
        [Column("neck_domain")]
        [StringLength(100)]
        public string? NeckDomain { get; set; }
        [Column("transmembrane_domain")]
        [StringLength(100)]
        public string? TransmembraneDomain { get; set; }
        [Column("cytoplasmic_domain")]
        [StringLength(100)]
        public string? CytoplasmicDomain { get; set; }

        [ForeignKey("PdbId")]
        [InverseProperty("PdbChains")]
        public virtual Pdb Pdb { get; set; } = null!;
        [ForeignKey("UniprotId")]
        [InverseProperty("PdbChains")]
        public virtual Uniprot Uniprot { get; set; } = null!;
    }
}
