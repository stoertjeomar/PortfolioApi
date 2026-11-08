using Microsoft.EntityFrameworkCore;

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

    // Zet een Blogpost (entity) om naar een BlogpostResponse (DTO)
    private static BlogpostResponse ToResponse(Blogpost blogpost)
    {
        return new BlogpostResponse(blogpost.Id, blogpost.Titel, blogpost.Inhoud, blogpost.Datum);
    }
}
