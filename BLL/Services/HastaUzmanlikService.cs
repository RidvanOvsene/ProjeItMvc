using BLL.Services.Interfaces;
using DAL.Repositories.Interfaces;

using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace BLL.Services
{

    public class HastaUzmanlikService : IHastaUzmanlikService
    {
        private readonly IHastaUzmanlikRepository _HastaUzmanlikpository;
        public HastaUzmanlikService(IHastaUzmanlikRepository HastaUzmanlikpository)
        {
            _HastaUzmanlikpository = HastaUzmanlikpository;
        }

        public HastaUzmanlik GetById(int Id)
        {
            return _HastaUzmanlikpository.FirstOrDefault(x => x.HastaUzmanlikId == Id);
        }
        public List<HastaUzmanlik> GetAll()
        {
            return _HastaUzmanlikpository.GetAll().ToList();
        }
        public HttpResponseMessage Create(HastaUzmanlik _HastaUzmanlik)
        {
            try
            {
                _HastaUzmanlikpository.Insert(_HastaUzmanlik);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.NotModified);
            }
        }
        public HttpResponseMessage Update(HastaUzmanlik _HastaUzmanlik)
        {
            try
            {
                var HastaUzmanlik = _HastaUzmanlikpository.FirstOrDefault(x => x.HastaUzmanlikId == _HastaUzmanlik.HastaUzmanlikId);
                if (HastaUzmanlik != null)
                {

                    _HastaUzmanlikpository.Update(_HastaUzmanlik);
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
                var HastaUzmanlik = _HastaUzmanlikpository.FirstOrDefault(x => x.HastaUzmanlikId == Id);
                if (HastaUzmanlik != null)
                {
                    _HastaUzmanlikpository.Delete(HastaUzmanlik);
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
