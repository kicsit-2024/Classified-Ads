namespace ClassifiedAds.Models
{
    public class AppRole:SharedModel
    {
        public string Name { get; set; }
        public string ShortCode { get; set; }
        public string Description { get; set; }
        public List<AppUser> Users { get; set; }
    }
}
