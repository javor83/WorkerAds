using WebApplication6.DatabaseModels;

namespace WebApplication6.Models
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
        public static void Include(this IServiceCollection sender,string connection_meister)
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
        /// <summary>
        /// показва само името на контролера
        /// </summary>
        /// <param name="con_name"></param>
        /// <returns></returns>
        public static string Navigate(this string con_name)
        {

            string result = con_name.Substring(0, con_name.IndexOf("Controller"));
            return result;
        }
        
        //**************************************************************************************************************************



    }
}
