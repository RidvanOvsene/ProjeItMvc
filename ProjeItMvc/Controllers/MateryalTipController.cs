 using BLL.Services.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeItMvc.Controllers
{
 
    public class MateryalTipController : Controller
    {
        private readonly IMateryalTipService _materyalTipService;
        public MateryalTipController(IMateryalTipService materyalTipService)
        {
            _materyalTipService = materyalTipService;
        }
        public ActionResult Index()
        {
            string RolAdi = Session["RolAdi"].ToString();
            ViewBag.RolAdi = RolAdi;
            var Data = _materyalTipService.GetAll();
            ViewBag.List = Data;
            return View(Data);
        }
        [HttpPost]
        public ActionResult Index(int Id)
        {
            var Data = _materyalTipService.GetAll();
            return View();
        }
        public ActionResult MateryalTipCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MateryalTipCreate(MateryalTip materyalTip)
        {

            _materyalTipService.Create(materyalTip);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult MateryalTipEdit(int Id)
        {
            var _materyalTip = _materyalTipService.GetById(Id);
            return View(_materyalTip);
        }
        [HttpPost]
        public ActionResult MateryalTipEdit(MateryalTip materyalTip)
        {
            var _materyalTip = _materyalTipService.GetById(materyalTip.MateryalTipId);
            _materyalTip.MateryalTipAdi = materyalTip.MateryalTipAdi;
            _materyalTipService.Update(_materyalTip);
            return RedirectToAction("Index");
        }
        public ActionResult MateryalTipDelete(int Id)
        {
            var _materyalTip = _materyalTipService.GetById(Id);
            _materyalTipService.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}