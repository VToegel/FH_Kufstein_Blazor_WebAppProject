using FH_Kufstein_Blazor_WebAppProject.Models;

namespace FH_Kufstein_Blazor_WebAppProject.Clients
{
    public class ContainerDataClient
    {
        private readonly List<ContainerData> containers =
        [
        new ContainerData { Id = 1, Name = $"Container {new Random().Next(0,200)}", DateTime = DateTime.Now, Location = "Gorleben", ContainerType = "Castor", Capacity = 5000, CurrentLevel = new Random().Next(1000,5000), Measurements = [$"{DateTime.UtcNow}, Temperature: {new Random().Next(0,50)}C, RadioActivity: {new Random().Next(200,1000)}mSV"] },
        new ContainerData { Id = 2, Name = $"Container {new Random().Next(0,200)}", DateTime = DateTime.Now, Location = "Gorleben", ContainerType = "Castor", Capacity = 5000, CurrentLevel = new Random().Next(1000,5000), Measurements = [$"{DateTime.UtcNow}, Temperature: {new Random().Next(0,50)}C, RadioActivity: {new Random().Next(200,1000)}mSV"] },
        new ContainerData { Id = 3, Name = $"Container {new Random().Next(0,200)}", DateTime = DateTime.Now, Location = "Gorleben", ContainerType = "Lead Lined", Capacity = 5000, CurrentLevel = new Random().Next(1000,5000), Measurements = [$"{DateTime.UtcNow}, Temperature: {new Random().Next(0,50)}C, RadioActivity: {new Random().Next(200,1000)}mSV"] },
        new ContainerData { Id = 4, Name = $"Container {new Random().Next(0,200)}", DateTime = DateTime.Now, Location = "Gorleben", ContainerType = "Stainless Steel", Capacity = 5000, CurrentLevel = new Random().Next(1000,5000), Measurements = [$"{DateTime.UtcNow}, Temperature: {new Random().Next(0,50)}C, RadioActivity: {new Random().Next(200,1000)}mSV"] },
        new ContainerData { Id = 5, Name = $"Container {new Random().Next(0,200)}", DateTime = DateTime.Now, Location = "Gorleben", ContainerType = "Lead lined Composite", Capacity = 5000, CurrentLevel = new Random().Next(1000,5000), Measurements = [$"{DateTime.UtcNow}, Temperature: {new Random().Next(0,50)}C, RadioActivity: {new Random().Next(200,1000)}mSV"] }
        ];

        public ContainerData[] GetContainerData() => [.. containers];
        public ContainerType[] GetContainerTypes() => new ContainerTypeClient().GetContainerTypes();
        public void AddContainerData(ContainerDetails containerDetails)
        {
            ContainerType containerType = GetContainerTypeById(containerDetails.ContainerTypeId);

            containers.Add(new ContainerData
            {
                Id = containers.Count + 1,
                Name = containerDetails.Name,
                DateTime = DateTime.Now,
                Location = containerDetails.Location,
                ContainerType = containerType.Name,
                Capacity = containerDetails.Capacity,
                CurrentLevel = containerDetails.CurrentLevel,
                Measurements = [$"{DateTime.UtcNow}, Temperature: {new Random().Next(0, 50)}C, RadioActivity: {new Random().Next(200, 1000)}mSV"]
            });
        }


        public ContainerDetails GetContainerData(int id)
        {
            ContainerData container = GetContainerById(id);

            ContainerType containerType = GetContainerTypes().Single(ct => string.Equals(ct.Name, container.ContainerType, StringComparison.OrdinalIgnoreCase));

            return new ContainerDetails
            {
                Id = container.Id,
                Name = container.Name,
                DateTime = container.DateTime,
                Location = container.Location,
                ContainerTypeId = containerType.Id.ToString(),
                Capacity = container.Capacity,
                CurrentLevel = container.CurrentLevel,
                Measurements = container.Measurements
            };
        }

        public void UpdateContainerData(ContainerDetails updatedContainer)
        {
            ContainerData existingContainer = GetContainerById(updatedContainer.Id);

            ContainerType containerType = GetContainerTypeById(updatedContainer.ContainerTypeId);

            existingContainer.Name = updatedContainer.Name;
            existingContainer.Location = updatedContainer.Location;
            existingContainer.ContainerType = containerType.Name;
            existingContainer.Capacity = updatedContainer.Capacity;
            existingContainer.CurrentLevel = updatedContainer.CurrentLevel;
        }

        public void DeleteContainerData(int id)
        {
            ContainerData container = GetContainerById(id);
            containers.Remove(container);
        }

        private ContainerData GetContainerById(int id)
        {
            ContainerData? container = containers.Find(c => c.Id == id);
            ArgumentNullException.ThrowIfNull(container);
            return container;
        }

        private ContainerType GetContainerTypeById(string? id)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(id);
            return GetContainerTypes().Single(ct => ct.Id == int.Parse(id));
        }
    }
}