using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Testes_Gerais.Configurations;
using Testes_Gerais.Interfaces;
using Testes_Gerais.Models;

namespace Testes_Gerais.Controllers
{
    public class HomeController : Controller
    {
        private readonly INameParserService _nameParserService;
        private readonly FeaturesConfiguration _featuresConfiguration;
        private readonly string nomeCompleto = "Richard G K Trage";

        public HomeController(INameParserService nameParserService, IOptions<FeaturesConfiguration> options)
        {
            _nameParserService = nameParserService;
            _featuresConfiguration = options.Value;
        }

        public IActionResult Index()
        {
            if (_featuresConfiguration.EnableTeste)
            {
                var test1 = _nameParserService.GetLastName(nomeCompleto);
                var test2 = _nameParserService.GetLastNameUsingSubstring(nomeCompleto);
                var test3 = _nameParserService.GetLastNameWithSpan(nomeCompleto);
            }
            
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
