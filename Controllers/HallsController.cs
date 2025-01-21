using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Eventique.Data;
using Eventique.Models;
using Microsoft.AspNetCore.Identity;

namespace Eventique.Controllers
{
    public class HallsController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        ApplicationDbContext context;

        public HallsController(ApplicationDbContext _context, UserManager<IdentityUser> userManager,
             SignInManager<IdentityUser> signInManager)
        {
            context = _context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            context.Users.ToList();
            return View(context.Hotels.ToList());
        }

        [HttpPost]
        [Route("CreateHall")]
        public async Task<IActionResult> CreateHall(string Name, string Address, int PhoneNumber, string HallType, string _Email, string _Password)
        {
            var user = new IdentityUser { Email = _Email, UserName = _Email, NormalizedEmail = _Email.ToUpper() };

            var result = await _userManager.CreateAsync(user, _Password);
            await _userManager.AddToRoleAsync(user, "WeddingHall");
            await _signInManager.SignInAsync(user, isPersistent: false);
            WeddingHall w = new WeddingHall()
            {
                Name = Name,
                Address = Address,
                PhoneNumber = PhoneNumber,
                HallType = HallType,
                Users = user

            };
            context.Hotels.Add(w);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("RemoveHall")]
        public IActionResult RemoveHall(int id)
        {
            var WeddingHall = context.Hotels.Find(id);
            context.Hotels.Remove(WeddingHall);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Halls/FindHall/{id}")]
        public IActionResult FindHall(int id)
        {
            var WeddingHall = context.Hotels.Find(id);
            //ArrayList li = new ArrayList();
            //li.Add(Photographer.Ph_Id);
            //li.Add(Photographer.Ph_Name);
            //li.Add(Photographer.Ph_Address);
            //li.Add(Photographer.Ph_PhoneNumber);
            Dictionary<string, string> HallsList = new Dictionary<string, string>();
            HallsList.Add("ID", WeddingHall.ID.ToString());
            HallsList.Add("Name", WeddingHall.Name);
            HallsList.Add("Address", WeddingHall.Address);
            HallsList.Add("PhoneNumber", WeddingHall.PhoneNumber.ToString());
            HallsList.Add("HallType", WeddingHall.HallType);

            return new JsonResult(HallsList);
        }


        [HttpPost]
        [Route("UpdateHall")]
        public IActionResult UpdateHall(int ID, string Name, string Address, string PhoneNumber, string HallType)
        {
            var WeddingHall = context.Hotels.Find(ID);
            //photographer.Ph_Id = Ph_Id;
            WeddingHall.Name = Name;
            WeddingHall.Address = Address;
            WeddingHall.PhoneNumber = int.Parse(PhoneNumber);
            WeddingHall.HallType = HallType;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
