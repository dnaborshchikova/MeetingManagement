using System;

namespace MeetingManagement
{
    public static class DatetimeProvider
    {
        public static string ConvertToShortTimeString(DateTime date)
        {
            return date.ToShortTimeString();
        }

        public static DateTime ParseDateToDatetimeFormat(string dateTime)
        {
            return DateTime.ParseExact(dateTime, DatetimeConfig.DatetimeFormat
                , System.Globalization.CultureInfo.InvariantCulture);
        }

        public static DateTime ParseDateToDateFormat(string dateTime)
        {
            return DateTime.ParseExact(dateTime, DatetimeConfig.DateFormat
                , System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
