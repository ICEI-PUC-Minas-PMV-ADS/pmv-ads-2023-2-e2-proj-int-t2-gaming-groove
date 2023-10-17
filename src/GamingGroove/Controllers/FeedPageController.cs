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
    public class FeedPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}