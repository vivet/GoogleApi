using System;
using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.DistanceMatrix.Response
{
	/// <summary>
	/// Duration.
	/// </summary>
	[DataContract(Name = "duration")]
	public class Duration
	{
		/// <summary>
		/// Value indicates the duration in seconds.
		/// </summary>
		public TimeSpan Value { get; set; }

		/// <summary>
		/// Text contains a human-readable representation of the duration.
		/// </summary>
		[DataMember(Name = "text")]
        public virtual string Text { get; set; }

        [DataMember(Name = "value")]
        internal virtual int ValueInSec
        {
            get
            {
                return (int)Math.Round(Value.TotalSeconds);
            }
            set
            {
                Value = TimeSpan.FromSeconds(value);
            }
        }
    }
}
