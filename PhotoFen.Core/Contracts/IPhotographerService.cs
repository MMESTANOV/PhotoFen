namespace PhotoFen.Core.Contracts
{
    public interface IPhotographerService
    {
        Task<bool> ExistsPhotographerByIdAsync(string userId);

        Task CreatePhotographerAsync(string userId, string userName, string photographerInfo);

        Task<int?> GetPhotographerIdAsync(string userId);
    }
}
