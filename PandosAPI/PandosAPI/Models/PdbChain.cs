using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PandosAPI.Models
{
    [Table("pdb_chain")]
    public partial class PdbChain
    {
        [Key]
        [Column("pdb_id")]
        [StringLength(50)]
        [Unicode(false)]
        public string PdbId { get; set; } = null!;
        [Key]
        [Column("pdb_chain_id")]
        [StringLength(10)]
        [Unicode(false)]
        public string PdbChainId { get; set; } = null!;
        [Column("uniprot_id")]
        [StringLength(20)]
        [Unicode(false)]
        public string UniprotId { get; set; } = null!;
        [Column("pdb_sequence")]
        [StringLength(200)]
        [Unicode(false)]
        public string? PdbSequence { get; set; }
        [Column("head_domain")]
        [StringLength(100)]
        [Unicode(false)]
        public string? HeadDomain { get; set; }
        [Column("hinge_domain")]
        [StringLength(100)]
        [Unicode(false)]
        public string? HingeDomain { get; set; }
        [Column("stalk_domain")]
        [StringLength(100)]
        [Unicode(false)]
        public string? StalkDomain { get; set; }
        [Column("neck_domain")]
        [StringLength(100)]
        [Unicode(false)]
        public string? NeckDomain { get; set; }
        [Column("transmembrane_domain")]
        [StringLength(100)]
        [Unicode(false)]
        public string? TransmembraneDomain { get; set; }
        [Column("cytoplasmic_domain")]
        [StringLength(100)]
        [Unicode(false)]
        public string? CytoplasmicDomain { get; set; }

        [ForeignKey(nameof(PdbId))]
        [InverseProperty("PdbChains")]
        public virtual Pdb Pdb { get; set; } = null!;
        [ForeignKey(nameof(UniprotId))]
        [InverseProperty("PdbChains")]
        public virtual Uniprot Uniprot { get; set; } = null!;
    }
}
