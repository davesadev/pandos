using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PandosAPI.Models
{
    [Table("User")]
    public partial class User
    {
        public User()
        {
            Checkouts = new HashSet<Checkout>();
        }

        [Key]
        [Column("userID")]
        public int UserId { get; set; }
        [Column("name")]
        [StringLength(50)]
        public string? Name { get; set; }
        [Column("email")]
        [StringLength(50)]
        public string? Email { get; set; }
        [Column("bookCheckoutCapacity")]
        public byte? BookCheckoutCapacity { get; set; }
        [Column("numBooksCheckedOutCurrently")]
        public byte? NumBooksCheckedOutCurrently { get; set; }
        [Column("readingLevel")]
        public int? ReadingLevel { get; set; }

        [InverseProperty(nameof(Checkout.User))]
        public virtual ICollection<Checkout> Checkouts { get; set; }
    }
}
