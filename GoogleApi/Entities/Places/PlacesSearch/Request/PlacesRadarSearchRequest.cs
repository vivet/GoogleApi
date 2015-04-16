

namespace GoogleApi.Entities.Places.PlacesSearch.Request
{
    public class PlacesRadarSearchRequest : PlacesBaseSearchRequest
    {
        protected internal override string BaseUrl
        {
            get
            {
                return base.BaseUrl + "radarsearch/";
            }
        }

        public virtual string Keyword { get; set; }
    }
}
