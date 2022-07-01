using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IProjeTanimService
    {
        ProjeTanim GetById(int Id);
        List<ProjeTanim> GetAll();
        HttpResponseMessage Create(ProjeTanim _ProjeTanim);
        HttpResponseMessage Update(ProjeTanim _ProjeTanim);
        HttpResponseMessage Delete(int Id);

    }
}
