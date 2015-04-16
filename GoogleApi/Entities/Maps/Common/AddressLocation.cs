using GoogleApi.Entities.Maps.Common.Interfaces;

namespace GoogleApi.Entities.Maps.Common
{
	public class AddressLocation : ILocationString
	{
        public virtual string Address { get; private set; }

		public AddressLocation(string address)
		{
            Address = address;
		}

	    public string LocationString
		{
			get { return Address; }
		}
	}
}