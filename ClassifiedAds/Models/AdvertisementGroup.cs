namespace ClassifiedAds.Models
{
    public class AdvertisementGroup : SharedModel
    {
        public string Title { get; set; }
        public string Desription { get; set; }
        public List<Ad> Ads { get; set; }
    }
}
