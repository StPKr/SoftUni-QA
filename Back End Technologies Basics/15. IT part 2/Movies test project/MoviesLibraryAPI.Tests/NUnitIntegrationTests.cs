using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MoviesLibraryAPI.Controllers;
using MoviesLibraryAPI.Controllers.Contracts;
using MoviesLibraryAPI.Data.Models;
using MoviesLibraryAPI.Services;
using MoviesLibraryAPI.Services.Contracts;
using System.ComponentModel.DataAnnotations;

namespace MoviesLibraryAPI.Tests
{
    [TestFixture]
    public class NUnitIntegrationTests
    {
        private MoviesLibraryNUnitTestDbContext _dbContext;
        private IMoviesLibraryController _controller;
        private IMoviesRepository _repository;
        IConfiguration _configuration;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }

        [SetUp]
        public async Task Setup()
        {
            string dbName = $"MoviesLibraryTestDb_{Guid.NewGuid()}";
            _dbContext = new MoviesLibraryNUnitTestDbContext(_configuration, dbName);

            _repository = new MoviesRepository(_dbContext.Movies);
            _controller = new MoviesLibraryController(_repository);
        }

        [TearDown]
        public async Task TearDown()
        {
            await _dbContext.ClearDatabaseAsync();
        }

        [Test]
        public async Task AddMovieAsync_WhenValidMovieProvided_ShouldAddToDatabase()
        {
            // Arrange
            var movie = new Movie
            {
                Title = "Test Movie",
                Director = "Test Director",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 86,
                Rating = 7.5
            };

            // Act
            await _controller.AddAsync(movie);

            // Assert
            var resultMovie = await _dbContext.Movies.Find(m => m.Title == "Test Movie").FirstOrDefaultAsync();
            Assert.IsNotNull(resultMovie);
        }

        [Test]
        public async Task AddMovieAsync_WhenInvalidMovieProvided_ShouldThrowValidationException()
        {
            // Arrange
            var invalidMovie = new Movie
            {
                // Provide an invalid movie object, for example, missing required fields like 'Title'
                // Assuming 'Title' is a required field, do not set it
            };

            // Act and Assert
            // Expect a ValidationException because the movie is missing a required field
            var exception = Assert.ThrowsAsync<ValidationException>(() => _controller.AddAsync(invalidMovie));
        }

        [Test]
        public async Task DeleteAsync_WhenValidTitleProvided_ShouldDeleteMovie()
        {
            // Arrange            

            // Act            

            // Assert
            // The movie should no longer exist in the database
        }


        [Test]
        public async Task DeleteAsync_WhenTitleIsNull_ShouldThrowArgumentException()
        {
            // Act and Assert
            //Assert.ThrowsAsync<ArgumentException>(() => _controller.DeleteAsync(null));
        }

        [Test]
        public async Task DeleteAsync_WhenTitleIsEmpty_ShouldThrowArgumentException()
        {
            // Act and Assert            
        }

        [Test]
        public async Task DeleteAsync_WhenTitleDoesNotExist_ShouldThrowInvalidOperationException()
        {
            // Act and Assert            
        }

        [Test]
        public async Task GetAllAsync_WhenNoMoviesExist_ShouldReturnEmptyList()
        {
            // Act
            var result = await _controller.GetAllAsync();

            // Assert
            Assert.IsEmpty(result);
        }

        [Test]
        public async Task GetAllAsync_WhenMoviesExist_ShouldReturnAllMovies()
        {
            // Arrange

            // Act

            // Assert
            // Ensure that all movies are returned
        }

        [Test]
        public async Task GetByTitle_WhenTitleExists_ShouldReturnMatchingMovie()
        {
            // Arrange

            // Act

            // Assert
        }

        [Test]
        public async Task GetByTitle_WhenTitleDoesNotExist_ShouldReturnNull()
        {
            // Act

            // Assert
            //Assert.IsNull(resultMovie);
        }


        [Test]
        public async Task SearchByTitleFragmentAsync_WhenTitleFragmentExists_ShouldReturnMatchingMovies()
        {
            // Arrange

            // Act

            // Assert // Should return one matching movie
        }

        [Test]
        public async Task SearchByTitleFragmentAsync_WhenNoMatchingTitleFragment_ShouldThrowKeyNotFoundException()
        {
            // Act and Assert
        }

        [Test]
        public async Task UpdateAsync_WhenValidMovieProvided_ShouldUpdateMovie()
        {
            // Arrange

            // Modify the movie

            // Act

            // Assert
        }

        [Test]
        public async Task UpdateAsync_WhenInvalidMovieProvided_ShouldThrowValidationException()
        {
            // Arrange
            // Movie without required fields

            // Act and Assert
        }


        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            await _dbContext.ClearDatabaseAsync();
        }
    }
}
