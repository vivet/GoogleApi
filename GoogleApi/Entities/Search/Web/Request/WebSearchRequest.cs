using System;
using System.Collections.Generic;
using GoogleApi.Entities.Common.Extensions;
using GoogleApi.Entities.Search.Common;
using GoogleApi.Entities.Search.Common.Enums;
using GoogleApi.Entities.Search.Common.Enums.Extensions;

namespace GoogleApi.Entities.Search.Web.Request;

/// <summary>
/// Web Search Request.
/// </summary>
public class WebSearchRequest : BaseSearchRequest
{
    /// <summary>
    /// BaseUrl property overriden.
    /// </summary>
    protected internal override string BaseUrl => "www.googleapis.com/customsearch/v1";

    /// <summary>
    /// Required.
    /// Search engine created for a site with the Google Control Panel
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
    /// Define properties of your search, like the search expression, number of results, language etc.
    /// </summary>
    public virtual SearchOptions Options { get; set; } = new();

    /// <summary>
    /// See <see cref="BaseRequest.GetQueryStringParameters()"/>.
    /// </summary>
    /// <returns>The <see cref="IList{KeyValuePair}"/> collection.</returns>
    public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
    {
        var parameters = base.GetQueryStringParameters();

        if (string.IsNullOrEmpty(this.SearchEngineId))
            throw new ArgumentException($"{nameof(this.SearchEngineId)} is required");

        parameters.Add("cx", this.SearchEngineId);

        parameters.Add("c2coff", this.Options.DisableCnTwTranslation ? "1" : "0");

        if (this.Options.CountryRestrict != null)
        {
            parameters.Add("cr", this.Options.CountryRestrict.ToString());
        }

        if (this.Options.DateRestrict != null)
        {
            parameters.Add("dateRestrict", this.Options.DateRestrict.ToString());
        }

        if (this.Options.ExactTerms != null)
        {
            parameters.Add("exactTerms", this.Options.ExactTerms);
        }

        if (this.Options.ExcludeTerms != null)
        {
            parameters.Add("excludeTerms", this.Options.ExcludeTerms);
        }

        parameters.Add("fileType", string.Join(",", this.Options.FileTypes));
        parameters.Add("filter", this.Options.Filter ? "0" : "1");

        if (this.Options.GeoLocation != null)
        {
            parameters.Add("gl", this.Options.GeoLocation.Value.ToGl());
        }

        if (this.Options.Googlehost != null)
        {
            parameters.Add("googleHost", this.Options.Googlehost);
        }

        if (this.Options.HighRange != null)
        {
            parameters.Add("highRange", this.Options.HighRange.ToString());
        }

        parameters.Add("hl", this.Options.InterfaceLanguage.ToHl());

        if (this.Options.AndTerms != null)
        {
            parameters.Add("hq", this.Options.AndTerms ?? string.Empty);
        }

        if (this.Options.LinkSite != null)
        {
            parameters.Add("linkSite", this.Options.LinkSite ?? string.Empty);
        }

        if (this.Options.LowRange != null)
        {
            parameters.Add("lowRange", this.Options.LowRange.ToString());
        }

        if (this.Options.Number != null)
        {
            if (this.Options.Number is > 10 or < 1)
                throw new ArgumentOutOfRangeException(nameof(SearchOptions.Number), this.Options.Number, "Number must be between 1 and 10");

            parameters.Add("num", this.Options.Number.ToString());
        }

        if (this.Options.OrTerms != null)
        {
            parameters.Add("orTerms", this.Options.OrTerms ?? string.Empty);
        }

        if (this.Options.RelatedSite != null)
        {
            parameters.Add("relatedSite", this.Options.RelatedSite ?? string.Empty);
        }

        parameters.Add("rights", string.Join(",", this.Options.Rights));

        if (this.Options.SafetyLevel != SafetyLevel.Off && !this.Options.InterfaceLanguage.AllowSafeSearch())
        {
            throw new ArgumentOutOfRangeException(nameof(SearchOptions.SafetyLevel), this.Options.SafetyLevel, $"SafetyLevel is not allowed for specified InterfaceLanguage: {this.Options.InterfaceLanguage}");
        }

        parameters.Add("safe", this.Options.SafetyLevel.ToString().ToLower());

        if (this.Options.SiteSearch != null)
        {
            parameters.Add("siteSearch", this.Options.SiteSearch.Site ?? string.Empty);
            parameters.Add("siteSearchFilter", this.Options.SiteSearch.Filter.ToFilterString() ?? string.Empty);
        }

        if (this.Options.SortExpression != null)
        {
            parameters.Add("sort", this.Options.SortExpression.ToString());
        }

        parameters.Add("start", this.Options.StartIndex.ToString());

        return parameters;
    }
}