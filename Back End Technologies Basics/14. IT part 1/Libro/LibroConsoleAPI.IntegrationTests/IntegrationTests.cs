using LibroConsoleAPI.Business;
using LibroConsoleAPI.Business.Contracts;
using LibroConsoleAPI.Data.Models;
using LibroConsoleAPI.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;

namespace LibroConsoleAPI.IntegrationTests
{
    public class IntegrationTests : IClassFixture<BookManagerFixture>
    {
        private readonly BookManager _bookManager;
        private readonly TestLibroDbContext _dbContext;

        public IntegrationTests(BookManagerFixture fixture)
        {
            _bookManager = fixture.BookManager;
            _dbContext = fixture.DbContext;
        }

        [Fact]
        public async Task AddBookAsync_TryToAddBookWithInvalidCredentials_ShouldThrowException()
        {
            // Arrange

            // Act

            // Assert
            //Assert.ThrowsAsync<ValidationException>(() => _bookManager.AddAsync(invalidBook));
        }

        [Fact]
        public async Task DeleteBookAsync_WithValidISBN_ShouldRemoveBookFromDb()
        {
            // Arrange

            // Act

            // Assert
            //var bookInDb = await _dbContext.Books.FindAsync(validIsbn);
            //Assert.Null(bookInDb);
        }
        [Fact]
        public async Task DeleteBookAsync_TryToDeleteWithNullOrWhiteSpaceISBN_ShouldThrowException()
        {
            // Arrange

            // Act

            // Assert
        }

        [Fact]
        public async Task GetAllAsync_WhenBooksExist_ShouldReturnAllBooks()
        {
            // Arrange

            // Act

            // Assert
        }

        [Fact]
        public async Task GetAllAsync_WhenNoBooksExist_ShouldThrowKeyNotFoundException()
        {
            // Arrange

            // Act

            // Assert
        }

        [Fact]
        public async Task SearchByTitleAsync_WithValidTitleFragment_ShouldReturnMatchingBooks()
        {
            // Arrange

            // Act

            // Assert
        }

        [Fact]
        public async Task SearchByTitleAsync_WithInvalidTitleFragment_ShouldThrowKeyNotFoundException()
        {
            // Arrange

            // Act

            // Assert
        }

        [Fact]
        public async Task GetSpecificAsync_WithValidIsbn_ShouldReturnBook()
        {
            // Arrange

            // Act

            // Assert
        }

        [Fact]
        public async Task GetSpecificAsync_WithInvalidIsbn_ShouldThrowKeyNotFoundException()
        {
            // Arrange

            // Act

            // Assert
        }

        [Fact]
        public async Task UpdateAsync_WithValidBook_ShouldUpdateBook()
        {
            // Arrange

            // Act

            // Assert
        }

        [Fact]
        public async Task UpdateAsync_WithInvalidBook_ShouldThrowValidationException()
        {
            // Arrange

            // Act

            // Assert
        }

    }
}
