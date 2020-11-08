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
        Headquarters = 0,

        /// <summary>
        /// Main branch
        /// </summary>
        [EnumMember(Value = @"MAIN_BRANCH")]
        MainBranch = 1,

        /// <summary>
        /// Branch
        /// </summary>
        [EnumMember(Value = @"BRANCH")]
        Branch = 2,
    }
}
