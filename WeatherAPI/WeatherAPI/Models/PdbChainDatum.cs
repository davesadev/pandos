using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WeatherAPI.Models
{
    [Table("pdb_chain_data")]
    public partial class PdbChainDatum
    {
        [Key]
        [Column("pdb_chain_data_id")]
        public int PdbChainDataId { get; set; }
        [Column("pdb_chain_id")]
        public int? PdbChainId { get; set; }
        [Column("head_domain")]
        [StringLength(50)]
        [Unicode(false)]
        public string? HeadDomain { get; set; }
        [Column("hinge_domain")]
        [StringLength(50)]
        [Unicode(false)]
        public string? HingeDomain { get; set; }
        [Column("stalk_domain")]
        [StringLength(50)]
        [Unicode(false)]
        public string? StalkDomain { get; set; }
        [Column("neck_domain")]
        [StringLength(50)]
        [Unicode(false)]
        public string? NeckDomain { get; set; }
        [Column("transmembrane")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Transmembrane { get; set; }
        [Column("cytoplasmic")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Cytoplasmic { get; set; }

        [ForeignKey(nameof(PdbChainId))]
        [InverseProperty("PdbChainData")]
        public virtual PdbChain? PdbChain { get; set; }
    }
}
