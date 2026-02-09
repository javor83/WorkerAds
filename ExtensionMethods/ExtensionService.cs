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
            sender.AddTransient<IWageTaxService, ServiceWageTax>();
            sender.AddTransient<IWorkCategoryService, ServiceWorkCategory>();
            sender.AddTransient<IWorkHoursIService, ServiceWorkHours>();
            sender.AddTransient<IWorkerService, ServiceWorker>();
            sender.AddTransient<IAdsPersonService, ServiceAdsPerson>();
            sender.AddTransient<ICapabilityService, ServiceCapability>();

            sender.AddTransient<IPublishAdsService, PublishAds>();
        }


        //**************************************************************************************************************************



    }
}
