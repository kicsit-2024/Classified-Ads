using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassifiedAds.Models
{
    public class Ad : SharedModel
    {
        public decimal Price { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public AdNature AdNature { get; set; }
        public string GoogleMap { get; set; }

        //[ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }  // Category_Id

        public List<AdImage> Images { get; set; }
        public List<Comment> Comments { get; set; }

        //[Required]
        public override int? UserId { get => base.UserId; set => base.UserId = value; }
        public AppUser User { get; set; }

        public int? GroupId { get; set; }
        public AdvertisementGroup Group { get; set; }
        public List<AdSpecValue> SpecsValues { get; set; }

        [NotMapped]
        public List<IFormFile> Uploads { get; set; }
    }

    public class AdSpecValue : SharedModel
    {
        public string Value { get; set; }

        public int SpecId { get; set; }
        public CategorySpec Spec { get; set; }

        public int AdId { get; set; }
        public Ad Ad { get; set; }
    }
}
