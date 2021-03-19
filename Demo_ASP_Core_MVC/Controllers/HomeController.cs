using Demo_ASP_Core_MVC.DataServices;
using Demo_ASP_Core_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_ASP_Core_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private TopicService _topicService;

        public HomeController(ILogger<HomeController> logger, TopicService topicService)
        {
            _logger = logger;
            _topicService = topicService;
        }

        public IActionResult Index()
        {
            HomeViewModel homeVM = new HomeViewModel()
            {
                Topics = _topicService.GetAllWithLastMessage()
            };

            return View(homeVM);
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
