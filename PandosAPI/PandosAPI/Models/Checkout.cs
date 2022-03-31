using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PandosAPI.Models
{
    [Table("Checkout")]
    public partial class Checkout
    {
        [Key]
        [Column("CheckoutID")]
        public int CheckoutId { get; set; }
        [StringLength(10)]
        public string? BookTitle { get; set; }
        [Column("BookID")]
        public int? BookId { get; set; }
        [Column("AuthorID")]
        public int? AuthorId { get; set; }
        [Column("UserID")]
        public int? UserId { get; set; }
        public bool? CheckedOut { get; set; }
        [Column(TypeName = "date")]
        public DateTime? CheckoutDate { get; set; }
        [Column("GenreID")]
        public int? GenreId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DueByDate { get; set; }

        [ForeignKey(nameof(AuthorId))]
        [InverseProperty("Checkouts")]
        public virtual Author? Author { get; set; }
        [ForeignKey(nameof(BookId))]
        [InverseProperty("Checkouts")]
        public virtual Book? Book { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Checkouts")]
        public virtual User? User { get; set; }
    }
}
