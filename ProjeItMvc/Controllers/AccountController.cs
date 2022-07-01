using BLL.Services.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeItMvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly IKullaniciService _kullaniciService;
        private readonly IRolService _rolService;
        public AccountController(IKullaniciService kullaniciService,
                                               IRolService rolService)
        {
            _kullaniciService = kullaniciService;
            _rolService = rolService;

        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string KullaniciAdi, string Sifre)
        {
            var Data = _kullaniciService.Login(KullaniciAdi, Sifre);
            if (Data != null)
            {
                var Role = _rolService.GetById((int)Data.RolId);
                #region Session add                            

                Session["RolAdi"] = Role.RolAdi.ToString();
                
                #endregion
                return RedirectToAction("Index", "ProjeTanim");
            }
            ViewBag.kullanici = Data;
            return View();
        }
        [HttpGet]
        public ActionResult Logout()
        {
            return RedirectToAction("Login", "Account");
        }
    }
}