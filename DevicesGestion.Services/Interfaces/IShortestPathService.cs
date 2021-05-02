using DevicesGestion.Models;
using System.Collections.Generic;

namespace DevicesGestion.Services.Interfaces
{
    /// <summary>
    /// Interface qui va permettre de faire la liason entre le ConvertService et l'infrastruture (Dijkstra) 
    /// </summary>
    public interface IShortestPathService
    {
        /// <summary>
        /// Fonction qui permet de récupérer la liste des chemins le plus court pour le calcul
        /// </summary>
        /// <param name="convertRequest">requête</param>
        /// <param name="exchangeRates">liste des taux de changes</param>
        /// <returns></returns>
        IEnumerable<string> Get(Request conversionRequest, IEnumerable<ExchangeRate> exchangeRates);
    }
}
