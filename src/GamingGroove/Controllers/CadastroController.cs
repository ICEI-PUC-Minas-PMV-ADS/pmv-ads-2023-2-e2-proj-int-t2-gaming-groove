using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GamingGroove.Data;
using GamingGroove.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace GamingGroove
{
    public class CadastroController : Controller
    {
        private readonly GamingGrooveDbContext _context;

        public CadastroController(GamingGrooveDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("usuarioId,nomeUsuario,nomeCompleto,dataNascimento,email,senha,iconePerfil,capaPerfil,fotosGaleria,jogosFavoritos,biografia,registrationDate,tipoUsuario")] UsuarioModel usuarioModel)
        {
            if (ModelState.IsValid)
            {
                usuarioModel.senha = BCrypt.Net.BCrypt.HashPassword(usuarioModel.senha);
                _context.Add(usuarioModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login", "Login");
            }

            return View("Login");
        }


    }
}    