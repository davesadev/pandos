﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PandosAPI.Models
{
    [Index(nameof(Use), Name = "IX_Keys_Use")]
    public partial class Key
    {
        [Key]
        public string Id { get; set; } = null!;
        public int Version { get; set; }
        public DateTime Created { get; set; }
        public string? Use { get; set; }
        [StringLength(100)]
        public string Algorithm { get; set; } = null!;
        [Column("IsX509Certificate")]
        public bool IsX509certificate { get; set; }
        public bool DataProtected { get; set; }
        public string Data { get; set; } = null!;
    }
}
