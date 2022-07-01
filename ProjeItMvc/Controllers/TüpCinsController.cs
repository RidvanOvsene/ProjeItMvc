using BLL.Services.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeItMvc.Controllers
{
    public class TüpCinsController : Controller
    {
        private readonly ITüpCinsService _tüpCinsService;
        public TüpCinsController(ITüpCinsService tüpCinsService)
        {
            _tüpCinsService = tüpCinsService;
        }
        public ActionResult Index()
        {
            string RolAdi = Session["RolAdi"].ToString();
            ViewBag.RolAdi = RolAdi;
            var Data = _tüpCinsService.GetAll();
            ViewBag.List = Data;
            return View(Data);
        }
        [HttpPost]
        public ActionResult Index(int Id)
        {
            var Data = _tüpCinsService.GetAll();
            return View();
        }
        public ActionResult TüpCinsCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TüpCinsCreate(TüpCins tüpCins)
        {
            _tüpCinsService.Create(tüpCins);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult TüpCinsEdit(int Id)
        {
            var _tüpCins = _tüpCinsService.GetById(Id);
            return View(_tüpCins);
        }
        [HttpPost]
        public ActionResult TüpCinsEdit(TüpCins tüpCins)
        {
            var _tüpCins = _tüpCinsService.GetById(tüpCins.TüpCinsId);
            _tüpCins.TüpCinsAdi = tüpCins.TüpCinsAdi;
            _tüpCinsService.Update(_tüpCins);
            return RedirectToAction("Index");
        }
        public ActionResult TüpCinsDelete(int Id)
        {
            var _tüpCins = _tüpCinsService.GetById(Id);
            _tüpCinsService.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}