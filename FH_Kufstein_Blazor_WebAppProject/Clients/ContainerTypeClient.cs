using FH_Kufstein_Blazor_WebAppProject.Models;

namespace FH_Kufstein_Blazor_WebAppProject.Clients
{
    public class ContainerTypeClient
    {
        private readonly ContainerType[] containerTypes =
        [
            new ContainerType { Id = 1, Name = "Castor" },
            new ContainerType { Id = 2, Name = "Lead Lined" },
            new ContainerType { Id = 3, Name = "Stainless Steel" },
            new ContainerType { Id = 4, Name = "Lead" },
            new ContainerType { Id = 5, Name = "Lead lined Composite" }
        ];

        public ContainerType[] GetContainerTypes() => containerTypes;
    }
}
