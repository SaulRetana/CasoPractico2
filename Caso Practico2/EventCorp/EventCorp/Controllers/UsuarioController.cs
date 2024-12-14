using EventCorp.Data;
using EventCorp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventCorp.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly EventCorpDbContext _context;

        public UsuarioController(EventCorpDbContext context)
        {
            _context = context;
        }

        // Listado de usuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
        }

        // Crear usuario
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NombreUsuario,NombreCompleto,Correo,Telefono,Contraseña,Rol")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }
    }
}
