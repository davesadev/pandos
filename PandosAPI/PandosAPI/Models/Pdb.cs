using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PandosAPI.Models
{
    [Table("pdb")]
    public partial class Pdb
    {
        public Pdb()
        {
            PdbChains = new HashSet<PdbChain>();
        }

        [Key]
        [Column("pdb_id")]
        [StringLength(50)]
        [Unicode(false)]
        public string PdbId { get; set; } = null!;

        [InverseProperty(nameof(PdbChain.Pdb))]
        public virtual ICollection<PdbChain> PdbChains { get; set; }
    }
}
