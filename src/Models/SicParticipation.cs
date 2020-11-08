using System.Runtime.Serialization;

namespace Six.BankMaster
{
    /// <summary>
    /// Provides information regarding participation in the services SIC and LSV+/BDD in CHF.
    /// </summary>
    public enum SicParticipation
    {
        /// <summary>
        /// No participation in SIC
        /// </summary>
        [EnumMember(Value = @"NO_PARTICIPATION")]
        NoParticipation = 0,

        /// <summary>
        /// Participation in SIC and in LSV+/BDD as DEB-FI. Direct debits in CHF debitable to an IID not indicated with this code will be rejected
        /// (DEB-FI = direct debit payers financial institution).
        /// </summary>
        [EnumMember(Value = @"SIC_PARTICIPATION_AND_LSV_AS_DEBTOR_FI")]
        SicParticipationAndLsvAsDebtorFinancialInstitution = 1,

        /// <summary>
        /// Participation in SIC
        /// </summary>
        [EnumMember(Value = @"SIC_PARTICIPATION")]
        SicParticipation = 2,

        /// <summary>
        /// Participation in SIC with QR-IID for payments with QR reference
        /// </summary>
        [EnumMember(Value = @"SIC_PARTICIPATION_WITH_QR_IID")]
        SicParticipationWithQrIid = 3,
    }
}
