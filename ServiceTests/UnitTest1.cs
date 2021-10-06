using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceClient;
using ServiceClient.Services;

namespace ServiceTests
{
    [TestClass]
    public class UnitTest1
    {
        private TestServer _server;
        private HttpClient _client;

        [TestInitialize]
        public void Setup()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [TestMethod]
        public async Task GetPeople_3InDatabase_3IsReturned()
        {
            var response = await _client.GetAsync("/People");
            response.EnsureSuccessStatusCode();
            var people = await response
                .Content
                .ReadFromJsonAsync<IEnumerable<Person>>();

            people.Count().Should().Be(4, "3 people are in the database");
        }

        [TestMethod]
        public async Task PostPeople_PersonIsUnder16_Error()
        {
            var person = new Person(0, "Test", 14);
            var response = await _client.PostAsJsonAsync("/People", person);

            Assert.AreEqual((int)response.StatusCode, 500);
        }

        // Person post => Count 4
    }
}
