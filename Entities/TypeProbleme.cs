using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterventionsBackend.Entities
{

    [Table("TypesProbleme")]
    public class TypeProbleme
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string descriptionTypeProbleme { get; set; }


#region propriétés de navigation

        public IEnumerable<Probleme>? Problemes { get; set; }

#endregion


    }
}