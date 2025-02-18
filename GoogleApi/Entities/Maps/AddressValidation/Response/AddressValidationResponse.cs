namespace GoogleApi.Entities.Maps.AddressValidation.Response;

/// <summary>
/// Address Validation Response.
/// The response to an address validation request.
/// </summary>
public class AddressValidationResponse : BaseResponseX
{
    /// <summary>
    /// Response Id.
    /// The UUID that identifies this response.
    /// If the address needs to be re-validated, this UUID must accompany the new request.
    /// </summary>
    public virtual string ResponseId { get; set; }

    /// <summary>
    /// Result.
    /// The result of the address validation.
    /// </summary>
    public virtual ValidationResult Result { get; set; }
}