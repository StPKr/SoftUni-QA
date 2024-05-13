using LibroConsoleAPI.Business;
using LibroConsoleAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroConsoleAPI.IntegrationTests.XUnit
{
    public class GetSpecificMethodTest : IClassFixture<BookManagerFixture>
    {
        private readonly BookManager _bookManager;
        private readonly TestLibroDbContext _dbContext;

        public GetSpecificMethodTest(BookManagerFixture fixture)
        {
            _bookManager = fixture.BookManager;
            _dbContext = fixture.DbContext;
        }
        [Fact]
        public async Task GetSpeicifcAsync_ShouldRetrunCorrectElement()
        {
            //Arrange
            await DatabaseSeeder.SeedDatabaseAsync(_dbContext, _bookManager);
            //Act
            var result = await _bookManager.GetSpecificAsync("9780312857753");
            //Assert
            Assert.Equal("9780312857753", result.ISBN);
        }
    }
}
