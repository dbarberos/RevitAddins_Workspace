using FluentAssertions;
using Xunit;

namespace RevitAddin.Tests.Helpers
{
    // Supongamos un OperationResult genérico que encapsula el resultado del negocio
    public class OperationResult<T>
    {
        public bool Success { get; }
        public T Value { get; }
        public string ErrorMessage { get; }

        private OperationResult(bool success, T value, string errorMessage)
        {
            Success = success;
            Value = value;
            ErrorMessage = errorMessage;
        }

        public static OperationResult<T> Ok(T value) => new(true, value, null);
        public static OperationResult<T> Fail(string msg) => new(false, default, msg);
    }

    public class OperationResultTests
    {
        [Fact]
        public void Ok_CreatesSuccessfulResult()
        {
            // Act
            var result = OperationResult<int>.Ok(42);

            // Assert
            result.Success.Should().BeTrue();
            result.Value.Should().Be(42);
        }

        [Fact]
        public void Fail_CreatesFailedResultWithMessage()
        {
            // Act
            var result = OperationResult<int>.Fail("Something went wrong");

            // Assert
            result.Success.Should().BeFalse();
            result.ErrorMessage.Should().Be("Something went wrong");
        }
    }
}
