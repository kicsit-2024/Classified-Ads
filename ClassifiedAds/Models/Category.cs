using ClassifiedAds.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassifiedAds.Models
{
    public class Category : SharedModel
    {
        [Required(ErrorMessage = "Category name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "2~50 valid length")]
        [UnicodeDataType]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public string LogoUrl { get; set; }

        [NotMapped]
        public IFormFile Logo { get; set; }

        public List<Ad> Ads { get; set; }
        public List<CategorySpecGroup> SpecsGroups { get; set; }

        public override void MakeSafe(bool isUpdate = false)
        {
            Ads = new List<Ad>();
            base.MakeSafe(isUpdate);
        }
    }

    public class CategorySpecGroup : SharedModel
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<CategorySpec> Specs { get; set; }
    }

    public class CategorySpec : SharedModel
    {
        public string Name { get; set; }
        public int Rank { get; set; }

        public string ShortCode { get; set; }
        public CategorySpecValueType ValueType { get; set; }
        public int GroupId { get; set; }
        public CategorySpecGroup Group { get; set; }
    }



    public enum CategorySpecValueType
    {
        Text = 0,
        Numeric = 1,
        DDList = 2,
        Boolean = 3,
        DateTime = 4
    }
}
