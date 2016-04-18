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
        public virtual string Address { get; private set; }
        /// <summary>
        /// Address expressed as Google compatible string.
        /// </summary>
        public string LocationString
        {
            get { return this.Address; }
        }

        /// <summary>
        /// Constructor initializing a valid AddressLocation
        /// </summary>
        /// <param name="_address"></param>
		public AddressLocation(string _address)
		{
            this.Address = _address;
		}


        public override string ToString()
        {
            return LocationString;
        }
	}
}