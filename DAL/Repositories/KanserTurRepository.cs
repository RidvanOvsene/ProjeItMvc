using Dal.Context;
using Dal.Repositories.Interfaces;
using DAL.BaseRepository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repositories
{
    public class KanserTurRepository : BaseRepository<KanserTur>, IKanserTurRepository
    {
        public KanserTurRepository(ProjeItContext context) : base(context)
        {
        }
    }
}
