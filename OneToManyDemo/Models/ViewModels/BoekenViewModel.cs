namespace OneToManyDemo.Models.ViewModels
{
    //[Keyless]
    public class BoekenViewModel
    {
        public int Id { get; set; }       //om te view te generere
        public List<BoekAuteurViewModel> Boeken { get; set; }
        public List<Auteur> Auteurs { get; set; }
        public int GeselecteerdeAuteurId { get; set; }

    }
}
