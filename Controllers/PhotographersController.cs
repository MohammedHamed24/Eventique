using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Eventique.Data;
using Eventique.Models;
using Eventique.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Eventique.Controllers
{
    [Authorize(Roles = "Photographer")]
    public class PhotographersController : Controller
    {
        private readonly ApplicationDbContext context;
        private IHostingEnvironment Environment;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<PhotographersController> _logger;


        public PhotographersController(ApplicationDbContext _context , IHostingEnvironment _environment,
             UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<PhotographersController> logger)
        {
            context = _context;
            Environment = _environment;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;

        }
        public IActionResult Index()
        {
            Photographer p = new Photographer();
            return View();
        }

        //public IActionResult PhoEdit(int id)
        //{
        //    Photographer p = new Photographer();
        //    p = context.Photographers.Where(p => p.Ph_Id == id).FirstOrDefault();
        //    context.Albums.ToList();
        //    context.Images.ToList();
        //    context.Users.ToList();
        //    return View(p);
        //}

        public IActionResult TestPhoEdit(int id)
        {
            Photographer p = new Photographer();
            p = context.Photographers.Where(p => p.Ph_Id == id).FirstOrDefault();
            context.Albums.ToList();
            context.Reviews.ToList();
            context.Members.ToList();
            context.Images.ToList();
            context.Users.ToList();
            context.PriceOffers.ToList();
            context.PhotographerRequests.ToList();
            context.Members.ToList();

            return View(p);
        }
        //public IActionResult CreateAlbum()
        //{
        //    Photographer p = new Photographer();
        //    //p = context.Photographers.Where(p => p.Ph_Id == id).FirstOrDefault();
        //    context.Albums.ToList();
        //    context.Images.ToList();
        //    return View();
        //}
        public IActionResult CreateNewAlbum()
        {
            Photographer p = new Photographer();
            //p = context.Photographers.Where(p => p.Ph_Id == id).FirstOrDefault();
            context.Albums.ToList();
            context.Images.ToList();
            return View();
        }

   
        [HttpPost]
        public IActionResult CreateNewAlbum(int id, Album b)
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
           
            b.MyProperty = imgP;
            Photographer po = new Photographer();
            po = context.Photographers.Where(s => s.Ph_Id == id).FirstOrDefault();
            context.Albums.ToList();
            context.Images.ToList();
            context.Albums.Add(b);
            po.ListAlbum.Add(b);
            context.SaveChanges();
            return RedirectToAction("TestPhoEdit", new { id = id });
        }



        public IActionResult EditPho(int id)
        {
            Photographer p = new Photographer();
            p = context.Photographers.Where(p => p.Ph_Id == id).FirstOrDefault();
            context.Albums.ToList();
            context.Images.ToList();
            context.Users.ToList();
            return View(p);
        }

        [HttpPost]
        public IActionResult EditPho(Photographer p)
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
                            Photographer edited = new Photographer();
                            edited = context.Photographers.Where(po => po.Ph_Id == p.Ph_Id).FirstOrDefault();
                            edited.Ph_Name = p.Ph_Name;
                            edited.Ph_PhoneNumber = p.Ph_PhoneNumber;
                            edited.Ph_Price = p.Ph_Price;
                            edited.Ph_Address = p.Ph_Address;
                            edited.Ph_CameraType = p.Ph_CameraType;
                            edited.Ph_Offers = p.Ph_Offers;
                            edited.Description = p.Description;
                            edited.ImagePath = imgP;
                            edited.TestDate = p.TestDate;
                            context.SaveChanges();
                            return RedirectToAction("TestPhoEdit", new { id = p.Ph_Id });
                        }
                    }
                }
                else
                {
                    Photographer edited = new Photographer();
                    edited = context.Photographers.Where(po => po.Ph_Id == p.Ph_Id).FirstOrDefault();
                    edited.Ph_Name = p.Ph_Name;
                    edited.Ph_PhoneNumber = p.Ph_PhoneNumber;
                    edited.Ph_Price = p.Ph_Price;
                    edited.Ph_Address = p.Ph_Address;
                    edited.Ph_CameraType = p.Ph_CameraType;
                    edited.Ph_Offers = p.Ph_Offers;
                    edited.Description = p.Description;
                    edited.ImagePath = p.ImagePath;
                    edited.TestDate = p.TestDate;
                    context.SaveChanges();
                    return RedirectToAction("TestPhoEdit", new { id = p.Ph_Id });

                }
            }
            return View(p);
        }

        //For displaying deals in photographer page
        public IActionResult Deals()
        {
            var user = User.FindFirst(ClaimTypes.NameIdentifier);
            Photographer ph = context.Photographers.Where(h => h.Users.Id == user.Value).FirstOrDefault();
            //p = context.Photographers.Where(p => p.Ph_Id == id).FirstOrDefault();
            context.Images.ToList();
            context.Users.ToList();
            context.PhotographerRequests.ToList();
            context.Members.ToList();
            return View(ph);
        }

        [HttpPost]
        public IActionResult AcceptDeal (int id)
        {
            var user = User.FindFirst(ClaimTypes.NameIdentifier);
            Photographer ph = context.Photographers.Where(h => h.Users.Id == user.Value).FirstOrDefault();
            PhotographerRequest pr = context.PhotographerRequests.Where(fr => fr.ID == id).FirstOrDefault();
            pr.Status = "Accepted";
            var DateLi = ph.TestDate.Split(",");
            List<string> dt = new List<string>();
            dt = DateLi.ToList();
            foreach (var item in dt)
            {
                if (pr.Date == item)
                {
                    dt.Remove(item);
                    break;
                }

            }
            StringBuilder st = new StringBuilder();
            for (int i = 0; i < dt.Count; i++)
            {
                if (i == dt.Count-1 )
                {
                    st.Append(dt[i]);
                }
                else
                {
                    st.Append(dt[i] + ",");
                }
            }
            ph.TestDate = st.ToString();
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
            Photographer ph = context.Photographers.Where(h => h.Users.Id == user.Value).FirstOrDefault();
            PhotographerRequest pr = context.PhotographerRequests.Where(fr => fr.ID == id).FirstOrDefault();
            pr.Status = "Canceled";
            var DateLi = ph.TestDate.Split(",");
            List<string> dt = new List<string>();
            dt = DateLi.ToList();
            dt.Add(pr.Date);
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
            ph.TestDate = st.ToString();
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
            Photographer ph = context.Photographers.Where(h => h.Users.Id == user2.Value).FirstOrDefault();

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
                return RedirectToAction("EditPho", new { id= ph.Ph_Id });
            }
            return View(passVM);
        }

        [Route("Photographers/Find/{id}")]
        public IActionResult Find(int id)
        {
            context.PriceOffers.ToList();
            var offers = context.PriceOffers.Where(offer => offer.Of_ID == id).FirstOrDefault();
            var Photo = context.Photographers.Where(p => p.OffersList.Where(o => o.Of_ID == id).FirstOrDefault().Of_ID == id).FirstOrDefault();
            Dictionary<string, string> DList = new Dictionary<string, string>();
            DList.Add("Of_ID", offers.Of_ID.ToString());
            DList.Add("OfferTitle", offers.OfferTitle);
            DList.Add("OfferDetails", offers.OfferDetails);
            DList.Add("OffersPrice", offers.OffersPrice.ToString());
            DList.Add("OfferImgPath", offers.OfferImgPath);
            return new JsonResult(DList);
        }

        [HttpPost]
        [Route("UpdateOffers")]
        public IActionResult UpdateOffers(PriceOffer f)
        {
            if (ModelState != null)
            {
                context.PriceOffers.ToList();
                var p = context.Photographers.Where(p => p.OffersList.Where(o => o.Of_ID == f.Of_ID).FirstOrDefault().Of_ID == f.Of_ID).FirstOrDefault();
                string wwwPath = this.Environment.WebRootPath;
                string contentPath = this.Environment.ContentRootPath;
                string path = Path.Combine(this.Environment.WebRootPath, "Images");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                List<string> uploadedFiles = new List<string>();
                if (f.ImageFilePath != null)
                {
                    foreach (IFormFile postedFile in f.ImageFilePath)
                    {
                        string fileName = Path.GetFileName(postedFile.FileName);
                        using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                        {
                            postedFile.CopyTo(stream);
                            uploadedFiles.Add(fileName);
                            string imgP = "/Images/" + fileName;
                            var edited = context.PriceOffers.Where(of => of.Of_ID == f.Of_ID).FirstOrDefault();
                            edited.OfferTitle = f.OfferTitle;
                            edited.OfferDetails = f.OfferDetails;
                            edited.OffersPrice = f.OffersPrice;
                            edited.OfferImgPath = imgP;
                            context.SaveChanges();
                            return RedirectToAction("TestPhoEdit", new { id = p.Ph_Id });
                        }
                    }
                }
                else
                {
                    var edited = context.PriceOffers.Where(of => of.Of_ID == f.Of_ID).FirstOrDefault();
                    edited.OfferTitle =f.OfferTitle;
                    edited.OfferDetails = f.OfferDetails;
                    edited.OffersPrice = f.OffersPrice;
                    context.SaveChanges();
                    return RedirectToAction("TestPhoEdit", new { id = p.Ph_Id });

                }
            }
            return View(f);

        }
        [HttpPost]
        public IActionResult AddOffer(PriceOffer f)
        {
            var user = User.FindFirst(ClaimTypes.NameIdentifier);
            Photographer edited = context.Photographers.Where(p => p.Users.Id == user.Value).FirstOrDefault();
            //Photographer edited = context.Photographers.Where(p => p.OffersList.Where(f => f.Of_ID == f.Of_ID).FirstOrDefault().Of_ID == f.Of_ID).FirstOrDefault();
            if (ModelState != null)
            {
                context.PriceOffers.ToList();
                var p = context.Photographers.Where(p => p.OffersList.Where(o => o.Of_ID == f.Of_ID).FirstOrDefault().Of_ID == f.Of_ID).FirstOrDefault();
                string wwwPath = this.Environment.WebRootPath;
                string contentPath = this.Environment.ContentRootPath;
                string path = Path.Combine(this.Environment.WebRootPath, "Images");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                List<string> uploadedFiles = new List<string>();
                if (f.ImageFilePath != null)
                {
                    foreach (IFormFile postedFile in f.ImageFilePath)
                    {
                        string fileName = Path.GetFileName(postedFile.FileName);
                        using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                        {
                            postedFile.CopyTo(stream);
                            uploadedFiles.Add(fileName);
                            string imgP = "/Images/" + fileName;
                            edited.OffersList.Add(new PriceOffer() { OfferTitle = f.OfferTitle, OfferDetails = f.OfferDetails, OfferEndDate = f.OfferEndDate, OfferImgPath = imgP, OffersPrice = f.OffersPrice });
                            context.SaveChanges();
                            return RedirectToAction("TestPhoEdit", new { id = edited.Ph_Id });
                        }
                    }
                }
                else
                {
                    edited.OffersList.Add(new PriceOffer() { OfferTitle = f.OfferTitle, OfferDetails = f.OfferDetails, OfferEndDate = f.OfferEndDate, OfferImgPath = "/Images/22.jpg", OffersPrice = f.OffersPrice });
                    context.SaveChanges();
                    return RedirectToAction("TestPhoEdit", new { id = edited.Ph_Id });

                }
            }
            return View(f);

        }
        [HttpPost]
        [Route("RemoveOffer")]
        public IActionResult RemoveOffer(int Of_ID)
        {
            context.PriceOffers.ToList();
            var user = User.FindFirst(ClaimTypes.NameIdentifier);
            Photographer pho = context.Photographers.Where(p => p.Users.Id == user.Value).FirstOrDefault();
            PhotographerRequest ps = context.PhotographerRequests.Where(p => p.PriceOffer.Of_ID == Of_ID).FirstOrDefault();
            if (ps == null)
            {
                PriceOffer pr = context.PriceOffers.Find(Of_ID);
                pho.OffersList.Remove(pr);
                context.PriceOffers.Remove(pr);
                context.SaveChanges();
                return RedirectToAction("TestPhoEdit", new { id = pho.Ph_Id });
            }
            else
            {
                TempData["err"] = "this offer can't be deleted it used by some members";
                return RedirectToAction("TestPhoEdit", new { id = pho.Ph_Id });
            }

        }




    }
}