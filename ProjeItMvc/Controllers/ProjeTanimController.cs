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
    public class ProjeTanimController : Controller
    {
       
        private ProjeItContext db = new ProjeItContext();
        private readonly IProjeTanimService _projeTanimService;
        private readonly ISponsorService _sponsorService;
        private readonly IHastaUzmanlikService _hastaUzmanlikService;
        private readonly IKanserTurService _kanserTurService;
        private readonly IMateryalTipService _materyalTipService;
        private readonly ITüpCinsService _tüpCinsService;
        public ProjeTanimController(IProjeTanimService projeTanimService,
                                ISponsorService sponsorService,
                                IHastaUzmanlikService hastaUzmanlikService,
                                IKanserTurService kanserTurService,
                                IMateryalTipService materyalTipService,
                                ITüpCinsService tüpCinsService)
        {
            _projeTanimService = projeTanimService;
            _sponsorService = sponsorService;
            _hastaUzmanlikService = hastaUzmanlikService;
            _kanserTurService = kanserTurService;
            _materyalTipService = materyalTipService;
            _tüpCinsService = tüpCinsService;
        }
        public ActionResult Index()
        {
            string RolAdi = Session["RolAdi"].ToString();
            ViewBag.RolAdi = RolAdi;
            var Proje = (from a in db.ProjeTanimlari
                             join b in db.Sponsor on a.SponsorId equals b.SponsorId
                             join c in db.HastaUzmanlik on a.HastaUzmanlikId equals c.HastaUzmanlikId
                             join d in db.KanserTurleri on a.KanserTurId equals d.KanserTurId
                             join e in db.MateryalTipleri on a.MateryalTipId equals e.MateryalTipId
                             join f in db.TüpCinsleri on a.TüpCinsId equals f.TüpCinsId
                             select new ProjeTanimDto
                             {
                                 ProjeTanimId = a.ProjeTanimId,
                                 ProjeTanimAdi = a.ProjeTanimAdi,
                                 SponsorId = b.SponsorId,
                                 SponsorAdi = b.SponsorAdi,
                                 HastaUzmanlikId = c.HastaUzmanlikId,
                                 HastaUzmanlikAdi = c.HastaUzmanlikAdi,
                                 KanserTurId = d.KanserTurId,
                                 KanserTurAdi = d.KanserTurAdi,
                                 MateryalTipId = e.MateryalTipId,
                                 MateryalTipAdi = e.MateryalTipAdi,
                                 TüpCinsId = f.TüpCinsId,
                                 TüpCinsAdi = f.TüpCinsAdi
                             }).ToList();
            //var Data = _projeTanimService.GetAll();
            //ViewBag.List = Data;
            return View(Proje);
        }
        [HttpPost]
        public ActionResult Index(int Id)
        {
            var Data = _projeTanimService.GetAll();
            return View();
        }
        public ActionResult ProjeTanimCreate()
        {
            var Sponsor = _sponsorService.GetAll();
            var HastaUzmanlik = _hastaUzmanlikService.GetAll();
            var KanserTur = _kanserTurService.GetAll();
            var MateryalTip = _materyalTipService.GetAll();
            var TüpCins = _tüpCinsService.GetAll();
            ViewBag.Sponsors = Sponsor;
            ViewBag.HastaUzmanlik = HastaUzmanlik;
            ViewBag.KanserTur = KanserTur;
            ViewBag.MataryalTip = MateryalTip;
            ViewBag.Tüpcins = TüpCins;
            return View();
        }
        [HttpPost]
        public ActionResult ProjeTanimCreate(ProjeTanim projeTanim)
        {
            _projeTanimService.Create(projeTanim);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ProjeTanimEdit(int Id)
        {
            var _projeTanim = _projeTanimService.GetById(Id);
            var Sponsor = _sponsorService.GetAll();
            var HastaUzmanlik = _hastaUzmanlikService.GetAll();
            var KanserTur = _kanserTurService.GetAll();
            var MateryalTip = _materyalTipService.GetAll();
            var TüpCins = _tüpCinsService.GetAll();
            ViewBag.Proje = _projeTanim;
            ViewBag.Sponsors = Sponsor;
            ViewBag.HastaUzmanlik = HastaUzmanlik;
            ViewBag.KanserTur = KanserTur;
            ViewBag.MataryalTip = MateryalTip;
            ViewBag.TüpCins = TüpCins;
            return View(_projeTanim);
        }
        [HttpPost]
        public ActionResult ProjeTanimEdit(ProjeTanim projeTanim)
        {
            var _projeTanim = _projeTanimService.GetById(projeTanim.ProjeTanimId);
            _projeTanim.ProjeTanimAdi = projeTanim.ProjeTanimAdi;
            _projeTanim.SponsorId = projeTanim.SponsorId;
            _projeTanim.HastaUzmanlikId = projeTanim.HastaUzmanlikId;
            _projeTanim.KanserTurId = projeTanim.KanserTurId;
            _projeTanim.MateryalTipId = projeTanim.MateryalTipId;
            _projeTanim.TüpCinsId = projeTanim.TüpCinsId;
            _projeTanimService.Update(_projeTanim);
            return RedirectToAction("Index");
        }
        public ActionResult ProjeTanimDelete(int Id)
        {
            var _projeTanim = _projeTanimService.GetById(Id);
            _projeTanimService.Delete(Id);
            return RedirectToAction("Index");
        }
             
    }
}