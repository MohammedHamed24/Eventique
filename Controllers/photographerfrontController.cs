using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventique.Data;
using Eventique.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eventique.Controllers
{
    public class photographerfrontController : Controller
    {
        private readonly ApplicationDbContext context;

        public photographerfrontController(ApplicationDbContext _context)
        {
            context = _context;
        }
        public IActionResult PhoView()
        {
            ViewData["ListAlbum"] = context.Albums.ToList();
            return View(context.Images.ToList());
        }

        //[HttpPost]
        //public IActionResult PhoView(int id)
        //{
        //    Photographer p = new Photographer();
        //    ViewData["photographer"] = context.Photographers.Where(p => p.Ph_Id == id).FirstOrDefault();
        //    return View(p);
        //}
    }
}