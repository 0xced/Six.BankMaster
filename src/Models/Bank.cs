using NodaTime;

namespace Six.BankMaster
{
    /// <summary>
    /// Holds the data describing a bank.
    /// </summary>
    public class Bank
    {
        /// <summary>
        /// The banks/financial institutions are divided into so-called bank groups.
        /// </summary>
        public BankGroup Group { get; init; } = default!;

        /// <summary>
        /// Each bank/financial institution is identified by way of an IID (institution identification) made up of 3 to 5 digits.
        /// </summary>
        public int Iid { get; init; }

        /// <summary>
        /// Together with the IID the branch ID provides a conclusive key for each entry. Each IID has a main branch with the branch ID "0000";
        /// the branch IDs from "0001" are assigned to this IID.
        /// </summary>
        public string BranchId { get; init; } = default!;

        /// <summary>
        /// If this field contains a number, the IID is no longer valid (e.g. due to a merger) and is to be replaced by the "New IID" (so-called concatenation).
        /// A concatenation is always carried out with the branch ID "0000" of the new IID. All other record fields and the original information remain
        /// unchanged until the cancellation of the concatenation.
        /// </summary>
        public int? NewIid { get; init; }

        /// <summary>
        /// This is always a 6-digit number and may be used only by SIC and euroSIC participants.
        /// </summary>
        public string SicIid { get; init; } = default!;

        /// <summary>
        /// IID of the head office (headquarters).
        /// </summary>
        public int HeadOffice { get; init; }

        /// <summary>
        /// Provides information as to the respective type of <see cref="Bank"/>.
        /// </summary>
        public IidType IidType { get; init; } = default!;

        /// <summary>
        /// Date from which the information in a record is valid. The date is adjusted as soon as an amendment has been made in one or
        /// several fields or in the case of a record which is for the first time included in the file.
        /// </summary>
        public LocalDate ValidSince { get; init; }

        /// <summary>
        /// This code provides information regarding participation in the services SIC and LSV+/BDD in CHF.
        /// </summary>
        public SicParticipation SicParticipation { get; init; } = default!;

        /// <summary>
        /// This code provides information regarding participation in the services euroSIC and LSV+/BDD in EUR.
        /// </summary>
        public EuroSicParticipation EuroSicParticipation { get; init; } = default!;

        /// <summary>
        /// The preferred <see cref="Language"/> of the bank.
        /// </summary>
        /// <remarks>The fields <see cref="ShortName"/> and <see cref="BankOrInstitutionName"/> for each record are supplied in the respective languages.</remarks>
        public Language Language { get; init; } = default!;

        /// <summary>
        /// Short name of the bank or financial institution, in its respective <see cref="Language"/>.
        /// </summary>
        public string ShortName { get; init; } = default!;

        /// <summary>
        /// Name of the bank or financial institution, in its respective <see cref="Language"/>.
        /// </summary>
        /// <remarks>
        /// <para>
        /// + in the first position  of  the name of the bank/institution = in liquidation
        /// </para>
        /// <para>
        /// ++ in the first position  of  the name of the bank/institution = alternation of purpose
        /// </para>
        /// </remarks>
        public string BankOrInstitutionName { get; init; } = default!;

        /// <summary>
        /// Address of domicile.
        /// </summary>
        public string? DomicileAddress { get; init; }

        /// <summary>
        /// Postal address.
        /// </summary>
        public string? PostalAddress { get; init; }

        /// <summary>
        /// Postal/Zip code.
        /// </summary>
        public string ZipCode { get; init; } = default!;

        /// <summary>
        /// Place.
        /// </summary>
        public string Place { get; init; } = default!;

        /// <summary>
        /// Phone number. Formatted representation (with blanks).
        /// </summary>
        public string? Phone { get; init; }

        /// <summary>
        /// Fax number. Formatted representation (with blanks).
        /// </summary>
        public string? Fax { get; init; }

        /// <summary>
        /// International dialling code for telephone and fax (foreign entries only).
        /// </summary>
        public string? DiallingCode { get; init; }

        /// <summary>
        /// 2-digit alphabetical country code according to the ISO standard 3166 (foreign entries only).
        /// </summary>
        public string? CountryCode { get; init; }

        /// <summary>
        /// Postal account number.
        /// <para>
        /// A * in the first position points out that the listed postal account number is part of a higher-level IID (e.g. main branch).
        /// </para>
        /// </summary>
        public string? PostalAccount { get; init; }

        /// <summary>
        /// BIC of the bank or financial institution. Formatted representation (XXXXXXXXXXX) (= 11 characters).
        /// </summary>
        /// <remarks>
        /// The SWIFT/BIC addresses used in this directory are the property of SWIFT SCRL, 1310 La Hulpe / Belgium and have been made available by SIX Interbank
        /// Clearing Ltd on behalf of the bank or financial institution.
        /// </remarks>
        public string? Bic { get; init; }
    }
}
