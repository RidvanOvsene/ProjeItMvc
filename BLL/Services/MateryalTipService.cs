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
    public class MateryalTipService : IMateryalTipService
    {
        private readonly IMateryalTipRepository _MateryalTippository;
        public MateryalTipService(IMateryalTipRepository MateryalTippository)
        {
            _MateryalTippository = MateryalTippository;
        }

        public MateryalTip GetById(int Id)
        {
            return _MateryalTippository.FirstOrDefault(x => x.MateryalTipId == Id);
        }
        public List<MateryalTip> GetAll()
        {
            return _MateryalTippository.GetAll().ToList();
        }
        public HttpResponseMessage Create(MateryalTip _MateryalTip)
        {
            try
            {
                _MateryalTippository.Insert(_MateryalTip);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.NotModified);
            }
        }
        public HttpResponseMessage Update(MateryalTip _MateryalTip)
        {
            try
            {
                var MateryalTip = _MateryalTippository.FirstOrDefault(x => x.MateryalTipId == _MateryalTip.MateryalTipId);
                if (MateryalTip != null)
                {

                    _MateryalTippository.Update(_MateryalTip);
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
                var MateryalTip = _MateryalTippository.FirstOrDefault(x => x.MateryalTipId == Id);
                if (MateryalTip != null)
                {
                    _MateryalTippository.Delete(MateryalTip);
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
