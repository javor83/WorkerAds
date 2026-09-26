using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication6.Controllers
{
    public class CultureController : Controller
    {
        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            // 1. Create the cookie value using ASP.NET Core's built-in helper
            string cookieValue = CookieRequestCultureProvider.MakeCookieValue(
                new RequestCulture(culture)
            );

            // 2. Append the cookie to the response (valid for 1 year)
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName, // ".AspNetCore.Culture"
                cookieValue,
                new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1),
                    IsEssential = true, // Ensures it works even if cookie consent is strict
                    HttpOnly = true
                }
            );

            // 3. Redirect back to the page the user came from
            if (Url.IsLocalUrl(returnUrl))
            {
                return LocalRedirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
