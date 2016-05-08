using AutoMapper;
using PagedList;
using System;
using System.Collections.Generic;

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

        public static int ToPageIndex(this int? source)
        {
            return source.HasValue && source.Value > 0
                    ? source.Value
                    : 1;
        }

        public static IPagedList<TDestination> ToMappedPagedList<TSource, TDestination>(this IPagedList<TSource> list)
        {
            IEnumerable<TDestination> sourceList = Mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(list);
            IPagedList<TDestination> pagedResult = new StaticPagedList<TDestination>(sourceList, list.GetMetaData());
            return pagedResult;

        }
    }
}