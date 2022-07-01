using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IKanserTurService
    {
        List<KanserTur> GetAll();
        KanserTur GetById(int Id);
        HttpResponseMessage Create(KanserTur _KanserTur);
        HttpResponseMessage Update(KanserTur _KanserTur);
        HttpResponseMessage Delete(int Id);
    }
}
