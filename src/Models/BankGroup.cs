using System.Runtime.Serialization;

namespace Six.BankMaster
{
    /// <summary>
    /// The banks/financial institutions are divided into so-called bank groups.
    /// </summary>
    /// <remarks>The enum values match the "Bank Master – Record Description" documentation available at https://www.six-group.com/dam/download/banking-services/interbank-clearing/en/bc_bank_master/bc_records.pdf</remarks>
    public enum BankGroup
    {
        /// <summary>
        /// Swiss National Bank
        /// </summary>
        [EnumMember(Value = @"01")]
        SwissNationalBank = 1,

        /// <summary>
        /// UBS Group
        /// </summary>
        [EnumMember(Value = @"02")]
        UbsGroup = 2,

        /// <summary>
        /// Reserve
        /// </summary>
        [EnumMember(Value = @"03")]
        Reserve = 3,

        /// <summary>
        /// Credit Suisse Group
        /// </summary>
        /// <seealso cref="CreditSuisseGroup5"/>
        [EnumMember(Value = @"04")]
        CreditSuisseGroup4 = 4,

        /// <summary>
        /// Credit Suisse Group
        /// </summary>
        /// <seealso cref="CreditSuisseGroup4"/>
        [EnumMember(Value = @"05")]
        CreditSuisseGroup5 = 5,

        /// <summary>
        /// Entris Banks
        /// </summary>
        [EnumMember(Value = @"06")]
        EntrisBank = 6,

        /// <summary>
        /// Cantonal Banks
        /// </summary>
        [EnumMember(Value = @"07")]
        CantonalBank = 7,

        /// <summary>
        /// Raiffeisen Banks and individual institutions
        /// </summary>
        [EnumMember(Value = @"08")]
        RaiffeisenBank = 8,

        /// <summary>
        /// PostFinance
        /// </summary>
        [EnumMember(Value = @"09")]
        PostFinance = 9,
    }
}
