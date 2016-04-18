namespace GoogleApi.Entities.Common.Interfaces
{
    /// <summary>
    /// Interface for converting addresses and coordinates into google compatible location strings.
    /// </summary>
	public interface ILocationString
	{
        /// <summary>
        /// Formatted as string for Google parameters.
        /// </summary>
		string LocationString { get; }
	}
}