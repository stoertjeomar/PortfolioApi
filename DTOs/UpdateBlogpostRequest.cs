using System.ComponentModel.DataAnnotations;

// Wat de client stuurt bij PUT (wijzigen) van een blogpost (zonder Id)
public class UpdateBlogpostRequest
{
    [Required]
    [StringLength(100)]
    public string Titel { get; set; } = "";

    [Required]
    public string Inhoud { get; set; } = "";

    public DateTime Publicatiedatum { get; set; }
}
