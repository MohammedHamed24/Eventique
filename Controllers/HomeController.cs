using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Eventique.Models;
using Eventique.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Identity;
using System.Security.Policy;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Collections;
using System.Runtime.Intrinsics.X86;

namespace Eventique.Controllers
{
    public class HomeController : Controller
    {
        List<string> picList = new List<string>();
        private IHostingEnvironment Environment;
        private readonly ApplicationDbContext context;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly List<WeddingHall> halls = new List<WeddingHall>();


        public HomeController(ApplicationDbContext _context, IHostingEnvironment _environment, UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            context = _context;
            Environment = _environment;
            _userManager = userManager;
            _signInManager = signInManager;
            //halls = context.Hotels.ToList();
        }
        public IActionResult Index()
        {
            return View(context.Photographers.ToList());
        }

        [Authorize(Roles = "User")]
        public IActionResult MyDeals()
        {
            var user = User.FindFirst(ClaimTypes.NameIdentifier);
            context.Users.ToList();
            context.Photographers.ToList();
            context.Hotels.ToList();
            context.InvitationCards.ToList();
            context.PriceOffers.ToList();
            context.Designers.ToList();
            context.weddingHallsOffers.ToList();
            try
            {
                ViewData["phoRequest"] = context.PhotographerRequests.Where(p => p.RequestUser.Users.Id == user.Value)?.ToList();
            }
            catch (Exception)
            {
                ViewData["phoRequest"] = new List<PhotographerRequest>().ToList();
            }
            try
            {
                ViewData["WeddRequest"] = context.WeddingHallsRequests.Where(w => w.RequestUser.Users.Id == user.Value)?.ToList();
            }
            catch (Exception)
            {
                ViewData["WeddRequest"] = new List<WeddingHallsRequest>().ToList();
            }
            try
            {
                ViewData["DesiRequest"] = context.DesignerRequests.Where(d => d.RequestUser.Users.Id == user.Value)?.ToList();

            }
            catch (Exception)
            {
                ViewData["DesiRequest"] = new List<DesignerRequest>().ToList();
            }
            return View();
        }

        [Authorize(Roles = "User")]
        public IActionResult DeletePhoDeal(int ID)
        {
            context.PriceOffers.ToList();
            PhotographerRequest ps = context.PhotographerRequests.Find(ID);
            var dateLi = ps.Date.Split('/');
            try
            {
                DateTime date1 = new DateTime(int.Parse(dateLi[2]), int.Parse(dateLi[0]), int.Parse(dateLi[1]), 0, 0, 0);
                TimeSpan d = date1.Subtract(DateTime.Now);

                if (d.Days >= 10 && ps.Status != "Accepted")
                {
                    context.PhotographerRequests.Remove(ps);
                    context.SaveChanges();
                    TempData["msg"] = "Deleted Request successfully";
                }
                else
                {
                    TempData["msg"] = "Can't delete This request";
                }
                return RedirectToAction("MyDeals");
            }
            catch
            {
                DateTime date1 = new DateTime(int.Parse(dateLi[2]), int.Parse(dateLi[1]), int.Parse(dateLi[0]), 0, 0, 0);
                TimeSpan d = date1.Subtract(DateTime.Now);

                if (d.Days >= 10 && ps.Status != "Accepted")
                {
                    context.PhotographerRequests.Remove(ps);
                    context.SaveChanges();
                    TempData["msg"] = "Deleted Request successfully";
                }
                else
                {
                    TempData["msg"] = "Can't delete This request";
                }
                return RedirectToAction("MyDeals");
            }
        }
  
        public IActionResult DeleteDesiDeal(int ID)
        {
            context.PriceOffers.ToList();
            DesignerRequest des = context.DesignerRequests.Find(ID);
            var dateLi = des.Date.Split('/');
            try
            {
                DateTime date1 = new DateTime(int.Parse(dateLi[2]), int.Parse(dateLi[0]), int.Parse(dateLi[1]), 0, 0, 0);
                TimeSpan d = date1.Subtract(DateTime.Now);
                if (d.Days >= 7 && des.Status != "Accepted")
                {
                    context.DesignerRequests.Remove(des);
                    context.SaveChanges();
                    TempData["msgDesi"] = "Deleted Request successfully";
                }
                else
                {
                    TempData["msgDesi"] = "Can't delete This request";
                }
                return RedirectToAction("MyDeals");
            }
            catch
            {
                DateTime date1 = new DateTime(int.Parse(dateLi[2]), int.Parse(dateLi[1]), int.Parse(dateLi[0]), 0, 0, 0);
                TimeSpan d = date1.Subtract(DateTime.Now);
                if (d.Days >= 7 && des.Status != "Accepted")
                {
                    context.DesignerRequests.Remove(des);
                    context.SaveChanges();
                    TempData["msgDesi"] = "Deleted Request successfully";
                }
                else
                {
                    TempData["msgDesi"] = "Can't delete This request";
                }
                return RedirectToAction("MyDeals");
            }

           
        }
        public IActionResult DeleteWeddDeal(int ID)
        {
            context.PriceOffers.ToList();
            WeddingHallsRequest wed = context.WeddingHallsRequests.Find(ID);
            var dateLi = wed.Date.Split('/');
            try
            {
                DateTime date1 = new DateTime(int.Parse(dateLi[2]), int.Parse(dateLi[0]), int.Parse(dateLi[1]), 0, 0, 0);
                TimeSpan d = date1.Subtract(DateTime.Now);
                if (d.Days >= 10 && wed.Status != "Accepted")
                {
                    context.WeddingHallsRequests.Remove(wed);
                    context.SaveChanges();
                    TempData["msgWedd"] = "Deleted Request successfully";
                }
                else
                {
                    TempData["msgWedd"] = "Can't delete This request";
                }
                return RedirectToAction("MyDeals");
            }
            catch
            {
                DateTime date1 = new DateTime(int.Parse(dateLi[2]), int.Parse(dateLi[1]), int.Parse(dateLi[0]), 0, 0, 0);
                TimeSpan d = date1.Subtract(DateTime.Now);
                if (d.Days >= 10 && wed.Status != "Accepted")
                {
                    context.WeddingHallsRequests.Remove(wed);
                    context.SaveChanges();
                    TempData["msgWedd"] = "Deleted Request successfully";
                }
                else
                {
                    TempData["msgWedd"] = "Can't delete This request";
                }
                return RedirectToAction("MyDeals");
            }
           
        }
        public IActionResult PhotoghrapherShow()
        {
            return View(context.Photographers.ToList());
        }

        public IActionResult AllDesigners()
        {
            context.Reviews.ToList();
            return View(context.Designers.ToList());

        }
        [Authorize(Roles = "User")]
        public IActionResult LastReco()
        {
            context.Hotels.ToList();
            context.Designers.ToList();
            context.Photographers.ToList();
            context.InvitationCards.ToList();
            context.weddingHallsOffers.ToList();
            context.PriceOffers.ToList();
            return View(context.Recommendations.ToList());
        }


        public async Task<IActionResult> TestView()
        {
            string returnUrl = null;
            returnUrl = returnUrl ?? Url.Content("~/");

            if (_signInManager.IsSignedIn(User))
            {
                var user = User.FindFirst(ClaimTypes.NameIdentifier);
                IList<string> role = await _userManager.GetRolesAsync(context.Users.Where(u => u.Id == user.Value).FirstOrDefault());
                if (role.Contains("Photographer"))
                {
                    Photographer photographer = context.Photographers.Where(p => p.Users.Id == user.Value).FirstOrDefault();
                    returnUrl = "~/Photographers/TestPhoEdit/" + photographer.Ph_Id;
                    return LocalRedirect(returnUrl);
                }
                else if (role.Contains("Designer"))
                {
                    Designer designer = context.Designers.Where(d => d.Users.Id == user.Value).FirstOrDefault();
                    returnUrl = "~/Designers/TestDesiEdit/" + designer.ID;
                    return LocalRedirect(returnUrl);
                }
                else if (role.Contains("WeddingHall"))
                {
                    returnUrl = "~/WeddingHalls/TestWeddEdit";
                    return LocalRedirect(returnUrl);
                }
                else
                {
                    context.Members.ToList();
                    ViewData["photo"] = context.Photographers.ToList();
                    ViewData["halls"] = context.Hotels.ToList();
                    ViewData["designers"] = context.Designers.ToList();
                    ViewData["Reviews"] = context.Reviews.ToList();
                    context.PriceOffers.ToList();
                    return View();
                }
            }
            else
            {
                context.Members.ToList();
                ViewData["photo"] = context.Photographers.ToList();
                ViewData["halls"] = context.Hotels.ToList();
                ViewData["designers"] = context.Designers.ToList();
                ViewData["Reviews"] = context.Reviews.ToList();
                context.PriceOffers.ToList();
                return View();
            }

        }

        public IActionResult AllWeddingHalls(int Price = 5000, string HallType = null, string OtherServices = null, int Capacity = 100, string Regon = null, string Date = null)
        {
            context.Albums.ToList();
            context.Images.ToList();
            context.Recommendations.ToList();
            List<WeddingHall> wedHalls = new List<WeddingHall>();
            if(Date == "Next Month")
            {
                wedHalls = context.Hotels.Where(h => h.Hall_Price <= Price && h.HallType == HallType && h.OtherServices == OtherServices && h.Capacity <= Capacity && h.Address.Contains(Regon) && h.TestDate.Contains("/07/")).ToList();
            }
            else if(Date == "This Month")
            {
                wedHalls = context.Hotels.Where(h => h.Hall_Price <= Price && h.HallType == HallType && h.OtherServices == OtherServices && h.Capacity <= Capacity && h.Address.Contains(Regon) && h.TestDate.Contains("/06/")).ToList();
            }
            else if(Price == 5000 && HallType == null && OtherServices == null && Capacity == 100 && Regon == null && Date == null)
            {
                wedHalls = context.Hotels.ToList();
            }
            return View(wedHalls);
        }

        //public IActionResult Search(string Price , string HallType , string OtherServices , string Capacity , string Regon , string Date)
        //{
        //    return 
        //}

        public IActionResult AllPhotographers(int Price = 1000, string CameraType = null, string Regon = null, string Date = null)
        {
            List<Photographer> photographers = new List<Photographer>();
            if (Date == "Next Month")
            {
                photographers = context.Photographers.Where(h => h.Ph_Price <= Price && h.Ph_CameraType == CameraType && h.Ph_Address.Contains(Regon) && h.TestDate.Contains("/07/")).ToList();
            }
            else if (Date == "This Month")
            {
                photographers = context.Photographers.Where(h => h.Ph_Price <= Price && h.Ph_CameraType == CameraType && h.Ph_Address.Contains(Regon) && h.TestDate.Contains("/06/")).ToList();
            }
            else
            {
                photographers = context.Photographers.ToList();
            }
            return View(photographers);
        }
        
        public IActionResult TestWeddView(int id)
        {
            WeddingHall hall = new WeddingHall();
            hall = context.Hotels.Where(h => h.ID == id).FirstOrDefault();
            context.Albums.ToList();
            context.Images.ToList();
            context.weddingHallsOffers.ToList();
            context.Hotels.ToList();
            context.Users.ToList();
            context.Reviews.ToList();
            context.Members.ToList();
            return View(hall);
        }

        public IActionResult TestDesiView(int id)
        {
            Designer D = new Designer();
            D = context.Designers.Where(d => d.ID == id).FirstOrDefault();
            context.Albums.ToList();
            context.Images.ToList();
            context.InvitationCards.ToList();
            context.Reviews.ToList();
            context.Users.ToList();
            context.weddingHallsOffers.ToList();
            context.Members.ToList();
            return View(D);
        }
        public IActionResult TestPhoView(int id)
        {
            Photographer p = new Photographer();
            p = context.Photographers.Where(p => p.Ph_Id == id).FirstOrDefault();
            context.Albums.ToList();
            context.Images.ToList();
            context.Reviews.ToList();
            context.Members.ToList();
            context.Users.ToList();
            context.PriceOffers.ToList();
            return View(p);
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public IActionResult PostReview(int id, Review review)
        {
            Photographer photographer = context.Photographers.Where(p => p.Ph_Id == id).FirstOrDefault();
            var user = User.FindFirst(ClaimTypes.NameIdentifier);
            context.Users.ToList();
            float temp = photographer.Rate;
            temp = (temp + review.Avg()) / 2;
            temp = (float)Math.Floor(temp * 10) / 10;
            photographer.Rate = temp;
            context.SaveChanges();
            Member member = context.Members.Where(m => m.Users.Id == user.Value).FirstOrDefault();
            if (ModelState.IsValid)
            {
                photographer.Ph_Reviews.Add(new Review()
                {
                    Quality = review.Quality,
                    DeleverTime = review.DeleverTime,
                    TimeManagement = review.TimeManagement,
                    ReviewMessage = review.ReviewMessage,
                    ReviewDate = DateTime.Now,
                    ReviewedMember = member
                });
                context.SaveChanges();
                return RedirectToAction("TestPhoView", new { id = photographer.Ph_Id } );
            }
            return View(photographer);
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public IActionResult PostDesReview(int id , Review review)
        {
            Designer designer = context.Designers.Where(d => d.ID == id).FirstOrDefault();
            var user = User.FindFirst(ClaimTypes.NameIdentifier);
            context.Users.ToList();
            float temp = designer.Rate;
            temp = (temp + review.Avg()) / 2;
            temp = (float)Math.Floor(temp * 10) / 10;
            designer.Rate = temp;
            Member member = context.Members.Where(m => m.Users.Id == user.Value).FirstOrDefault();
            if (ModelState.IsValid)
            {
                designer.Reviews.Add(new Review()
                {
                    Quality = review.Quality,
                    DeleverTime = review.DeleverTime,
                    TimeManagement = review.TimeManagement,
                    ReviewMessage = review.ReviewMessage,
                    ReviewDate = DateTime.Now,
                    ReviewedMember = member
                });
                context.SaveChanges();
                return RedirectToAction("TestDesiView", new { id = designer.ID });
            }
            return View(designer);
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public IActionResult PostHallReview(int id, Review review)
        {
            WeddingHall hall = context.Hotels.Where(d => d.ID == id).FirstOrDefault();
            var user = User.FindFirst(ClaimTypes.NameIdentifier);
            context.Users.ToList();
            float temp = hall.Rate;
            temp = (temp + review.Avg()) / 2;
            temp = (float)Math.Floor(temp * 10) / 10;
            hall.Rate = temp;
            context.SaveChanges();
            Member member = context.Members.Where(m => m.Users.Id == user.Value).FirstOrDefault();
            if (ModelState.IsValid)
            {
                hall.HallsReview.Add(new Review()
                {
                    Quality = review.Quality,
                    DeleverTime = review.DeleverTime,
                    TimeManagement = review.TimeManagement,
                    ReviewMessage = review.ReviewMessage,
                    ReviewDate = DateTime.Now,
                    ReviewedMember = member
                });
                context.SaveChanges();
                return RedirectToAction("TestweddView", new { id = hall.ID });
            }
            return View(hall);
        }

        public IActionResult PhoView(int id)
        {
            Photographer p = new Photographer();
            p = context.Photographers.Where(p => p.Ph_Id == id).FirstOrDefault();
            context.Albums.ToList();
            context.Images.ToList();
            return View(p);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //function for photographer requests 
        [HttpPost]
        [Authorize(Roles = "User")]
        public IActionResult PhoRequest(int id , PhotographerRequest p , string Offer)
        {
            PriceOffer prof = context.PriceOffers.Where(o => o.OfferTitle == Offer).FirstOrDefault();
            PhotographerRequest pr = new PhotographerRequest();
            var user = User.FindFirst(ClaimTypes.NameIdentifier);
            Photographer po = context.Photographers.Where(p => p.Ph_Id == id).FirstOrDefault();
            context.Users.ToList();
            var member = context.Members.Where(m => m.Users.Id == user.Value).FirstOrDefault();
            pr.RequestPhotographer = po;
            pr.PriceOffer = prof;
            pr.Date = p.Date;
            pr.RequestUser = member;
            pr.Message = p.Message;
            pr.Status = "Pending";
            context.PhotographerRequests.Add(pr);
            context.SaveChanges();
            return RedirectToAction("TestPhoView", new { id = id }); 
        }


        [HttpPost]
        [Authorize(Roles = "User")]
        public IActionResult WeddRequest(int id, WeddingHallsRequest wd,string offerTitle)
        {
            weddingHallsOffers offer = context.weddingHallsOffers.Where(of => of.Title == offerTitle).FirstOrDefault();
            WeddingHallsRequest wdr = new WeddingHallsRequest();
            var user =  User.FindFirst(ClaimTypes.NameIdentifier);
            WeddingHall w =  context.Hotels.Where(p => p.ID == id).FirstOrDefault();
            context.Users.ToList();
            var member =  context.Members.Where(m => m.Users.Id == user.Value).FirstOrDefault();
            wdr.RequestHotel = w;
            wdr.Offer = offer;
            wdr.Date = wd.Date;
            wdr.RequestUser = member;
            wdr.Message = wd.Message;
            wdr.Status = "Pending";
            context.WeddingHallsRequests.Add(wdr);
            context.SaveChanges();
            return RedirectToAction("TestWeddView", new { id = id });
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpGet]
        [Route("Home/find/{id}")]
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
        [Route("UpdateRequest")]
        public IActionResult Update(int id,string Inv_Id , string Message , int Quantity , string Date)
        {
            var user = User.FindFirst(ClaimTypes.NameIdentifier);
            var member = context.Members.Where(m => m.Users.Id == user.Value).FirstOrDefault();
            var invitation = context.InvitationCards.Find(int.Parse(Inv_Id));
            Designer d = context.Designers.Where(des => des.ID == id).FirstOrDefault();
            DesignerRequest dr = new DesignerRequest();
            dr.InvitationStyle = invitation;
            dr.Message = Message;
            dr.Quantity = Quantity;
            dr.RequestHotel = d;
            dr.RequestUser = member;
            dr.Date = Date;
            dr.Status = "pending";
            context.DesignerRequests.Add(dr);
            context.SaveChanges();
            return RedirectToAction("TestDesiView", new { id = d.ID });
        }


        [HttpPost]
        public IActionResult Recommendation(float Budget, string date, int InvNumber , string City)
        {
            if(context.Recommendations.ToList().Count != 0)
            {
                foreach (var item in context.Recommendations.ToList())
                {
                    context.Recommendations.Remove(item);
                    context.SaveChanges();
                }
            }
            var newdate = date.Split('-');
            string dateNew = $"{newdate[2]}/{newdate[1]}/{newdate[0]}";
            List<Recommendation> recommendations = new List<Recommendation>();
            List<Photographer> ph = new List<Photographer>();
            List<WeddingHall> wd = new List<WeddingHall>();
            List<Designer> d = new List<Designer>();
            context.InvitationCards.ToList();
            context.weddingHallsOffers.ToList();
            context.PriceOffers.ToList();
            d = context.Designers.ToList();
            wd = context.Hotels.Where(w => w.Address.Contains(City) && w.TestDate.Contains(dateNew)).ToList();
            ph = context.Photographers.Where(p => p.TestDate.Contains(dateNew) && p.Ph_Address.Contains(City)).ToList();
            for (int i = 0; i < wd.Count(); i++)
            {
                for (int j = 0; j < ph.Count(); j++)
                {
                    for (int x = 0; x < d.Count(); x++)
                    {
                        for (int z = 0; z < d[x].Invitations.Count(); z++)
                        {
                            float totalCardPrice = InvNumber * d[x].Invitations[0].Inv_Price;
                            if((wd[i].weddingHallsOffers[0].Price + ph[j].OffersList[0].OffersPrice + totalCardPrice) < Budget)
                            {
                                recommendations.Add(new Recommendation() { RecommendedWeddingHall = wd[i], RecommendedPhotographer = ph[j], RecommendedDesigner = d[x], phOffer = ph[j].OffersList[0], hallsOffers = wd[i].weddingHallsOffers[0], RecommendedInvitation = d[x].Invitations[z], Save = Budget - (wd[i].weddingHallsOffers[0].Price + ph[j].OffersList[0].OffersPrice + totalCardPrice), Date = dateNew, InvQuantity = InvNumber });
                                
                                break;
                            }
                            
                        }
                    }
                }
            }
            try
            {
                float f = recommendations.Select(r => r.Save).Min();
                context.Recommendations.Add(recommendations.Where(r => r.Save == f).FirstOrDefault());
                context.SaveChanges();
            }
            catch
            {
                TempData["testReco"] = "there is No Dates avilable";
            }
            return RedirectToAction("LastReco");
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public IActionResult AcceptReco(int id)
        {
            context.Users.ToList();
            var user = User.FindFirst(ClaimTypes.NameIdentifier);
            Member m = context.Members.Where(m => m.Users.Id == user.Value).FirstOrDefault();
            context.Photographers.ToList();
            context.Designers.ToList();
            context.PriceOffers.ToList();
            context.weddingHallsOffers.ToList();
            context.Hotels.ToList();
            context.InvitationCards.ToList();
            Recommendation reco = context.Recommendations.Where(r => r.ID == id).FirstOrDefault();
            context.WeddingHallsRequests.Add(new WeddingHallsRequest() { Date = reco.Date, Message = "Recomendation", RequestHotel = reco.RecommendedWeddingHall, RequestUser = m, Status = "Pending" ,Offer = reco.hallsOffers});
            context.PhotographerRequests.Add(new PhotographerRequest() { Date = reco.Date, Message = "Recommendation", RequestPhotographer = reco.RecommendedPhotographer, RequestUser = m, Status = "Prnding" , PriceOffer = reco.phOffer});
            context.DesignerRequests.Add(new DesignerRequest() { Date = reco.Date, Message = "Recommendation", RequestHotel = reco.RecommendedDesigner, InvitationStyle = reco.RecommendedInvitation, Quantity = reco.InvQuantity, RequestUser = m, Status = "Pending" });
            context.SaveChanges();
            return RedirectToAction("TestView");
        }
    }


}

