using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IHastaUzmanlikService
    {
        List<HastaUzmanlik> GetAll();
        HastaUzmanlik GetById(int Id);
        HttpResponseMessage Create(HastaUzmanlik _HastaUzmanlik);
        HttpResponseMessage Update(HastaUzmanlik _HastaUzmanlik);
        HttpResponseMessage Delete(int Id);
    }
}
