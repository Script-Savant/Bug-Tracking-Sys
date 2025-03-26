using System;
using System.ComponentModel.DataAnnotations;

namespace Bug_Tracking_Sys.Models
{
    public enum BugStatus
    {
        Open,
        InProgress,
        Resolved,
        Closed
    }

    public class Bug
    {
        [Key]
        public int BugId { get; set; }

        [Required(ErrorMessage = "A title is required")]
        [StringLength(200, ErrorMessage = "Title cannot be longer than 200 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "A description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Created By is required")]
        public User CreatedBy { get; set; }

        public User AssignedTo { get; set; }

        [Required(ErrorMessage = "Created At is required")]
        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
        public DateTime? ResolvedAt { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public BugStatus Status { get; set; }

        public ICollection<BugHistory> History { get; set; } = new List<BugHistory>();
    }
}