using NUnit.Framework;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Internal;
using System.Collections.Generic;

namespace AzureDemos.Function.Test
{
    public class GreeterFunctionTests
    {
        private ILogger logger;

        private HttpRequest request;

        [SetUp]
        public void Setup()
        {
            this.logger = Mock.Of<ILogger>();
            this.request = Mock.Of<HttpRequest>();
        }

        [Test]
        public async Task Test_JsonRequestBody_ReturnsOkObjectResult()
        {
            // Arrange
            using var stream =
                new MemoryStream(
                    System.Text.Encoding.UTF8.GetBytes("{\"name\":\"jan\"}")
                );

            Mock.Get(request)
                .SetupGet(r => r.Body)
                .Returns(stream);

            // Act
            var response = await GreeterFunction
                .ExecuteAsync(request, logger)
                .ConfigureAwait(false);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(response);
        }
    }
}