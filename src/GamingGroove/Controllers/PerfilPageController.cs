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
        public IActionResult Index()
        {
            return View();
        }
    }
}
