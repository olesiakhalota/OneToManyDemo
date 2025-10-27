using System.ComponentModel.DataAnnotations;

namespace OneToManyDemo.Models.ViewModels
{
	public class CreateBoekViewModel
	{
        [Required (ErrorMessage = "Titlel is verplicht")]
        public string Titel { get; set; }

		[Required(ErrorMessage = "Auteur is verplicht")]

		[Display (Name = "Auteur")]
		public int AuteurId { get; set; }
        public List<Auteur>? Auteurs { get; set; }  /* ? = nullable */

        //including changes checkboxes and radiobuttons
        public bool IsAvailable { get; set; }
        public bool IsNewRelease { get; set; }
        public bool IsBestseller { get; set; }

        [Required(ErrorMessage = "Een optie moet worden selecterd")]
        public int BindingType { get; set; }


    }
}
