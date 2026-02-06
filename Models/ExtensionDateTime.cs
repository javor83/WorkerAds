namespace WebApplication6.Models
{
    public static class ExtensionDateTime
    {
        public static string OnlyDatePart(this DateTime? sender)
        {
            return Convert.ToDateTime(sender).ToString("dd.MMMM.yyyy");
        }


    }
}
