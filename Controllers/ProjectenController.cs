using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ProjectenController : ControllerBase
{
    // GET: api/Projecten
    [HttpGet]
    public string GetString()
    {
        return "Het endpoint werkt!";
    }
}