using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneToManyDemo.Models
{
    public class Boek //one to many relation
    {
        [Key]
        public int BoekId { get; set; }
        [StringLength(50)]
        public string Titel { get; set; }

        [ForeignKey("Auteur")]
        public int AuteurId { get; set; }
        public Auteur Auteur { get; set; } //one


		//including changes checkboxes and radiobuttons
		public bool? IsAvailable { get; set; }  // в наличии?
        public bool? IsNewRelease { get; set; }  // новый релиз?
        public bool? IsBestseller { get; set; }  // бестселлер?

        public int? BindingType { get; set; }  // обложка 

        //do migration and update database
        //update modelview

        public string GetBindingType  // получить тип привязки
        {
            get  //omdat readonly
            {
                return BindingType switch
                {
                    1 => "Paperback",
                    2 => "Hardcover",
                    3 => "E-book",
                    _ => "Unknown"  // _ = geen value zijn
                };
            }
        }





    }
}
