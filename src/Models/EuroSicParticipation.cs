using System.Runtime.Serialization;

namespace Six.BankMaster
{
    /// <summary>
    /// Provides information regarding participation in the services euroSIC and LSV+/BDD in EUR.
    /// </summary>
    /// <remarks>The enum values match the "Bank Master – Record Description" documentation available at https://www.six-group.com/dam/download/banking-services/interbank-clearing/en/bc_bank_master/bc_records.pdf</remarks>
    public enum EuroSicParticipation
    {
        /// <summary>
        /// No participation in euroSIC
        /// </summary>
        [EnumMember(Value = @"NO_PARTICIPATION")]
        NoParticipation = 0,

        /// <summary>
        /// Participation in euroSIC and in LSV+/BDD as DEB-FI. Direct debits in EUR debitable to an IID not indicated with this code will be rejected
        /// (DEB-FI = direct debit payers financial institution).
        /// </summary>
        [EnumMember(Value = @"EURO_SIC_PARTICIPATION_AND_LSV_AS_DEBTOR_FI")]
        EuroSicParticipationAndLsvAsDebtorFinancialInstitution = 1,

        /// <summary>
        /// Participation in euroSIC
        /// </summary>
        [EnumMember(Value = @"EURO_SIC_PARTICIPATION")]
        EuroSicParticipation = 3,

        /// <summary>
        /// Participation in euroSIC with QR-IID for payments with QR reference
        /// </summary>
        [EnumMember(Value = @"EURO_SIC_PARTICIPATION_WITH_QR_IID")]
        EuroSicParticipationWithQrIid = 4,
    }
}
