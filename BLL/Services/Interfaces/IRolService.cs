using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IRolService
    {
        Rol GetById(int Id);
        List<Rol> GetAll();
        HttpResponseMessage Create(Rol _Rol);
        HttpResponseMessage Update(Rol _Rol);
        HttpResponseMessage Delete(int Id);

    }
}
