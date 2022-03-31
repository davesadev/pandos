using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PandosAPI.Models
{
    [Table("Genre")]
    public partial class Genre
    {
        [Key]
        [Column("Genre")]
        [StringLength(50)]
        public string Genre1 { get; set; } = null!;
    }
}
