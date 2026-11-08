using Microsoft.EntityFrameworkCore;

public class ProjectService
{
    private readonly PortfolioDb _db;

    public ProjectService(PortfolioDb db)
    {
        _db = db;
    }

    public async Task<List<ProjectResponse>> GetAll()
    {
        var projecten = await _db.Projecten.ToListAsync();
        return projecten.Select(project => ToResponse(project)).ToList();
    }

    public async Task<ProjectResponse?> GetById(int id)
    {
        var project = await _db.Projecten.FindAsync(id);
        if (project == null)
        {
            return null;
        }
        return ToResponse(project);
    }

    public async Task<ProjectResponse> Create(ProjectRequest request)
    {
        var project = new Project
        {
            Naam = request.Naam,
            Beschrijving = request.Beschrijving,
            Taal = request.Taal,
            Jaar = request.Jaar
        };

        _db.Projecten.Add(project);
        await _db.SaveChangesAsync();
        return ToResponse(project);
    }

    public async Task<bool> Update(int id, ProjectRequest request)
    {
        var project = await _db.Projecten.FindAsync(id);
        if (project == null)
        {
            return false;
        }

        project.Naam = request.Naam;
        project.Beschrijving = request.Beschrijving;
        project.Taal = request.Taal;
        project.Jaar = request.Jaar;

        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var project = await _db.Projecten.FindAsync(id);
        if (project == null)
        {
            return false;
        }

        _db.Projecten.Remove(project);
        await _db.SaveChangesAsync();
        return true;
    }

    // Zet een Project (entity) om naar een ProjectResponse (DTO)
    private static ProjectResponse ToResponse(Project project)
    {
        return new ProjectResponse(project.Id, project.Naam, project.Beschrijving, project.Taal, project.Jaar);
    }
}
