namespace GoogleApi.Entities.Common.Interfaces
{
    /// <summary>
    /// Interface used by facede engine.
    /// </summary>
    public interface IResponseFor
    {
        /// <summary>
        /// The raw json returned, if any.
        /// </summary>
        string RawJson { get; set; }
    }
}