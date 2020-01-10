using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.Base.Infrastructure.Utilities
{
    public static class DateTimeFormats
    {
        public const string DateFormat = "yyyy-MM-dd";
        public const string ShortTimeFormat = "HH:mm";
        public const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
        public const string ShortDateTimeFormat = "yyyy-MM-dd HH:mm";
        public const string ClientSideDateFormat = "dd-mm-yy";
        public const string ClientSideDatetimeFormat = "yyyy-MM-dd HH:mm:ss";

        public static string ToDateStringSafe(this DateTime? date)
        {
            if (date.HasValue)
                return date.Value.ToString(DateFormat);
            return string.Empty;
        }

        public static string ToDateStringSafe(this DateTime date)
        {
            if (date != null)
                return date.ToString(DateFormat);
            return string.Empty;
        }

        public static string ToShortTimeStringSafe(this DateTime? date)
        {
            if (date.HasValue)
                return date.Value.ToString(ShortTimeFormat);
            return string.Empty;
        }

        public static string ToShortTimeStringSafe(this DateTime date)
        {
            if (date != null)
                return date.ToString(ShortTimeFormat);
            return string.Empty;
        }
        public static string ToDateTimeStringSafe(this DateTime? date)
        {
            if (date.HasValue)
                return date.Value.ToString(DateTimeFormat);
            return string.Empty;
        }

        public static string ToDateTimeStringSafe(this DateTime date)
        {
            if (date != null)
                return date.ToString(DateTimeFormat);
            return string.Empty;
        }

        public static string ToShortDateTimeStringSafe(this DateTime? date)
        {
            if (date.HasValue)
                return date.Value.ToString(ShortDateTimeFormat);
            return string.Empty;
        }

        public static string ToShortDateTimeStringSafe(this DateTime date)
        {
            if (date != null)
                return date.ToString(ShortDateTimeFormat);
            return string.Empty;
        }
    }
}
