using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NOV26.Portfolio.web.Models;

namespace NOV26.Portfolio.web.Controllers;

public class HomeController : Controller
{
    private Data.NOV26PortfoliowebContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, Data.NOV26PortfoliowebContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        HomeViewModel model = new HomeViewModel()
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
        };

        model.Resumes = _context.ResumeModel.ToList();
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
}