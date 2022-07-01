using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Context
{
    public class ProjeItContext : DbContext
    {
        public ProjeItContext() : base("ProjeItDB")
        {
        }
        public DbSet<HastaUzmanlik> HastaUzmanlik { get; set; }
        public DbSet<KanserTur> KanserTurleri { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<MateryalTip> MateryalTipleri { get; set; }
        public DbSet<ProjeTanim> ProjeTanimlari { get; set; }
        public DbSet<Rol> Roller { get; set; }
        public DbSet<Sponsor> Sponsor { get; set; }
        public DbSet<TüpCins> TüpCinsleri { get; set; }

        public static ProjeItContext Create()
        {
            return new ProjeItContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);

        }

    }
}
