using System;

namespace DevicesGestion.Infrastructure.Models
{
    /// <summary>
    /// Classe de liaison entre 2 sommets (devices)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Edge<T>
        where T : IEquatable<T>
    {
        /// <summary>
        /// Premier sommet
        /// </summary>
        public Vertex<T> FirstVertex { get; set; }

        /// <summary>
        /// Deuxième sommet
        /// </summary>
        public Vertex<T> SecondVertex { get; set; }

        /// <summary>
        /// Construteur
        /// </summary>
        /// <param name="firstVertex">premier sommet</param>
        /// <param name="secondVertex">deuxième sommet</param>
        public Edge(Vertex<T> firstVertex, Vertex<T> secondVertex)
        {
            this.FirstVertex = firstVertex;
            this.SecondVertex = secondVertex;
        }

    }
}
