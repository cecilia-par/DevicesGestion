using System;
using System.Globalization;

namespace DevicesGestion.Models
{
    /// <summary>
    /// Classe qui contient un taux de change
    /// </summary>
    public class ExchangeRate
    {
        /// <summary>
        /// Devise source (device d'entrée)
        /// </summary>
        public string SourceCurrency { get; }

        /// <summary>
        /// Device cible (device de sortie)
        /// </summary>
        public string TargetCurrency { get; }

        /// <summary>
        /// Taux de change
        /// </summary>
        public decimal Rate { get; }

        /// <summary>
        /// Construteur
        /// </summary>
        /// <param name="line">ligne de donnée</param>
        public ExchangeRate(string line)
        {
             SourceCurrency = line.Substring(0, Constants.SEPARATOR_NUMBER);
            TargetCurrency = line.Substring(line.IndexOf(Constants.SEPARATOR) + 1, Constants.SEPARATOR_NUMBER);
            bool isValid = decimal.TryParse(line.Substring(line.LastIndexOf(Constants.SEPARATOR) + 1,
                                       line.Length - line.LastIndexOf(Constants.SEPARATOR) - 1), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal rate);
            Rate = isValid ? rate : 0;
        }
    }
}
