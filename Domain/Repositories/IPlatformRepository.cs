using Domain.Entities;

namespace Infrastructure.Repositories
{
    public interface IPlatformRepository
    {
        Platform[] Get(string? location);
        void Put(Platform[] platforms);
    }
}