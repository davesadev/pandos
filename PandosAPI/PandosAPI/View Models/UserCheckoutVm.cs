using System.ComponentModel.DataAnnotations;

namespace PandosAPI.View_Models
{
    public class UserCheckoutVm
    {
        public int UserId { get; set; }
        public byte? BookCheckoutCapacity { get; set; }
        public byte? NumBooksCheckedOutCurrently { get; set; }
        public int BookId { get; set; }
        public string? Title { get; set; }
        public int? CheckedOutToId { get; set; }
        public int? AuthorId { get; set; }
        public virtual ICollection<CheckoutVm> Checkouts { get; set; }

    }
}
