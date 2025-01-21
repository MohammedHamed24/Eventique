using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Eventique.Data;
using Eventique.Models;
using Microsoft.AspNetCore.Identity;

namespace Eventique.Controllers.Admin
{
    public class DesController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        ApplicationDbContext context;
        public DesController(ApplicationDbContext _context, UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            context = _context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            context.Users.ToList();
            return View(context.Designers.ToList());
        }
        [HttpPost]
        [Route("AddDesigner")]
        public async Task<IActionResult> AddDesigner(string Name, int PhoneNumber, string Address, string ShopName ,string _Email,string _password )
        {
            var user = new IdentityUser { Email = _Email, UserName = _Email, NormalizedUserName = _Email.ToUpper()  };
            var result = await _userManager.CreateAsync(user,_password);
            await _userManager.AddToRoleAsync(user, "Designer");
            await _signInManager.SignInAsync(user, isPersistent: false);
            var designer = new Designer
            {
                Name = Name,
                PhoneNumber = PhoneNumber,
                Address = Address,
                ShopName = ShopName,
                Users = user
            };
            context.Designers.Add(designer);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost]
        [Route("RemoveDesigner")]
        public IActionResult RemoveDesigner(int id)
        {
            var desinger = context.Designers.Find(id);
            context.Designers.Remove(desinger);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Des/FindDesigner/{id}")]
        public IActionResult FindDesigner(int id)
        {
            var designer = context.Designers.Find(id);
            Dictionary<string, string> DList = new Dictionary<string, string>();
            DList.Add("ID", designer.ID.ToString());
            DList.Add("Name", designer.Name);
            DList.Add("PhoneNumber", designer.PhoneNumber.ToString());
            DList.Add("Address", designer.Address);
            DList.Add("ShopName", designer.ShopName);
            return new JsonResult(DList);
        }

        [HttpPost]
        [Route("UpdateDesigner")]
        public IActionResult UpdateDesigner(int ID, string Name, string PhoneNumber, string Address, string ShopName)
        {
            //var designer = context.Designers.Where(d => d.ID == ID).FirstOrDefault();
            var designer = context.Designers.Find(ID);
            //designer.ID = ID;
            designer.Name = Name;
            designer.PhoneNumber = int.Parse(PhoneNumber);
            designer.Address = Address;
            designer.ShopName = ShopName;
            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
