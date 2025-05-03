using System.Net.Http.Json;
using backend.Models.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace backend.Tests
{
    public class UserApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public UserApiTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CreateUser_Returns200AndId()
        {
            var newUser = new UserDto
            {
                Email = "test@tdd.com",
                Name = "TDD Tester",
                Provider = "Google",
                ProviderId = "google-123"
            };

            var response = await _client.PostAsJsonAsync("/api/users", newUser);
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadFromJsonAsync<Dictionary<string, object>>();
            Assert.True(body.ContainsKey("id")); 
        }
    }
}
