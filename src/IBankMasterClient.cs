using System.Threading;
using System.Threading.Tasks;
using Refit;

namespace Six.BankMaster
{
    /// <summary>
    /// The Bank Master contains all the master data required for electronic payment traffic by financial institutions that are connected to the Swiss payment
    /// systems SIC and euroSIC. The Bank Master is centrally administered by SIX Interbank Clearing, updated daily and published in various electronic formats.
    /// <para>
    /// All the details published in the Bank Master Data are based on information provided by the respective banks/institutions.
    /// Information in the Download Bank Master may be used freely. SIX assumes no responsibility for the completeness of this information, nor for any damages
    /// from actions taken based on this information. SIX reserves the express right to change or delete this information from its website at any time.
    /// </para>
    /// <para>
    /// Two methods are provided as part of this library for creating a <see cref="IBankMasterClient"/> instance.
    /// <list type="bullet">
    /// <item>
    /// <description><see cref="BankMasterClientFactory.CreateNewtonsoftJsonClient"/> which uses Json.NET for JSON deserialization.</description>
    /// </item>
    /// <item>
    /// <description><see cref="BankMasterClientFactory.CreateSystemTextJsonClient"/> which uses System.Text.Json for JSON deserialization.</description>
    /// </item>
    /// </list>
    /// </para>
    /// The client based on System.Text.Json is more performant, both in speed and allocated memory, but produces lower quality exceptions than Json.NET if the
    /// JSON is invalid.
    /// </summary>
    /// <remarks>
    /// More documentation is available on
    /// https://www.six-group.com/en/products-services/banking-services/interbank-clearing/online-services/download-bank-master.html
    /// </remarks>
    public interface IBankMasterClient
    {
        /// <summary>
        /// Returns the Bank Master data.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
        /// <returns>The Bank Master data.</returns>
        /// <exception cref="Refit.ApiException">When the Bank Master API returns an HTTP status code does not indicate success.</exception>
        [Get("/public")]
        Task<BankMasterData> GetMasterDataAsync(CancellationToken cancellationToken = default);
    }
}
