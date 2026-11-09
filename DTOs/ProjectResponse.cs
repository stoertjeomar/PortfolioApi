// Wat de API terugstuurt voor een project
public record ProjectResponse(int Id, string Titel, string Beschrijving, string Categorie, string GitHubUrl, DateTime Datum);
