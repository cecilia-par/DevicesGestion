using DevicesGestion.Infrastructure.Models;
using DevicesGestion.Models;
using DevicesGestion.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DevicesGestion.Infrastructure
{
    /// <summary>
    /// Classe d'entrée pour jouer l'algorithme Dijkstra
    /// </summary>
    public class DijkstraAdapter : IShortestPathService
    {
        private readonly IDijkstraService<string> _dijkstraService;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="dijkstraService"></param>
        public DijkstraAdapter(IDijkstraService<string> dijkstraService)
        {
            _dijkstraService = dijkstraService;
        }

        /// <summary>
        /// Fonction qui permet de récupérer la liste des chemins le plus court pour le calcul
        /// </summary>
        /// <param name="convertRequest">requête</param>
        /// <param name="exchangeRates">liste des taux de changes</param>
        /// <returns></returns>
        public IEnumerable<string> Get(Request convertRequest, IEnumerable<ExchangeRate> exchangeRates)
        {
            var graph = GetGraph(exchangeRates);
            Vertex<string> vSource = new Vertex<string>(convertRequest.SourceCurrency);
            Vertex<string> vTarget = new Vertex<string>(convertRequest.TargetCurrency);
            var result = _dijkstraService.GetShortestPath(vSource, vTarget, graph);
            return result.Select(e => e.Id);
        }

        /// <summary>
        /// Fonction qui permet de construire le graph
        /// </summary>
        /// <param name="exchangesRates">liste des taux de changes</param>
        /// <returns></returns>
        private Graph<string> GetGraph(IEnumerable<ExchangeRate> exchangesRates)
        {
            Graph<string> graph = new Graph<string>();
            //Récupération des devices source
            var sources = exchangesRates.Select(er => er.SourceCurrency);
            // Récupération des devices cible 
            var targets = exchangesRates.Select(er => er.TargetCurrency);
            // Tri pour récupérer une fois chaque devices
            var devices = sources.Union(targets).Distinct();

            //Contient la listes des différentes devices
            graph.Vertices = devices.Select(c => new Vertex<string>(c)).ToList();

            //Liste des taux de changes sous forme de Vertex
            graph.Edges = exchangesRates.Select(er => new Edge<string>(
                graph.Vertices.Single(v => v.Id == er.SourceCurrency),
                graph.Vertices.Single(v => v.Id == er.TargetCurrency))).ToList();
            return graph;
        }
    }
}
