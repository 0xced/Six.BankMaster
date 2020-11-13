using System.Runtime.Serialization;

namespace Six.BankMaster
{
    /// <summary>
    /// Provides information as to the respective type of <see cref="Bank"/>.
    /// </summary>
    /// <remarks>The enum values match the "Bank Master – Record Description" documentation available at https://www.six-group.com/dam/download/banking-services/interbank-clearing/en/bc_bank_master/bc_records.pdf</remarks>
    public enum IidType
    {
        /// <summary>
        /// Headquarters
        /// </summary>
        [EnumMember(Value = @"HEADQUARTERS")]
        Headquarters = 1,

        /// <summary>
        /// Main branch
        /// </summary>
        [EnumMember(Value = @"MAIN_BRANCH")]
        MainBranch = 2,

        /// <summary>
        /// Branch
        /// </summary>
        [EnumMember(Value = @"BRANCH")]
        Branch = 3,
    }
}
