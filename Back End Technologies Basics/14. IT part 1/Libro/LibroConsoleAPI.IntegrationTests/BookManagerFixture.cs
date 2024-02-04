using LibroConsoleAPI.Business.Contracts;
using LibroConsoleAPI.Business;
using LibroConsoleAPI.IntegrationTests;
using LibroConsoleAPI.Repositories;

public class BookManagerFixture : IDisposable
{
    public TestLibroDbContext DbContext { get; private set; }
    public IBookManager BookManager { get; private set; }

    public BookManagerFixture()
    {
        DbContext = new TestLibroDbContext();
        var bookRepository = new BookRepository(DbContext);
        BookManager = new BookManager(bookRepository);
    }

    public void Dispose()
    {
        // Clean up resources after tests
        DbContext.Dispose();
    }
}
