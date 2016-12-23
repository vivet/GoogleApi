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
        /// <summary>
        /// Dictionary containing all query string parameters for a request.
        /// </summary>
        public virtual Dictionary<string, string> List { get; protected set; }

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
        /// <param name="_key"></param>
        /// <param name="_value"></param>
		public void Add(string _key, string _value)
        {
            if (_key == null) 
                throw new ArgumentNullException("_key");
            
            if (_value == null) 
                throw new ArgumentNullException("_value");

            if (this.List.ContainsKey(_key))
            {
                this.List[_key] = _value;
            }
            else
            {
                this.List.Add(_key, _value);
            }
        }
        /// <summary>
        /// Remove a parameter.
        /// </summary>
        /// <param name="_key"></param>
        public void Remove(string _key)
        {
            if (_key == null)
                throw new ArgumentNullException("_key");

            this.List.Remove(_key);
        }

        /// <summary>
        /// returns the query string collection as url paremer string.
        ///  </summary>
        /// <returns></returns>
		public string GetQueryStringPostfix()
		{
			return string.Join("&", this.List.Select(_x => Uri.EscapeDataString(_x.Key) + "=" + Uri.EscapeDataString(_x.Value)));
		}
	}
}
