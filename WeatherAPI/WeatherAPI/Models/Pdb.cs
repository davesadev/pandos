﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WeatherAPI.Models
{
    [Table("pdb")]
    [Index(nameof(UniprotId), Name = "IX_pdb_uniprot_id")]
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
        [Column("uniprot_id")]
        public int UniprotId { get; set; }

        [ForeignKey(nameof(UniprotId))]
        [InverseProperty("Pdbs")]
        public virtual Uniprot Uniprot { get; set; } = null!;
        [InverseProperty(nameof(PdbChain.Pdb))]
        public virtual ICollection<PdbChain> PdbChains { get; set; }
    }
}
