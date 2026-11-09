using Microsoft.AspNetCore.Mvc;

// Laag 3 (Presentation): ontvangt requests en kiest het HTTP-resultaat. De logica zit in ProjectService.
[Route("api/[controller]")]
[ApiController]
public class ProjectsController : ControllerBase
{
    private readonly ProjectService _service;

    public ProjectsController(ProjectService service)
    {
        _service = service;
    }

    // GET: api/Projects
    [HttpGet]
    public async Task<ActionResult<List<ProjectResponse>>> GetAll()
    {
        var projects = await _service.GetAll();
        return Ok(projects);
    }

    // GET: api/Projects/5
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

    // POST: api/Projects
    [HttpPost]
    public async Task<ActionResult<ProjectResponse>> Create(CreateProjectRequest request)
    {
        var project = await _service.Create(request);
        return CreatedAtAction(nameof(GetById), new { id = project.Id }, project);
    }

    // PUT: api/Projects/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateProjectRequest request)
    {
        var gelukt = await _service.Update(id, request);
        if (!gelukt)
        {
            return NotFound();
        }
        return NoContent();
    }

    // DELETE: api/Projects/5
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
