using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassifiedAds.Models
{
    public class SharedModel
    {
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DbEntryTime { get; set; } = DateTime.Now;
        
        [ScaffoldColumn(false)]
        public DateTime? LastModifiedOn { get; set; }
        
        [ScaffoldColumn(false)]
        public RecordStatus RecordStatus { get; set; }

        public virtual int? UserId { get; set; }
        public string Token { get; set; }

        public virtual void MakeSafe(bool isUpdate = false)
        {
            DbEntryTime = DateTime.Now;
            if (isUpdate)
            {
                LastModifiedOn = DateTime.Now;
            }
            else
            {
                LastModifiedOn = null;
            }

            RecordStatus = RecordStatus.Active;
        }
        
    }

    public enum RecordStatus
    {
        Draft = -1,
        Active = 0,
        Archieve = 1,
        Deleted = 999
    }
}
