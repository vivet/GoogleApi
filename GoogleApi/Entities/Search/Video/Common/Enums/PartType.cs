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
        Snippet = 1 << 0,

        /// <summary>
        /// Content Details.
        /// </summary>
        ContentDetails = 1 << 1,

        /// <summary>
        /// File Details.
        /// </summary>
        FileDetails = 1 << 2,

        /// <summary>
        /// Player.
        /// </summary>
        Player = 1 << 3,

        /// <summary>
        /// Processing Details.
        /// </summary>
        ProcessingDetails = 1 << 4,

        /// <summary>
        /// Recording Details.
        /// </summary>
        RecordingDetails = 1 << 5,

        /// <summary>
        /// Statistics.
        /// </summary>
        Statistics = 1 << 6,

        /// <summary>
        /// Status.
        /// </summary>
        Status = 1 << 7,

        /// <summary>
        /// Suggestions.
        /// </summary>
        Suggestions = 1 << 8,

        /// <summary>
        /// Topic Details.
        /// </summary>
        TopicDetails = 1 << 9
    }
}