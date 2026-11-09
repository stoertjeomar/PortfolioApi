using Microsoft.EntityFrameworkCore;

// Laag 1 (Data Access): de toegangspoort naar de database via EF Core
public class PortfolioDb : DbContext
{
    public PortfolioDb(DbContextOptions<PortfolioDb> options) : base(options)
    {
    }

    public DbSet<Project> Projects => Set<Project>();
    public DbSet<Blogpost> Blogposts => Set<Blogpost>();
}
