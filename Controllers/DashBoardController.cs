using System.Diagnostics;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using realEstateWebApp.Areas.Identity.Data;
using realEstateWebApp.Models;

namespace realEstateWebApp.Controllers;

public class DashboardController : Controller
{
    
    private readonly ApplicationDbContext _context;

    public DashboardController(ApplicationDbContext context)
    {
        _context = context;
    }

    //Nous renvoies vers les vues respectives

    //Index du Dashboard
    public IActionResult Index()
    {
        return View();
    }

    //Vue du chat
    public IActionResult Inbox()
    {
        return View();
    }

    //Vue du formulaire d'ajout d'un bien
    public IActionResult SellEstate()
    {
        return View();
    }

    //Vue de la page pour gérer l'abonnement
    public IActionResult MySubscription()
    {
        return View();
    }

   

    // GET: BienModel
    // Affiche les biens de la personne connectée
    public async Task<IActionResult> MyEstate()
    {
        return _context.Biens != null ?
                    View(await _context.Biens.Where(b => b.IdUser.Equals(User.Identity.GetUserId())).ToListAsync()) :
                    Problem("Entity set 'ApplicationDbContext.Bien'  is null.");
    }

    //
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

