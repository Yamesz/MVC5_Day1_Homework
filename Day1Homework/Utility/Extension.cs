using System;

namespace Day1Homework.Utility
{
    public static class Extension
    {
        /// <summary>
        /// string轉DateTime 轉失敗會回傳DateTime.MinValue
        /// </summary>
        /// <returns></returns>
        public static DateTime ToDateTime(this string sourceString)
        {
            DateTime retVal = DateTime.MinValue;
            DateTime.TryParse(sourceString, out retVal);
            return retVal;
        }
    }
}