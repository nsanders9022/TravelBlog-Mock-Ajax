using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelBlog.Controllers;
using TravelBlog.Models;
using Xunit;
using Moq;

namespace TravelBlog.Tests.ControllerTests
{
    public class LocationsControllerTest
    {

        Mock<ILocationRepository> mock = new Mock<ILocationRepository>();

        private void DbSetup()
        {
            mock.Setup(m => m.Locations).Returns(new Location[]
            {
                new Location { LocationId = 1, Name = "Paris", Description = "Holla"},
                new Location { LocationId = 2, Name = "London", Description = "Great"},
                new Location { LocationId = 3, Name = "Dubai", Description = "Hot hot hot"}
            }.AsQueryable());
        }

        [Fact]
        public void Mock_ViewResult_Index_Test()
        {
            //Arrange
            DbSetup();
            LocationsController controller = new LocationsController(mock.Object);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Mock_ModelList_Index_Test()
        {
            //Arrange
            DbSetup();
            ViewResult indexView = new LocationsController(mock.Object).Index() as ViewResult;

            //Act
            var result = indexView.ViewData.Model;

            //Assert
            Assert.IsType<List<Location>>(result);
        }

        [Fact]
        public void Mock_MethodAddsLocation_Test()
        {
            DbSetup();
            LocationsController controller = new LocationsController(mock.Object);
            Location testLocation = new Location();
            testLocation.Description = "test location";
            testLocation.LocationId = 1;
            testLocation.Name = "test name";

  
            ViewResult indexView = new LocationsController().Index() as ViewResult;

            var collection = indexView.ViewData.Model as IEnumerable<Location>;

            Assert.Contains<Location>(testLocation, collection);
        }
    }
}
