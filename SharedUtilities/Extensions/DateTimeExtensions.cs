namespace SharedUtilities.Extensions
{
    public static class DateTimeExtensions
    {
        public static string GetDaySuffix(this int day)
        {
            switch (day)
            {
                case 1:
                case 21:
                case 31:
                    return "st";
                case 2:
                case 22:
                    return "nd";
                case 3:
                case 23:
                    return "rd";
                default:
                    return "th";
            }
        }

        public static string GetDayWithSuffix(this int day)
        {
            return day + GetDaySuffix(day);
        }
    }
}
