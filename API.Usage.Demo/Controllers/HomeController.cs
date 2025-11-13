using System.Diagnostics;
using API.Usage.Demo.Models;
using Microsoft.AspNetCore.Mvc;
using API.Usage.Demo.Classes;
using Microsoft.Extensions.Configuration;

namespace API.Usage.Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<IActionResult> F1News()
        {
            var rapidApiKey = _configuration["RapidApi:NewsKey"] ??  string.Empty;
            var result = await F1NewsReader.GetF1News(rapidApiKey);
            return View(result);
        }

        public async Task<IActionResult> CryptoNews()
        {
            var rapidApiKey = _configuration["RapidApi:NewsKey"] ?? string.Empty;
            var result = await CryptoNewsReader.GetCryptoNews(rapidApiKey);
            return View(result);
        }

        public async Task<IActionResult> PremNews()
        {
            var rapidApiKey = _configuration["RapidApi:NewsKey"] ?? string.Empty;
            var result = await PremNewsReader.GetPremNews(rapidApiKey);
            return View(result);
        }

        public async Task<IActionResult> UKNews()
        {
            var rapidApiKey = _configuration["RapidApi:NewsKey"] ?? string.Empty;
            var result = await UKNewsReader.GetUKNews(rapidApiKey);
            return View(result);
        }

        public async Task<IActionResult> TechNews()
        {
            var rapidApiKey = _configuration["RapidApi:NewsKey"] ?? string.Empty;
            var result = await TechNewsReader.GetTechNews(rapidApiKey);
            return View(result);
        }

        public async Task<IActionResult> F1NewsSmall()
        {
            var rapidApiKey = _configuration["RapidApi:NewsKey"] ?? string.Empty;
            var result = await F1NewsReader.GetF1News(rapidApiKey);
            return View(result);
        }

        public async Task<IActionResult> CryptoNewsSmall()
        {
            var rapidApiKey = _configuration["RapidApi:NewsKey"] ?? string.Empty;
            var result = await CryptoNewsReader.GetCryptoNews(rapidApiKey);
            return View(result);
        }

        public async Task<IActionResult> PremNewsSmall()
        {
            var rapidApiKey = _configuration["RapidApi:NewsKey"] ?? string.Empty;
            var result = await PremNewsReader.GetPremNews(rapidApiKey);
            return View(result);
        }

        public async Task<IActionResult> UKNewsSmall()
        {
            var rapidApiKey = _configuration["RapidApi:NewsKey"] ?? string.Empty;
            var result = await UKNewsReader.GetUKNews(rapidApiKey);
            return View(result);
        }

        public async Task<IActionResult> TechNewsSmall()
        {
            var rapidApiKey = _configuration["RapidApi:NewsKey"] ?? string.Empty;
            var result = await TechNewsReader.GetTechNews(rapidApiKey);
            return View(result);
        }

        public IActionResult Index()
        {
            return View();
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
}
