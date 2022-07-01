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
    public class ProjeTanimService : IProjeTanimService
    {
        private readonly IProjeTanimRepository _ProjeTanimpository;
        public ProjeTanimService(IProjeTanimRepository ProjeTanimpository)
        {
            _ProjeTanimpository = ProjeTanimpository;
        }

        public ProjeTanim GetById(int Id)
        {
            return _ProjeTanimpository.FirstOrDefault(x => x.ProjeTanimId == Id);
        }
        public List<ProjeTanim> GetAll()
        {
            return _ProjeTanimpository.GetAll().ToList();
        }
        public HttpResponseMessage Create(ProjeTanim _ProjeTanim)
        {
            try
            {
                _ProjeTanimpository.Insert(_ProjeTanim);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.NotModified);
            }
        }
        public HttpResponseMessage Update(ProjeTanim _ProjeTanim)
        {
            try
            {
                var ProjeTanim = _ProjeTanimpository.FirstOrDefault(x => x.ProjeTanimId == _ProjeTanim.ProjeTanimId);
                if (ProjeTanim != null)
                {

                    _ProjeTanimpository.Update(_ProjeTanim);
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
                var ProjeTanim = _ProjeTanimpository.FirstOrDefault(x => x.ProjeTanimId == Id);
                if (ProjeTanim != null)
                {
                    _ProjeTanimpository.Delete(ProjeTanim);
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
