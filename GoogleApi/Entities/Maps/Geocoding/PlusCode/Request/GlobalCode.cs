using System;

namespace GoogleApi.Entities.Maps.Geocoding.PlusCode.Request
{
    /// <summary>
    /// Global Code.
    /// The global code part of a plus code.
    /// </summary>
    public class GlobalCode
    {
        /// <summary>
        /// Code.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="code">The code.</param>
        public GlobalCode(string code)
        {
            this.Code = code ?? throw new ArgumentNullException(nameof(code));
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return this.Code;
        }
    }
}