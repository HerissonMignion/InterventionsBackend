using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace InterventionsBackend.Entities;

[Table("Problemes")]
public class Probleme
{

    private DateTime _dateProbleme = DateTime.Now;

    public DateTime dateProbleme
    {
        get
        {
            return this._dateProbleme;
        }
        set
        {
            this._dateProbleme = value;
        }
    }


    [Key]
    public int Id { get; set; }

    [Required]
    [MinLength(3)]
    [StringLength(50)]
    [MaxLength(50)]
    public string prenom { get; set; }


    public string nom { get; set; }

    public int noTypeProbleme { get; set; }

    public string courriel { get; set; }

    public string courrielConfirmation { get; set; }

    public string telephone { get; set; }

    public int notification { get; set; }

    public string noUnite { get; set; }

    public string descriptionProbleme { get; set; }

    public DateTime date { get; set; }

    // TODO: les annotations

}
