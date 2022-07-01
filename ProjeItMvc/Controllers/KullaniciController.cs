using BLL.Services.Interfaces;
using Dal.Context;
using Entities;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeItMvc.Controllers
{
    public class KullaniciController : Controller
    {
        private ProjeItContext db = new ProjeItContext();
        private readonly IKullaniciService _kullaniciService;
        private readonly IRolService _rolService;
        public KullaniciController(IKullaniciService kullaniciService,
                                               IRolService rolService)
        {
            _kullaniciService = kullaniciService;
            _rolService = rolService;

        }
        public ActionResult KullaniciList()
        {
            string RolAdi = Session["RolAdi"].ToString();
            ViewBag.RolAdi = RolAdi;
            var Kullanici = (from a in db.Kullanicilar
                             join c in db.Roller on a.RolId equals c.RolId
                             select new KullaniciDto
                             {
                                 KullaniciId=a.KullaniciId,
                                 KullaniciAdi = a.KullaniciAdi,
                                 AdiSoyadi = a.AdiSoyadi,
                                 RolId=c.RolId,
                                 RolAdi = c.RolAdi
                             }).ToList();
        
            return View(Kullanici);
        }
        [HttpPost]
        public ActionResult KullaniciList(int Id)
        {
            var Data = _kullaniciService.GetAll();
         
            return View();
        }
        public ActionResult KullaniciCreate()
        {
            var Rol = _rolService.GetAll();
            ViewBag.Rol = Rol;
            return View();
        }
        [HttpPost]
        public ActionResult KullaniciCreate(Kullanici kullanici)
        {
            _kullaniciService.Create(kullanici);
            return RedirectToAction("KullaniciList");
        }
        [HttpGet]
        public ActionResult KullaniciEdit(int Id )
        {
            var _kullanici = _kullaniciService.GetById(Id);
            var Rol = _rolService.GetAll();
            ViewBag.kullanıcı = _kullanici;
            ViewBag.Rol = Rol;
            return View(_kullanici);
        }
        [HttpPost]
        public ActionResult KullaniciEdit(Kullanici kullanici)
        {
            var _kullanici = _kullaniciService.GetById(kullanici.KullaniciId);
            _kullanici.AdiSoyadi = kullanici.AdiSoyadi;
            _kullanici.KullaniciAdi = kullanici.KullaniciAdi;
            _kullanici.RolId = kullanici.RolId;
            _kullanici.Sifre = _kullanici.Sifre;
            _kullaniciService.Update(_kullanici);

            return RedirectToAction("KullaniciList");
        }
        public ActionResult KullaniciDelete(int Id)
        {
            var _kullanici = _kullaniciService.GetById(Id);
            _kullaniciService.Delete(Id);
            return RedirectToAction("KullaniciList");
        }
    }
}