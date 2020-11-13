using System.Runtime.Serialization;

namespace Six.BankMaster
{
    /// <summary>
    /// Provides information regarding participation in the services SIC and LSV+/BDD in CHF.
    /// </summary>
    /// <remarks>The enum values match the "Bank Master – Record Description" documentation available at https://www.six-group.com/dam/download/banking-services/interbank-clearing/en/bc_bank_master/bc_records.pdf</remarks>
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
        SicParticipation = 3,

        /// <summary>
        /// Participation in SIC with QR-IID for payments with QR reference
        /// </summary>
        [EnumMember(Value = @"SIC_PARTICIPATION_WITH_QR_IID")]
        SicParticipationWithQrIid = 4,
    }
}
