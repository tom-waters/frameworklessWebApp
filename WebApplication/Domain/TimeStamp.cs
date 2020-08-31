using System;

namespace WebApplication.Domain
{
    public static class TimeStamp
    {
        public static string FormatDate(DateTime dateTime)
        {
            var time = dateTime.ToString("h:mm tt");
            var date = dateTime.ToString("dd MMMM yyyy");
            return $"{time} on {date}";
        }
    }
}