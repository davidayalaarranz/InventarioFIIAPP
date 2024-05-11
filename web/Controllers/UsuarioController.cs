using Microsoft.AspNetCore.Mvc;
using InventarioFIIAPP.Models;
using Microsoft.EntityFrameworkCore;

namespace InventarioFIIAPP.Controllers;

public class UsuarioController : Controller
{
    private readonly InventarioFIIAPPDbContext _context;

    public UsuarioController(InventarioFIIAPPDbContext context)
    {
        _context = context;
    }

    // GET: Movies/Details/5
    public async Task<IActionResult> Index()
    {
        var usuarios = await _context.Usuarios.AsNoTracking().ToListAsync();
        return View(usuarios);
    }
    
}