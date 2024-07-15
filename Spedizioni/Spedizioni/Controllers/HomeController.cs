using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Spedizioni.Models;

namespace Spedizioni.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, IConfiguration conf)
    {
        _logger = logger;
        var connection = new System.Data.SqlClient.SqlConnection(conf.GetConnectionString("AppDb"));
        connection.Open();
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }


    ///-----------PAGINA CONTATTI------------------------------------------------
    public IActionResult Contatti()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Submit(Contact contact)
    {
        if (ModelState.IsValid)
        {
            // Qui puoi aggiungere il codice per gestire il contatto, come inviare un'email
            TempData["SuccessMessage"] = "Il tuo messaggio è stato inviato con successo!";
            return RedirectToAction("Index");
        }

        return View("Index", contact);
    }





    /*--------------------------------------------------------*/
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

