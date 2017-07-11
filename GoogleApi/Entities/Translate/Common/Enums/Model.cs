using System.Runtime.Serialization;

namespace GoogleApi.Entities.Translate.Common.Enums
{
    /// <summary>
    /// The translation model. 
    /// </summary>
    public enum Model
    {
        /// <summary>
        /// Base, Phrase-Based Machine Translation (PBMT) model
        /// </summary>
        [EnumMember(Value = "base")]
        Base,

        /// <summary>
        /// Nmt, Neural Machine Translation (NMT) model.
        /// </summary>
        [EnumMember(Value = "nmt")]
        Nmt
    }
}