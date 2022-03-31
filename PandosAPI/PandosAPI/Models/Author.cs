using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PandosAPI.Models
{
    [Table("Author")]
    public partial class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
            Checkouts = new HashSet<Checkout>();
        }

        [Key]
        [Column("AuthorID")]
        public int AuthorId { get; set; }
        [StringLength(50)]
        public string? FirstName { get; set; }
        [StringLength(50)]
        public string? LastName { get; set; }
        [StringLength(50)]
        public string? PrimaryGenre { get; set; }
        [StringLength(50)]
        public string? SecondaryGenre { get; set; }
        [StringLength(50)]
        public string? PrimaryPublisher { get; set; }
        [StringLength(50)]
        public string? SecondaryPublisher { get; set; }

        [InverseProperty(nameof(Book.AuthorNavigation))]
        public virtual ICollection<Book> Books { get; set; }
        [InverseProperty(nameof(Checkout.Author))]
        public virtual ICollection<Checkout> Checkouts { get; set; }
    }
}
