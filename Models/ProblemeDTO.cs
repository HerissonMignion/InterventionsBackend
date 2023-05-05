
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InterventionsBackend.Entities;

namespace InterventionsBackend.Models;

public class ProblemeDTO {

    
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    [MinLength(3)]
    public string? prenom { get; set; }

    [Required]
    [StringLength(50)]
    [MaxLength(50)]
    public string? nom { get; set; }

    [Required]
    public int noTypeProbleme { get; set; }


    [StringLength(100)]
    public string? descriptionTypeProbleme { get; set; }

    [StringLength(100)]
    [EmailAddress]
    public string? courriel { get; set; }

    [StringLength(100)]
    public string? courrielConfirmation { get; set; }

    [StringLength(10)]
    [MinLength(10)]
    [MaxLength(10)]
    [RegularExpression("[0-9]+")]
    public string? telephone { get; set; }

    [Required]
    [StringLength(20)]
    public string? notification { get; set; }

    [StringLength(20)]
    public string? noUnite { get; set; }

    [Required]
    [StringLength(500)]
    [MinLength(5)]
    public string? descriptionProbleme { get; set; }

    public DateTime dateProbleme { get; set; }

    // jamais de navigation dans les DTO    

}



