using BLL.Services.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeItMvc.Controllers
{
    public class KanserTurController : Controller
    {
        private readonly IKanserTurService _kanserTurService;
        public KanserTurController(IKanserTurService kanserTurService)
        {
            _kanserTurService = kanserTurService;
        }
        public ActionResult Index()
        {
            string RolAdi = Session["RolAdi"].ToString();
            ViewBag.RolAdi = RolAdi;
            var Data = _kanserTurService.GetAll();
            ViewBag.List = Data;
            return View(Data);
        }
        [HttpPost]
        public ActionResult Index(int Id)
        {
            var Data = _kanserTurService.GetAll();
            return View();
        }
        public ActionResult KanserTurCreate()
        {

            return View();
        }
        [HttpPost]
        public ActionResult KanserTurCreate(KanserTur kanserTur)
        {
            _kanserTurService.Create(kanserTur);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult KanserTurEdit(int Id)
        {
            var _kanserTur = _kanserTurService.GetById(Id);
            return View(_kanserTur);
        }
        [HttpPost]
        public ActionResult KanserTurEdit(KanserTur kanserTur)
        {
            var _kanserTur = _kanserTurService.GetById(kanserTur.KanserTurId);
            _kanserTur.KanserTurAdi = kanserTur.KanserTurAdi;
            _kanserTurService.Update(_kanserTur);
            return RedirectToAction("Index");
        }
        public ActionResult KanserTurDelete(int Id)
        {
            var _kanserTur = _kanserTurService.GetById(Id);
            _kanserTurService.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}