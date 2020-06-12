using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using Testes_Gerais.Configurations;
using Testes_Gerais.Interfaces;
using Testes_Gerais.Models;
using Testes_Gerais.Services;

namespace Testes_Gerais.Controllers
{
    public class HomeController : Controller
    {
        private readonly INameParserService _nameParserService;
        private readonly FeaturesConfiguration _featuresConfiguration;
        private readonly string nomeCompleto = "Richard G K Trage";
        private readonly GuidService _guidService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(INameParserService nameParserService,
            GuidService guidService,
            IOptions<FeaturesConfiguration> options,
            ILogger<HomeController> logger)
        {
            _logger = logger;
            _guidService = guidService;
            _nameParserService = nameParserService;
            _featuresConfiguration = options.Value;
        }

        public IActionResult Index()
        {
            var guid = _guidService.GetGuid();
            var logMessage = $"Controller: The GUID from GUidService is {guid}";
            _logger.LogInformation(logMessage);

            if (_featuresConfiguration.EnableTeste)
            {
                var test1 = _nameParserService.GetLastName(nomeCompleto);
                var test2 = _nameParserService.GetLastNameUsingSubstring(nomeCompleto);
                var test3 = _nameParserService.GetLastNameWithSpan(nomeCompleto);
            }

            // Encrypt
            var tst = BCrypt.Net.BCrypt.Verify("", guid);

            var tst2 = BCrypt.Net.BCrypt.HashPassword(guid);
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
