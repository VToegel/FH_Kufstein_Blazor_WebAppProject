using FH_Kufstein_Blazor_WebAppProject.Models;

namespace FH_Kufstein_Blazor_WebAppProject.Clients
{
    public class ContainerDataClient
    {
        private readonly List<ContainerData> containers =
        [
        new ContainerData { Id = 1, Name = $"Container {new Random().Next(0,200)}", DateTime = DateTime.Now, Location = "Gorleben", ContainerType = "Barrel", Capacity = 5000, CurrentLevel = new Random().Next(1000,5000), Measurements = [$"{DateTime.UtcNow}, Temperature: {new Random().Next(0,50)}C, RadioActivity: {new Random().Next(200,1000)}mSV"] },
        new ContainerData { Id = 2, Name = $"Container {new Random().Next(0,200)}", DateTime = DateTime.Now, Location = "Gorleben", ContainerType = "Barrel", Capacity = 5000, CurrentLevel = new Random().Next(1000,5000), Measurements = [$"{DateTime.UtcNow}, Temperature: {new Random().Next(0,50)}C, RadioActivity: {new Random().Next(200,1000)}mSV"] },
        new ContainerData { Id = 3, Name = $"Container {new Random().Next(0,200)}", DateTime = DateTime.Now, Location = "Gorleben", ContainerType = "Barrel", Capacity = 5000, CurrentLevel = new Random().Next(1000,5000), Measurements = [$"{DateTime.UtcNow}, Temperature: {new Random().Next(0,50)}C, RadioActivity: {new Random().Next(200,1000)}mSV"] },
        new ContainerData { Id = 4, Name = $"Container {new Random().Next(0,200)}", DateTime = DateTime.Now, Location = "Gorleben", ContainerType = "Barrel", Capacity = 5000, CurrentLevel = new Random().Next(1000,5000), Measurements = [$"{DateTime.UtcNow}, Temperature: {new Random().Next(0,50)}C, RadioActivity: {new Random().Next(200,1000)}mSV"] },
        new ContainerData { Id = 5, Name = $"Container {new Random().Next(0,200)}", DateTime = DateTime.Now, Location = "Gorleben", ContainerType = "Barrel", Capacity = 5000, CurrentLevel = new Random().Next(1000,5000), Measurements = [$"{DateTime.UtcNow}, Temperature: {new Random().Next(0,50)}C, RadioActivity: {new Random().Next(200,1000)}mSV"] }
        ];

        public ContainerData[] GetContainerData() => [.. containers];
        public ContainerType[] GetContainerTypes() => new ContainerTypeClient().GetContainerTypes();
        public void AddContainerData(ContainerDetails containerDetails)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(containerDetails.ContainerTypeId);
            ContainerType containerType = GetContainerTypes().Single(ct => ct.Id == int.Parse(containerDetails.ContainerTypeId));

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
    }
}