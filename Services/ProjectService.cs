using Microsoft.EntityFrameworkCore;

// Laag 2 (Business Logic): de logica voor projecten. Praat met de database via PortfolioDb.
public class ProjectService
{
    private readonly PortfolioDb _db;

    public ProjectService(PortfolioDb db)
    {
        _db = db;
    }

    public async Task<List<ProjectResponse>> GetAll()
    {
        var projects = await _db.Projects.ToListAsync();
        return projects.Select(project => ToResponse(project)).ToList();
    }

    public async Task<ProjectResponse?> GetById(int id)
    {
        var project = await _db.Projects.FindAsync(id);
        if (project == null)
        {
            return null;
        }
        return ToResponse(project);
    }

    public async Task<ProjectResponse> Create(CreateProjectRequest request)
    {
        // DTO -> entity
        var project = new Project
        {
            Titel = request.Titel,
            Beschrijving = request.Beschrijving,
            Categorie = request.Categorie,
            GitHubUrl = request.GitHubUrl,
            Datum = request.Datum
        };

        _db.Projects.Add(project);
        await _db.SaveChangesAsync();
        return ToResponse(project);
    }

    public async Task<bool> Update(int id, UpdateProjectRequest request)
    {
        var project = await _db.Projects.FindAsync(id);
        if (project == null)
        {
            return false;
        }

        // DTO -> entity
        project.Titel = request.Titel;
        project.Beschrijving = request.Beschrijving;
        project.Categorie = request.Categorie;
        project.GitHubUrl = request.GitHubUrl;
        project.Datum = request.Datum;

        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var project = await _db.Projects.FindAsync(id);
        if (project == null)
        {
            return false;
        }

        _db.Projects.Remove(project);
        await _db.SaveChangesAsync();
        return true;
    }

    // Entity -> DTO: zet een Project om naar een ProjectResponse
    private static ProjectResponse ToResponse(Project project)
    {
        return new ProjectResponse(project.Id, project.Titel, project.Beschrijving, project.Categorie, project.GitHubUrl, project.Datum);
    }
}
