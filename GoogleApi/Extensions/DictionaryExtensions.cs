using System;
using System.Collections.Generic;

namespace GoogleApi.Extensions
{
    public static class DictionaryExtensions
    {
        public static string ToQueryString<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            var queryString = string.Empty;

            foreach (var valuePair in dictionary)
            {
                queryString += string.Format("{0}={1}&", valuePair.Key, valuePair.Value);
            }
            
            return queryString.Remove(queryString.LastIndexOf("&", StringComparison.Ordinal));
        }
    }
}
