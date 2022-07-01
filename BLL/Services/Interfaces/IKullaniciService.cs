using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IKullaniciService
    {
        Kullanici GetById(int Id);
        List<Kullanici> GetAll();
        Kullanici Login(string KullaniciAdi, string Sifre);
        HttpResponseMessage Create(Kullanici _Kullanici);
        HttpResponseMessage Update(Kullanici _Kullanici);
        HttpResponseMessage Delete(int Id);
    }
}
