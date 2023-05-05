
using System.ComponentModel.DataAnnotations;

namespace InterventionsBackend.Models;

public class TypeProblemeDTO {

    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; }


}


