using Mongo2Go;
using System;

namespace MoviesLibraryAPI.XUnitTests
{
    public class DatabaseFixture : IDisposable
    {
        public MongoDbRunner Runner { get; private set; }
        public MoviesLibraryXUnitTestDbContext DbContext { get; private set; }

        public DatabaseFixture()
        {
            Runner = MongoDbRunner.Start();

            string dbName = $"MoviesLibraryTestDb_{Guid.NewGuid()}";
            DbContext = new MoviesLibraryXUnitTestDbContext(Runner.ConnectionString, dbName);
        }

        public void Dispose()
        {
            Runner.Dispose();
        }
    }
}
