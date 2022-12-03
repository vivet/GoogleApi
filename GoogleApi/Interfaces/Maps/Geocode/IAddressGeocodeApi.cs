using GoogleApi.Entities.Maps.Geocoding;
using GoogleApi.Entities.Maps.Geocoding.Address.Request;

namespace GoogleApi.Interfaces.Maps.Geocode;

/// <inheritdoc />
public interface IAddressGeocodeApi : IApi<AddressGeocodeRequest, GeocodeResponse>
{

}