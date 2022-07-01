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
  public  class RolService : IRolService
    {
        private readonly IRolRepository _Rolpository;
        public RolService(IRolRepository Rolpository)
        {
            _Rolpository = Rolpository;
        }

        public Rol GetById(int Id)
        {
            return _Rolpository.FirstOrDefault(x => x.RolId == Id);
        }
        public List<Rol> GetAll()
        {
            return _Rolpository.GetAll().ToList();
        }
        public HttpResponseMessage Create(Rol _Rol)
        {
            try
            {
                _Rolpository.Insert(_Rol);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.NotModified);
            }
        }
        public HttpResponseMessage Update(Rol _Rol)
        {
            try
            {
                var Rol = _Rolpository.FirstOrDefault(x => x.RolId == _Rol.RolId);
                if (Rol != null)
                {

                    _Rolpository.Update(_Rol);
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
                var Rol = _Rolpository.FirstOrDefault(x => x.RolId == Id);
                if (Rol != null)
                {
                    _Rolpository.Delete(Rol);
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
