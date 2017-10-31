using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloAPI.Controllers;
using System.Web.Http.Results;
using System.IO;
using HelloBusiness;

namespace HelloAPI.Tests.IntegrationTests.Api
{
    /// <summary>
    /// Integration tests the hello controller.
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
            HelloController helloController = new HelloController();

            //Act
            var result = helloController.Get();
            var contentResult = result as OkNegotiatedContentResult<string>;

            //Assert
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<string>));
            Assert.AreEqual("Hello World", contentResult.Content);
        }

        /// <summary>
        /// Tests the post with console external.
        /// </summary>
        [TestMethod]
        public void TestPostWithConsoleExternal()
        {
            //Arrange
            HelloController helloController = new HelloController(new ConsoleWriter());

            using(StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                //Act
                var result = helloController.Post();

                //Assert
                Assert.IsInstanceOfType(result, typeof(OkResult));
                Assert.AreEqual("Hello World\r\n", sw.ToString());
            }
        }
    }
}
