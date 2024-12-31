using System.ComponentModel.DataAnnotations;

namespace ClassifiedAds.Models
{
    public class AppUser:SharedModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CellNumber { get; set; }
        public string ProfilePhoto { get; set; }

        public List<Comment> Comments { get; set; }
        public List<Ad> Ads { get; set; }
        public List<AppRole> Roles { get; set; }

        [StringLength(280)]
        public string Address { get; set; }
    }
}
