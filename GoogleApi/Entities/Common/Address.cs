namespace GoogleApi.Entities.Common
{
    /// <summary>
    /// Address.
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Address.
        /// </summary>
        public virtual string Adr { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            return this.Adr;
        }
    }
}