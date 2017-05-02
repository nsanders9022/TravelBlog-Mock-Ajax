using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelBlog.Models;
using Xunit;

namespace TravelBlot.Tests
{
    public class LocationTest
    {
        [Fact]
        public void GetDescriptionTest()
        {
            //Arrange
            var location = new Location();
            location.Name = "Beautiful landscape";

            //Act
            var result = location.Name;

            //Assert
            Assert.Equal("Beautiful landscape", result);
        }
    }
}
