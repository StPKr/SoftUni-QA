using LibroConsoleAPI.Business;
using LibroConsoleAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroConsoleAPI.IntegrationTests.XUnit
{
    public class UpdateBookMethodTests : IClassFixture<BookManagerFixture>
    {
        private readonly BookManager _bookManager;
        private readonly TestLibroDbContext _dbContext;

        public UpdateBookMethodTests(BookManagerFixture fixture)
        {
            _bookManager = fixture.BookManager;
            _dbContext = fixture.DbContext;
        }
        [Fact]
        public async Task UpdateBookAsync_ShouldUpdateBook()
        {
            //Arrange
            var newBook = new Book
            {
                Title = "Test Book",
                Author = "John Doe",
                ISBN = "1234567890123",
                YearPublished = 2021,
                Genre = "Fiction",
                Pages = 100,
                Price = 19.99
            };
            await _bookManager.AddAsync(newBook);
            newBook.Title = "UpdatedTitle";

            //Act
            await _bookManager.UpdateAsync(newBook);

            //Assert
            var bookInDb = _dbContext.Books.FirstOrDefault( b => b.Title == newBook.Title);
            Assert.Equal("UpdatedTitle", bookInDb.Title);
        }
    }
}
