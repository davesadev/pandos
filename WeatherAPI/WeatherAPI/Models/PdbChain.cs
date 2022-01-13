using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WeatherAPI.Models
{
    [Table("pdb_chain")]
    public partial class PdbChain
    {
        public PdbChain()
        {
            PdbChainData = new HashSet<PdbChainDatum>();
        }

        [Key]
        [Column("pdb_chain_id")]
        public int PdbChainId { get; set; }
        [Column("pdb_id")]
        [StringLength(50)]
        [Unicode(false)]
        public string? PdbId { get; set; }
        [Column("chain")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Chain { get; set; }
        [Column("pdb_sequence")]
        [MaxLength(200)]
        public byte[]? PdbSequence { get; set; }

        [ForeignKey(nameof(PdbId))]
        [InverseProperty("PdbChains")]
        public virtual Pdb? Pdb { get; set; }
        [InverseProperty(nameof(PdbChainDatum.PdbChain))]
        public virtual ICollection<PdbChainDatum> PdbChainData { get; set; }
    }
}
