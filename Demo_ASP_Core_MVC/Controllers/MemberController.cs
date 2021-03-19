using Demo_ASP_Core_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_ASP_Core_MVC.Controllers
{
    public class MemberController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(MemberLoginViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                // TODO Utiliser les data services pour valider le login

                // TODO Si OK - Créer une session pour l'utilisateur
                // TODO Sinon - Renvoyer l'utilisateur sur la page

                return RedirectToAction("Index", "Home");
            }
            return View(viewModel);
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(MemberRegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // TODO Créer un nouveau compte avec les data services

                // TODO Créer une session pour l'utilisateur

                return RedirectToAction("Index", "Home");
            }
            return View(viewModel);
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
