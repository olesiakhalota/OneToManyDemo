namespace OneToManyDemo.Models.ViewModels
{
	public class BoekenViewModelONE
	{
		public List<Auteur> Auteurs { get; set; }
		public List<Boek> Boeken { get; set; }
		public int GeselecteerdeAuteurId { get; set; }


		//View Model - is a class . you put all what you needed. you cany extend class people 
		//view model - maaken and daarna view maken
		//maak erst view model in View model  map. -> extend classen -> no problem with datatbase bebben 
		//
	}
}
