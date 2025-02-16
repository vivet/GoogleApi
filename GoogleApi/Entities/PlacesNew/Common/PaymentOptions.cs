namespace GoogleApi.Entities.PlacesNew.Common;

/// <summary>
/// Payment options the place accepts.
/// </summary>
public class PaymentOptions
{
    /// <summary>
    /// Place accepts credit cards as payment.
    /// </summary>
    public virtual bool AcceptsCreditCards { get; set; }

    /// <summary>
    /// Place accepts debit cards as payment.
    /// </summary>
    public virtual bool AcceptsDebitCards { get; set; }

    /// <summary>
    /// Place accepts cash only as payment.
    /// Places with this attribute may still accept other payment methods.
    /// </summary>
    public virtual bool AcceptsCashOnly { get; set; }

    /// <summary>
    /// Place accepts NFC payments.
    /// </summary>
    public virtual bool AcceptsNfc { get; set; }
}