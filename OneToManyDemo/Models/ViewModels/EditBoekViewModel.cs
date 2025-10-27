using System.ComponentModel.DataAnnotations;

namespace OneToManyDemo.Models.ViewModels
{
    public class EditBoekViewModel
    {
        public int BoekId { get; set; }
        [Required(ErrorMessage = "Titel is verplicht")]
        public string Titel { get; set; }
        [Required(ErrorMessage = "Auteur is verplicht")]
        public int AuteurId { get; set; }              //maak AuteurId nullable
        public List<Auteur>? Auteurs { get; set; }      //maak Auteurs LIST nullable



        //edited

        public bool IsAvailable { get; set; }
        public bool IsNewRelease { get; set; }
        public bool IsBestseller { get; set; }

        [Required(ErrorMessage = "Een optie moet worden selecteerd")]
        public int? BindingType { get; set; }


    }
}
