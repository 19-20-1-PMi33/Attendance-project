using System;
using Microsoft.AspNetCore.Mvc;
using Attendance.Controllers;
using Xunit;

namespace AppTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }
        [Fact]
        public void IndexViewDataMessage()
        {
            // Arrange
            TestController controller = new TestController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.Equal("Hello world!", result?.ViewData["Message"]);
        }

        [Fact]
        public void IndexViewResultNotNull()
        {
            // Arrange
            TestController controller = new TestController();
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }
        [Fact]
        public void IndexViewNameEqualIndex()
        {
            // Arrange
            TestController controller = new TestController();
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.Equal("Index", result?.ViewName);
        }
    }
}
