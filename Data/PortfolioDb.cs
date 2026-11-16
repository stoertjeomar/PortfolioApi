using Microsoft.EntityFrameworkCore;

public class PortfolioDb : DbContext
{
    public PortfolioDb(DbContextOptions<PortfolioDb> options) : base(options)
    {
    }

    public DbSet<Project> Projects => Set<Project>();
    public DbSet<Blogpost> Blogposts => Set<Blogpost>();
}
