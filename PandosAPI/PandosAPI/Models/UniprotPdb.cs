using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PandosAPI.Models
{
    [Table("uniprot_pdb")]
    public partial class UniprotPdb
    {
        [Key]
        [Column("uniprot_id")]
        [StringLength(20)]
        [Unicode(false)]
        public string UniprotId { get; set; } = null!;
        [Key]
        [Column("pdb_id")]
        [StringLength(50)]
        [Unicode(false)]
        public string PdbId { get; set; } = null!;
    }
}
