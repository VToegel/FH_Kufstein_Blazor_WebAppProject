namespace FH_Kufstein_Blazor_WebAppProject.Models
{
    public class ContainerDetails
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTimeOffset DateTime { get; set; }
        public required string Location { get; set; }
        public string? ContainerTypeId { get; set; }
        public int Capacity { get; set; }
        public int CurrentLevel { get; set; }
        public string[]? Measurements { get; set; }
    }
}
