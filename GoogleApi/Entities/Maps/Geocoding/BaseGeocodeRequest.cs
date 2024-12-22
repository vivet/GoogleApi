using System.Collections.Generic;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Common.Extensions;
using GoogleApi.Entities.Interfaces;
using GoogleApi.Entities.Maps.Geocoding.Common.Enums;

namespace GoogleApi.Entities.Maps.Geocoding;

/// <summary>
/// Base Geocoding Request.
/// </summary>
public abstract class BaseGeocodeRequest : BaseMapsChannelRequest, IRequestQueryString
{
    /// <inheritdoc />
    protected internal override string BaseUrl => base.BaseUrl + "geocode/json";

    /// <summary>
    /// language (optional) — The language in which to return results.
    /// See the supported list of domain languages. Note that we often update supported languages so this list may not be exhaustive.
    /// If language is not supplied, the geocoder will attempt to use the native language of the domain from which the request is sent wherever possible.
    /// </summary>
    public virtual Language Language { get; set; } = Language.English;

    /// <summary>
    /// Extra Computations.
    /// </summary>
    public virtual IEnumerable<ExtraComputation> ExtraComputations { get; set; } = new List<ExtraComputation>();

    /// <inheritdoc />
    public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
    {
        var parameters = base.GetQueryStringParameters();

        parameters.Add("language", this.Language.ToCode());

        foreach (var extraComputation in this.ExtraComputations)
        {
            switch (extraComputation)
            {
                case ExtraComputation.AddressDescriptors:
                    parameters.Add("extra_computations", "ADDRESS_DESCRIPTORS");
                    break;
                case ExtraComputation.BuildingAndEntrances:

                    parameters.Add("extra_computations", "BUILDING_AND_ENTRANCES");
                    break;
            }
        }

        return parameters;
    }
}