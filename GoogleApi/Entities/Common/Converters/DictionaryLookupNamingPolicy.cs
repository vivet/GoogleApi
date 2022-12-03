using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace GoogleApi.Entities.Common.Converters;

internal class DictionaryLookupNamingPolicy : JsonNamingPolicyDecorator
{
    private readonly IDictionary<string, string> dictionary;

    internal DictionaryLookupNamingPolicy(IDictionary<string, string> dictionary, JsonNamingPolicy underlyingNamingPolicy)
        : base(underlyingNamingPolicy)
    {
        this.dictionary = dictionary ?? throw new ArgumentNullException(nameof(dictionary));
    }

    public override string ConvertName(string name)
    {
        var tryGetValue = dictionary.TryGetValue(name, out var value);
        if (tryGetValue)
        {
            return value;
        }

        var containsValue = dictionary.Values.Contains(name);
        if (containsValue)
        {
            name = dictionary
                .First(x => x.Value.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                .Key;
        }

        return base.ConvertName(name);
    }
}