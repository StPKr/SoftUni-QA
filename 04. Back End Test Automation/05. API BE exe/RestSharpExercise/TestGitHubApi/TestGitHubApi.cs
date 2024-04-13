using RestSharpServices;
using System.Net;
using System.Reflection.Emit;
using System.Text.Json;
using RestSharp;
using RestSharp.Authenticators;
using NUnit.Framework.Internal;
using RestSharpServices.Models;
using System;

namespace TestGitHubApi
{
    public class TestGitHubApi
    {
        private GitHubApiClient client;
        private static string repo;
        private static int lastCreatedIssueNumber;
        private static int lastCreatedCommentId;

        [SetUp]
        public void Setup()
        {
            client = new GitHubApiClient("https://api.github.com/repos/testnakov/", "StPKr", "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");
            repo = "test-nakov-repo";
        }


        [Test, Order(1)]
        public void Test_GetAllIssuesFromARepo()
        {
            //Arrange

            //Act
            var issues = client.GetAllIssues(repo);

            //Assert
            Assert.That(issues, Has.Count.GreaterThan(0),
                "There should be more than one issue.");

            foreach (Issue issue in issues)
            {
                Assert.That(issue.Id, Is.GreaterThan(0),
                    "Issue ID should be greater than 0");
                Assert.That(issue.Number, Is.GreaterThan(0),
                    "Issue Number should be greater than 0");
                Assert.That(issue.Title, Is.Not.Empty,
                    "Issue Title should not be empty");
            }
        }

        [Test, Order(2)]
        public void Test_GetIssueByValidNumber()
        {
            //Arrange
            int issueNumber = 1;
            //Act
            var issue = client.GetIssueByNumber(repo, issueNumber);

            //Assert
            Assert.That(issue, Is.Not.Null,
                "The response should contain issue data.");
            Assert.That(issue.Id, Is.GreaterThan(0),
                     "Issue ID should be greater than 0.");
            Assert.That(issue.Number, Is.EqualTo(issueNumber),
                "Issue Number should be as requested.");
            Assert.That(issue.Title, Is.Not.Empty,
                "Issue Title should not be empty.");
        }

        [Test, Order(3)]
        public void Test_GetAllLabelsForIssue()
        {
            //Arrange
            int issueNumber = 6;
            //Act
            var labels = client.GetAllLabelsForIssue(repo, issueNumber);

            //Assert
            Assert.That(labels.Count, Is.GreaterThan(0),
                "There should be labels on the issue.");

            foreach (var label in labels)
            {
                Assert.That(label.Id, Is.GreaterThan(0),
                    "Label ID should be more than 0.");
                Assert.That(label.Name, Is.Not.Empty,
                    "Label Name should not be empty");

                Console.WriteLine($"Label: {label.Id} - Name: {label.Name}");
            }
        }

        [Test, Order(4)]
        public void Test_GetAllCommentsForIssue()
        {
            //Arrange
            int issueNumber = 6;
            //Act
            var comments = client.GetAllCommentsForIssue(repo, issueNumber);

            //Assert
            Assert.That(comments.Count, Is.GreaterThan(0),
                "There should be comments on the issue.");

            foreach (var comment in comments)
            {
                Assert.That(comment.Id, Is.GreaterThan(0),
                    "Comment ID should be more than 0.");
                Assert.That(comment.Body, Is.Not.Empty,
                    "Comment Body should not be empty");

                Console.WriteLine($"Comment: {comment.Id} - Name: {comment.Body}");
            }
        }

        [Test, Order(5)]
        public void Test_CreateGitHubIssue()
        {
            //Arrange
            string title = "New random title ala bala";
            string body = "New Body of the new Issue";

            //Act
            var issue = client.CreateIssue(repo, title, body);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(issue.Id, Is.GreaterThan(0));
                Assert.That(issue.Number, Is.GreaterThan(0));
                Assert.That(issue.Title, Is.Not.Empty);
                Assert.That(issue.Title, Is.EqualTo(title));

            });

            Console.WriteLine(issue.Number);
            lastCreatedIssueNumber = issue.Number;
        }

        [Test, Order(6)]
        public void Test_CreateCommentOnGitHubIssue()
        {
            //Arrange
            int issueNumber = 6;
            string body = "New Body of the new Issue";

            //Act
            var comment = client.CreateCommentOnGitHubIssue(repo, issueNumber, body);

            //Assert
            Assert.IsNotNull(comment, "Expected to retrieve a comment but got null.");
            Assert.That(comment.Id, Is.EqualTo(issueNumber), "The retrieved comment ID should match the requested comment ID.");
        }

        [Test, Order(7)]
        public void Test_GetCommentById()
        {
            int commentId = 6;

            var comment = client.GetCommentById(repo, commentId);

            Assert.That(comment, Is.Not.Null);
            Assert.That(comment.Id, Is.EqualTo(commentId));
        }


        [Test, Order(8)]
        public void Test_EditCommentOnGitHubIssue()
        {

        }

        [Test, Order(9)]
        public void Test_DeleteCommentOnGitHubIssue()
        {

        }


    }
}

