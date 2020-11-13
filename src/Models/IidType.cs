using System.Runtime.Serialization;

namespace Six.BankMaster
{
    /// <summary>
    /// Provides information as to the respective type of <see cref="Bank"/>.
    /// </summary>
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
