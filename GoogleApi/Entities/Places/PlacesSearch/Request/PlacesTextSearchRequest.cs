using System.Collections.Generic;

namespace GoogleApi.Entities.Places.PlacesSearch.Request
{
    public class PlacesTextSearchRequest : PlacesBaseSearchRequest
    {
        protected internal override string BaseUrl
        {
            get
            {
                return base.BaseUrl + "textsearch/";
            }
        }

        public string Query { get; set; }

        protected override IDictionary<string, string> GetQueryStringParameters()
        {
            var parameters = base.GetQueryStringParameters();

            parameters.Add("query", Query);

            return parameters;
        }
    }
}