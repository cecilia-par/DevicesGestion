using DevicesGestion.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevicesGestion.Infrastructure
{
    /// <summary>
    /// Service qui permet de calculer le chemin le plus court
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DijkstraService<T> : IDijkstraService<T>
        where T : IEquatable<T>
    {

        private List<Edge<T>> edgesTemps;

        /// <summary>
        /// Fonction qui va renvoyé la liste des chemins pour aller de la source à la destination 
        /// ou vide si pas de chemin possible
        /// </summary>
        /// <param name="source">Sommet de la source</param>
        /// <param name="target">Sommet de destination</param>
        /// <param name="graph">graf</param>
        /// <returns></returns>
        public IEnumerable<Vertex<T>> GetShortestPath(Vertex<T> source, Vertex<T> target, Graph<T> graph)
        {
            graph.SetDistance(source, 0);
            DijkstraAlgo(source, target, graph);
            var shortestPath = GetShortestPath(target);
            return shortestPath;
        }

        /// <summary>
        /// Fonction qui contient l'algorithme
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="graph"></param>
        private void DijkstraAlgo(Vertex<T> source, Vertex<T> target, Graph<T> graph)
        {
            edgesTemps = new List<Edge<T>>();
            var vComparer = new VertexComparer<T>();
            var isTargetFounded = false;
            var vertexToBeTreated = graph.Vertices.Where(v => v.Id.Equals(source.Id)).ToList();

            while (vertexToBeTreated.Any() && vertexToBeTreated.Any(v => v.Distance != double.PositiveInfinity) && !isTargetFounded)
            {
                //Recheche le nouveau sommet à traiter
                var currentVertex = vertexToBeTreated.OrderBy(v => v.Distance).ThenBy(v => v.Id).First(); // Find the new vertex to treat

                //Recherche les liaisons auquel est rattaché la source 
                var s1 = graph.Edges.Where(e => e.FirstVertex.Id.Equals(currentVertex.Id)).Select(e => e.SecondVertex);
                var s2 = graph.Edges.Where(e => e.SecondVertex.Id.Equals(currentVertex.Id)).Select(v => v.FirstVertex);

                var nodes = s1.Union(s2, vComparer).Where(v => !v.IsTreated).OrderByDescending(s => s.Distance).ToList();

                if (nodes.Any())
                {
                    foreach (var node in nodes)
                    {
                        var dis = currentVertex.Distance + 1;
                        //Test si la distance est plus courte
                        if (dis < node.Distance) 
                        {
                            //Affectation de la nouvelle distant au sommet
                            node.Distance = dis; 
                            edgesTemps.Add(new Edge<T>(node, currentVertex));
                        }
                    }
                }
                currentVertex.IsTreated = true;
                //Cherche si on a la device cible dans la liste des recherches précédentes
                isTargetFounded = edgesTemps.Exists(p => p.FirstVertex.Equals(target));
                vertexToBeTreated = graph.Vertices.Where(v => !v.IsTreated).ToList();
            }
        }

        /// <summary>
        /// Fonction qui permet de construire le resultat sous forme de liste
        /// </summary>
        /// <param name="target">Sommet de destination(cible)</param>
        /// <returns></returns>
        private List<Vertex<T>> GetShortestPath(Vertex<T> target)
        {
            List<Vertex<T>> shortestPath = new List<Vertex<T>> { target };
            var stop = false;
            Vertex<T> targetTemps = target;
            while (!stop)
            {
                var pred = edgesTemps.SingleOrDefault(p => p.FirstVertex.Id.Equals(targetTemps.Id));
                if (pred != null)
                {
                    shortestPath.Add(pred.SecondVertex);
                    targetTemps = pred.SecondVertex;
                }
                else
                {
                    stop = true;
                }
            }
            shortestPath.Reverse();
            if (shortestPath.Count == 1) shortestPath = new List<Vertex<T>>();
            return shortestPath;
        }
    }
}
