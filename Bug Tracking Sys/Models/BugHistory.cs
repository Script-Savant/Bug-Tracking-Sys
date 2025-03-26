using System;
using System.ComponentModel.DataAnnotations;

namespace BugTrackingSys.Models
{
    public class BugHistory
    {
        [Key]
        public int BugHistoryId { get; set; }

        [Required(ErrorMessage = "Bug is required")]
        public Bug Bug { get; set; }

        [Required(ErrorMessage = "Changed By is required")]
        public User ChangedBy { get; set; }

        [Required(ErrorMessage = "Status Before is required")]
        public BugStatus StatusBefore { get; set; }

        [Required(ErrorMessage = "Status After is required")]
        public BugStatus StatusAfter { get; set; }

        [Required(ErrorMessage = "Change Timestamp is required")]
        public DateTime ChangeTimestamp { get; set; }
    }
}