using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PandosAPI.Models
{
    [Table("ReadingLevel")]
    public partial class ReadingLevel
    {
        [Key]
        [Column("ReadingLevel")]
        public byte ReadingLevel1 { get; set; }
        [Column("wordsPerMinute")]
        public byte? WordsPerMinute { get; set; }
    }
}
