using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ProjectenController : ControllerBase
{
    private readonly ProjectService _service;

    public ProjectenController(ProjectService service)
    {
        _service = service;
    }

    // GET: api/Projecten
    [HttpGet]
    public async Task<ActionResult<List<ProjectResponse>>> GetAll()
    {
        var projecten = await _service.GetAll();
        return Ok(projecten);
    }

    // GET: api/Projecten/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ProjectResponse>> GetById(int id)
    {
        var project = await _service.GetById(id);
        if (project == null)
        {
            return NotFound();
        }
        return Ok(project);
    }

    // POST: api/Projecten
    [HttpPost]
    public async Task<ActionResult<ProjectResponse>> Create(ProjectRequest request)
    {
        var project = await _service.Create(request);
        return CreatedAtAction(nameof(GetById), new { id = project.Id }, project);
    }

    // PUT: api/Projecten/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ProjectRequest request)
    {
        var gelukt = await _service.Update(id, request);
        if (!gelukt)
        {
            return NotFound();
        }
        return NoContent();
    }

    // DELETE: api/Projecten/5
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
