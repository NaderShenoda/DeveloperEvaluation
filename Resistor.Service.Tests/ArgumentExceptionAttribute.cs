using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Resistor.Service.Tests
{
    public sealed class ArgumentExceptionAttribute : ExpectedExceptionBaseAttribute
    {
        private readonly Type ExpectedExceptionType;
        private readonly string ExpectedExceptionParameter;

        public ArgumentExceptionAttribute(Type expectedExceptionType, string expectedExceptionParameter)
        {
            ExpectedExceptionType = expectedExceptionType;
            ExpectedExceptionParameter = expectedExceptionParameter;
        }

        protected override void Verify(Exception exception)
        {
            Assert.IsNotNull(exception);

            Assert.IsInstanceOfType(exception, ExpectedExceptionType, "Wrong type of exception was thrown.");

            var argumentException = exception as ArgumentException;

            Assert.IsNotNull(argumentException, "Exception is not of type ArgumentException.");

            Assert.AreEqual(ExpectedExceptionParameter, argumentException.ParamName, "Wrong exception parameter name was returned.");
        }
    }
}
