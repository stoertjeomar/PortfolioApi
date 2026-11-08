using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class BlogpostsController : ControllerBase
{
    private readonly BlogpostService _service;

    public BlogpostsController(BlogpostService service)
    {
        _service = service;
    }

    // GET: api/Blogposts
    [HttpGet]
    public async Task<ActionResult<List<BlogpostResponse>>> GetAll()
    {
        var blogposts = await _service.GetAll();
        return Ok(blogposts);
    }

    // GET: api/Blogposts/1
    [HttpGet("{id}")]
    public async Task<ActionResult<BlogpostResponse>> GetById(int id)
    {
        var blogpost = await _service.GetById(id);
        if (blogpost == null)
        {
            return NotFound();
        }
        return Ok(blogpost);
    }
}
