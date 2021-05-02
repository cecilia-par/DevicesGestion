using System;
using System.Collections.Generic;
using System.Text;

namespace DevicesGestion.Infrastructure.Models
{
    /// <summary>
    /// Classe qui permet de comparer 2 sommets
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class VertexComparer<T> : IEqualityComparer<Vertex<T>>
        where T : IEquatable<T>
    {
        public bool Equals(Vertex<T> x, Vertex<T> y)
        {
            if (x == null && y == null)
                return false;
            else if (x == null || y == null)
                return false;
            else if (Equals(x.Id, y.Id))
                return true;
            else
                return false;
        }

        public int GetHashCode(Vertex<T> obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
