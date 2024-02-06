using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NOV26.Portfolio.web.Models;

namespace NOV26.Portfolio.web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
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

        model.Resumes = new List<ResumeModel>();
        model.Resumes.Add(new ResumeModel()
        {
            StartYear = 2014,
            EndYear = 2015,
            Title = "Master Degree of Design",
            InstitutionName = "Cambridge University",
            Description = "A small river named Duden flows by their place and supplies it with the necessary regelialia. It is a paradisematic country, in which roasted parts of sentences fly into your mouth."
        });
        model.Resumes.Add(new ResumeModel()
        {
            StartYear = 2016,
            EndYear = 2018,
            Title = "Master Degree of Design",
            InstitutionName = "Tribhuwan University",
            Description = "A small river named Duden flows by their place and supplies it with the necessary regelialia. It is a paradisematic country, in which roasted parts of sentences fly into your mouth."
        });
        model.Resumes.Add(new ResumeModel()
        {
            StartYear = 2019,
            EndYear = 2021,
            Title = "Master Degree of Design",
            InstitutionName = "Kathmandu University",
            Description = "A small river named Duden flows by their place and supplies it with the necessary regelialia. It is a paradisematic country, in which roasted parts of sentences fly into your mouth."
        });
        model.Resumes.Add(new ResumeModel()
        {
            StartYear = 2021,
            EndYear = 2023,
            Title = "Master Degree of Design",
            InstitutionName = "Pokhara University",
            Description = "A small river named Duden flows by their place and supplies it with the necessary regelialia. It is a paradisematic country, in which roasted parts of sentences fly into your mouth."
        });
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