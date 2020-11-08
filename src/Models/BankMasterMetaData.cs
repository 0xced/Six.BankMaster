using NodaTime;

namespace Six.BankMaster
{
    /// <summary>
    /// Metadata about the <see cref="BankMasterData"/>.
    /// </summary>
    public class BankMasterMetaData
    {
        /// <summary>
        /// The date for which the entries are valid.
        /// </summary>
        public LocalDate ValidForClearingDay { get; set; }

        /// <summary>
        /// The date and time at which this response was created.
        /// </summary>
        public OffsetDateTime CreatedStamp { get; set; }
    }
}
