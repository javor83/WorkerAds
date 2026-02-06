namespace WebApplication6.ExtensionMethods
{
    /// <summary>
    /// оформление на датата
    /// </summary>
    public static class ExtensionDateTime
    {
        /// <summary>
        /// показва датата - само деня, без час
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static string OnlyDatePart(this DateTime? sender)
        {
            return Convert.ToDateTime(sender).ToString("dd.MMMM.yyyy");
        }


    }
}
