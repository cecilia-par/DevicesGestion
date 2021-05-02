using DevicesGestion.Infrastructure.Models;
using DevicesGestion.Models;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DevicesGestion.Infrastructure.UnitTests
{
    public class DijkstraAdapterTest
    {
        private Mock<IDijkstraService<string>> Mock;

        [SetUp]
        public void Setup()
        {
            Mock = new Mock<IDijkstraService<string>>();
        }

        [Test]
        public void Should_find_path()
        {
            //arrange
            List<ExchangeRate> exchangeRates = new()
            {
                new ExchangeRate("AUD;CHF;0.9661"),
                new ExchangeRate("JPY;KRW;13.1151"),
                new ExchangeRate("EUR;CHF;1.2053"),
                new ExchangeRate("AUD;JPY;86.0305"),
                new ExchangeRate("EUR;USD;1.2989"),
                new ExchangeRate("JPY;INR;0.6571")
            };

            var request = new Request("EUR;550;JPY");

            Mock.Setup(m => m.GetShortestPath(It.IsAny<Vertex<string>>(), It.IsAny<Vertex<string>>(), It.IsAny<Graph<string>>()))
                .Returns(new List<Vertex<string>>{
                    new Vertex<string>("EUR"),
                    new Vertex<string>("CHF"),
                    new Vertex<string>("AUD"),
                    new Vertex<string>("JPY") }.AsEnumerable());

            var service = new DijkstraAdapter(Mock.Object);

            //action
            var result = service.Get(request, exchangeRates);

           //assert
            result.Should().BeEquivalentTo(new[] { "EUR", "CHF", "AUD", "JPY" }, options => options.WithStrictOrdering());
        }

        [Test]
        public void Should_not_find_path()
        {
            //arrange
            List<ExchangeRate> exchangeRates = new()
            {
                new ExchangeRate("AUD;CHF;0.9661"),
                new ExchangeRate("JPY;KRW;13.1151"),
                new ExchangeRate("EUR;CHF;1.2053"),
                new ExchangeRate("AUD;JPY;86.0305"),
                new ExchangeRate("EUR;USD;1.2989"),
                new ExchangeRate("JPY;INR;0.6571")
            };

            var request = new Request("EUR;550;JPY");

            Mock.Setup(m => m.GetShortestPath(It.IsAny<Vertex<string>>(), It.IsAny<Vertex<string>>(), It.IsAny<Graph<string>>()))    
                .Returns(new List<Vertex<string>>());
            var service = new DijkstraAdapter(Mock.Object);

            //action
            var result = service.Get(request, exchangeRates);

           //assert
            result.Should().HaveCount(0);
        }
    }
}