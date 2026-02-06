namespace WebApplication6.Models
{
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
