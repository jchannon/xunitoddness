using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwinTesting.Tests
{
    using System.Net;
    using System.Net.Http;
    using Microsoft.Owin.Testing;
    using Xunit;

    public class HomeTests
    {
        [Fact]
        public async Task DoesItWork()
        {
            //Given
            var client = CreateHttpClient();

            //When
            var response = await client.GetAsync("http://localhost/");

            //Then
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            
        }

        private static HttpClient CreateHttpClient()
        {
            var client = TestServer.Create(builder =>
                new Startup()
                .Configuration(builder))
                .HttpClient;

            client.DefaultRequestHeaders.Add("Accept", "application/json");

            return client;
        }
    }
}
