using DevicesGestion.Models;
using DevicesGestion.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevicesGestion.Services
{
    /// <summary>
    /// Classe qui permet de faire les convertions
    /// </summary>
    public class ConvertService : IConvertService
    {
        private IShortestPathService _shortestPathService;

        public ConvertService(IShortestPathService shortestPathService)
        {
            _shortestPathService = shortestPathService;
        }

        /// <summary>
        /// Liste des Taux de change
        /// </summary>
        private IEnumerable<ExchangeRate> ExchangeRates { get; set; }

        /// <summary>
        /// Fonction qui permet de récupérer le résultat de Dijkstra et calculer la valeur de sortie
        /// </summary>
        /// <param name="request">donnée d'entrée de la requête</param>
        /// <param name="exchangeRates">liste des taux de change</param>
        /// <returns></returns>
        public string Convert(Request request, IEnumerable<ExchangeRate> exchangeRates)
        {
            ExchangeRates = exchangeRates; 
            var convertResult = _shortestPathService.Get(request, exchangeRates);
            if (convertResult.Count() > 0)
            {
                var result = ApplyRates(request.Amount, convertResult.ToList());
                if (result == 0) return ErrorMessage.WRONG_RESULT_REQUEST;
                return Math.Round(result, MidpointRounding.AwayFromZero).ToString();
            }
            return ErrorMessage.WRONG_RESULT_REQUEST;
        }

        /// <summary>
        /// Fonction qui permet d'appliquer le taux de change
        /// </summary>
        /// <param name="amountToConvert">montant à convertir</param>
        /// <param name="convertPaths">chemin du calcul de la convertion</param>
        /// <returns></returns>
        private decimal ApplyRates(decimal amountToConvert, List<string> convertPaths)
        {
            var result = amountToConvert;
            for (var i = 0; i < convertPaths.Count - 1; i++)
            {
                var rate = GetRate(convertPaths[i], convertPaths[i + 1]);
                result = decimal.Round(result * rate, 4, MidpointRounding.AwayFromZero);
            }
            return result;
        }

        /// <summary>
        /// Fonction qui permet d'obtenir le taux de change
        /// </summary>
        /// <param name="sourceCurrency">device source</param>
        /// <param name="targetCurrency">device cible</param>
        /// <returns></returns>
        private decimal GetRate(string sourceCurrency, string targetCurrency)
        {
            try
            {
                decimal? sourceToTargetRate;
                decimal targetToSourceRate = 0.0000m;

                sourceToTargetRate = ExchangeRates.SingleOrDefault(er => er.SourceCurrency.Equals(sourceCurrency) && er.TargetCurrency.Equals(targetCurrency))?.Rate;
                if (!sourceToTargetRate.HasValue)
                {
                    targetToSourceRate = ExchangeRates.SingleOrDefault(er => er.SourceCurrency.Equals(targetCurrency) && er.TargetCurrency.Equals(sourceCurrency)).Rate;                
                    targetToSourceRate = decimal.Round((1 / targetToSourceRate), 4, MidpointRounding.AwayFromZero);
                }
                return sourceToTargetRate ?? targetToSourceRate;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getRate : {ex.Message}");
                return 0;
            }
            
        }
    }
}
