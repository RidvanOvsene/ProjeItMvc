using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface ISponsorService
    {
        Sponsor GetById(int Id);
        List<Sponsor> GetAll();
        HttpResponseMessage Create(Sponsor _Sponsor);
        HttpResponseMessage Update(Sponsor _Sponsor);
        HttpResponseMessage Delete(int Id);
    }
}
