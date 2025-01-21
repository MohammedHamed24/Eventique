using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Eventique.Data;
using Eventique.Models;
using Eventique.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Eventique.Controllers
{
    public class EditUserController : Controller
    {
        private readonly ApplicationDbContext context;
        private IHostingEnvironment Environment;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<EditUserController> _logger;

        public EditUserController
            (
            ApplicationDbContext _context,
            IHostingEnvironment _environment,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<EditUserController> logger
            )
        {
            context = _context;
            Environment = _environment;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult EditUser()
        {
            var user = User.FindFirst(ClaimTypes.NameIdentifier); 
            Member member = context.Members.Where(m => m.Users.Id == user.Value).FirstOrDefault();
            context.Users.ToList();
            context.Members.ToList();
            context.Images.ToList();
            return View(member);
        }

        [HttpPost]
        public IActionResult EditUser(Member member)
        {
            if (ModelState != null)
            {
                context.Users.ToList();
                context.Members.ToList();

                string wwwPath = this.Environment.WebRootPath;
                string contentPath = this.Environment.ContentRootPath;

                string path = Path.Combine(this.Environment.WebRootPath, "Images");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                List<string> uploadedFiles = new List<string>();
                if (member.ImageFilePath != null)
                {
                    foreach (IFormFile postedFile in member.ImageFilePath)
                    {
                        string fileName = Path.GetFileName(postedFile.FileName);
                        using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                        {
                            postedFile.CopyTo(stream);
                            uploadedFiles.Add(fileName);
                            string imgP = "/Images/" + fileName;
                            var user = User.FindFirst(ClaimTypes.NameIdentifier);
                            Member Edited = context.Members.Where(m => m.Users.Id == user.Value).FirstOrDefault();
                            Edited.Name = member.Name;
                            Edited.PhoneNumber = member.PhoneNumber;
                            Edited.About = member.About;
                            Edited.ImagePath = imgP;
                            context.SaveChanges();
                            return RedirectToAction("EditUser");
                        }
                    }
                }
                else
                {
                    var user = User.FindFirst(ClaimTypes.NameIdentifier);
                    Member Edited = context.Members.Where(m => m.Users.Id == user.Value).FirstOrDefault();
                    Edited.Name = member.Name;
                    Edited.PhoneNumber = member.PhoneNumber;
                    Edited.About = member.About;
                    Edited.ImagePath = member.ImagePath;
                    context.SaveChanges();
                    return RedirectToAction("EditUser");
                }
            }
            return View(member);
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePassVM passVM)
        {
            if(ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if(user == null)
                {
                    return RedirectToAction("");
                }

                var result = await _userManager.ChangePasswordAsync(user, passVM.CurrentPassword, passVM.NewPassword);
                if(!result.Succeeded)
                {
                    foreach (var Error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, Error.Description);
                    }
                    return View();
                }
                await _signInManager.RefreshSignInAsync(user);
                return RedirectToAction("EditUser");
            }
            return View(passVM);
        }

    }
}