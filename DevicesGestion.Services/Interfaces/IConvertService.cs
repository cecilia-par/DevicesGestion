using DevicesGestion.Models;
using System.Collections.Generic;

namespace DevicesGestion.Services
{
    /// <summary>
    /// Interface qui permet de faire les convertions des taux de change
    /// </summary>
    /// <typeparam name="T">type de donnée</typeparam>
    public interface IConvertService
    {
        /// <summary>
        /// Fonction de convertion
        /// </summary>
        /// <param name="request"></param>
        /// <param name="exchangeRates"></param>
        /// <returns></returns>
        string Convert(Request request, IEnumerable<ExchangeRate> exchangeRates);
    }
}
