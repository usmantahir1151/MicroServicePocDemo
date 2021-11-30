using FrontendApp.Common;
using FrontendApp.Models;
using FrontendApp.Services.ClientService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SharedComponent.ViewModels.Configurations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClientService _clientService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IClientService clientService)
        {
            _logger = logger;
            _clientService = clientService;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation($"{nameof(Index)} method running");
            var responseObject = await _clientService.GetAsync<List<GlobalConfigurationVM>>(EndPoints.GetConfigurations);
            return View(responseObject);
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
