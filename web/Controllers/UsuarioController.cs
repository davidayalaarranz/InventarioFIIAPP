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
    public IActionResult Index(string filter)
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

    [HttpGet]
    public async Task<PartialViewResult> Edit(int? id)
    {
        var model = await _context.Usuarios.FirstAsync(u => u.IdUsuario == id);

        return PartialView("EditUsuario", model);
    }

    [HttpPost]
    public ActionResult Edit(Usuario model)
    {
        var record = _context.Usuarios.Single(t => t.IdUsuario == model.IdUsuario);
        if (record != null)
        {
            _context.Entry(record).CurrentValues.SetValues(model);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<PartialViewResult> Delete(int id)
    {
        var model = await _context.Usuarios.FirstAsync(u => u.IdUsuario == id);
        return PartialView("DeleteUsuario", model);
    }

    [HttpPost]
    public ActionResult Delete(Usuario model)
    {
        if (model != null)
        {
            Usuario? obj = _context.Usuarios.Find(model.IdUsuario);
            _context.Usuarios.Remove(obj);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }
}