using DAL.BaseRepository;
using DAL.Repositories.Interfaces;
using Dal.Context;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class HastaUzmanlikRepository : BaseRepository<HastaUzmanlik>, IHastaUzmanlikRepository
    {
        public HastaUzmanlikRepository(ProjeItContext context) : base(context)
        {
        }
    }
}
