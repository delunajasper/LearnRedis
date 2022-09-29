using System.Text.Json;
using LearnRedis.Models;
using StackExchange.Redis;

namespace LearnRedis.Data;

public class RedisPlatformRepository : IPlatformRepository
{
    private readonly IConnectionMultiplexer _redis;
    
    public RedisPlatformRepository(IConnectionMultiplexer redis)
    {
        _redis = redis;
    }
    
    public void CreatePlatform(Platform platform)
    {
        if (platform == null)
        {
            throw new ArgumentOutOfRangeException(nameof(platform));
        }

        var db = _redis.GetDatabase();

        var searilizePlatform = JsonSerializer.Serialize(platform);

        db.StringSet(platform.Id, searilizePlatform);
    }

    public Platform? GetPlatform(string id)
    {
        var db = _redis.GetDatabase();

        var platform = db.StringGet(id);

        return !string.IsNullOrEmpty(platform) ? JsonSerializer.Deserialize<Platform>(platform) : null;
    }

    public IEnumerable<Platform> GetAllPlatforms()
    {
        throw new NotImplementedException();
    }
}