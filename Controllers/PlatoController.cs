using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Chefs.Models;

public class PlatoController : Controller
{
    private readonly MyContext _context;

    public PlatoController(MyContext context)
    {
        _context = context;
    }

    // Mostrar lista de platos
    public async Task<IActionResult> Index()
    {
        var platos = await _context.Platos.Include(p => p.Chef).ToListAsync();
        return View(platos);
    }

    // Mostrar formulario para crear un nuevo plato
    public IActionResult Create()
    {
        return View();
    }

 // Guardar el nuevo plato en la base de datos
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("PlatoId, Nombre, Calorias, Sabor, ChefId")] Plato plato)
{
    if (ModelState.IsValid)
    {
        _context.Add(plato);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index", "Home"); // Redirecciona a la acción Index del controlador Home
    }
    return View("~/Views/Home/FormularioPlato.cshtml", plato);
}
    
    // Otras acciones como Edit, Delete, Details, etc.
}
