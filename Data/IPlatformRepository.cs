using LearnRedis.Models;

namespace LearnRedis.Data;

public interface IPlatformRepository
{
    void CreatePlatform(Platform platform);
    Platform GetPlatform(string id);
    IEnumerable<Platform> GetAllPlatforms();
}