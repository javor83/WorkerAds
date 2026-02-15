using Microsoft.AspNetCore.Mvc;
using GCommon.Models;

namespace WebApplication6.Views.Shared
{
    /// <summary>
    /// контрола за успешно направени промени по базата
    /// </summary>
    public class SucccessAlertViewComponent:ViewComponent
    {

        public IViewComponentResult Invoke(string caption)
        {
          
            return View<string>(caption);
        }

    }
}
