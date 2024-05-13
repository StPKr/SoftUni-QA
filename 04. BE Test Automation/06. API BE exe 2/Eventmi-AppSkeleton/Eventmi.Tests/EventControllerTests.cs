using Eventmi.Core.Models.Event;
using Eventmi.Infrastructure.Data.Contexts;
using Eventmi.Infrastructure.Migrations;
using Eventmi.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using RestSharp;

namespace Eventmi.Tests
{
    public class Tests
    {
        private RestClient _client;
        private string _baseUrl = "https://localhost:7236";


        [SetUp]
        public void Setup()
        {
            _client = new RestClient(_baseUrl);
        }

        [Test]
        public async Task GetAllEvents_ReturnsSuccessStatusCode()
        {
            //Arrange
            var request = new RestRequest("/Event/All", Method.Get);

            //Act
            var response = await _client.ExecuteAsync(request);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task Add_GetRequest_ReturnsAddView()
        {
            var request = new RestRequest("/Event/Add", Method.Get);

            var response = await _client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task Add_PostRequest_AddsNewEventAndRedirects()
        {
            var input = new EventFormModel()
            {
                Name = "Soft Uni Conf",
                Start = new DateTime(2024, 09, 29, 09, 0, 0),
                End = new DateTime(2024, 09, 29, 19, 0, 0),
                Place = "Soft Uni",
            };

            var request = new RestRequest("/Event/Add", Method.Post);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            request.AddParameter("Name", input.Name);
            request.AddParameter("Start", input.Start.ToString("MM/dd/yyyy hh:mm tt"));
            request.AddParameter("End", input.End.ToString("MM/dd/yyyy hh:mm tt"));
            request.AddParameter("Place", input.Place);

            var response = await _client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Status code is not OK!");
            Assert.True(CheckIfEventExists(input.Name), "Event was not found");
        }

        [Test]

        public async Task Details_GetRequest_shouldReturnDetailedView()
        {
            var eventId = 1;
            var request = new RestRequest($"/Event/Details/{eventId}", Method.Get);

            var response = await _client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]

        public async Task Details_GetRequest_shouldReturnNotFoundIfNoIdIsGiven()
        {
            var eventId = 1;
            var request = new RestRequest($"/Event/Details/", Method.Get);

            var response = await _client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }


        [Test]

        public async Task Edit_GetRequest_ShouldReturnEditView()
        {
            var eventId = 1;

            var request = new RestRequest($"/Event/Edit/{eventId}", Method.Get);

            var response = await _client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]

        public async Task Edit_GetRequest_ShouldReturnNotFoundIfNoIdIsGiven()
        {
            var eventId = 1;

            var request = new RestRequest($"/Event/Edit/", Method.Get);

            var response = await _client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]

        public async Task Edit_PostRequest_ShouldEditAnEvent()
        {
            var eventId = 7;
            var dbEvent = await GetEventById(eventId);



            var input = new EventFormModel()
            {
                Id = dbEvent.Id,
                Name = dbEvent.Name,
                Start = dbEvent.Start,
                End = dbEvent.End,
                Place = dbEvent.Place,
            };

            string updatedName = "UpdatedEventName";
            input.Name = updatedName;

            var request = new RestRequest($"/Event/Edit/{eventId}", Method.Post);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            request.AddParameter("Id", input.Id);
            request.AddParameter("Name", input.Name);
            request.AddParameter("Start", input.Start.ToString("MM/dd/yyyy hh:mm tt"));
            request.AddParameter("End", input.End.ToString("MM/dd/yyyy hh:mm tt"));
            request.AddParameter("Place", input.Place);

            var response = await _client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]

        public async Task Edit_WithIdMismatch_ShouldReturnNotFound()
        {
            var eventId = 7;
            var dbEvent = await GetEventById(eventId);


            var input = new EventFormModel()
            {
                Id = 445,
                Name = dbEvent.Name,
                Start = dbEvent.Start,
                End = dbEvent.End,
                Place = dbEvent.Place,
            };

            var request = new RestRequest($"/Event/Edit/{eventId}", Method.Post);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            request.AddParameter("Id", input.Id);
            request.AddParameter("Name", input.Name);
            request.AddParameter("Start", input.Start.ToString("MM/dd/yyyy hh:mm tt"));
            request.AddParameter("End", input.End.ToString("MM/dd/yyyy hh:mm tt"));
            request.AddParameter("Place", input.Place);

            var response = await _client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]

        public async Task DeleteAction_WithValid_RedirectsToAllEvents()
        {

            var input = new EventFormModel()
            {
                Name = "Event For Deleting",
                Start = new DateTime(2024, 09, 29, 09, 0, 0),
                End = new DateTime(2024, 09, 29, 19, 0, 0),
                Place = "Soft Uni",
            };

            var request = new RestRequest("/Event/Add", Method.Post);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            request.AddParameter("Name", input.Name);
            request.AddParameter("Start", input.Start.ToString("MM/dd/yyyy hh:mm tt"));
            request.AddParameter("End", input.End.ToString("MM/dd/yyyy hh:mm tt"));
            request.AddParameter("Place", input.Place);

            await _client.ExecuteAsync(request);

            var eventInDb = await GetEventByName(input.Name);
            var eventIdToDelete = eventInDb.Id;

            var deleteRequest = new RestRequest($"/Event/Delete/{eventIdToDelete}", Method.Post);

            var response = await _client.ExecuteAsync(deleteRequest);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Redirect));

        }

        private bool CheckIfEventExists(string name)
        {
            var options = new DbContextOptionsBuilder<EventmiContext>().UseSqlServer("Server=DESKTOP-SPN5UL4\\SQLEXPRESS;Database=Eventmi;Trusted_Connection=True;MultipleActiveResultSets=true").Options;

            using var context = new EventmiContext(options);

            return context.Events.Any(x => x.Name == name);
        }

        private async Task<Event> GetEventByName(int name)
        {
            var options = new DbContextOptionsBuilder<EventmiContext>()
                .UseSqlServer
                ("Server=DESKTOP-SPN5UL4\\SQLEXPRESS;Database=Eventmi;Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options;

            using (var context = new EventmiContext(options))
            {
                return await context.Events.FirstOrDefaultAsync(e => e.Name == name);
            }
        }

        private async Task<Event> GetEventById(int id)
        {
            var options = new DbContextOptionsBuilder<EventmiContext>()
                .UseSqlServer
                ("Server=DESKTOP-SPN5UL4\\SQLEXPRESS;Database=Eventmi;Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options;

            using (var context = new EventmiContext(options))
            {
                return await context.Events.FirstOrDefaultAsync(e => e.Id == id);
            }
        }
    }
}