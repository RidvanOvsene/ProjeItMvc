using BLL.Services.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeItMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHastaUzmanlikService _hastaUzmanlikService;
        public HomeController(IHastaUzmanlikService hastaUzmanlikService)
        {
            _hastaUzmanlikService = hastaUzmanlikService;
        }
        public ActionResult Index()
        {
            string RolAdi = Session["RolAdi"].ToString();
            ViewBag.RolAdi = RolAdi;
            var Data = _hastaUzmanlikService.GetAll();
            ViewBag.List = Data;
            return View(Data);
        }
        [HttpPost]
        public ActionResult Index(int Id)
        {
            var Data = _hastaUzmanlikService.GetAll();
            return View();
        }
        public ActionResult HastaUzmanlikCreate()
        {
            //var HastaUzmanlik = _hastaUzmanlikService.GetById(Id);
            return View();
        }
        [HttpPost]
        public ActionResult HastaUzmanlikCreate(HastaUzmanlik hastaUzmanlik)
        {
            _hastaUzmanlikService.Create(hastaUzmanlik);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult HastaUzmanlikEdit(int Id)
        {
            var _hastaUzmanlik = _hastaUzmanlikService.GetById(Id);
            return View(_hastaUzmanlik);
        }
        [HttpPost]
        public ActionResult HastaUzmanlikEdit(HastaUzmanlik hastaUzmanlik)
        {
            var _hastaUzman = _hastaUzmanlikService.GetById(hastaUzmanlik.HastaUzmanlikId);
            _hastaUzman.HastaUzmanlikAdi = hastaUzmanlik.HastaUzmanlikAdi;
            _hastaUzmanlikService.Update(_hastaUzman);
            return RedirectToAction("Index");
        }
        public ActionResult HastaUzmanlikDelete(int Id)
        {
            var _hastaUzmanlik = _hastaUzmanlikService.GetById(Id);
            _hastaUzmanlikService.Delete(Id);
            return RedirectToAction("Index");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}