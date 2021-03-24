using Demo_ASP_Core_MVC.DataServices;
using Demo_ASP_Core_MVC.Models;
using Demo_ASP_Core_MVC.SessionHelper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_ASP_Core_MVC.Controllers
{
    public class MemberController : Controller
    {
        private MemberService _memberService;

        public MemberController(MemberService memberService)
        {
            _memberService = memberService;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(MemberLoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Member member = _memberService.GetByCredentials(vm.Email, vm.Password);

                if (!(member is null))
                {
                    HttpContext.Session.SetMember(member);
                    // TODO : Add ClaimIdentities in HttpContext.User
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("login-error", "L'e-mail et/ou le mot de passe sont incorrect");
            }
            return View(vm);
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
                bool errorData = false;
                if(!_memberService.CheckEmailIsAvailable(viewModel.Email))
                {
                    errorData = true;
                    ModelState.AddModelError("Email", "Cette e-mail est utilisé !");
                }

                if(!_memberService.CheckPseudoIsAvailable(viewModel.Pseudo))
                {
                    errorData = true;
                    ModelState.AddModelError("Pseudo", "Ce pseudo est utilisé (Tips: Met des chiffre :p)");
                }

                if (!errorData)
                {
                    Member member = _memberService.Create(new Member()
                    {
                        Email = viewModel.Email,
                        Pseudo = viewModel.Pseudo,
                        Password = viewModel.Password1
                    });

                    HttpContext.Session.SetMember(member);

                    return RedirectToAction("Index", "Home");
                }
            }
            return View(viewModel);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
