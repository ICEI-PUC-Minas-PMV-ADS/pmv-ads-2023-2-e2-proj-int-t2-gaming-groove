using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GamingGroove.Data;
using GamingGroove.Models;
namespace GamingGroove
{
    public class PerfilPageController : Controller
    {
        private readonly GamingGrooveDbContext _contexto;

        public PerfilPageController(GamingGrooveDbContext contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index(string user)
        {
            var usuario = _contexto.Usuarios.FirstOrDefault(u => u.nomeUsuario == user);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        private string ObterBiografiaDoUsuario(int user)
        {
            var usuario = _contexto.Usuarios.FirstOrDefault(u => u.usuarioId == user);
            return usuario != null ? usuario.biografia : string.Empty;
        }
    }
}
