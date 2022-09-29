using LearnRedis.Data;
using Microsoft.AspNetCore.Mvc;

namespace LearnRedis.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlatformController : ControllerBase
{
    private readonly IPlatformRepository _repo;

    public PlatformController(IPlatformRepository repo)
    {
        _repo = repo;
    }
}