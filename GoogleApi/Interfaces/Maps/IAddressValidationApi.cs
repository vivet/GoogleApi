using GoogleApi.Entities.Maps.AddressValidation.Request;
using GoogleApi.Entities.Maps.AddressValidation.Response;

namespace GoogleApi.Interfaces.Maps;

/// <inheritdoc />
public interface IAddressValidationApi : IApi<AddressValidationRequest, AddressValidationResponse>;