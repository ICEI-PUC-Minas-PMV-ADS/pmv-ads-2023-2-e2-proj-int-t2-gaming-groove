using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GamingGroove.Data;
using GamingGroove.Models; // Importe o namespace correto para acessar a classe UsuarioModel

namespace GamingGroove
{
    public class PerfilPageController : Controller
    {
        private readonly GamingGrooveDbContext _contexto;

        public PerfilPageController(GamingGrooveDbContext contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index(int id)
        {
            var usuario = _contexto.Usuarios.FirstOrDefault(u => u.usuarioId == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }
    }
}
