using GoogleApi.Entities.Maps.Common.Interfaces;

namespace GoogleApi.Entities.Maps.Common
{
	public class AddressLocation : ILocationString
	{
        public virtual string Address { get; private set; }

		public AddressLocation(string _address)
		{
            this.Address = _address;
		}

	    public string LocationString
		{
			get { return this.Address; }
		}
	}
}