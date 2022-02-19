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
        [Key]
        [Column("uniprot_id")]
        [StringLength(20)]
        [Unicode(false)]
        public string UniprotId { get; set; } = null!;
        [Column("accession_number")]
        [StringLength(20)]
        [Unicode(false)]
        public string? AccessionNumber { get; set; }
        [Column("entry_status")]
        [StringLength(50)]
        [Unicode(false)]
        public string? EntryStatus { get; set; }
        [Column("sequence")]
        [StringLength(2000)]
        [Unicode(false)]
        public string? Sequence { get; set; }
    }
}
