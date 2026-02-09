using WebApplication6.Services;
using WebApplication6.Interfaces;
using WebApplication6.Data;

namespace WebApplication6.ExtensionMethods
{
    public static class ExtensionService
    {
        // Scaffold-DbContext "Server=DESKTOP-EMOJLLD\SQLEXPRESS;Database=MEISTER;Trusted_Connection=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir DatabaseModels -force
        //**************************************************************************************************************************
        /// <summary>
        /// включва услугите специфични за приложението
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="connection_meister"></param>
        public static void Include(this IServiceCollection sender, string connection_meister)
        {
            sender.AddSqlServer<MeisterContext>(connection_meister);
            sender.AddTransient<IWageTaxService, WageTaxService>();
            sender.AddTransient<IWorkCategoryService, WorkCategoryService>();
            sender.AddTransient<IWorkHoursService, WorkHoursService>();
            sender.AddTransient<IWorkerService, WorkerService>();
            sender.AddTransient<IAdsPersonService, AdsPersonService>();
            sender.AddTransient<ICapabilityService, CapabilityService>();

            sender.AddTransient<IPublishAdsService, PublishAdsService>();
        }


        //**************************************************************************************************************************



    }
}
