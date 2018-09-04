namespace GoogleApi.Entities.Search.Video.Response
{
    /// <summary>
    /// 
    /// </summary>
    public class Video
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Kind { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string ETag { get; set; }      

        /// <summary>
        /// 
        /// </summary>
        public virtual Status Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Statistics Statistics { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ContentDetails ContentDetails { get; set; }

    }
}