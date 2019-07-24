using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCMS.Infrastructure.Helper
{
    public class CommonLogic
    {
        #region "DB Value Conversion Related Function"

        public static string GetStringValue(object value)
        {
            return Convert.ToString(value);
        }

        public static int GetIntValue(object value)
        {
            return Convert.ToInt32(value);
        }

        public static bool GetBoolValue(object value)
        {
            return Convert.ToBoolean(value);
        }

        public static decimal GetDecimalValue(object value)
        {
            return Math.Round(Convert.ToDecimal(value), 2);
        }

        public static bool GetBoolValue(object value, bool defaultValue)
        {
            return Convert.IsDBNull(value) ? defaultValue : Convert.ToBoolean(value);
        }

        public static DateTime GetDateTimeValue(object value)
        {
            if (Convert.IsDBNull(value))
                return DateTime.MinValue;
            else
                return Convert.ToDateTime(value);
        }

        public static decimal GetDecimalValue(object value, decimal defaultValue)
        {
            return Convert.IsDBNull(value) ? Math.Round(defaultValue, 2) : Math.Round(Convert.ToDecimal(value), 2);
        }

        public static string GetStringValue(object value, string defaultValue)
        {
            return Convert.IsDBNull(value) ? defaultValue : Convert.ToString(value);
        }

        public static int GetIntValue(object value, int defaultValue)
        {
            return Convert.IsDBNull(value) ? defaultValue : Convert.ToInt32(value);
        }

        public static Int16 GetShortValue(object value)
        {
            return Convert.ToInt16(value);
        }

        public static Int16 GetShortValue(object value, short defaultValue)
        {
            return Convert.IsDBNull(value) ? defaultValue : Convert.ToInt16(value);
        }
        #endregion

        #region "Conversion Related Function"

        public static DateTime ConvertToDateTime(string value)
        {
            return Convert.ToDateTime(value);
        }

        public static string DatimeFormat(object value, string Format)
        {
            if (Convert.IsDBNull(value))
                return "";
            return Convert.ToDateTime(value).ToString(Format);
        }

        public static int ConvertToInt(string value)
        {
            return Convert.ToInt32(value);
        }

        public static string ConvertToString(object value)
        {
            return Convert.ToString(value);
        }

        public static string GetDateFormat(object value)
        {
            if (Convert.IsDBNull(value))
                return "";
            if (Convert.ToDateTime(value) == DateTime.MinValue)
                return "";
            return Convert.ToDateTime(value).ToString("MM/dd/yyyy");
        }

        public static string GetDateTimeFormat(object value)
        {
            return Convert.ToDateTime(value).ToString("MM/dd/yyyy HH:mm");
        }

        public static string GetCurrencyFormat(object value)
        {
            return "$" + GetDecimalValue(value, Convert.ToDecimal("0.00")).ToString();
        }

        #endregion
    }
}
