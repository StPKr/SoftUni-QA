using QA_Exam_C_.Models;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;
using System.Text.Json;

namespace QA_Exam_C_
{
    public class Tests
    {
        private RestClient client;
        private const string BASEURL = "https://d5wfqm7y6yb3q.cloudfront.net";
        private const string USERNAME = "ognqn";
        private const string PASSWORD = "123456";

        private static string storyId;


        [OneTimeSetUp]
        public void Setup()
        {
            string jwtToken = GetJwtToken(USERNAME, PASSWORD);

            var options = new RestClientOptions(BASEURL)
            {
                Authenticator = new JwtAuthenticator(jwtToken)
            };

            client = new RestClient(options);
        }

        private string GetJwtToken(string username, string password)
        {
            RestClient authClient = new RestClient(BASEURL);
            var request = new RestRequest("/api/User/Authentication");
            request.AddJsonBody(new
            {
                username,
                password
            });

            var response = authClient.Execute(request, Method.Post);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = JsonSerializer.Deserialize<JsonElement>(response.Content);
                var token = content.GetProperty("accessToken").GetString();
                if (string.IsNullOrWhiteSpace(token))
                {
                    throw new InvalidOperationException("Access Token is null or empty");
                }
                return token;
            }
            else
            {
                throw new InvalidOperationException($"Unexpected response type {response.StatusCode} with data {response.Content}");
            }
        }

        [Test, Order(1)]
        public void CreateANewStorySpoiler_WithRequiredFields_ShouldSucceed()
        {
            var requestData = new StoryDTO()
            {
                Title = "TestTitle",
                Description = "TestDescription",
            };

            var request = new RestRequest("/api/Story/Create");
            request.AddJsonBody(requestData);

            var response = client.Execute(request, Method.Post);
            var responseData = JsonSerializer.Deserialize<ApiResponseDTO>(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.IsNotNull(responseData.StoryId);
            Assert.That(responseData.Msg, Is.EqualTo("Successfully created!"));

            storyId = responseData.StoryId;
        }
        [Test, Order(2)]
        public void EditTheStorySpoilerThatYouCreated_WithCorrectDetails_ShouldSucceed()
        {
            var requestData = new StoryDTO()
            {
                Title = "EditedTestTitle",
                Description = "TestDescription with edits",
            };

            var request = new RestRequest($"/api/Story/Edit/{storyId}");
            request.AddJsonBody(requestData);

            var response = client.Execute(request, Method.Put);
            var responseData = JsonSerializer.Deserialize<ApiResponseDTO>(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(responseData.Msg, Is.EqualTo("Successfully edited"));
        }

        [Test, Order(3)]
        public void DeleteAStory_ShouldSucceed()
        {
            var request = new RestRequest($"/api/Story/Delete/{storyId}");

            var response = client.Execute(request, Method.Delete);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Content, Does.Contain("Deleted successfully!"));
        }

        [Test, Order(4)]
        public void TryToCreateANewStory_WithoutCorrectData_ShouldFail()
        {
            var requestData = new StoryDTO()
            {
                Title = "Impossible"
            };

            var request = new RestRequest("/api/Story/Create");
            request.AddJsonBody(requestData);

            var response = client.Execute(request, Method.Post);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test, Order(5)]
        public void EditANonExistingStory_ShouldFail()
        {
            var requestData = new StoryDTO()
            {
                Title = "Random Title",
                Description = "Won't pass",
            };

            var request = new RestRequest("/api/Story/Edit/pesho");
            request.AddJsonBody(requestData);

            var response = client.Execute(request, Method.Put);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(response.Content, Does.Contain("No spoilers..."));
        }

        [Test, Order(6)]
        public void DeleteANonExistingStory_ShouldFail()
        {
            var request = new RestRequest("/api/Story/Delete/gosho");

            var response = client.Execute(request, Method.Delete);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(response.Content, Does.Contain("Unable to delete this story spoiler!"));
        }
    }
}