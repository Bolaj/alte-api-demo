namespace alte_app.Data
{
    public class AddProjectDto
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required List<string> Skills { get; set; }
        public required string Duration { get; set; }
        public required string SalaryRange { get; set; }
        public required DateTime PostedDate { get; set; }
        public required bool IsBookmarked { get; set; }
    }
}