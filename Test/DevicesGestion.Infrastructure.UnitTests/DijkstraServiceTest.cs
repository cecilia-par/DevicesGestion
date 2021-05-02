using DevicesGestion.Infrastructure.Models;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace DevicesGestion.Infrastructure.UnitTests
{
    public class DijkstraServiceTest
    {
        private DijkstraService<string> _dijkstraService;

        [SetUp]
        public void Setup()
        {
            _dijkstraService = new DijkstraService<string>();
        }

        [Test]
        public void Should_find_path()
        {
            //arrange
            var source = new Vertex<string>("EUR");
            var target = new Vertex<string>("USD");
            var JPY = new Vertex<string>("JPY");

            List<Vertex<string>> vertices = new()
            {
                source,
                target,
                JPY
            };

            List<Edge<string>> edges = new()
            {
                new Edge<string>(source, JPY),
                new Edge<string>(JPY, target),
            };

            var graph = new Graph<string> { Vertices = vertices, Edges = edges };
          
            //action
            var result = _dijkstraService.GetShortestPath(source, target, graph);

            //assert
            var expectedPath = new List<Vertex<string>> { source, JPY, target };
            result.Should().BeEquivalentTo(expectedPath, options => options.Including(v => v.Id).WithStrictOrdering());
        }

        [Test]
        public void Should_not_find_path()
        {
            //arrange
            var source = new Vertex<string>("EUR");
            var target = new Vertex<string>("USD");
            var CHF = new Vertex<string>("CHF");
            var JPY = new Vertex<string>("JPY");

            List<Vertex<string>> vertices = new()
            {
                source,
                target,
                CHF,
                JPY
            };
            List<Edge<string>> edges = new()
            {
                new Edge<string>(source, CHF),
                new Edge<string>( target, JPY),
            };

            var graph = new Graph<string> { Vertices = vertices, Edges = edges };

            //action
            var result = _dijkstraService.GetShortestPath(source, target, graph);

            //assert
            result.Should().HaveCount(0);
        }

        [Test]
        public void Should_find_path_with_multiple_paths_with_same_distance()
        {
            //arrange
            var source = new Vertex<string>("EUR");
            var target = new Vertex<string>("USD");
            var AUD = new Vertex<string>("AUD");
            var KRW = new Vertex<string>("KRW");
            var CHF = new Vertex<string>("CHF");
            var INR = new Vertex<string>("INR");
            var CAD = new Vertex<string>("CAD");
            var CNY = new Vertex<string>("CNY");
            var MAD = new Vertex<string>("MAD");
            var BRL = new Vertex<string>("BRL");
            var XPF = new Vertex<string>("XPF");

            List<Vertex<string>> vertices = new()
            {
                source,
                target,
                AUD, KRW, CHF,
                INR, CAD, CNY,
                MAD, BRL, XPF
            };
            List<Edge<string>> edges = new()
            {
                new Edge<string>(source, AUD),
                new Edge<string>(AUD, KRW),
                new Edge<string> (KRW, CHF),
                new Edge<string>(CHF, target),

                new Edge<string>(source, INR),
                new Edge<string>(INR, CAD),
                new Edge<string>(CAD, CNY),
                new Edge<string>(CNY, target),

                new Edge<string>(source, MAD),
                new Edge<string>(MAD, BRL),
                new Edge<string>(BRL, XPF),
                new Edge<string>(XPF, target),
            };

            var graph = new Graph<string> { Vertices = vertices, Edges = edges };
            
            //action
            var result = _dijkstraService.GetShortestPath(source, target, graph);

            //assert
            //S'il y a plusieurs chemin de même distance alors l'algorithme prend le chemin avec l'ID de l'avant dernier
            // qui est le plus proche de la lettre A (classement par ordre alphabétique) 
            var expectedPath = new List<Vertex<string>> { source, AUD, KRW, CHF, target };
            result.Should().BeEquivalentTo(expectedPath, options => options.Including(v => v.Id).WithStrictOrdering());
        }
    }
}
