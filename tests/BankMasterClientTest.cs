using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Six.BankMaster.Tests
{
    internal class RecordedFileHandler : DelegatingHandler
    {
        private readonly DirectoryInfo _directory;

        public RecordedFileHandler(DirectoryInfo directory)
        {
            _directory = directory ?? throw new ArgumentNullException(nameof(directory));
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var apiPath = request.RequestUri.LocalPath.Replace(BankMasterClientFactory.BaseUri.LocalPath, "");
            var localPath = Path.ChangeExtension(Path.Combine(_directory.FullName, apiPath), "json");
            var content = await File.ReadAllBytesAsync(localPath, cancellationToken);
            return new HttpResponseMessage(HttpStatusCode.OK) { Content = new ByteArrayContent(content) };
        }
    }

    public class BankMasterClientTest
    {
        private readonly HttpMessageHandler _httpMessageHandler;

        public BankMasterClientTest()
        {
            _httpMessageHandler = new RecordedFileHandler(new DirectoryInfo("."));
        }

        [Fact]
        public async Task SystemTextJsonClient_LiveApi_ReturnsValidMasterData()
        {
            // Arrange
            var client = BankMasterClientFactory.CreateSystemTextJsonClient();

            // Act
            var masterData = await client.GetMasterDataAsync();

            // Assert
            AssertValidData(masterData);
        }

        [Fact]
        public async Task NewtonsoftJsonClient_LiveApi_ReturnsValidMasterData()
        {
            // Arrange
            var client = BankMasterClientFactory.CreateNewtonsoftJsonClient();

            // Act
            var masterData = await client.GetMasterDataAsync();

            // Assert
            AssertValidData(masterData);
        }

        [Fact]
        public async Task SystemTextJsonClient_RecordedResponse_ReturnsValidMasterData()
        {
            // Arrange
            var client = BankMasterClientFactory.CreateSystemTextJsonClient(() => _httpMessageHandler);

            // Act
            var masterData = await client.GetMasterDataAsync();

            // Assert
            AssertValidData(masterData);
        }

        [Fact]
        public async Task NewtonsoftJsonClient_RecordedResponse_ReturnsValidMasterData()
        {
            // Arrange
            var client = BankMasterClientFactory.CreateNewtonsoftJsonClient(() => _httpMessageHandler);

            // Act
            var masterData = await client.GetMasterDataAsync();

            // Assert
            AssertValidData(masterData);
        }

        private static void AssertValidData(BankMasterData masterData)
        {
            masterData.Entries.Should().NotBeEmpty();
            masterData.Entries.Select(e => e.BranchId).Should().AllBeOfType<string>();
            masterData.Entries.Select(e => e.SicIid).Should().AllBeOfType<string>();
            masterData.Entries.Select(e => e.ShortName).Should().AllBeOfType<string>();
            masterData.Entries.Select(e => e.BankOrInstitutionName).Should().AllBeOfType<string>();
            masterData.Entries.Select(e => e.ZipCode).Should().AllBeOfType<string>();
            masterData.Entries.Select(e => e.Place).Should().AllBeOfType<string>();
        }
    }
}
