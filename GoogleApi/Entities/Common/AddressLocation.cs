using GoogleApi.Entities.Common.Interfaces;

namespace GoogleApi.Entities.Common
{
    /// <summary>
    /// 
    /// </summary>
	public class AddressLocation : ILocationString
	{
        /// <summary>
        /// Address.
        /// </summary>
        public string Address { get; protected set; }
        /// <summary>
        /// Address expressed as Google compatible string.
        /// </summary>
        public virtual string LocationString => this.Address;

	    /// <summary>
        /// Constructor initializing a valid AddressLocation
        /// </summary>
        /// <param name="_address"></param>
		public AddressLocation(string _address)
		{
            this.Address = _address;
		}

        /// <summary>
        /// Returns locations as Google formatted locationstring. 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.LocationString;
        }
	}
}