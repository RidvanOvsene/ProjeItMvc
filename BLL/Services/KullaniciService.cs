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
    public class KullaniciService : IKullaniciService
    {
        private readonly IKullaniciRepository _Kullanicipository;
        public KullaniciService(IKullaniciRepository Kullanicipository)
        {
            _Kullanicipository = Kullanicipository;
        }
        public Kullanici GetById(int Id)
        {
            return _Kullanicipository.FirstOrDefault(x => x.KullaniciId == Id);
        }
        public List<Kullanici> GetAll()
        {
            return _Kullanicipository.GetAll().ToList();
        }
        public Kullanici Login(string KullaniciAdi, string Sifre)
        {
            return _Kullanicipository.FirstOrDefault(r => r.KullaniciAdi == KullaniciAdi && r.Sifre == Sifre);
        }
        public HttpResponseMessage Create(Kullanici _Kullanici)
        {
            try
            {
                _Kullanicipository.Insert(_Kullanici);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.NotModified);
            }
        }
        public HttpResponseMessage Update(Kullanici _Kullanici)
        {
            try
            {
                var Kullanici = _Kullanicipository.FirstOrDefault(x => x.KullaniciId == _Kullanici.KullaniciId);
                if (Kullanici != null)
                {

                    _Kullanicipository.Update(_Kullanici);
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
                var Kullanici = _Kullanicipository.FirstOrDefault(x => x.KullaniciId == Id);
                if (Kullanici != null)
                {
                    _Kullanicipository.Delete(Kullanici);
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
