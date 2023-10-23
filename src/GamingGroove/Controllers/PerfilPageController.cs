using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GamingGroove.Data;
using GamingGroove.Models;
using GamingGroove.Views.PerfilPage;
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
            var viewModel = new PerfilPageViewModel(_contexto);
            viewModel.OnGet(user);
            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        private string ObterBiografiaDoUsuario(int user)
        {
            var usuario = _contexto.Usuarios.FirstOrDefault(u => u.usuarioId == user);
            return usuario != null ? usuario.biografia : string.Empty;
        }
    }
}
