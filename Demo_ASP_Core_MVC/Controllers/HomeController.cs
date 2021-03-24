using Demo_ASP_Core_MVC.DataServices;
using Demo_ASP_Core_MVC.Models;
using Demo_ASP_Core_MVC.SessionHelper;
using Microsoft.AspNetCore.Authorization;
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
        private MessageService _msgService;

        public HomeController(ILogger<HomeController> logger, TopicService topicService, MessageService messageService)
        {
            _logger = logger;
            _topicService = topicService;
            _msgService = messageService;
        }

        public IActionResult Index()
        {
            HomeViewModel homeVM = new HomeViewModel()
            {
                Topics = _topicService.GetAllWithLastMessage()
            };

            return View(homeVM);
        }

        [HttpGet]
        [Authorize]
        public IActionResult CreateTopic()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult CreateTopic(TopicCreationViewModel vm)
        {
            if(ModelState.IsValid)
            {
                Member creator = HttpContext.Session.GetMember();

                _topicService.Create(vm.Title, vm.Content, creator.Id);

                return RedirectToAction(nameof(Index));
            }

            return View(vm);
        }

        public IActionResult Topic(Guid id)
        {
            Topic topic = _topicService.Get(id);
            IEnumerable<Message> messages = _msgService.GetAllOfTopic(id);

            return View(new TopicViewModel()
            {
                Topic = topic,
                Messages = messages,
                NewMessage = null
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Topic(Guid id, TopicViewModel viewModel) 
        {
            if(ModelState.IsValid)
            {
                Member creator = HttpContext.Session.GetMember();
                _msgService.Create(id, viewModel.NewMessage, creator.Id);
                return RedirectToAction(nameof(Topic));
            }

            return View(new TopicViewModel()
            {
                Topic = _topicService.Get(id),
                Messages = _msgService.GetAllOfTopic(id),
                NewMessage = viewModel.NewMessage
            });
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
