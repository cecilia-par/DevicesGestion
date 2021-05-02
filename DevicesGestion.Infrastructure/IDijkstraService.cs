using DevicesGestion.Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace DevicesGestion.Infrastructure
{
    /// <summary>
    /// Interface du service Dijkstra
    /// </summary>
    public interface IDijkstraService<T>
             where T : IEquatable<T>
        {
        /// <summary>
        /// Fonction qui va renvoyé la liste des chemins pour aller de la source à la destination 
        /// ou vide si pas de chemin possible
        /// </summary>
        /// <param name="source">Sommet de la source</param>
        /// <param name="target">Sommet de destination</param>
        /// <param name="graph">graf</param>
        /// <returns></returns>
         IEnumerable<Vertex<T>> GetShortestPath(Vertex<T> source, Vertex<T> target, Graph<T> graph);
        }
}
