using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WeatherAPI.Models
{
    public partial class Book
    {
        public Book()
        {
            Checkouts = new HashSet<Checkout>();
        }

        [Key]
        [Column("BookID")]
        public int BookId { get; set; }
        [StringLength(50)]
        public string? Title { get; set; }
        [StringLength(50)]
        public string? Genre { get; set; }
        public byte? ReadingLevel { get; set; }
        [StringLength(50)]
        public string? Author { get; set; }
        [StringLength(50)]
        public string? Publisher { get; set; }
        public byte? MultipleCopies { get; set; }
        [Column("CheckedOutToID")]
        public int? CheckedOutToId { get; set; }
        [Column("AuthorID")]
        public int? AuthorId { get; set; }
        [Column("PublisherID")]
        public int? PublisherId { get; set; }

        [ForeignKey(nameof(AuthorId))]
        [InverseProperty("Books")]
        public virtual Author? AuthorNavigation { get; set; }
        [InverseProperty(nameof(Checkout.Book))]
        public virtual ICollection<Checkout> Checkouts { get; set; }
    }
}
