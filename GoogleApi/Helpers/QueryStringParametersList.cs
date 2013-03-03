using System;
using System.Collections.Generic;
using System.Linq;

namespace GoogleApi.Helpers
{
	public class QueryStringParametersList
	{
		private List<KeyValuePair<string,string>> List { get; set; }

		public QueryStringParametersList()
		{
			List = new List<KeyValuePair<string, string>>();
		}

		public void Add(string _key, string _value)
		{
			List.Add(new KeyValuePair<string, string>(_key, _value));
		}

		public string GetQueryStringPostfix()
		{
			return string.Join("&", List.Select(_p => Uri.EscapeDataString(_p.Key) + "=" + Uri.EscapeDataString(_p.Value)));
		}
	}
}
