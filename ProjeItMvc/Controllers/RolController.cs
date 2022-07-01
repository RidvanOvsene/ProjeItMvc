using BLL.Services.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeItMvc.Controllers
{
    public class RolController : Controller
    {
        private readonly IRolService _rolService;
        public RolController(IRolService rolService)
        {
            _rolService = rolService;
        }
        public ActionResult Index()
        {
            var Data = _rolService.GetAll();
            ViewBag.List = Data;
            return View(Data);
        }
        [HttpPost]
        public ActionResult Index(int Id)
        {
            var Data = _rolService.GetAll();
            return View();
        }
        public ActionResult RolCreate(int Id)
        {
            var Rol = _rolService.GetById(Id);
            return View(Rol);
        }
        [HttpPost]
        public ActionResult RolCreate(Rol rol)
        {
            var _hastaUzman = _rolService.GetById(rol.RolId);
            _rolService.Create(_hastaUzman);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult RolEdit(int Id)
        {
            var _rol = _rolService.GetById(Id);
            return View(_rol);
        }
        [HttpPost]
        public ActionResult RolEdit(Rol rol)
        {
            var _rol = _rolService.GetById(rol.RolId);
            _rol.RolAdi = rol.RolAdi;
            _rolService.Update(_rol);
            return RedirectToAction("Index");
        }
        public ActionResult RolDelete(int Id)
        {
            var _rol = _rolService.GetById(Id);
            _rolService.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}