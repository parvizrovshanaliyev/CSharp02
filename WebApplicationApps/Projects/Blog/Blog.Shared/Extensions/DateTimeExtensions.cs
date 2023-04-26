using System;

namespace Blog.Shared.Extensions
{
    public static class DateTimeExtensions
    {
        public static string FullDateTimeStringWithUnderscore(this DateTime dateTime)
        {
            return
                $"D{dateTime.Day}_MM{dateTime.Month}_YYYY{dateTime.Year}_{dateTime.Hour}_{dateTime.Minute}_{dateTime.Millisecond}";
        }
    }
}