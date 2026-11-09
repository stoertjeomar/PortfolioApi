using Microsoft.EntityFrameworkCore;

// Laag 2 (Business Logic): de logica voor blogposts. Praat met de database via PortfolioDb.
public class BlogpostService
{
    private readonly PortfolioDb _db;

    public BlogpostService(PortfolioDb db)
    {
        _db = db;
    }

    public async Task<List<BlogpostResponse>> GetAll()
    {
        var blogposts = await _db.Blogposts.ToListAsync();
        return blogposts.Select(blogpost => ToResponse(blogpost)).ToList();
    }

    public async Task<BlogpostResponse?> GetById(int id)
    {
        var blogpost = await _db.Blogposts.FindAsync(id);
        if (blogpost == null)
        {
            return null;
        }
        return ToResponse(blogpost);
    }

    public async Task<BlogpostResponse> Create(CreateBlogpostRequest request)
    {
        // DTO -> entity
        var blogpost = new Blogpost
        {
            Titel = request.Titel,
            Inhoud = request.Inhoud,
            Publicatiedatum = request.Publicatiedatum
        };

        _db.Blogposts.Add(blogpost);
        await _db.SaveChangesAsync();
        return ToResponse(blogpost);
    }

    public async Task<bool> Update(int id, UpdateBlogpostRequest request)
    {
        var blogpost = await _db.Blogposts.FindAsync(id);
        if (blogpost == null)
        {
            return false;
        }

        // DTO -> entity
        blogpost.Titel = request.Titel;
        blogpost.Inhoud = request.Inhoud;
        blogpost.Publicatiedatum = request.Publicatiedatum;

        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var blogpost = await _db.Blogposts.FindAsync(id);
        if (blogpost == null)
        {
            return false;
        }

        _db.Blogposts.Remove(blogpost);
        await _db.SaveChangesAsync();
        return true;
    }

    // Entity -> DTO: zet een Blogpost om naar een BlogpostResponse
    private static BlogpostResponse ToResponse(Blogpost blogpost)
    {
        return new BlogpostResponse(blogpost.Id, blogpost.Titel, blogpost.Inhoud, blogpost.Publicatiedatum);
    }
}
