using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneToManyDemo.Data;
using OneToManyDemo.Models;

namespace OneToManyDemo.Controllers
{
    public class BoekenController : Controller
    {
        readonly BoekenDBContext _context;

        public BoekenController(BoekenDBContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var boekAuteurViewModel = _context.Boeks
                .Include(b => b.Auteur)
                .Select(b => new boekAuteurViewModel
                {
                    BoekId = b.BoekId,
                    Titel = b.Titel,
                    AuteurNaam = b.Auteur.Naam
                });
            //var boeken = await _context.Boeks.ToListAsync();
            return View();
        }

        


    }
}
