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
    public class HomePageController : Controller
    {
        public IActionResult Index()
        {           
            return View();
        }
    }
}    