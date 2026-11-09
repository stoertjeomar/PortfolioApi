using Microsoft.AspNetCore.Mvc;

// Laag 3 (Presentation): ontvangt requests en kiest het HTTP-resultaat. De logica zit in BlogpostService.
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

    // GET: api/Blogposts/5
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

    // POST: api/Blogposts
    [HttpPost]
    public async Task<ActionResult<BlogpostResponse>> Create(CreateBlogpostRequest request)
    {
        var blogpost = await _service.Create(request);
        return CreatedAtAction(nameof(GetById), new { id = blogpost.Id }, blogpost);
    }

    // PUT: api/Blogposts/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateBlogpostRequest request)
    {
        var gelukt = await _service.Update(id, request);
        if (!gelukt)
        {
            return NotFound();
        }
        return NoContent();
    }

    // DELETE: api/Blogposts/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var gelukt = await _service.Delete(id);
        if (!gelukt)
        {
            return NotFound();
        }
        return NoContent();
    }
}
