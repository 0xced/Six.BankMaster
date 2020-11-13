using System.Runtime.Serialization;

namespace Six.BankMaster
{
    /// <summary>
    /// The preferred language of the <see cref="Bank"/>.
    /// </summary>
    /// <remarks>The enum values match the "Bank Master – Record Description" documentation available at https://www.six-group.com/dam/download/banking-services/interbank-clearing/en/bc_bank_master/bc_records.pdf</remarks>
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
