using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Data;
using SchoolSystem.Models;
using SchoolSystem.ViewModel.Accounts;

namespace SchoolSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;


        public AccountController(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
           
        }
        [AllowAnonymous]
        public IActionResult Login(string PasswordChanged)
        {
            if (PasswordChanged == "yes")
            {
                ViewBag.PasswordChanged = "yes";
            }
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginVM loginVM)
         {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var user = await _userManager.FindByEmailAsync(loginVM.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid login attempt");
                return View();
            }
            var response = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
            if (!response.Succeeded)
            {
                ModelState.AddModelError("", "Invalid login attempt");
                return View();
            }

            if (await _userManager.IsInRoleAsync(user, "Admin"))
            {
                return RedirectToAction("Index", "Lecturer");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
      
            var patient = new Lecturer
            {
                LecturerName = registerVM.LecturerName,
                PhoneNumber = registerVM.PhoneNumber,
                Email = registerVM.Email,

            };
           

            var user = await _userManager.FindByEmailAsync(patient.Email);
            if (user != null)
            {
                ModelState.AddModelError("", "You are already registered with us");
                return View();
            }

            await _context.Lecturers.AddAsync(patient);
            var response = await _context.SaveChangesAsync();

            var newuser = new ApplicationUser
            {
                FullName = patient.LecturerName,
                Email = patient.Email,
                UserName = patient.Email,
                Gender="Male",
                EmailConfirmed = true
            };
            var password = registerVM.Password;
            var result = await _userManager.CreateAsync(newuser, password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(newuser, "Lecturer");
                ViewBag.Created = "Yes";
                return RedirectToAction("Login");
            }else
            {
                return View();
            }
        }

    }
}