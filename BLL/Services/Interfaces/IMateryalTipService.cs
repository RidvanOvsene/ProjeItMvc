using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
   public interface IMateryalTipService
    {
        MateryalTip GetById(int Id);
        List<MateryalTip> GetAll();
        HttpResponseMessage Create(MateryalTip _MateryalTip);
        HttpResponseMessage Update(MateryalTip _MateryalTip);
        HttpResponseMessage Delete(int Id);
    }
}
