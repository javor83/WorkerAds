using Microsoft.AspNetCore.Mvc;

namespace WebApplication6.Views.Shared
{
    public class ManagerSubtitleViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke(string caption)
        {
            return View<string>(caption);
        }
    }
}
