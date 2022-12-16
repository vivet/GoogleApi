using System;
using System.Text.Json;

namespace GoogleApi.Entities.Common.Converters;

/// <summary>
///Json Naming Policy Decorator.
/// </summary>
public class JsonNamingPolicyDecorator : JsonNamingPolicy
{
    private readonly JsonNamingPolicy underlyingNamingPolicy;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="underlyingNamingPolicy">The <see cref="JsonNamingPolicy"/>.</param>
    public JsonNamingPolicyDecorator(JsonNamingPolicy underlyingNamingPolicy)
    {
        this.underlyingNamingPolicy = underlyingNamingPolicy ?? throw new ArgumentNullException(nameof(underlyingNamingPolicy));
    }

    /// <inheritdoc />
    public override string ConvertName(string name)
    {
        if (name == null)
            throw new ArgumentNullException(nameof(name));
        
        return underlyingNamingPolicy == null
            ? name
            : underlyingNamingPolicy
                .ConvertName(name);
    }
}