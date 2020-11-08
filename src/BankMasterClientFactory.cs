using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using NodaTime;
using NodaTime.Serialization.JsonNet;
using NodaTime.Serialization.SystemTextJson;
using Refit;

namespace Six.BankMaster
{
    /// <summary>
    /// Provides default implementation of <see cref="IBankMasterClient"/>.
    /// </summary>
    public static class BankMasterClientFactory
    {
        /// <summary>
        /// The base URI of the SIX Bank Master service.
        /// </summary>
        public static Uri BaseUri => new Uri("https://api.six-group.com/api/epcd/bankmaster/v2/", UriKind.Absolute);

        /// <summary>
        /// Create an implementation of <see cref="IBankMasterClient"/> wit Refit configured to use Newtonsoft.Json for JSON deserialization.
        /// </summary>
        /// <param name="httpMessageHandlerFactory">Optionally supply a custom inner <see cref="HttpMessageHandler"/>.</param>
        /// <returns>An implementation of <see cref="IBankMasterClient"/> using Newtonsoft.Json.</returns>
        public static IBankMasterClient CreateNewtonsoftJsonClient(Func<HttpMessageHandler>? httpMessageHandlerFactory = null)
        {
            var jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.ConfigureForNodaTime(DateTimeZoneProviders.Tzdb);
            var contentSerializer = new NewtonsoftJsonContentSerializer(jsonSerializerSettings);
            var settings = new RefitSettings(contentSerializer) { HttpMessageHandlerFactory = httpMessageHandlerFactory };
            return RestService.For<IBankMasterClient>(BaseUri.ToString(), settings);
        }

        /// <summary>
        /// Create an implementation of <see cref="IBankMasterClient"/> wit Refit configured to use System.Text.Json for JSON deserialization.
        /// </summary>
        /// <param name="httpMessageHandlerFactory">Optionally supply a custom inner <see cref="HttpMessageHandler"/>.</param>
        /// <returns>An implementation of <see cref="IBankMasterClient"/> using System.Text.Json.</returns>
        public static IBankMasterClient CreateSystemTextJsonClient(Func<HttpMessageHandler>? httpMessageHandlerFactory = null)
        {
            var jsonSerializerOptions = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumMemberConverter() },
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            jsonSerializerOptions.ConfigureForNodaTime(DateTimeZoneProviders.Tzdb);
            var contentSerializer = new SystemTextJsonContentSerializer(jsonSerializerOptions);
            var settings = new RefitSettings(contentSerializer) { HttpMessageHandlerFactory = httpMessageHandlerFactory };
            return RestService.For<IBankMasterClient>(BaseUri.ToString(), settings);
        }
    }
}
