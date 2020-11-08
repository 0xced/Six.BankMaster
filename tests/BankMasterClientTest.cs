using System;
using System.IO;
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
        private readonly HttpMessageHandler _httpClientHandler;

        public BankMasterClientTest()
        {
            _httpClientHandler = new RecordedFileHandler(new DirectoryInfo("."));
        }

        [Fact]
        public async Task SystemTextJsonClient_LiveApi_ReturnsValidMasterData()
        {
            // Arrange
            var client = BankMasterClientFactory.CreateSystemTextJsonClient();

            // Act
            var masterData = await client.GetMasterDataAsync();

            // Assert
            masterData.Entries.Should().NotBeEmpty();
        }

        [Fact]
        public async Task NewtonsoftJsonClient_LiveApi_ReturnsValidMasterData()
        {
            // Arrange
            var client = BankMasterClientFactory.CreateNewtonsoftJsonClient();

            // Act
            var masterData = await client.GetMasterDataAsync();

            // Assert
            masterData.Entries.Should().NotBeEmpty();
        }

        [Fact]
        public async Task SystemTextJsonClient_RecordedResponse_ReturnsValidMasterData()
        {
            // Arrange
            var client = BankMasterClientFactory.CreateSystemTextJsonClient(() => _httpClientHandler);

            // Act
            var masterData = await client.GetMasterDataAsync();

            // Assert
            masterData.Entries.Should().NotBeEmpty();
        }

        [Fact]
        public async Task NewtonsoftJsonClient_RecordedResponse_ReturnsValidMasterData()
        {
            // Arrange
            var client = BankMasterClientFactory.CreateNewtonsoftJsonClient(() => _httpClientHandler);

            // Act
            var masterData = await client.GetMasterDataAsync();

            // Assert
            masterData.Entries.Should().NotBeEmpty();
        }
    }
}
