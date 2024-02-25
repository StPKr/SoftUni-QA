namespace GardenConsoleAPI.Business.Contracts
{
    public interface IEngine
    {
        Task Run(IPlantsManager plantsManager);
    }
}
