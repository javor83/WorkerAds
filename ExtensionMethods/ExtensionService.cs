using GCommon.Contracts;
using GCommon.Data;
using GCommon.Services;
using Microsoft.Extensions.DependencyInjection;


namespace GCommon.ExtensionMethods
{
    public static class ExtensionService
    {
        // Scaffold-DbContext "Server=DESKTOP-EMOJLLD\SQLEXPRESS;Database=MEISTER;Trusted_Connection=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Data -force
        //**************************************************************************************************************************
        /// <summary>
        /// включва услугите специфични за приложението
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="connection_meister"></param>
        public static void Include(this IServiceCollection sender, string connection_meister)
        {
            sender.AddHttpContextAccessor();
            sender.AddDistributedMemoryCache();
            sender.AddSqlServer<MeisterContext>(connection_meister);



            sender.AddTransient<IManageAsk, ManageAsk>();
            sender.AddTransient<IWageTaxService, WageTaxService>();
            sender.AddTransient<IWorkCategoryService, WorkCategoryService>();
            sender.AddTransient<IWorkHoursService, WorkHoursService>();
            sender.AddTransient<IWorkerService, WorkerService>();
            sender.AddTransient<IAdsPersonService, AdsPersonService>();
            sender.AddTransient<ICapabilityService, CapabilityService>();

            sender.AddTransient<IPublishAdsService, PublishAdsService>();
            sender.AddScoped<ILocalProfiles, LocalProfiles>();
            sender.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60); // Session expiration
                options.Cookie.HttpOnly = true;                // Security: Prevent JS access
                options.Cookie.IsEssential = true;             // Mark as essential for GDPR
            });
        }


        //**************************************************************************************************************************



    }
}
