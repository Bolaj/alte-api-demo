using System.ComponentModel.DataAnnotations;

namespace alte_app.Models
{
    public class ProjectCard
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Project Title is required")]
        public required string Title { get; set; }

        [Required(ErrorMessage = "Project Description is required")]
        public required string Description { get; set; }

        [Required(ErrorMessage = "At least two requirements are required")]
        [MinLength(2, ErrorMessage = "At least two skills are required")]
        public required List<string> Skills { get; set; }

        [Required(ErrorMessage = "Duration is required")]
        public required string Duration { get; set; }
        [Required(ErrorMessage = "Salary Range is required")]
        public required string SalaryRange { get; set; }
        [Required(ErrorMessage = "Posted Date is required")]
        public required DateTime PostedDate { get; set; }
        public required bool IsBookmarked { get; set; }

       

    }
}