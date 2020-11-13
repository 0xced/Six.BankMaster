using System.Runtime.Serialization;

namespace Six.BankMaster
{
    /// <summary>
    /// The preferred language of the <see cref="Bank"/>.
    /// </summary>
    public enum Language
    {
        /// <summary>
        /// The German language
        /// </summary>
        [EnumMember(Value = @"DE")]
        German = 1,

        /// <summary>
        /// The French language
        /// </summary>
        [EnumMember(Value = @"FR")]
        French = 2,

        /// <summary>
        /// The Italian language
        /// </summary>
        [EnumMember(Value = @"IT")]
        Italian = 3,
    }
}
