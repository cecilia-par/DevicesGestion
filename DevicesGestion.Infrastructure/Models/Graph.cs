using System;
using System.Collections.Generic;
using System.Linq;

namespace DevicesGestion.Infrastructure.Models
{
    /// <summary>
    /// Classe représentant le graph
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Graph<T>
        where T : IEquatable<T>
    {
        /// <summary>
        /// Liste de tous les sommets (device)
        /// </summary>
        public IEnumerable<Vertex<T>> Vertices { get; set; }

        /// <summary>
        /// Liste de toutes les laisons existantes
        /// </summary>
        public IEnumerable<Edge<T>> Edges { get; set; }

        /// <summary>
        /// Fonction qui permet d'affecter une distance
        /// </summary>
        /// <param name="vertex"></param>
        /// <param name="distance"></param>
        public void SetDistance(Vertex<T> vertex, double distance)
        {
            var result = Vertices.SingleOrDefault(v => v.Id.Equals(vertex.Id));
            if (result != null)
            {
                result.Distance = distance;
            }
        }
    }
}
