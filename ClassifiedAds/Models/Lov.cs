using System.ComponentModel.DataAnnotations;

namespace ClassifiedAds.Models
{
    public class Lov : SharedModel
    {
        [StringLength(100, MinimumLength = 2)]
        [RegularExpression("^[A-Z].*", ErrorMessage = "Must follow regex ^[A-Z].*")]
        public string Title { get; set; }
        public string ShortCode { get; set; }
        public List<LovOption> Options { get; set; }
    }

    public class LovOption : SharedModel
    {
        public string Value { get; set; }
        public string Text { get; set; }

        public int LovId { get; set; }
        public Lov Lov { get; set; }
    }
}