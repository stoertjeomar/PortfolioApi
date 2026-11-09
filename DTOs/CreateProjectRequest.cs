using System.ComponentModel.DataAnnotations;

// Wat de client stuurt bij POST (aanmaken) van een project (zonder Id)
public class CreateProjectRequest
{
    [Required]
    [StringLength(100)]
    public string Titel { get; set; } = "";

    [Required]
    public string Beschrijving { get; set; } = "";

    [Required]
    public string Categorie { get; set; } = "";

    [Required]
    [Url]
    public string GitHubUrl { get; set; } = "";

    public DateTime Datum { get; set; }
}
