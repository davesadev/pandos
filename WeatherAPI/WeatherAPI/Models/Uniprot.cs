using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WeatherAPI.Models
{
    [Table("uniprot")]
    public partial class Uniprot
    {
        public Uniprot()
        {
            Pdbs = new HashSet<Pdb>();
        }

        [Key]
        [Column("uniprot_id")]
        public int UniprotId { get; set; }
        [Column("accession_number")]
        public int? AccessionNumber { get; set; }
        [Column("entry_status")]
        [StringLength(50)]
        [Unicode(false)]
        public string? EntryStatus { get; set; }
        [Column("sequence")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Sequence { get; set; }

        [InverseProperty(nameof(Pdb.Uniprot))]
        public virtual ICollection<Pdb> Pdbs { get; set; }
    }
}
