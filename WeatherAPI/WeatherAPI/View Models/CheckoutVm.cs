namespace WeatherAPI.View_Models
{
    public class CheckoutVm
    {
        public int CheckoutId { get; set; }
        public bool? CheckedOut { get; set; }
        public DateTime? CheckoutDate { get; set; }
        public DateTime? DueByDate { get; set; }

    }
}
