using System;
using System.Collections.Generic;
using GoogleApi.Entities.Interfaces;
using GoogleApi.Entities.Common.Extensions;

namespace GoogleApi.Entities.Maps.AerialView.GetVideo.Request;

/// <summary>
/// Get Video Request.
/// </summary>
public class GetVideoRequest : BaseMapsRequest, IRequestQueryString
{
    /// <inheritdoc />
    protected internal override string BaseUrl => "aerialview.googleapis.com/v1beta/videos";

    /// <summary>
    /// Video Id.
    /// An ID returned from videos.renderVideo.
    /// Either use this or Address.
    /// </summary>
    public virtual string VideoId { get; set; }

    /// <summary>
    /// Address.
    /// A US postal address.
    /// Either use this or VideoId.
    /// </summary>
    public virtual string Address { get; set; }

    /// <inheritdoc />
    public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
    {
        var parameters = base.GetQueryStringParameters();

        if (this.VideoId == null && this.Address == null)
            throw new ArgumentException($"Either an '{nameof(this.Address)}' or a '{nameof(this.VideoId)}' is required.");

        if (this.VideoId != null && this.Address != null)
            throw new ArgumentException($"Only one of '{nameof(this.Address)}' or '{nameof(this.VideoId)}' can be specified.");

        if (this.Address != null)
        {
            parameters.Add("address", this.Address);
        }

        if (this.VideoId != null)
        {
            parameters.Add("videoId", this.VideoId);
        }

        return parameters;
    }
}