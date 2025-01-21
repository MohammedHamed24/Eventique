using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Eventique.Data;
using Eventique.Models;

namespace Eventique.Controllers
{
    public class AdminsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.usercount = _context.Users.ToList().Count();
            ViewBag.designercount = _context.Designers.ToList().Count();
            ViewBag.photographercount = _context.Photographers.ToList().Count();
            ViewBag.allmember = _context.Users.ToList().Count() +
               _context.Designers.ToList().Count() + _context.Photographers.ToList().Count();
            ViewBag.allimage = _context.Images.ToList().Count();

            return View(_context.Admins.ToList());
        }


        public IActionResult wedgits()
        {

            ViewBag.usercount = _context.Users.ToList().Count();
            ViewBag.designercount = _context.Designers.ToList().Count();
            ViewBag.photographercount = _context.Photographers.ToList().Count();
            ViewBag.hallscount = _context.Hotels.ToList().Count();
            ViewBag.allmember = _context.Users.ToList().Count() +
                _context.Designers.ToList().Count() + _context.Photographers.ToList().Count();
            ViewBag.allRequst = _context.DesignerRequests.ToList().Count() +
               _context.PhotographerRequests.ToList().Count() + _context.WeddingHallsRequests.ToList().Count();

            ViewBag.allimage = _context.Images.ToList().Count();
            ViewBag.imagephoto = _context.Photographers.Where(x => x.ImagePath != null).ToList().Count();

            ViewBag.imagedesigner = _context.Designers.Where(x => x.Designer_ImgPath != null).ToList().Count();
            ViewBag.requstholls = _context.WeddingHallsRequests.ToList().Count();
            ViewBag.imageholls = _context.Hotels.ToList().Count();
            ViewBag.requstphoto = _context.PhotographerRequests.ToList().Count();
            ViewBag.requstdesinger = _context.DesignerRequests.ToList().Count();

            return View(_context.Admins.ToList());
        }


        [HttpPost]
        [Route("AddAdmin")]

        public IActionResult AddAdmin(int ID, string Name)
        {
            var admin = new Eventique.Models.Admin
            {

                Name = Name,
                ID = ID

            };
            _context.Admins.Add(admin);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost]
        [Route("RemoveAdmin")]
        public IActionResult RemoveAdmin(int ID)
        {
            Eventique.Models.Admin admin = _context.Admins.Find(ID);
            _context.Admins.Remove(admin);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Admin/FindAdmin/{id}")]
        public JsonResult FindAdmin(int ID)
        {
            Eventique.Models.Admin admin = _context.Admins.Find(ID);
            return Json(admin);
        }

        [HttpPost]
        [Route("UpdateAdmin")]
        public IActionResult UpdateAdmin(int ID, string Name)
        {

            var admin = _context.Admins.Find(ID);
            admin.ID = ID;
            admin.Name = Name;
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}

//        // GET: Admins
//        public async Task<IActionResult> Index()
//        {


//            Photographer photo = new Photographer();
//            ViewBag.PhotographersCount = _context.Photographers.Count(x=>x.Ph_Requests.Count!=0);
//            return View(await _context.Admins.ToListAsync());
//        }
//        public async Task<IActionResult>Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var admin = await _context.Admins
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (admin == null)
//            {
//                return NotFound();
//            }

//            return View(admin);
//        }

//        // GET: Admins/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Admins/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("ID,Name")] Admin admin)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(admin);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(admin);
//        }

//        // GET: Admins/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var admin = await _context.Admins.FindAsync(id);
//            if (admin == null)
//            {
//                return NotFound();
//            }
//            return View(admin);
//        }

//        // POST: Admins/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Admin admin)
//        {
//            if (id != admin.ID)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(admin);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!AdminExists(admin.ID))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(admin);
//        }

//        // GET: Admins/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var admin = await _context.Admins
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (admin == null)
//            {
//                return NotFound();
//            }

//            return View(admin);
//        }

//        // POST: Admins/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var admin = await _context.Admins.FindAsync(id);
//            _context.Admins.Remove(admin);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool AdminExists(int id)
//        {
//            return _context.Admins.Any(e => e.ID == id);
//        }







//    }
//}
