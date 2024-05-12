using Microsoft.AspNetCore.Mvc;
using InventarioFIIAPP.Models;
using Microsoft.EntityFrameworkCore;
using InventarioFIIAPP.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace InventarioFIIAPP.Controllers;

public class UsuarioController : Controller
{
    private readonly InventarioFIIAPPDbContext _context;

    public UsuarioController(InventarioFIIAPPDbContext context)
    {
        _context = context;
    }

    // GET: Movies/Details/5
    public async Task<IActionResult> Index(string filter)
    {
        var qry = _context.Usuarios.AsNoTracking().AsQueryable();
        if (!string.IsNullOrWhiteSpace(filter))
        {
            qry = qry.Where(u => u.Nombre.Contains(filter));
        }
        var usuarios = qry;
        return View(usuarios);
    }

    [HttpGet]
    public PartialViewResult Create()
    {
        return PartialView("AddUsuario");
    }

    [HttpPost]
    public async Task<IActionResult> Create(Usuario model)
    {
        await _context.Usuarios.AddAsync(model);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }
}