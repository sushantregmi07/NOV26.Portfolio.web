using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NOV26.Portfolio.web.Models;

namespace NOV26.Portfolio.web.Controllers
{
    [AllowAnonymous]
        public class HomeController : Controller
    {
        Data.NOV26PortfoliowebContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, Data.NOV26PortfoliowebContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            /*HomeViewModel model = new HomeViewModel()
            {
                FullName = "Sushant Regmi",
                Address = "Kathmandu",
                Email = "sushantregmi07@gmail.com",
                Phone = "+977 9767277944",
                CompletedProjects = 10,
                DOB = new DateTime(2002,06,03),
                Summary = "Asp.Net Developer with one year of experience",
                Title = "Asp.Net Developer",
                ZipCode = "44600"
            };*/
            HomeViewModel model = new HomeViewModel();
            var personalInformation = _context.PersonalInformationModel.FirstOrDefault();
            model.FullName = personalInformation.FullName;
            model.Address = personalInformation.Address;
            model.Email = personalInformation.Email;
            model.Phone = personalInformation.Phone;
            model.CompletedProjects = personalInformation.CompletedProjects;
            model.DOB = personalInformation.DOB;
            model.Summary = personalInformation.Summary;
            model.Title = personalInformation.Title;
            model.ZipCode = personalInformation.ZipCode;
            model.UserPhotoUrl = personalInformation.UserPhotoUrl;

            model.Resumes = _context.ResumeModel.ToList();
            model.Services = _context.ServiceModel.ToList();
            model.Skills = _context.SkillModel.ToList();
            model.Projects = _context.ProjectModel.Include(x=> x.Service).ToList();
            model.Blogs = _context.BlogModel.OrderByDescending(x => x.DateTime).Take(3).ToList();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        } 
        
        public IActionResult Blog(int id)
        {
            
            var blog = _context.BlogModel.Find(id);
            var comments = _context.BlogCommentModel.Where(x => x.BlogId == id).ToList();
            BlogViewModel blogvm = new BlogViewModel()
            {
                ImageUrl = blog.ImageUrl,
                DateTime = blog.DateTime,
                Id = id,
                Paragraph1 = blog.Paragraph1,
                Paragraph2 = blog.Paragraph2,
                Title = blog.Title,
                comments = comments
            };
            return View(blogvm);
        }
    [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                bool isValidLogin = _context.UserModel.Any(x => x.UserName == model.UserName && x.Password == model.Password);
                if (isValidLogin)
                {
                    addingClaimIdentity(model, "admin");
                    return RedirectToAction("Index", "PersonalInformationModels");
                }
            }
            return View();
        }
        

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return Redirect("/");
        }
        private void addingClaimIdentity(LoginModel user, string roles)
        {
            //list of claims
            var userClaims = new List<Claim>()
            {
                new Claim("UserName", user.UserName),
                new Claim(ClaimTypes.Email,user.UserName),

               // new Claim(ClaimTypes.Role,"user"),
                new Claim(ClaimTypes.Role,"roles")
            };

            //create a identity claims
            var claimsIdentity = new ClaimsIdentity(
                userClaims, CookieAuthenticationDefaults.AuthenticationScheme);


            //httcontext , current user is authentic user
            //sing in user to httpcontext
            HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity)
            );
        }
        
    }
}


