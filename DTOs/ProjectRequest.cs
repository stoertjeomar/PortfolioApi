using System.ComponentModel.DataAnnotations;

// Wat de client stuurt bij POST en PUT (zonder Id)
public class ProjectRequest
{
    [Required]
    [StringLength(100)]
    public string Naam { get; set; } = "";

    [Required]
    public string Beschrijving { get; set; } = "";

    [Required]
    public string Taal { get; set; } = "";

    [Range(2000, 2100)]
    public int Jaar { get; set; }
}
