namespace GoogleApi.Entities.Search.Common;

/// <summary>
/// The OpenSearch URL element that defines the template for the API.
/// </summary>
public class Url
{
    /// <summary>
    /// The MIME type of the OpenSearch URL template for the Custom Search API.
    /// </summary>
    public virtual string Type { get; set; }

    /// <summary>
    /// The actual OpenSearch template for this API.
    /// </summary>
    public virtual string Template { get; set; }
}