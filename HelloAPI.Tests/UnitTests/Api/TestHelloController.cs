using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloAPI.Controllers;
using Moq;
using HelloContracts;
using System.Web.Http.Results;


namespace HelloAPI.Tests
{
    [TestClass]
    public class TestHelloController
    {
        [TestMethod]
        public void TestGet()
        {
            //Arrange
            var mockWriter = new Mock<IWriteToExternal>();
            mockWriter.Setup(x => x.Write(It.IsAny<string>())).Returns(true);

            HelloController helloController = new HelloController(mockWriter.Object);

            //Act
            var result = helloController.Get();
            var contentResult = result as OkNegotiatedContentResult<string>;

            //Assert
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<string>));
            Assert.AreEqual("Hello World", contentResult.Content);
        }

        [TestMethod]
        public void TestPost()
        {
            //Arrange
            var mockWriter = new Mock<IWriteToExternal>();
            mockWriter.Setup(x => x.Write(It.IsAny<string>())).Returns(true);

            HelloController helloController = new HelloController(mockWriter.Object);

            //Act
            var result = helloController.Post();

            //Assert
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }
    }
}
