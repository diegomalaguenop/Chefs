using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Chefs.Models;

public class ChefController : Controller
{
    private readonly MyContext _context;

    public ChefController(MyContext context)
    {
        _context = context;
    }

    // Mostrar lista de chefs
    public async Task<IActionResult> Index()
    {
        var chefs = await _context.Chefs.Include(c => c.Platos).ToListAsync();
        return View(chefs);
    }

    // Mostrar formulario para crear un nuevo chef
    public IActionResult Create()
    {
        return View();
    }

[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("ChefId, Nombre, FechaNacimiento")] Chef chef)
{
    if (ModelState.IsValid)
    {
        if (DateTime.Now.Year - chef.FechaNacimiento.Year < 18)
        {
            ModelState.AddModelError("FechaNacimiento", "El cocinero debe tener al menos 18 años.");
            return View("~/Views/Home/FormularioChef.cshtml", chef);
        }
        
        _context.Add(chef);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index", "Home"); // Redirecciona a la acción Index del controlador Home
    }
    return View("~/Views/Home/FormularioChef.cshtml", chef);
}
    
    // Otras acciones como Edit, Delete, Details, etc.
}
