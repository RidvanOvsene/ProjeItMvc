using BLL.Services.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeItMvc.Controllers
{
    public class SponsorController : Controller
    {
        private readonly ISponsorService _sponsorService;
        public SponsorController(ISponsorService sponsorService)
        {
            _sponsorService = sponsorService;
        }
        public ActionResult Index()
        {
            string RolAdi = Session["RolAdi"].ToString();
            ViewBag.RolAdi = RolAdi;
            var Data = _sponsorService.GetAll();
            ViewBag.List = Data;
            return View(Data);
        }
        [HttpPost]
        public ActionResult Index(int Id)
        {
            var Data = _sponsorService.GetAll();
            return View();
        }
        public ActionResult SponsorCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SponsorCreate(Sponsor sponsor)
        {
            _sponsorService.Create(sponsor);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SponsorEdit(int Id)
        {
            var _sponsor = _sponsorService.GetById(Id);
            return View(_sponsor);
        }
        [HttpPost]
        public ActionResult SponsorEdit(Sponsor sponsor)
        {
            var _sponsor = _sponsorService.GetById(sponsor.SponsorId);
            _sponsor.SponsorAdi = sponsor.SponsorAdi;
            _sponsorService.Update(_sponsor);
            return RedirectToAction("Index");
        }
        public ActionResult SponsorDelete(int Id)
        {
            var _sponsor = _sponsorService.GetById(Id);
            _sponsorService.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}