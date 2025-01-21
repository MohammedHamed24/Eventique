using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Eventique.Data;
using Eventique.Models;

namespace Eventique.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly ApplicationDbContext context;

        //private readonly IEmailSender _emailSender;

        public LoginModel(SignInManager<IdentityUser> signInManager, 
            ILogger<LoginModel> logger,
            UserManager<IdentityUser> userManager,
            ApplicationDbContext _context
            )


        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            context = _context;
        }

        [BindProperty]
        public InputModel Input { get; set; }
        public bool ShowResend { get; set; }
        public string UserId { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
            public string UserName { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (context.Recommendations.ToList().Count() != 0)
            {
                foreach (var item in context.Recommendations.ToList())
                {
                    context.Recommendations.Remove(item);
                }
                    context.SaveChanges();
            }
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {   
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    var user = new IdentityUser();
                    user = await _userManager.FindByEmailAsync(Input.Email);
                    IList<string> role = await _userManager.GetRolesAsync(user);
                    if (role.Contains("Photographer"))
                    {
                        Photographer ph = context.Photographers.Where(p => p.Users.Id == user.Id).FirstOrDefault();
                        returnUrl = "~/Photographers/TestPhoEdit/"+ph.Ph_Id;
                    }
                    else if(role.Contains("User"))
                    {
                        Member m = context.Members.Where(me => me.Users.Id == user.Id).FirstOrDefault();
                        returnUrl = "~/Home/TestView";

                    }
                    else if (role.Contains("Designer"))
                    {
                        Designer D = context.Designers.Where(me => me.Users.Id == user.Id).FirstOrDefault();
                        returnUrl = "~/Designers/TestDesiEdit/"+D.ID;

                    }
                    else if (role.Contains("WeddingHall"))
                    {
                        returnUrl = "~/WeddingHalls/TestWeddEdit";
                    }
                    else
                    {
                        returnUrl = "~/Admins/Index";
                    }
                    return LocalRedirect(returnUrl);
                }

                //if (result.IsNotAllowed)
                //{
                //    _logger.LogWarning("User email is not confirmed.");
                //    ModelState.AddModelError(string.Empty, "Email is not confirmed.");
                //    var user = await _userManager.FindByNameAsync(Input.Email);
                //    UserId = user.Id;
                //    ShowResend = true;
                //    return Page();
                //}
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        //public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    var user = await _userManager.FindByEmailAsync(Input.Email);
        //    if (user == null)
        //    {
        //        ModelState.AddModelError(string.Empty, "Verification email sent. Please check your email.");
        //    }

        //    var userId = await _userManager.GetUserIdAsync(user);
        //    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        //    var callbackUrl = Url.Page(
        //        "/Account/ConfirmEmail",
        //        pageHandler: null,
        //        values: new { userId = userId, code = code },
        //        protocol: Request.Scheme);
        //    await _emailSender.SendEmailAsync(
        //        Input.Email,
        //        "Confirm your email",
        //        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

        //    ModelState.AddModelError(string.Empty, "Verification email sent. Please check your email.");
        //    return Page();
        //}
    }
}
