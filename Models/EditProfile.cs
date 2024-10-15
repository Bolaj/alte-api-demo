using System.ComponentModel.DataAnnotations;

namespace alte_app.Models
{
    public class EditProfile
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Full name is required")]
        public required string FullName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "About me is required")]
        public required string About { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public required string Role { get; set; }

        [Required(ErrorMessage = "At least two skills are required")]
        [MinLength(2, ErrorMessage = "At least two skills are required")]
        public required List<string> Skills { get; set; }

        [Required(ErrorMessage = "Rate is required")]
        public required string Rate { get; set; }

        [Required(ErrorMessage = "At least one language is required")]
        [MinLength(1, ErrorMessage = "At least one language is required")]
        public required List<string> Language { get; set; }

        [Url(ErrorMessage = "Invalid LinkedIn profile URL")]
        public required string LinkedIn  { get; set; }

        [Url(ErrorMessage = "Invalid portfolio URL")]
        public required string Portfolio { get; set; }

        public string? Timezone { get; set; }

        public string? Availability { get; set; }
    }
}