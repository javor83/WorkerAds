using WebApplication6.AppImplement;
using WebApplication6.AppInterface;
using WebApplication6.DatabaseModels;
using WebApplication6.Models;

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
            sender.AddTransient<IServiceWageTax, ServiceWageTax>();
            sender.AddTransient<IServiceWorkCategory, ServiceWorkCategory>();
            sender.AddTransient<IServiceWorkHours, ServiceWorkHours>();
            sender.AddTransient<IServiceWorker, ServiceWorker>();
            sender.AddTransient<IServiceAdsPerson, ServiceAdsPerson>();
            sender.AddTransient<IServiceCapability, ServiceCapability>();
        }


        //**************************************************************************************************************************



    }
}
