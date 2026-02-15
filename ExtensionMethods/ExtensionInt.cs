namespace GCommon.ExtensionMethods
{
    public static class ExtensionInt
    {
        public static string PrintableHour(this int hour_value, int minute_value)
        {
            return $"{hour_value:D2}:{minute_value:D2}";
        }

        public static string PrintableHour(this int? hour_value, int? minute_value)
        {
            return $"{hour_value:D2}:{minute_value:D2}";
        }

    }
}
