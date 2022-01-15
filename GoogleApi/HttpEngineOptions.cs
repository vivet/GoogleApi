namespace GoogleApi
{
    /// <summary>
    /// Http Engine Options.
    /// </summary>
    public class HttpEngineOptions
    {
        /// <summary>
        ///
        /// </summary>
        public HttpEngineOptions()
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="throwsOnInvalid"></param>
        public HttpEngineOptions(bool throwsOnInvalid)
        {
            ThrowOnInvalidRequest = throwsOnInvalid;
        }

        /// <summary>
        /// Throw On Bad Request.
        /// </summary>
        public bool ThrowOnInvalidRequest { get; set; } = true;
    }
}