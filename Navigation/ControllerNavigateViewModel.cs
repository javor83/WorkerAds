using GCommon.ExtensionMethods;
using WebApplication6.Controllers;

namespace GCommon.Navigation
{
    /// <summary>
    /// навигация от изгледите към съответния контролер
    /// </summary>
    public class ControllerNavigateViewModel
    {
        public static readonly string UserAsk = nameof(UserAskController).Navigate();
        public static readonly string UserAsk_IncludeAsk = nameof(UserAskController.IncludeAsk);
        //---------------------------
        public static readonly string WageTax = nameof(WageTaxController).Navigate();
        public static readonly string WageTax_Index = nameof(WageTaxController.Index);
        public static readonly string WageTax_Create = nameof(WageTaxController.Create);
        public static readonly string WageTax_Delete = nameof(WageTaxController.Delete);
        public static readonly string WageTax_Update = nameof(WageTaxController.Update);
        //---------------------------
        public static readonly string Home = nameof(HomeController).Navigate();
        public static readonly string Home_Index = nameof(HomeController.Index);
        public static readonly string Home_Ads = nameof(HomeController.Ads);
        //---------------------------
        public static readonly string WorkCategory = nameof(WorkCategoryController).Navigate();
        public static readonly string WorkCategory_Index = nameof(WorkCategoryController.Index);
        public static readonly string WorkCategory_Delete = nameof(WorkCategoryController.Delete);
        public static readonly string WorkCategory_Edit = nameof(WorkCategoryController.Edit);
        public static readonly string WorkCategory_Create = nameof(WorkCategoryController.Create);
        //---------------------------
        public static readonly string WorkHour = nameof(WorkHourController).Navigate();
        public static readonly string WorkHour_Index = nameof(WorkHourController.Index);
        public static readonly string WorkHourController_Create = nameof(WorkHourController.Create);
        public static readonly string WorkHourController_Delete = nameof(WorkHourController.Delete);
        public static readonly string WorkHourController_Edit = nameof(WorkHourController.Edit);
        //---------------------------
        public static readonly string Worker = nameof(WorkerController).Navigate();
        public static readonly string Worker_Index = nameof(WorkerController.Index);
        public static readonly string Worker_Create = nameof(WorkerController.Create);
        public static readonly string Worker_Edit = nameof(WorkerController.Edit);
        public static readonly string Worker_Delete = nameof(WorkerController.Delete);
        public static readonly string Worker_Capability = nameof(WorkerController.Capability);
        public static readonly string Worker_EditCapability = nameof(WorkerController.EditCapability);
        public static readonly string Worker_EmptyCapability = nameof(WorkerController.EmptyCapability);
        public static readonly string Worker_DeleteCapability = nameof(WorkerController.DeleteCapability);
        public static readonly string Worker_Ads = nameof(WorkerController.Ads);

        public static readonly string Worker_EmptyAds = nameof(WorkerController.EmptyAds);
        public static readonly string Worker_DeleteAds = nameof(WorkerController.DeleteAds);
        public static readonly string Worker_EditAds = nameof(WorkerController.EditAds);
        //---------------------------
    }
}
