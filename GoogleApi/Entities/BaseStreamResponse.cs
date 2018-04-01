using System.IO;

namespace GoogleApi.Entities
{
    /// <summary>
    /// Base Stream Response.
    /// </summary>
    public class BaseStreamResponse : BaseResponse
    {
        /// <summary>
        /// Buffer.
        /// </summary>
        public virtual byte[] Buffer { get; set; }

        /// <summary>
        /// Stream.
        /// </summary>
        public virtual MemoryStream Stream => new MemoryStream(this.Buffer ?? new byte[0]);
    }
}