using System;
using System.Collections.Generic;
using GoogleApi.Entities.Search.Common.Request;

namespace GoogleApi.Entities.Search.Web.Request
{
    /// <summary>
    /// Web Search Request.
    /// </summary>
    public class WebSearchRequest : BaseSearchRequest
    {
        /// <summary>
        /// Required. Search engine created for a site with the Google Control Panel 
        /// To create a Google Custom Search engine that searches the entire web:
        /// 1. From the Google Custom Search homepage (http://www.google.com/cse), click Create a Custom Search Engine.
        /// 2. Type a name and description for your search engine.
        /// 3. Under Define your search engine, in the Sites to Search box, enter at least one valid URL (For now, just put www.anyurl.com to get past this screen.More on this later).
        /// 4. Select the CSE edition you want and accept the Terms of Service, then click Next.Select the layout option you want, and then click Next.
        /// 5. Click any of the links under the Next steps section to navigate to your Control panel.
        /// 6. In the left-hand menu, under Control Panel, click Basics.
        /// 7. In the Search Preferences section, select Search the entire web but emphasize included sites.
        /// 8. Click Save Changes.
        /// 9. In the left-hand menu, under Control Panel, click Sites.
        /// 10. Delete the site you entered during the initial setup process.
        /// 11. Now your custom search engine will search the entire web.
        /// </summary>
        public virtual string SearchEngineId { get; set; }

        /// <summary>
        /// Get the query string collection of added parameters for the request.
        /// </summary>
        /// <returns></returns>
        public override IDictionary<string, string> QueryStringParameters
        {
            get
            {
                if (string.IsNullOrEmpty(this.SearchEngineId))
                    throw new ArgumentException("SearchEngineId is required.");

                var parameters = base.QueryStringParameters;

                parameters.Add("cx", this.SearchEngineId);

                return parameters;
            }
        }
    }
}