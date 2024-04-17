using Microsoft.EntityFrameworkCore;
using PhotoFen.Core.Contracts;
using PhotoFen.Infrastructure.Data.Common;
using PhotoFen.Infrastructure.Data.Models;

namespace PhotoFen.Core.Services
{
    public class PhotographerService : IPhotographerService
    {
        private readonly IRepository repository;

        public PhotographerService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task CreatePhotographerAsync(string userId, string userName, string photographerInfo)
        {
            await repository.AddAsync(new Photographer()
            {
                UserId = userId,
                Name = userName,
                PhotographerInfo = photographerInfo
            });

            await repository.SaveChangesAsync();
        }

        public async Task<bool> ExistsPhotographerByIdAsync(string userId)
        {
            return await repository
                 .AllReadOnly<Photographer>()
                 .AnyAsync(p => p.UserId == userId);
        }

        public async Task<int?> GetPhotographerIdAsync(string userId)
        {
            return (await repository
               .AllReadOnly<Photographer>()
               .FirstOrDefaultAsync(p => p.UserId == userId))?.Id;
        }
    }
}
