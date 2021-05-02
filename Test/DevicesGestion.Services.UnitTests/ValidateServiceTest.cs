using DevicesGestion.Models;
using DevicesGestion.Services.UnitTests.TestCaseFake;
using DevicesGestion.Services;
using FluentAssertions;
using NUnit.Framework;

namespace DevicesGestion.Services.UnitTests
{
    public class ValidateServiceTest
    {
        private ValidateService ValidateService;

        [SetUp]
        public void Setup()
        {
            ValidateService = new ValidateService();
        }

        [Test]
        public void Should_validation_return_true_if_good_file()
        {
            //arrange + action
            var result = ValidateService.IsValid(ValidateServiceFake.CorrectFile, out string errorMessage);
            //assert
            result.Should().BeTrue();
            Assert.IsEmpty(errorMessage);
        }

        [Test]
        public void Should_validation_return_false_if_Wrong_File_With_Empty_File()
        {
            //arrange + action
            var result = ValidateService.IsValid(ValidateServiceFake.WrongFileWithEmptyFile, out string errorMessage);
            //assert
            result.Should().BeFalse();
            Assert.IsEmpty(errorMessage);
        }

        [Test]
        public void Should_validation_return_false_if_Wrong_File_With_Incorrect_Convert_Request_Line()
        {
            //arrange + action
            var result = ValidateService.IsValid(ValidateServiceFake.WrongFileWithIncorrectConvertRequestLine, out string errorMessage);
            //assert
            result.Should().BeFalse();
            Assert.AreEqual($"{ErrorMessage.WRONG_REQUEST}\r\n", errorMessage);
        }

        [Test]
        public void Should_validation_return_false_if_Wrong_File_With_Incorrect_ExchangeRateCount_Line()
        {
            //arrange + action
            var result = ValidateService.IsValid(ValidateServiceFake.WrongFileWithIncorrectExchangeRateCountLine, out string errorMessage);
            //assert
            result.Should().BeFalse();
            Assert.AreEqual($"{ErrorMessage.WRONG_EXCHANGE_RATE_COUNT}\r\n", errorMessage);
        }

        [Test]
        public void Should_validation_return_false_if_Wrong_File_With_Incorrect_ExchangeRate_Line()
        {
            //arrange + action
            var result = ValidateService.IsValid(ValidateServiceFake.WrongFileWithIncorrectExchangeRateLine, out string errorMessage);
            //assert
            result.Should().BeFalse();
            Assert.AreEqual($"{ErrorMessage.WRONG_EXCHANGE_RATE}", errorMessage);
        }

        [Test]
        public void Should_validation_return_false_if_Wrong_File_With_Less_Than_3_Lines()
        {
            //arrange + action
            var result = ValidateService.IsValid(ValidateServiceFake.WrongFileWithLessThan3Lines, out string errorMessage);
            //assert
            result.Should().BeFalse();
            Assert.IsEmpty(errorMessage);
        }

        [Test]
        public void Should_validation_return_false_if_Wrong_File_With_Declared_Count_And_Real_Count_Not_Match()
        {
            //arrange + action
            var result = ValidateService.IsValid(ValidateServiceFake.WrongFileWithDeclaredCountAndRealCountNotMatch, out string errorMessage);
            //assert
            result.Should().BeFalse();
            Assert.AreEqual($"{ErrorMessage.WRONG_EXCHANGE_RATE_AND_COUNT}", errorMessage);
        }

        [Test]
        public void Should_validation_return_false_if_Wrong_File_With_ExchangeRate_Containing_Duplicate_Currency()
        {
            //arrange + action
            var result = ValidateService.IsValid(ValidateServiceFake.WrongFileWithExchangeRateContainingDuplicateCurrency, out string errorMessage);
            //assert
            result.Should().BeFalse();
            Assert.AreEqual($"{ErrorMessage.WRONG_SOURCE_OR_TARGET_CURRENCY}", errorMessage);
        }

        [Test]
        public void Should_validation_return_false_if_Wrong_File_With_No_ExchangeRate_Containing_SourceCurrency()
        {
            //arrange + action
            var result = ValidateService.IsValid(ValidateServiceFake.WrongFileWithNoExchangeRateContainingSourceCurrency, out string errorMessage);
            //assert
            result.Should().BeFalse();
            Assert.AreEqual($"{ErrorMessage.WRONG_SOURCE_OR_TARGET_CURRENCY}", errorMessage);
        }

        [Test]
        public void Should_validation_return_false_if_Wrong_File_with_no_exchange_rate_containing_target_currency()
        {
            //arrange + action
            var result = ValidateService.IsValid(ValidateServiceFake.WrongFileWithNoExchangeRateContainingTargetCurrency, out string errorMessage);
            //assert
            result.Should().BeFalse();
            Assert.AreEqual($"{ErrorMessage.WRONG_SOURCE_OR_TARGET_CURRENCY}", errorMessage);
        }
    }
}
