using System.ComponentModel.DataAnnotations;

namespace FH_Kufstein_Blazor_WebAppProject.Models
{
    public class ContainerDetails
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name is too long")]
        public required string Name { get; set; }
        public DateTimeOffset DateTime { get; set; }
        public required string Location { get; set; }

        [Required(ErrorMessage = "ContainerType is required")]
        public string? ContainerTypeId { get; set; }

        [Range(1, 5000, ErrorMessage = "Capacity must be between 1 and 5000")]
        public int Capacity { get; set; }

        [Range(1, 5000, ErrorMessage = "CurrentLevel must be between 1 and 5000")]
        public int CurrentLevel { get; set; }
        public string[]? Measurements { get; set; }
    }
}
