using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibary.GeneralFunctions
{
    public static class DateAndTime
    {
        public static DateTime MonthStart(DateTime? date)
        {
            return ((DateTime)date).AddDays(-((DateTime)date).Day + 1).Date;
        }
        public static DateTime LastDayOfMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, DateTime.DaysInMonth(dateTime.Year, dateTime.Month));
        }
    }
}
