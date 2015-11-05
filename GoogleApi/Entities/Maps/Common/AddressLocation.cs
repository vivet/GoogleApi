using GoogleApi.Entities.Maps.Common.Interfaces;

namespace GoogleApi.Entities.Maps.Common
{
    /// <summary>
    /// 
    /// </summary>
	public class AddressLocation : ILocationString
	{
        /// <summary>
        /// Address.
        /// </summary>
        public virtual string Address { get; private set; }

        /// <summary>
        /// Constructor initializing a valid AddressLocation
        /// </summary>
        /// <param name="_address"></param>
		public AddressLocation(string _address)
		{
            this.Address = _address;
		}

        /// <summary>
        /// Address expressed as Google compatible string.
        /// </summary>
        public string LocationString
		{
			get { return this.Address; }
		}
	}
}