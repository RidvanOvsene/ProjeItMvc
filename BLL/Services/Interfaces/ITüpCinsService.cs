using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface ITüpCinsService
    {
        TüpCins GetById(int Id);
        List<TüpCins> GetAll();
        HttpResponseMessage Create(TüpCins _TüpCins);
        HttpResponseMessage Update(TüpCins _TüpCins);
        HttpResponseMessage Delete(int Id);
    }
}
