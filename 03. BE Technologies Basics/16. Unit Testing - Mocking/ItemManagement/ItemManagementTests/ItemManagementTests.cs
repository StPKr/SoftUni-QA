using NUnit.Framework;
using Moq;
using ItemManagementApp.Services;
using ItemManagementLib.Repositories;
using ItemManagementLib.Models;
using System.Collections.Generic;
using System.Linq;

namespace ItemManagement.Tests
{
    [TestFixture]
    public class ItemServiceTests
    {
        // Field to hold the mock repository and the service being tested
        

        [SetUp]
        public void Setup()
        {
            // Arrange: Create a mock instance of IItemRepository
            
            // Instantiate ItemService with the mocked repository
            
        }

        [Test]
        public void AddItem_ShouldCallAddItemOnRepository()
        {
            // Act: Call AddItem on the service
            

            // Assert: Verify that AddItem was called on the repository
            
        }

        [Test]
        public void GetAllItems_ShouldReturnAllItems()
        {
            
        }

        [Test]
        public void UpdateItem_ShouldCallUpdateItemOnRepository()
        {
           
        }

        [Test]
        public void DeleteItem_ShouldCallDeleteItemOnRepository()
        {
            
        }

        [Test]
        public void ValidateItemName_WhenNameIsValid_ShouldReturnTrue()
        {
            
        }

        [Test]
        public void ValidateItemName_WhenNameIsTooLong_ShouldReturnFalse()
        {
            
        }

        [Test]
        public void ValidateItemName_WhenNameIsEmpty_ShouldReturnFalse()
        {
            
        }
    }
}