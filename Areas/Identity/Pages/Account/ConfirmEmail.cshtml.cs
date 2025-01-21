using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eventique.Data;
using Eventique.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;

namespace Eventique.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ConfirmEmailModel : PageModel
    {
        public bool ShowInvalid { get; set; }
        public string Path { get; set; }

        public readonly UserManager<IdentityUser> _userManager;
        public SignInManager<IdentityUser> _signInManager;
        public readonly ApplicationDbContext _context;

        public ConfirmEmailModel(UserManager<IdentityUser> userManager , SignInManager<IdentityUser> signInManager , ApplicationDbContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToPage("/Index");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userId}'.");
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (!result.Succeeded)
            { 
                ShowInvalid = true;
            }
            else
            {
                IList<string> role = await _userManager.GetRolesAsync(user);
                if (role.Contains("Photographer"))
                {
                    Photographer ph = _context.Photographers.Where(p => p.Users.Id == user.Id).FirstOrDefault();
                    Path = "~/Photographers/TestPhoEdit/" + ph.Ph_Id;
                }
                else if (role.Contains("User"))
                {
                    Member m = _context.Members.Where(me => me.Users.Id == user.Id).FirstOrDefault();
                    Path = "Home/TestView" + m.ID;

                }
                else if (role.Contains("Designer"))
                {
                    Designer D = _context.Designers.Where(me => me.Users.Id == user.Id).FirstOrDefault();
                    Path = "~/Designers/TestDesiEdit/" + D.ID;

                }
                else if (role.Contains("WeddingHall"))
                {
                    Designer D = _context.Designers.Where(me => me.Users.Id == user.Id).FirstOrDefault();
                    Path = "~/WeddingHalls/TestWeddEdit";

                }
                //throw new InvalidOperationException($"Error confirming email for user with ID '{userId}':");
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            StatusMessage = result.Succeeded ? "Thank you for confirming your email." : "Error confirming your email.";
            return Page();
        }
    }
}
