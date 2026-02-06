namespace WebApplication6.Models
{
    /// <summary>
    /// статично оформление на парите със знак
    /// </summary>
    public static class ExtensionDecimal
    {
        public static string ToMoney(this decimal? value)
        {
            return $"€ {value:F2}";
                 
        }
        public static string ToMoney(this decimal value)
        {
            return $"€ {value:F2}";

        }
    }
}
