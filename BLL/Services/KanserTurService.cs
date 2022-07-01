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
    public class KanserTurService : IKanserTurService
    {
        private readonly IKanserTurRepository _KanserTurpository;
        public KanserTurService(IKanserTurRepository KanserTurpository)
        {
            _KanserTurpository = KanserTurpository;
        }

        public KanserTur GetById(int Id)
        {
            return _KanserTurpository.FirstOrDefault(x => x.KanserTurId == Id);
        }
        public List<KanserTur> GetAll()
        {
            return _KanserTurpository.GetAll().ToList();
        }
        public HttpResponseMessage Create(KanserTur _KanserTur)
        {
            try
            {
                _KanserTurpository.Insert(_KanserTur);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.NotModified);
            }
        }
        public HttpResponseMessage Update(KanserTur _KanserTur)
        {
            try
            {
                var KanserTur = _KanserTurpository.FirstOrDefault(x => x.KanserTurId == _KanserTur.KanserTurId);
                if (KanserTur != null)
                {

                    _KanserTurpository.Update(_KanserTur);
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
                var KanserTur = _KanserTurpository.FirstOrDefault(x => x.KanserTurId == Id);
                if (KanserTur != null)
                {
                    _KanserTurpository.Delete(KanserTur);
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
