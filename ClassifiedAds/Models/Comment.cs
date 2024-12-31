namespace ClassifiedAds.Models
{
    public class Comment : SharedModel
    {
        public string Comments { get; set; }

        public int AdId { get; set; }
        public Ad Ad { get; set; }
        public RankingStar Star { get; set; }

        public int UserId { get; set; }
        public AppUser User { get; set; }
    }

    public enum RankingStar
    {
        OneStar = 0,
        TwoStar = 1,
        ThreeStar = 2,
        FourStar = 3,
        FiveStar = 4
    }
}
