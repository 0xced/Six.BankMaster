using System.Collections.Generic;

namespace Six.BankMaster
{
    /// <summary>
    /// The Master Data returned by the Bank Master API service.
    /// </summary>
    public class BankMasterData
    {
        /// <summary>
        /// Metadata about the Master Data.
        /// </summary>
        public BankMasterMetaData MetaData { get; init; } = new BankMasterMetaData();

        /// <summary>
        /// A collection of <see cref="Bank"/> objects.
        /// </summary>
        public ICollection<Bank> Entries { get; init; } = new List<Bank>();
    }
}
