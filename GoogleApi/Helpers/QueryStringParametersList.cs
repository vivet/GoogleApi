using System;
using System.Collections.Generic;
using System.Linq;

namespace GoogleApi.Helpers
{
    /// <summary>
    /// Helper class to build querystrings for Google Requests.
    /// </summary>
	public class QueryStringParametersList
	{
		private List<KeyValuePair<string,string>> List { get; set; }

        /// <summary>
        /// Default Constructor.
        /// </summary>
		public QueryStringParametersList()
		{
			this.List = new List<KeyValuePair<string, string>>();
		}

        /// <summary>
        /// Adds a parameter.
        /// </summary>
        /// <param name="_key"></param>
        /// <param name="_value"></param>
		public void Add(string _key, string _value)
		{
			this.List.Add(new KeyValuePair<string, string>(_key, _value));
		}

        /// <summary>
        /// returns the query string collection as url paremer string.
        ///  </summary>
        /// <returns></returns>
		public string GetQueryStringPostfix()
		{
			return string.Join("&", this.List.Select(_p => Uri.EscapeDataString(_p.Key) + "=" + Uri.EscapeDataString(_p.Value)));
		}
	}
}
