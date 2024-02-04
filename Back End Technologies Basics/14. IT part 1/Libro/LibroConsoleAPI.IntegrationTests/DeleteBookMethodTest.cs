using LibroConsoleAPI.Business;
using LibroConsoleAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroConsoleAPI.IntegrationTests.XUnit
{
    public class DeleteBookMethodTest : IClassFixture<BookManagerFixture>
    {
        private readonly BookManager _bookManager;
        private readonly TestLibroDbContext _dbContext;

        public DeleteBookMethodTest(BookManagerFixture fixture)
        {
            _bookManager = fixture.BookManager;
            _dbContext = fixture.DbContext;
        }

        [Fact]
        public async Task DeletBookAsync_ShouldDeleteTheBook()
        {
            // Arrange
            /*var newBook = new Book
            {
                Title = "Some book title",
                Author = "John Doe",
                ISBN = "fdafds",
                YearPublished = 2021,
                Genre = "Fiction",
                Pages = 100,
                Price = 19.99
            };*/
            //await _bookManager.AddAsync(newBook);

            await DatabaseSeeder.SeedDatabaseAsync(_dbContext, _bookManager);

            // Act
            await _bookManager.DeleteAsync("9780312857753");
            // Assert
            var bookInDb = _dbContext.Books.ToList();
            Assert.Equal(9, bookInDb.Count);
        }
    }
}
