using DevicesGestion.Models;
using DevicesGestion.Services.UnitTests.TestCaseFake;
using DevicesGestion.Services;
using DevicesGestion.Services.Interfaces;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DevicesGestion.Services.UnitTests
{
    public class ConvertServiceTest
    {
        private Mock<IShortestPathService> IShortestPathService; 

        [SetUp]
        public void Setup()
        {
            IShortestPathService = new Mock<IShortestPathService>();
        }

        [Test]
        public void Should_convert_550_EUR_return_59033_JPY()
        {
            //arrange
            List<ExchangeRate> exchangeRates = ConvertServiceFake.CorrectExchangeRates;
            var request = new Request("EUR;550;JPY");
                        
            IShortestPathService.Setup(m => m.Get(It.IsAny<Request>(), It.IsAny<IEnumerable<ExchangeRate>>()))
                .Returns(new List<string> { "EUR", "CHF", "AUD", "JPY" }.AsEnumerable());
            var service = new ConvertService(IShortestPathService.Object);

            //action
            var result = service.Convert(request, exchangeRates);

            //assert
            result.Should().Be("59033");
        }

        [Test]
        public void Should_convert_550_JPY_return_5_EUR()
        {
            //arrange
            List<ExchangeRate> exchangeRates = ConvertServiceFake.CorrectExchangeRates;
            var Request = new Request("JPY;550;EUR");


            IShortestPathService.Setup(m => m.Get(It.IsAny<Request>(), It.IsAny<IEnumerable<ExchangeRate>>()))
                .Returns(new List<string> { "JPY", "AUD", "CHF", "EUR"}.AsEnumerable());
            var service = new ConvertService(IShortestPathService.Object);

            //action
            var result = service.Convert(Request, exchangeRates);

            //assert
            result.Should().Be("5");
        }

        [Test]
        public void Should_convert_550_EUR_JPY_fail()
        {
            //arrange
            List<ExchangeRate> exchangeRates = ConvertServiceFake.WrongExchangeRates;
            var Request = new Request("EUR;550;JPY"); ;

            IShortestPathService.Setup(m => m.Get(It.IsAny<Request>(), It.IsAny<IEnumerable<ExchangeRate>>()))
                .Returns(new List<string>());
            var service = new ConvertService(IShortestPathService.Object);

            //action
            var result = service.Convert(Request, exchangeRates);

            //assert
            result.Should().Be(ErrorMessage.WRONG_RESULT_REQUEST);
        }
    }
}