using System;
using System.Collections.Generic;

namespace DevicesGestion.Infrastructure.Models
{
    /// <summary>
    /// Classe représantant un sommet
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Vertex<T>
        where T : IEquatable<T>
    {
        /// <summary>
        /// Identifiant unique
        /// </summary>
        public T Id { get; set; }

        /// <summary>
        /// La distance du sommet source
        /// </summary>
        public double Distance { get; set; } 

        /// <summary>
        /// Boolean qui permet de savoir si le sommet a été traité dans l'algorithme
        /// </summary> 
        public bool IsTreated { get; set; } 

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="id"></param>
        public Vertex(T id)
        {
            Id = id;
            Distance = Double.PositiveInfinity;
        }
    }    
}
