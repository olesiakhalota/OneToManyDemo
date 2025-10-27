using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneToManyDemo.Data;
using OneToManyDemo.Models;
using OneToManyDemo.Models.ViewModels;

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
                .Select(b => new BoekAuteurViewModel
                {
                    BoekId = b.BoekId,
                    Titel = b.Titel,
                    AuteurNaam = b.Auteur.Naam
                });
            //var boeken = await _context.Boeks.ToListAsync();
            return View(boekAuteurViewModel);
        }


        public async Task<IActionResult> Filters(int? GeselecteerdeAuteurId)  // ? = nullable
        {
            var auteurs = await _context.Auteurs.ToListAsync();

            IQueryable<Boek> boekenQuery = _context.Boeks.Include(b => b.Auteur);

            if (GeselecteerdeAuteurId.HasValue)
            {
                boekenQuery = boekenQuery.Where(b => b.AuteurId == GeselecteerdeAuteurId);
            }

            var boeken = await boekenQuery.ToListAsync();

            var boekenViewModel = boeken.Select(b => new BoekAuteurViewModel
            {
                BoekId = b.BoekId,
                Titel = b.Titel,
                AuteurNaam = b.Auteur.Naam
            }).ToList();

            var filtersViewModel = new BoekenViewModel
            {
                Auteurs = auteurs,
                Boeken = boekenViewModel,
                GeselecteerdeAuteurId = GeselecteerdeAuteurId ?? 0  // ?? = NULL-coalescing operator.  NULL? -> 0,  als niet NULL -> niets doen
            };

            return View(filtersViewModel);
        }


        //MY ONE VIEW ACTION  
        //QUERY STRING - een parameter in url met ? teken b.v. "?GeselecteerdeAuteurId = 1"
        public async Task<IActionResult> FilterONE(int? GeselecteerdeAuteurId)
        {
            var auteurs = await _context.Auteurs.ToListAsync();

            IQueryable<Boek> boekenQuery = _context.Boeks.Include(b => b.Auteur);

            if (GeselecteerdeAuteurId.HasValue && GeselecteerdeAuteurId > 0)
            {
                boekenQuery = boekenQuery.Where(b => b.AuteurId == GeselecteerdeAuteurId.Value);
            }

            var boeken = await boekenQuery.ToListAsync();

            var viewModel = new BoekenViewModelONE
            {
                Auteurs = auteurs,
                Boeken = boeken,
                GeselecteerdeAuteurId = GeselecteerdeAuteurId ?? 0
            };

            return View(viewModel);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var auteurs = await _context.Auteurs.ToListAsync();
            var viewModel = new CreateBoekViewModel
            {

                Auteurs = auteurs,
            };

            return View(viewModel);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]  /* voor security van controol voraal HTTPPOST */
        public async Task<IActionResult> Create(CreateBoekViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Auteurs = await _context.Auteurs.ToListAsync();
                return View(viewModel);
            }

            //create a new book and beware in db
            var newBoek = new Boek
            {
                Titel = viewModel.Titel,
                AuteurId = viewModel.AuteurId,
                IsAvailable = viewModel.IsAvailable,
                IsNewRelease = viewModel.IsNewRelease,
                IsBestseller = viewModel.IsBestseller,
                BindingType = viewModel.BindingType
            };
            _context.Boeks.Add(newBoek); //toegang to DB
            await _context.SaveChangesAsync();  //update 

            return RedirectToAction(nameof(Filters));
        }

        //lezen = http get
        public async Task<IActionResult> Details(int? id) //id is nullable
        {
            //testing if id is nullable
            if (id == null) //omdat we testen hier if nullable is -> than we have to put ? teken in id parameter in the function  //green line should appear, hove over and read the message there -> set "?" teken to -> Details(int? id) //defencive programming - verdedigen jezelf
            {
                return NotFound();
            }
            //inlezen en viden deze id
            var boek = await _context.Boeks
                .Include(b => b.Auteur)
                .FirstOrDefaultAsync(b => b.BoekId == id);

            //testing if book is nullable
            if (boek == null)  //defensive programming -> if you havent find the book - you have NotFound error
            {
                return NotFound();
            }

            //view maken

            return View(boek);
        }

        //generic repository pattern 
        //goed bestudeer and zien 
        //unit of work design pattern
        //super complex program

        //OLD: DTO = data transfer object -> NOW: ViewModel

        [HttpGet]
        public async Task<IActionResult> Edit(int? id) //id is ook nullable
        {
            if (id == null) //test om id niet null is
            {
                return NotFound();
            }

            var boek = await _context.Boeks
                .Include(b => b.Auteur)
                .FirstOrDefaultAsync(b => b.BoekId == id);

            if (boek == null)
            {
                return NotFound();
            }

            var auteurs = await _context.Auteurs.ToListAsync();

            //create a view EditViewModel

            var viewModel = new EditBoekViewModel
            {
                BoekId = boek.BoekId,
                Titel = boek.Titel,
                AuteurId = boek.AuteurId,
                Auteurs = auteurs,
                IsAvailable = (bool)boek.IsAvailable.GetValueOrDefault(),//instead of casting and you will get rid of the green lines
                IsNewRelease = (bool)boek.IsNewRelease.GetValueOrDefault(),
                IsBestseller = (bool)boek.IsBestseller.GetValueOrDefault(),
                BindingType = boek.BindingType
            };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditBoekViewModel viewModel)
        {
            if (!ModelState.IsValid)                                         //testing if the ModelState is not valid, als we problemen zijn
            {
                viewModel.Auteurs = await _context.Auteurs.ToListAsync();    //viewModel.Auteurs pakken

                return View(viewModel);                                      //and hetzelfde view tonen
            }
            var boek = await _context.Boeks
                .FindAsync(viewModel.BoekId);

            if (boek == null)
            {
                return NotFound(viewModel);
            }

            var auteurs = await _context.Auteurs.ToListAsync();

            //viewModel = new EditBoekViewModel
            //{
            //	BoekId = boek.BoekId,
            //	Titel = boek.Titel,
            //	AuteurId = boek.AuteurId,
            //	Auteurs = auteurs,
            //	IsAvailable = (bool)boek.IsAvailable,
            //	IsNewRelease = (bool)boek.IsNewRelease,
            //	IsBestseller = (bool)boek.IsBestseller,
            //	BindingType = boek.BindingType
            //};

            boek.Titel = viewModel.Titel;
            boek.AuteurId = viewModel.AuteurId;
            boek.IsAvailable = viewModel.IsAvailable;
            boek.IsNewRelease = viewModel.IsNewRelease;
            boek.IsBestseller = viewModel.IsBestseller;
            boek.BindingType = viewModel.BindingType;

            _context.Update(boek);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Filters));

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boek = await _context.Boeks
                .Include(b => b.Auteur)
                .FirstOrDefaultAsync(b => b.BoekId == id);
            if (boek == null)
            {
                return NotFound();
            }

            return View(boek);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var boek = await _context.Boeks.FindAsync(id);
            if (boek == null)
            {
                return NotFound();
            }


            _context.Boeks.Remove(boek);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Filters));
        }






    }
}
