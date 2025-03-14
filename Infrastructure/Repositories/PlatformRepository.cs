using Domain.Entities;

namespace Infrastructure.Repositories;

public class PlatformRepository : IPlatformRepository
{
    private Platform[] _platforms = [];

    public void Put(Platform[] platforms)
    {
        _platforms = platforms;
    }

    public Platform[] Get(string? location)
    {
        if (location == null)
            return _platforms;
        else
            return Search(location);
    }

    private Platform[] Search(string location)
    {
        var parts = location.Split('/', StringSplitOptions.RemoveEmptyEntries);

        return _platforms
            .Where(p => p.Locations.Any(l =>
            {

                for (int i = parts.Length - 1; i > -1; i--)
                {
                    if (l.EndsWith(parts[i]))
                        return true;
                }
                return false;
            }))
            .ToArray();
    }
}
