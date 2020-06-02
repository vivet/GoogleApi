using System;

namespace GoogleApi.Entities.Search.Video.Common.Enums
{
    /// <summary>
    /// Part Type.
    /// </summary>
    [Flags]
    public enum PartType
    {
        /// <summary>
        /// Snippet.
        /// </summary>
        Snippet = 1 << 1,

        /// <summary>
        /// Content Details.
        /// </summary>
        ContentDetails = 1 << 2,

        /// <summary>
        /// File Details.
        /// </summary>
        FileDetails = 1 << 3,

        /// <summary>
        /// Player.
        /// </summary>
        Player = 1 << 4,

        /// <summary>
        /// Processing Details.
        /// </summary>
        ProcessingDetails = 1 << 5,

        /// <summary>
        /// Recording Details.
        /// </summary>
        RecordingDetails = 1 << 6,

        /// <summary>
        /// Statistics.
        /// </summary>
        Statistics = 1 << 7,

        /// <summary>
        /// Status.
        /// </summary>
        Status = 1 << 8,

        /// <summary>
        /// Suggestions.
        /// </summary>
        Suggestions = 1 << 9,

        /// <summary>
        /// Topic Details.
        /// </summary>
        TopicDetails = 1 << 10
    }
}