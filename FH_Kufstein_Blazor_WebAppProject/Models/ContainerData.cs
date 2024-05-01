namespace FH_Kufstein_Blazor_WebAppProject.Models
{
    public class ContainerData
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTimeOffset DateTime { get; set; }
        public required string Location { get; set; }
        public required string ContainerType { get; set; }
        public int Capacity { get; set; }
        public int CurrentLevel { get; set; }
        public string[]? Measurements { get; set; }
    }
}
