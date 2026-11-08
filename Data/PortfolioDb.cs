using Microsoft.EntityFrameworkCore;

public class PortfolioDb : DbContext
{
    public PortfolioDb(DbContextOptions<PortfolioDb> options) : base(options)
    {
    }

    public DbSet<Project> Projecten => Set<Project>();
    public DbSet<Blogpost> Blogposts => Set<Blogpost>();

    // Startdata: blogposts kun je alleen opvragen, dus ze moeten al in de database staan
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blogpost>().HasData(
            new Blogpost
            {
                Id = 1,
                Titel = "Mijn eerste Web API",
                Inhoud = "In deze blogpost vertel ik hoe ik mijn eerste API heb gemaakt met ASP.NET Core.",
                Datum = new DateTime(2026, 11, 1)
            },
            new Blogpost
            {
                Id = 2,
                Titel = "Wat ik heb geleerd over JavaScript",
                Inhoud = "Voor mijn portfoliosite heb ik geleerd hoe je met JavaScript de DOM aanpast en data ophaalt met fetch.",
                Datum = new DateTime(2026, 10, 1)
            }
        );
    }
}
