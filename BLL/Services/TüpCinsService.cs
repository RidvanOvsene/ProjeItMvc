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
    public class TüpCinsService : ITüpCinsService
    {
        private readonly ITüpCinsRepository _TüpCinspository;
        public TüpCinsService(ITüpCinsRepository TüpCinspository)
        {
            _TüpCinspository = TüpCinspository;
        }

        public TüpCins GetById(int Id)
        {
            return _TüpCinspository.FirstOrDefault(x => x.TüpCinsId == Id);
        }
        public List<TüpCins> GetAll()
        {
            return _TüpCinspository.GetAll().ToList();
        }
        public HttpResponseMessage Create(TüpCins _TüpCins)
        {
            try
            {
                _TüpCinspository.Insert(_TüpCins);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.NotModified);
            }
        }
        public HttpResponseMessage Update(TüpCins _TüpCins)
        {
            try
            {
                var TüpCins = _TüpCinspository.FirstOrDefault(x => x.TüpCinsId == _TüpCins.TüpCinsId);
                if (TüpCins != null)
                {

                    _TüpCinspository.Update(_TüpCins);
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
                var TüpCins = _TüpCinspository.FirstOrDefault(x => x.TüpCinsId == Id);
                if (TüpCins != null)
                {
                    _TüpCinspository.Delete(TüpCins);
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
