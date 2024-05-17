using System.ComponentModel.DataAnnotations.Schema;

namespace OneToManyDemo.Models
{
    public class Boek //one to many relation
    {
        public int BoekId { get; set; }
        public string Titel { get; set; }

        [ForeignKey("Auteur")]
        public int AuteurId { get; set; }
        public Auteur Auteur { get; set; } //one

    }
}
