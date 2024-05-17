using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;

namespace OneToManyDemo.Models
{
    public class Auteur //many to one relation
    {
        public int AuteurId { get; set; }
        [Required]                         //data annotation
        [StringLength(50)]
        public string Naam { get; set; }
        public ICollection<Boek> Boeken { get; set; }  //many    // ICollection<> better than List<>
    }
}
