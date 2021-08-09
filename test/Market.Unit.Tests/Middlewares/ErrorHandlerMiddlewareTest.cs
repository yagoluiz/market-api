using System;
using System.Threading.Tasks;
using Market.API.Middleware;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;

namespace Market.Unit.Tests.Middlewares
{
    public class ErrorHandlerMiddlewareTest
    {
        private readonly Mock<IWebHostEnvironment> _webHostEnvironmentMock;

        public ErrorHandlerMiddlewareTest()
        {
            _webHostEnvironmentMock = new Mock<IWebHostEnvironment>();
        }

        [Fact(DisplayName = "Invoke error handler middleware when exist exception")]
        public async Task InvokeErrorHandlerMiddlewareWhenExistExceptionTest()
        {
            _webHostEnvironmentMock.Setup(setup => setup.EnvironmentName)
                .Returns("Development");

            var httpContext = new DefaultHttpContext().Request.HttpContext;
            var exceptionHandlerFeature = new ExceptionHandlerFeature
            {
                Error = new Exception()
            };

            httpContext.Features.Set<IExceptionHandlerFeature>(exceptionHandlerFeature);

            var middleware = new ErrorHandlerMiddleware(_webHostEnvironmentMock.Object);
            await middleware.Invoke(httpContext);

            Assert.NotNull(middleware);
        }

        [Fact(DisplayName = "Invoke error handler middleware when not exist exception")]
        public async Task InvokeErrorHandlerMiddlewareWhenNotExistExceptionTest()
        {
            _webHostEnvironmentMock.Setup(setup => setup.EnvironmentName)
                .Returns("Development");

            var httpContext = new DefaultHttpContext().Request.HttpContext;

            var middleware = new ErrorHandlerMiddleware(_webHostEnvironmentMock.Object);
            await middleware.Invoke(httpContext);

            Assert.NotNull(middleware);
        }
    }
}