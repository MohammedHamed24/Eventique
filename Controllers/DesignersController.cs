
using System;
using System.Collections;
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
    public class DesignersController : Controller
    {
        private readonly ApplicationDbContext context;
        private IHostingEnvironment Environment;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<DesignersController> _logger;

        public DesignersController(ApplicationDbContext _context, IHostingEnvironment _environment,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<DesignersController> logger)
        {
            context = _context;
            Environment = _environment;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }


        public IActionResult TestDesiEdit(int id)
        {
            Designer d = new Designer();
            d = context.Designers.Where(des => des.ID == id).FirstOrDefault();
            context.Images.ToList();
            context.Reviews.ToList();
            context.InvitationCards.ToList();
            context.Users.ToList();
            context.Members.ToList();
            return View(d);
        }

        public IActionResult NewTestDesiEdit()
        {
            return View();
        }
        public IActionResult CreateNewInvitation(int id)
        {
            Designer d = new Designer();
            context.Images.ToList();
            context.InvitationCards.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult CreateNewInvitation(int id, InvitationCard b)
        {
            string wwwPath = this.Environment.WebRootPath;
            string contentPath = this.Environment.ContentRootPath;
            string path = Path.Combine(this.Environment.WebRootPath, "Images");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            List<Image> imgP = new List<Image>();
            List<string> uploadedFiles = new List<string>();
            foreach (IFormFile postedFile in b.ImageFilePath)
            {
                string fileName = Path.GetFileName(postedFile.FileName);
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                    uploadedFiles.Add(fileName);
                    imgP.Add(new Image() { Img_Path = "/Images/" + fileName });
                }

            }
            b.Img = imgP[0];
            Designer po = new Designer();
            po = context.Designers.Where(s => s.ID == id).FirstOrDefault();
            context.Images.ToList();
            context.InvitationCards.Add(b);
            po.Invitations.Add(b);
            context.SaveChanges();
            context.Reviews.ToList();
            return RedirectToAction("TestDesiEdit", new { id = id });
        }


        public IActionResult EditDesi(int id)
        {
            Designer d = new Designer();
            d = context.Designers.Where(p => p.ID == id).FirstOrDefault();
            context.Images.ToList();
            context.Users.ToList();
            return View(d);
        }

        [HttpPost]
        public IActionResult EditDesi(Designer p)
        {
            if (ModelState != null)
            {
                string wwwPath = this.Environment.WebRootPath;
                string contentPath = this.Environment.ContentRootPath;

                string path = Path.Combine(this.Environment.WebRootPath, "Images");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                List<string> uploadedFiles = new List<string>();
                if (p.ImageFilePath != null)
                {
                    foreach (IFormFile postedFile in p.ImageFilePath)
                    {
                        string fileName = Path.GetFileName(postedFile.FileName);
                        using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                        {
                            postedFile.CopyTo(stream);
                            uploadedFiles.Add(fileName);
                            string imgP = "/Images/" + fileName;
                            Designer edited = new Designer();
                            edited = context.Designers.Where(po => po.ID == p.ID).FirstOrDefault();
                            edited.Name = p.Name;
                            edited.PhoneNumber = p.PhoneNumber;
                            edited.Address = p.Address;
                            edited.Offers = p.Offers;
                            edited.ShopName = p.ShopName;
                            edited.Designer_ImgPath = imgP;
                            context.SaveChanges();
                            return RedirectToAction("TestDesiEdit", new { id = p.ID });
                        }

                    }
                }
                else
                {
                    Designer edited = new Designer();
                    edited = context.Designers.Where(po => po.ID == p.ID).FirstOrDefault();
                    edited.Name = p.Name;
                    edited.PhoneNumber = p.PhoneNumber;
                    edited.Address = p.Address;
                    edited.Offers = p.Offers;
                    edited.Designer_ImgPath = p.Designer_ImgPath;
                    context.SaveChanges();
                    return RedirectToAction("TestDesiEdit", new { id = p.ID });

                }


            }

            return View(p);
        }

        [HttpGet]
        [Route("Designers/find/{id}")]
        public IActionResult Find(int id)
        {
            var invitation = context.InvitationCards.Find(id);
            ArrayList li = new ArrayList();
            li.Add(invitation.Inv_Id.ToString());
            li.Add(invitation.Inv_Title);
            li.Add(invitation.Inv_Price);
            Dictionary<string, string> EmployeeList = new Dictionary<string, string>();
            EmployeeList.Add("Inv_Id", invitation.Inv_Id.ToString());
            EmployeeList.Add("Inv_Title", invitation.Inv_Title);
            EmployeeList.Add("Inv_Price", invitation.Inv_Price.ToString());
            return new JsonResult(EmployeeList);
        }


        [HttpPost]
        [Route("UpdateDes")]

        public IActionResult Update(string Inv_Id, string Inv_Title, string Inv_Price)
        {
            var invitation = context.InvitationCards.Find(int.Parse(Inv_Id));
            invitation.Inv_Title = Inv_Title;
            invitation.Inv_Price = float.Parse(Inv_Price);
            Designer des = context.Designers.Where(d => d.Invitations.Where(i => i.Inv_Id == int.Parse(Inv_Id)).FirstOrDefault().Inv_Id == invitation.Inv_Id).FirstOrDefault();
            context.SaveChanges();
            return RedirectToAction("TestDesiEdit", new { id = des.ID });
        }

        public IActionResult Deals()
        {
            var user = User.FindFirst(ClaimTypes.NameIdentifier);
            Designer ph = context.Designers.Where(h => h.Users.Id == user.Value).FirstOrDefault();
            //p = context.Photographers.Where(p => p.Ph_Id == id).FirstOrDefault();
            context.Images.ToList();
            context.Users.ToList();
            context.Designers.ToList();
            context.DesignerRequests.ToList();
            context.InvitationCards.ToList();
            context.Members.ToList();
            return View(ph);
        }

        [HttpPost]
        public IActionResult AcceptDeal(int id)
        {
            DesignerRequest pr = context.DesignerRequests.Where(fr => fr.ID == id).FirstOrDefault();
            pr.Status = "Accepted";
            context.SaveChanges();
            //GMailer.GmailUsername = "fady.ragaa48@gmail.com";
            //GMailer.GmailPassword = "fady2020";

            //GMailer mailer = new GMailer();
            //mailer.ToEmail = "bahersaweres@gmail.com";
            //mailer.Subject = "Eventique Website";
            //mailer.Body = "Thanks for Registering your Booking .<br> your booking accepted now</a>";
            //mailer.IsHtml = false;
            //mailer.Send();
            return RedirectToAction("Deals");
        }

        [HttpPost]
        public IActionResult CancelDeal(int id)
        {
            DesignerRequest pr = context.DesignerRequests.Where(fr => fr.ID == id).FirstOrDefault();
            pr.Status = "Canceled";
            context.SaveChanges();
            //GMailer.GmailUsername = "fady.ragaa48@gmail.com";
            //GMailer.GmailPassword = "fady2020";

            //GMailer mailer = new GMailer();
            //mailer.ToEmail = "bahersaweres@gmail.com";
            //mailer.Subject = "Eventique Website";
            //mailer.Body = "Thanks for Registering your Booking .<br> your booking accepted now</a>";
            //mailer.IsHtml = false;
            //mailer.Send();
            return RedirectToAction("Deals");
        }
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePassVM passVM)
        {
            var user2 = User.FindFirst(ClaimTypes.NameIdentifier);
            Designer ph = context.Designers.Where(h => h.Users.Id == user2.Value).FirstOrDefault();

            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return RedirectToAction("");
                }

                var result = await _userManager.ChangePasswordAsync(user, passVM.CurrentPassword, passVM.NewPassword);
                if (!result.Succeeded)
                {
                    foreach (var Error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, Error.Description);
                    }
                    return View();
                }
                await _signInManager.RefreshSignInAsync(user);
                return View("EditDesi",new { id = ph.ID});
            }
            return View(passVM);
        }
    }

}
