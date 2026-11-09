using System.ComponentModel.DataAnnotations;

// Wat de client stuurt bij POST (aanmaken) van een blogpost (zonder Id)
public class CreateBlogpostRequest
{
    [Required]
    [StringLength(100)]
    public string Titel { get; set; } = "";

    [Required]
    public string Inhoud { get; set; } = "";

    public DateTime Publicatiedatum { get; set; }
}
