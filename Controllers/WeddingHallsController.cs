using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Eventique.Data;
using Eventique.Models;
using Eventique.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace Eventique.Controllers
{
    public class WeddingHallsController : Controller
    {

        private readonly ApplicationDbContext context;
        private IHostingEnvironment Environment;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<WeddingHallsController> _logger;

        public WeddingHallsController(ApplicationDbContext _context, IHostingEnvironment _environment,
             UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<WeddingHallsController> logger)
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

       

        public IActionResult TestWeddEdit()
        {
            try
            {
                var user = User.FindFirst(ClaimTypes.NameIdentifier);
                WeddingHall wh = context.Hotels.Where(h => h.Users.Id == user.Value).FirstOrDefault();
                if (wh != null)
                {
                    context.Users.ToList();
                    context.Members.ToList();
                    context.Reviews.ToList();
                    context.WeddingHallsRequests.ToList();
                    context.Images.ToList();
                    context.Albums.ToList();
                    context.weddingHallsOffers.ToList();
                    context.Hotels.ToList();
                    return View(wh);
                }
                else
                {
                    return RedirectToAction("AccessDeniedPage");
                }
            }
            catch(Exception)
            {
                return RedirectToAction("AccessDeniedPage");

            }
        }

        public IActionResult EditWedd()
        {
            var user = User.FindFirst(ClaimTypes.NameIdentifier);
            WeddingHall wh = context.Hotels.Where(h => h.Users.Id == user.Value).FirstOrDefault();
            context.Albums.ToList();
            context.Images.ToList();
            context.Users.ToList();
            return View(wh);
        }


        [HttpPost]
        public IActionResult EditWedd(WeddingHall wed)
        {
            var user = User.FindFirst(ClaimTypes.NameIdentifier);
            WeddingHall wh = context.Hotels.Where(h => h.Users.Id == user.Value).FirstOrDefault();
            if (ModelState != null)
            {
                string wwwPath = this.Environment.WebRootPath;
                string contentPath = this.Environment.ContentRootPath;
                List<Image> imgPForAlbum = new List<Image>();
                string path = Path.Combine(this.Environment.WebRootPath, "Images");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                List<string> uploadedFiles = new List<string>();
                if (wed.ImageFilePath != null && wed.ImageFilePathAlbum != null)
                {
                    foreach (IFormFile postedFile in wed.ImageFilePath)
                    {
                        string fileName = Path.GetFileName(postedFile.FileName);
                        using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                        {
                            postedFile.CopyTo(stream);
                            uploadedFiles.Add(fileName);
                            string imgP = "/Images/" + fileName;
                            wh.Hall_ImgPath = imgP;
                        }

                    }
                    foreach (IFormFile postedFile in wed.ImageFilePathAlbum)
                    {
                        string fileName = Path.GetFileName(postedFile.FileName);
                        using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                        {
                            postedFile.CopyTo(stream);
                            uploadedFiles.Add(fileName);
                            imgPForAlbum.Add(new Image() { Img_Path = "/Images/" + fileName });

                        }

                    }

                    wh.Name = wed.Name;
                    wh.PhoneNumber = wed.PhoneNumber;
                    wh.Hall_Price = wed.Hall_Price;
                    wh.HallType = wed.HallType;
                    wh.Address = wed.Address;
                    wh.Capacity = wed.Capacity;
                    wh.OtherServices = wed.OtherServices;
                    wh.TestDate = wed.TestDate;
                    wh.Album = new Album() { Al_Title = wed.Name , MyProperty = imgPForAlbum };
                    wh.Offers = wed.Offers;
                    context.SaveChanges();
                    return RedirectToAction("TestWeddEdit");

                }
                else
                {
                    wh.Name = wed.Name;
                    wh.PhoneNumber = wed.PhoneNumber;
                    wh.Hall_Price = wed.Hall_Price;
                    wh.HallType = wed.HallType;
                    wh.Address = wed.Address;
                    wh.Capacity = wed.Capacity;
                    wh.OtherServices = wed.OtherServices;
                    wh.TestDate = wed.TestDate;
                    wh.Offers = wed.Offers;
                    context.SaveChanges();
                    return RedirectToAction("TestWeddEdit");
                }
            }

            return View(wh);
        }

        public IActionResult Deals()
        {
            var user = User.FindFirst(ClaimTypes.NameIdentifier);
            WeddingHall wh = context.Hotels.Where(h => h.Users.Id == user.Value).FirstOrDefault();
            //p = context.Photographers.Where(p => p.Ph_Id == id).FirstOrDefault();
            context.Images.ToList();
            context.Users.ToList();
            context.WeddingHallsRequests.ToList();
            context.weddingHallsOffers.ToList();
            context.Members.ToList();
            return View(wh);
        }


        [HttpPost]
        public IActionResult AcceptDeal(int id)
        {
            var user = User.FindFirst(ClaimTypes.NameIdentifier);
            WeddingHall hall = context.Hotels.Where(h => h.Users.Id == user.Value).FirstOrDefault();
            WeddingHallsRequest wh = context.WeddingHallsRequests.Where(fr => fr.ID == id).FirstOrDefault();
            wh.Status = "Accepted";
            var DateLi = hall.TestDate.Split(",");
            List<string> dt = new List<string>();
            dt = DateLi.ToList();
            foreach (var item in dt)
            {
                if (wh.Date == item)
                {
                    dt.Remove(item);
                    break;
                }

            }
            StringBuilder st = new StringBuilder();
            for (int i = 0; i < dt.Count; i++)
            {
                if (i == dt.Count - 1)
                {
                    st.Append(dt[i]);
                }
                else
                {
                    st.Append(dt[i] + ",");
                }
            }
            hall.TestDate = st.ToString();
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
            var user = User.FindFirst(ClaimTypes.NameIdentifier);
            WeddingHall hall = context.Hotels.Where(h => h.Users.Id == user.Value).FirstOrDefault();
            WeddingHallsRequest wh = context.WeddingHallsRequests.Where(fr => fr.ID == id).FirstOrDefault();
            wh.Status = "Canceled";
            var DateLi = hall.TestDate.Split(",");
            List<string> dt = new List<string>();
            dt = DateLi.ToList();
            dt.Add(wh.Date);
            StringBuilder st = new StringBuilder();
            for (int i = 0; i < dt.Count; i++)
            {
                if (i == dt.Count - 1)
                {
                    st.Append(dt[i]);
                }
                else
                {
                    st.Append(dt[i] + ",");
                }
            }
            hall.TestDate = st.ToString();
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
        public IActionResult AccessDeniedPage()
        {
            return View();
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePassVM passVM)
        {
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
                return RedirectToAction("EditWedd");
            }
            return View(passVM);
        }

        [HttpPost]
        public IActionResult AddOffer(weddingHallsOffers weddingHallsOffers)
        {
            var user = User.FindFirst(ClaimTypes.NameIdentifier);
            WeddingHall wh = context.Hotels.Where(h => h.Users.Id == user.Value).FirstOrDefault();
            context.Hotels.ToList();
            
            context.Users.ToList();
            if (ModelState != null)
            {
                context.weddingHallsOffers.ToList();
                wh.weddingHallsOffers.Add(new weddingHallsOffers()
                {
                    Title = weddingHallsOffers.Title,
                    Capacity = weddingHallsOffers.Capacity,
                    Dinner = weddingHallsOffers.Dinner,
                    otherServices = weddingHallsOffers.otherServices,
                    Price = weddingHallsOffers.Price,
                    EndDate = weddingHallsOffers.EndDate
                });
                context.SaveChanges();
                return RedirectToAction("TestWeddEdit");
            }
            return View(wh);
        }

        [HttpGet]
        [Route("WeddingHalls/find/{id}")]
        public IActionResult Find(int id)
        {
            var offer = context.weddingHallsOffers.Find(id);
            Dictionary<string, string> offerList = new Dictionary<string, string>();
            offerList.Add("ID", offer.ID.ToString());
            offerList.Add("Title", offer.Title);
            offerList.Add("Price", offer.Price.ToString());
            offerList.Add("Capacity", offer.Capacity.ToString());
            offerList.Add("otherServices", offer.otherServices);
            offerList.Add("Dinner", offer.Dinner);
            offerList.Add("EndDate", offer.EndDate.ToString());
            return new JsonResult(offerList);
        }

        [HttpPost]
        public IActionResult UpdateOffer(weddingHallsOffers weddingHallsOffers)
        {
            if (ModelState.IsValid)
            {
                weddingHallsOffers Edited = context.weddingHallsOffers.Where(of => of.ID == weddingHallsOffers.ID).FirstOrDefault();
                Edited.Capacity = weddingHallsOffers.Capacity;
                Edited.Price = weddingHallsOffers.Price;
                Edited.Title = weddingHallsOffers.Title;
                Edited.otherServices = weddingHallsOffers.otherServices;
                Edited.Dinner = weddingHallsOffers.Dinner;
                Edited.EndDate = weddingHallsOffers.EndDate;
                context.SaveChanges();
                return RedirectToAction("TestWeddEdit");
            }
            return View(weddingHallsOffers);
        }

        [HttpPost]
        [Route("DeleteOffer")]
        public IActionResult DeleteOffer(int offId)
        {

            context.weddingHallsOffers.ToList();
            var user = User.FindFirst(ClaimTypes.NameIdentifier);
            WeddingHall weddingHall = context.Hotels.Where(w => w.Users.Id == user.Value).FirstOrDefault();
            WeddingHallsRequest weddingHallsRequest = context.WeddingHallsRequests.Where(wr => wr.Offer.ID == offId).FirstOrDefault();
            if (weddingHallsRequest == null)
            {
                weddingHallsOffers hallsOffer = context.weddingHallsOffers.Find(offId);
                weddingHall.weddingHallsOffers.Remove(hallsOffer);
                context.weddingHallsOffers.Remove(hallsOffer);
                
                context.SaveChanges();
                return RedirectToAction("TestWeddEdit");
            }
            else
            {
                TempData["err"] = "this offer can't be deleted it used by some members";
                return RedirectToAction("TestWeddEdit");
            }
        }
    }
}