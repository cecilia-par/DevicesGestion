using DevicesGestion.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DevicesGestion.Services
{
    /// <summary>
    /// Classe qui permet de valider un type de donnée
    /// </summary>
    public class ValidateService : IValidateService<IEnumerable<string>>
    {
        /// <summary>
        /// Fonction qui permet de test que le fichier en entrée est correct
        /// </summary>
        /// <param name="lines">les lignes contenues dans le fichier</param>
        /// <param name="errorMessage">retour du message d'erreur</param>
        /// <returns></returns>
        public bool IsValid(IEnumerable<string> lines, out string errorMessage)
        {
            if (IsValidFormat(lines, out errorMessage))
            {
                return IsValidData(lines, out errorMessage);
            }
            return false;
        }

        /// <summary>
        /// Fonction qui permet de tester que le format du fichier est correct
        /// </summary>
        /// <param name="lines">les lignes contenues dans le fichier</param>
        /// <param name="errorMessage">retour du message d'erreur</param>
        /// <returns></returns>
        private bool IsValidFormat(IEnumerable<string> lines, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (lines.Count() >= Constants.MIN_LINES_INPUT_FILE)
            {
                bool isValidFormatRequest= IsValidRegex(lines.First(), Constants.REQUEST_LINE_REGEX);
                bool isValidFormatExchangeRateCount = IsValidRegex(lines.Skip(1).First(), Constants.EXCHANGE_RATE_COUNT_LINE_REGEX);
                bool isValidFormatExchangeRate = lines.Skip(2).All(l => IsValidRegex(l, Constants.EXCHANGE_RATE_LINE_REGEX));

                if (!isValidFormatRequest) errorMessage = ErrorMessage.WRONG_REQUEST + "\r\n" ;
                if (!isValidFormatExchangeRateCount) errorMessage += ErrorMessage.WRONG_EXCHANGE_RATE_COUNT + "\r\n";
                if (!isValidFormatExchangeRate) errorMessage += ErrorMessage.WRONG_EXCHANGE_RATE;

                return isValidFormatRequest
                    && isValidFormatExchangeRateCount
                    && isValidFormatExchangeRate;
            } 
            return false;
        }

        /// <summary>
        /// Methode qui permet de tester une expression régulière
        /// </summary>
        /// <param name="line">chaine de caractère à tester</param>
        /// <param name="regex">expression régulière à appliquer</param>
        /// <returns></returns>
        private bool IsValidRegex(string line, string regex)
        {
            return new Regex(regex).IsMatch(line);
        }

        /// <summary>
        /// Fonction qui permet de tester que toutes les données du fichier sont corrects.
        /// </summary>
        /// <param name="data">donnée à tester</param>
        /// <param name="errorMessage">retour du message d'erreur</param>
        /// <returns></returns>
        private bool IsValidData(IEnumerable<string> lines, out string errorMessage)
        {
            bool isValidData = true;
            errorMessage = string.Empty;
            Request request = new Request(lines.First());
            int.TryParse(lines.Skip(1).First(), out int exchangeRateCount);
            IEnumerable<ExchangeRate> exchangeRates = lines.Skip(2).Select(line => new ExchangeRate(line));

            //Verification si le nom de ligne de taux de change correspond au nombre donnée en ligne 2
            if (exchangeRateCount != exchangeRates.Count())
            {
                isValidData = false;
                errorMessage = ErrorMessage.WRONG_EXCHANGE_RATE_AND_COUNT;
            }

            /* Verification que la devise source ou la device cible de la requête
             * existe au moins une fois dans la liste de taux de change 
             * et que la device source n'est pas la même que la device cible */
            if (!exchangeRates.Any(er => er.SourceCurrency == request.SourceCurrency || er.TargetCurrency == request.SourceCurrency)
                || !exchangeRates.Any(er => er.SourceCurrency == request.TargetCurrency || er.TargetCurrency == request.TargetCurrency)
                || exchangeRates.Any(er => er.SourceCurrency == er.TargetCurrency))
            {
                isValidData = false;
                errorMessage = ErrorMessage.WRONG_SOURCE_OR_TARGET_CURRENCY;
            }

            return isValidData;
        }
    }
}
