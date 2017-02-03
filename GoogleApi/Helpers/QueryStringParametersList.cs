using System;
using System.Collections.Generic;
using System.Linq;

namespace GoogleApi.Helpers
{
    /// <summary>
    /// Helper class to build querystrings for Google Requests.
    /// </summary>
    public sealed class QueryStringParametersList : Dictionary<string, string>, IDictionary<string, string>
    {
        /// <summary>
        /// Adds a parameter.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public new void Add(string key, string value)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (base.ContainsKey(key))
            {
                base[key] = value;
            }
            else
            {
                base.Add(key, value);
            }
        }

        /// <summary>
        /// returns the query string collection as url paremer string.
        ///  </summary>
        /// <returns></returns>
        public string GetQueryStringPostfix()
        {
            return string.Join("&", this.Select(x => Uri.EscapeDataString(x.Key) + "=" + Uri.EscapeDataString(x.Value)));
        }
    }
}