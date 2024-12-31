namespace ClassifiedAds.Models
{
    public class AdImage : SharedModel
    {
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int Rank { get; set; }

        public int AdId { get; set; }
        public Ad Ad { get; set; }
    }
}
