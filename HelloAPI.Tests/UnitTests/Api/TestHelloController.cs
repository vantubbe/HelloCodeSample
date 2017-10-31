using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloAPI.Controllers;
using Moq;
using HelloContracts;
using System.Web.Http.Results;


namespace HelloAPI.Tests
{
    /// <summary>
    /// Unit tests the hello controller.
    /// </summary>
    [TestClass]
    public class TestHelloController
    {
        /// <summary>
        /// Tests the get.
        /// </summary>
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

        /// <summary>
        /// Tests the post.
        /// </summary>
        [TestMethod]
        public void TestPost()
        {
            //Arrange
            var mockWriter = new Mock<IWriteToExternal>();
            mockWriter.Setup(x => x.Write(It.IsAny<string>())).Returns(true);
            var mockHello = new Mock<IHello>();
            mockHello.Setup(x => x.HelloWorld()).Returns("Hello World\r\n");

            HelloController helloController = new HelloController(mockHello.Object,mockWriter.Object);

            //Act
            var result = helloController.Post();

            //Assert
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }
    }
}
