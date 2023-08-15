using System;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Common.Converters;

namespace GoogleApi.Entities.Places.Common;

/// <summary>
/// Review.
/// </summary>
public class Review
{
    /// <summary>
    /// author_name the name of the user who submitted the review. Anonymous reviews are attributed to "A Google user".
    /// </summary>
    [JsonPropertyName("author_name")]
    public virtual string AuthorName { get; set; }

    /// <summary>
    /// Rating the user's overall rating for this place. This is a whole number, ranging from 1 to 5.
    /// </summary>
    public virtual double? Rating { get; set; }

    /// <summary>
    /// The relative time, in human language description.
    /// </summary>
    [JsonPropertyName("relative_time_description")]
    public virtual string RelativeTime { get; set; }

    /// <summary>
    /// Time the time that the review was submitted, measured in the number of seconds since since midnight, January 1, 1970 UTC.
    /// </summary>
    [JsonPropertyName("time")]
    [JsonConverter(typeof(EpochSecondsToDateTimeJsonConverter))]
    public virtual DateTime DateTime { get; set; }

    /// <summary>
    /// author_url the URL to the users Google+ profile, if available.
    /// </summary>
    [JsonPropertyName("author_url")]
    public virtual string AuthorUrl { get; set; }

    /// <summary>
    /// Language an IETF language code indicating the language used in the user's review. This field contains the main language tag only,
    /// and not the secondary tag indicating country or region. For example, all the English reviews are tagged as 'en', and not 'en-AU' or 'en-UK' and so on.
    /// </summary>
    public virtual string Language { get; set; }

    /// <summary>
    /// An IETF language code indicating the original language of the review.
    /// If the review has been translated, then original_language != language.This field contains the main language tag only,
    /// and not the secondary tag indicating country or region.
    /// For example, all the English reviews are tagged as 'en', and not 'en-AU' or 'en-UK' and so on.
    /// This field is empty if there is only a rating with no review text.
    /// </summary>
    [JsonPropertyName("original_language")]
    public virtual string OriginalLanguage { get; set; }

    /// <summary>
    /// The url to the photo.
    /// </summary>
    [JsonPropertyName("profile_photo_url")]
    public virtual string ProfilePhotoUrl { get; set; }

    /// <summary>
    /// Text contains the user's review. When reviewing a location with Google Places,
    /// text reviews are considered optional; therefore, this field may by empty.
    /// </summary>
    public virtual string Text { get; set; }

    /// <summary>
    /// A boolean value indicating if the review was translated from the original language it was written in.
    /// If a review has been translated, corresponding to a value of true, Google recommends that you indicate this to your users.
    /// For example, you can add the following string, “Translated by Google”, to the review.
    /// </summary>
    public virtual bool Translated { get; set; }
}