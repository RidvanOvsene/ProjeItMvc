using BLL.Services.Interfaces;
using Dal.Repositories.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SponsorService : ISponsorService
    {
        private readonly ISponsorRepository _Sponsorpository;
        public SponsorService(ISponsorRepository Sponsorpository)
        {
            _Sponsorpository = Sponsorpository;
        }

        public Sponsor GetById(int Id)
        {
            return _Sponsorpository.FirstOrDefault(x => x.SponsorId == Id);
        }
        public List<Sponsor> GetAll()
        {
            return _Sponsorpository.GetAll().ToList();
        }
        public HttpResponseMessage Create(Sponsor _Sponsor)
        {
            try
            {
                _Sponsorpository.Insert(_Sponsor);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.NotModified);
            }
        }
        public HttpResponseMessage Update(Sponsor _Sponsor)
        {
            try
            {
                var Sponsor = _Sponsorpository.FirstOrDefault(x => x.SponsorId == _Sponsor.SponsorId);
                if (Sponsor != null)
                {

                    _Sponsorpository.Update(_Sponsor);
                }

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.NotModified);
            }
        }
        public HttpResponseMessage Delete(int Id)
        {
            try
            {
                var Sponsor = _Sponsorpository.FirstOrDefault(x => x.SponsorId == Id);
                if (Sponsor != null)
                {
                    _Sponsorpository.Delete(Sponsor);
                }

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.NotModified);
            }


        }
    }
}
