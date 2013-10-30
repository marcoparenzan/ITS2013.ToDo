using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS2013.BestPractices
{
    public static class DateTimeExtension
    {
        public static DateTime Tomorrow(this DateTime that)
        {
            return that.AddDays(1);
        }

        public static DateTime TomorrowWork(this DateTime that)
        {
            while (true)
            {
                that = that.AddDays(1);
                if ((that.DayOfWeek != DayOfWeek.Sunday) 
                    || (that.DayOfWeek != DayOfWeek.Saturday)) break;
            }
            return that;
        }

        public static DateTime Yesterday(this DateTime that)
        {
            return that.AddDays(-1);
        }

        public static DateTime At(
            this DateTime that
            , double? hh = null
            , double? mm = null
            , double? ss = null
        )
        {
            if (hh.HasValue) that = that.AddHours(hh.Value);
            if (mm.HasValue) that = that.AddMinutes(mm.Value);
            if (ss.HasValue) that = that.AddSeconds(ss.Value);
            return that;
        }
    }
}
