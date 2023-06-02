using custom.Repository;
using DSWEBSITE_K13.Repositories.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace DSWEBSITE_K13.Libraries.Infrastructure
{
    public static class IServiceCollectionExtensions
    {
        public static void AddMyServices(this IServiceCollection services)
        {
            AddViewComponentServices(services);
            AddRepositories(services);
            services.AddSingleton<RepositoryCacheHelper>();
        }
        private static void AddRepositories(IServiceCollection services)
        {
            services.AddSingleton<VcRepository>();
            services.AddSingleton<BlogRepository>();
            services.AddSingleton<TilesRepository>();
            services.AddSingleton<RepositoryCacheHelper>();
            services.AddSingleton<PageHeadRepository>();
            services.AddSingleton<BreadcrumbRepository>();
            services.AddSingleton<ServiceRepository>();
            services.AddSingleton<ExpertRepository>();
            services.AddSingleton<HeaderRepository>();
            services.AddSingleton<TopSectionRepository>();
            services.AddSingleton<NewslatterRepository>();
            services.AddSingleton<ClienteleRepository>();
            services.AddSingleton<ProcessRepository>();
            services.AddSingleton<FooterRepository>();
            services.AddSingleton<TechnologyRepository>();
            services.AddSingleton<InnerPageSectionRepository>();
            services.AddSingleton<ActivitiesRepository>();
            services.AddSingleton<CareerRepository>();
            services.AddSingleton<ContactusRepository>();
            services.AddSingleton<SupportRepository>();
        }

        private static void AddViewComponentServices(IServiceCollection services)
        {
        }
    }
}
