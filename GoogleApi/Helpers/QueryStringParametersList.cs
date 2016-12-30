using System;
using System.Collections.Generic;
using System.Linq;

namespace GoogleApi.Helpers
{
    /// <summary>
    /// Helper class to build querystrings for Google Requests.
    /// </summary>
	public sealed class QueryStringParametersList
	{
        /// <summary>
        /// Dictionary containing all query string parameters for a request.
        /// </summary>
        public Dictionary<string, string> List { get; }

        /// <summary>
        /// Default Constructor.
        /// </summary>
		public QueryStringParametersList()
		{
            this.List = new Dictionary<string, string>();
		}

        /// <summary>
        /// Adds a parameter.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
		public void Add(string key, string value)
        {
            if (key == null) 
                throw new ArgumentNullException(nameof(key));
            
            if (value == null) 
                throw new ArgumentNullException(nameof(value));

            if (this.List.ContainsKey(key))
            {
                this.List[key] = value;
            }
            else
            {
                this.List.Add(key, value);
            }
        }

        /// <summary>
        /// Remove a parameter.
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            this.List.Remove(key);
        }

        /// <summary>
        /// returns the query string collection as url paremer string.
        ///  </summary>
        /// <returns></returns>
		public string GetQueryStringPostfix()
		{
			return string.Join("&", this.List.Select(x => Uri.EscapeDataString(x.Key) + "=" + Uri.EscapeDataString(x.Value)));
		}
	}
}
