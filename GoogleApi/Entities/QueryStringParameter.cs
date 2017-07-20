namespace GoogleApi.Entities
{
    /// <summary>
    /// QueryString parameter in a request.
    /// </summary>
    public struct QueryStringParameter
    {
        /// <summary>
        /// Parameter name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Parameter value.
        /// </summary>
        public string Value { get; set; }
    }
}