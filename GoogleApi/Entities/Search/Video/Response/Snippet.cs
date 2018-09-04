using System;

namespace GoogleApi.Entities.Search.Video.Response
{
    /// <summary>
    /// 
    /// </summary>
    public class Snippet
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual int CategoryId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTimeOffset PublishedAt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Thumbnails Thumbnails { get; set; }
    }
}