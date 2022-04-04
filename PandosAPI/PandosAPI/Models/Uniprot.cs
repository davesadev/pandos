using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PandosAPI.Models
{
    [Table("uniprot")]
    public partial class Uniprot
    {
        public Uniprot()
        {
            PdbChains = new HashSet<PdbChain>();
            Pdbs = new HashSet<Pdb>();
        }

        [Key]
        [Column("uniprot_id")]
        [StringLength(20)]
        public string UniprotId { get; set; } = null!;
        [Column("accession_number")]
        [StringLength(20)]
        public string? AccessionNumber { get; set; }
        [Column("entry_status")]
        [StringLength(50)]
        public string? EntryStatus { get; set; }
        [Column("sequence")]
        [StringLength(2000)]
        public string? Sequence { get; set; }

        [InverseProperty("Uniprot")]
        public virtual ICollection<PdbChain> PdbChains { get; set; }
        [InverseProperty("Uniprot")]
        public virtual ICollection<Pdb> Pdbs { get; set; }
    }
}
