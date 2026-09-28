using GCommon.Contracts;
using GCommon.Data;
using GCommon.Models;
using GCommon.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using WebApplication6.Data;


namespace GCommon.ExtensionMethods
{
    public static class ExtensionService
    {
        extension(WebApplication app)
        {
            public void AppLocalize()
            {


                app.UseRequestLocalization();


            }
        }

        extension(IServiceCollection sender)
        {
            public void Languages()
            {
                var supportedCultures = new CultureInfo[]
                {
                    new CultureInfo("en-us"), // English
                    new CultureInfo("bg-bg"), // Bulgarian
                };
                sender.Configure<RequestLocalizationOptions>(options =>
                {
                    options.DefaultRequestCulture = new RequestCulture("en-us");

                    // Formatting for numbers, dates, currency
                    options.SupportedCultures = supportedCultures;

                    // UI string translations (populates LocOptions.Value.SupportedUICultures)
                    options.SupportedUICultures = supportedCultures;
                });

                // 1. локализация като услуга в "Resources" папка
                sender.AddLocalization(options => options.ResourcesPath = "Resources");
            }



            // Scaffold-DbContext "Server=localhost\SQLEXPRESS;Database=MEISTER;Trusted_Connection=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Data -force
            // Scaffold-DbContext "Server=DESKTOP-H09IM5N;Database=MEISTER;Trusted_Connection=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Data -force
            //**************************************************************************************************************************
            /// <summary>
            /// включва услугите специфични за приложението
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="connection_meister"></param>
            public void Include(string connection_meister)
            {
                sender.AddHttpContextAccessor();
                sender.AddDistributedMemoryCache();
                sender.AddSqlServer<MeisterContext>(connection_meister);


                sender.AddTransient<IManageOrders, ManageOrders>();
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
                //-------------------------------------------------------------------
               


               
            }
        }

        
        //**************************************************************************************************************************
    }
}
