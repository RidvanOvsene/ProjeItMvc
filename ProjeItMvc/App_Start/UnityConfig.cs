using BLL.Services;
using BLL.Services.Interfaces;
using Dal.Repositories;
using Dal.Repositories.Interfaces;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using System;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace ProjeItMvc.App_Start
{
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            return container;
        });

        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion
        public static void RegisterTypes(IUnityContainer container)
        {

            container.RegisterType<IHastaUzmanlikService, HastaUzmanlikService>();
            container.RegisterType<IHastaUzmanlikRepository, HastaUzmanlikRepository>();

            container.RegisterType<IKanserTurService, KanserTurService>();
            container.RegisterType<IKanserTurRepository, KanserTurRepository>();

            container.RegisterType<IKullaniciService, KullaniciService>();
            container.RegisterType<IKullaniciRepository, KullaniciRepository>();

            container.RegisterType<IMateryalTipService, MateryalTipService>();
            container.RegisterType<IMateryalTipRepository, MateryalTipRepository>();

            container.RegisterType<IProjeTanimService, ProjeTanimService>();
            container.RegisterType<IProjeTanimRepository, ProjeTanimRepository>();

            container.RegisterType<ISponsorService, SponsorService>();
            container.RegisterType<ISponsorRepository, SponsorRepository>();

            container.RegisterType<ITüpCinsService, TüpCinsService>();
            container.RegisterType<ITüpCinsRepository, TüpCinsRepository>();

            container.RegisterType<IRolService, RolService>();
            container.RegisterType<IRolRepository, RolRepository>();
        }
    }
}