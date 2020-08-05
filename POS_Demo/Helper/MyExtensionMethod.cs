using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace POS_Demo.Helper
{
    public static class MyExtensionMethod
    {
        public static string asSomeLocalCurrency(this int money, CultureInfo cInfo)
        {
            return (money / 100m).ToString("c", cInfo); // e.g. 12345 with InvariantCulture is ¤123.45
        }

        public static string ToYesNo(this bool b)
        {
            return b ? "Yes" : "No";
        }

        public static string ToActivate(this bool b)
        {
            return b ? "Deactivate" : "Activate";
        }

        public static string ToYesNo(this int? num)
        {
            return num.HasValue ? "Yes" : "No";
        }
        

        public static string ToShortDescription(this string st, int startIndex, int length)
        {
            return st.Length > length ? string.Format("{0} ...", st.Substring(startIndex, length)) : st;
        }


        public static string GetDisplayName(this Enum enumValue)
        {
            var memberInfo = enumValue.GetType().GetMember(enumValue.ToString()).FirstOrDefault();
            return memberInfo != null
                ? memberInfo.GetCustomAttribute<DisplayAttribute>().GetName()
                : string.Empty;
        }
        


        public static bool ToBoolean(this string input)
        {
            //Define the false keywords
            String[] bFalse = { "false", "0", "off", "no" };

            //Return false for any of the false keywords or an empty/null value
            if (String.IsNullOrEmpty(input) || bFalse.Contains(input.ToLower()))
                return false;

            //Return true for anything not false
            return true;
        }


        public static TResult ItemCastOrDefault<TResult>(this ViewDataDictionary that, string key)
        {
            var value = that[key];
            if (value == null)
                return default(TResult);
            else
                return (TResult)value;
        }
    }
}