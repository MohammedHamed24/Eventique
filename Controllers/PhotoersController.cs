using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Eventique.Data;
using Eventique.Models;
using System.Collections;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Eventique.Controllers
{

    public class PhotoersController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        ApplicationDbContext context;

        public PhotoersController(ApplicationDbContext _context, UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            context = _context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            context.Users.ToList();
            return View(context.Photographers.ToList());
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(string Ph_Name, string Ph_Address, string Ph_PhoneNumber, string _Email, string _Password)
        {
            var user = new IdentityUser { Email = _Email, UserName = _Email, NormalizedEmail = _Email.ToUpper() };

            var result = await _userManager.CreateAsync(user, _Password);
            await _userManager.AddToRoleAsync(user, "Photographer");
            await _signInManager.SignInAsync(user, isPersistent: false);

            Photographer p = new Photographer()
            {
                Ph_Name = Ph_Name,
                Ph_Address = Ph_Address,
                Ph_PhoneNumber = Ph_PhoneNumber,
                Users=user

            };
            context.Photographers.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("Remove")]
        public IActionResult Remove(int id)
        {
            var photographer = context.Photographers.Find(id);
            context.Photographers.Remove(photographer);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Photoers/Find/{id}")]
        public IActionResult Find(int id)
        {
            var Photographer = context.Photographers.Find(id);

            Dictionary<string, string> EmployeeList = new Dictionary<string, string>();
            EmployeeList.Add("Ph_Id", Photographer.Ph_Id.ToString());
            EmployeeList.Add("Ph_Name", Photographer.Ph_Name);
            EmployeeList.Add("Ph_Address", Photographer.Ph_Address);
            EmployeeList.Add("Ph_PhoneNumber", Photographer.Ph_PhoneNumber);

            return new JsonResult(EmployeeList);
        }


        [HttpPost]
        [Route("Update")]
        public IActionResult Update(int Ph_Id, string Ph_Name, string Ph_Address, string Ph_PhoneNumber)
        {
            var photographer = context.Photographers.Find(Ph_Id);
            photographer.Ph_Id = Ph_Id;
            photographer.Ph_Name = Ph_Name;
            photographer.Ph_Address = Ph_Address;
            photographer.Ph_PhoneNumber = Ph_PhoneNumber;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
