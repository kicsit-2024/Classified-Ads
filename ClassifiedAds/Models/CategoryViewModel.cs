using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ClassifiedAds.Attributes;

namespace ClassifiedAds.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Token { get; set; }
        [Required(ErrorMessage = "Category name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "2~50 valid length")]
        [UnicodeDataType]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public string LogoUrl { get; set; }
        public IFormFile Logo { get; set; }
        public List<GroupViewModel> Groups { get; set; }
    }

    public class GroupViewModel
    {
        public string Name { get; set; }
        public List<CategorySpecViewModel> Specs { get; set; }
    }
    public class CategorySpecViewModel
    {
        public string Name { get; set; }
        public int Rank { get; set; }
        public string ShortCode { get; set; }
        public CategorySpecValueType ValueType { get; set; }
    }
}
