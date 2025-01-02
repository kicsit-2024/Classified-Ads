using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ClassifiedAds.Attributes;

namespace ClassifiedAds.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LogoUrl { get; set; }
        public int AdsCount { get; set; }
    }
}
