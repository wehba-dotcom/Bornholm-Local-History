using System;
using RestSharp;
using SharedModels;
using Polly;
using Polly.Retry;

namespace OrderApi.Infrastructure
{
    public class IdentityServiceGateway : IServiceGateway<UserDto>
    {
        string UserServiceBaseUrl;
        private readonly AsyncRetryPolicy _retryPolicy;

        public IdentityServiceGateway(string baseUrl)
        {
            UserServiceBaseUrl = baseUrl;

            _retryPolicy = Policy
            .Handle<HttpRequestException>()
            .WaitAndRetryAsync(10, retryAttempt =>
                TimeSpan.FromSeconds(3), onRetry: (exception, timeSpan, retryCount, context) =>
                {
                    Console.WriteLine($"Retry {retryCount}. Attemp failed, trying again...");
                }
            );
        }

        public async Task<UserDto> GetAsync(int id)
        {
            RestClient c = new RestClient(UserServiceBaseUrl);

            var request = new RestRequest(id.ToString());
            var resp = await _retryPolicy.ExecuteAsync(async () =>
            {
                var response = await c.GetAsync<UserDto>(request);
                return response;

            });
            return resp;       
        }
    }
}
