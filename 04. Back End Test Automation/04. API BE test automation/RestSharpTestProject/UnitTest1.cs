using RestSharp.Authenticators;
using RestSharp;
using System.Net;
using Newtonsoft.Json;

namespace RestSharpTestProject
{
    public class Tests
    {
        RestClient client;
        [SetUp]
        public void Setup()
        {
            var options = new RestClientOptions("https://api.github.com")
            {
                Authenticator = new HttpBasicAuthenticator("StPKr", "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")
            };

            client = new RestClient(options);
        }

        [Test]
        public void Test_GitGetIssuesEndpoint()
        {
            //Arrange           

            var request = new RestRequest
             ("/repos/testnakov/test-nakov-repo/issues", Method.Get);

            //Act
            var response = client.Execute(request);

            //Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        }

        [Test]
        public void Test_GitGetIssuesEndpoint_MoreValidation()
        {
            //Arrange           

            var request = new RestRequest
             ("/repos/testnakov/test-nakov-repo/issues", Method.Get);

            //Act
            var response = client.Execute(request);
            var issuesObjects = JsonConvert.DeserializeObject<List<Issue>>(response.Content);

            //Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);

            foreach (var issue in issuesObjects)
            {
                Assert.That(issue.id, Is.GreaterThan(0));
                Assert.That(issue.number, Is.GreaterThan(0));
                Assert.That(issue.title, Is.Not.Empty);
            }
        }

        [Test]
        public void Test_GitPostMethod()
        {
            //Arrange & Act
            var createdIssue = CreateIssue("IssueTests9d912019021", "BodyRandom12919");

            //Assert
            Assert.That(createdIssue.title.Equals("IssueTests9d912019021"));
            Assert.That(createdIssue.body.Equals("BodyRandom12919"));

        }
        private Issue CreateIssue(string title, string body)
        {
            var request = new RestRequest
             ("/repos/testnakov/test-nakov-repo/issues", Method.Post);
            request.AddBody(new { body, title });

            var response = client.Execute(request);
            var issuesObject = JsonConvert.DeserializeObject<Issue>(response.Content);

            return issuesObject;

        }
    }
}