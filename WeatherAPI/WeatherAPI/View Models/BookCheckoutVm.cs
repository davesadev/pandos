namespace WeatherAPI.View_Models
{
    public class BookCheckoutVm
    {

        public int BookId { get; set; }
        public string? Title { get; set; }
        public int? CheckedOutToId { get; set; }
        public int? AuthorId { get; set; }
        public virtual ICollection<CheckoutVm> Checkouts { get; set; }
        // should there be many books per checkout or many checkouts per book? many to many?

    }
}
