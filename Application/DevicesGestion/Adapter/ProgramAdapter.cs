using DevicesGestion.Models;
using DevicesGestion.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DevicesGestion.Adapter
{
    /// <summary>
    /// Classe qui permet de faire la liaison entre le main et les différents services 
    /// </summary>
    public class ProgramAdapter
    {
        /// <summary>
        /// Service de validation des données d'entrée 
        /// </summary>
        private readonly IValidateService<IEnumerable<string>> _validateService;
        /// <summary>
        /// Service de convertion du taux de change
        /// </summary>
        private readonly IConvertService _convertService;

        /// <summary>
        /// Construteur
        /// </summary>
        /// <param name="validateService"></param>
        /// <param name="convertService"></param>
        public ProgramAdapter(IValidateService<IEnumerable<string>> validateService, IConvertService convertService)
        {
            _validateService = validateService;
            _convertService = convertService;
        }

        /// <summary>
        /// Fonction qui permet de tester la validité des données et faire la convertion
        /// </summary>
        /// <param name="filePath">chemin du fichier</param>
        internal void Run(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            if (_validateService.IsValid(lines, out string errorMessage))
            {
                var result = _convertService.Convert(ToConvertRequest(lines), ToExchangesRates(lines));
                Console.WriteLine(result);              
            }
            else
            {
                Console.WriteLine(errorMessage);
                Console.WriteLine(string.Format(ErrorMessage.WRONG_FILE_CONTENT, filePath));
            }
        }

        /// <summary>
        /// Fonction qui permet de convertir la première ligne en Request objet
        /// </summary>
        /// <param name="lines">ligne de donnée</param>
        /// <returns></returns>
        private static Request ToConvertRequest(string[] lines)
        {
            return new Request(lines.First());
        }

        /// <summary>
        /// Fonction qui permet de convertir de la 3ème à la dernière ligne en ExchangeRate objet 
        /// </summary>
        /// <param name="lines">ligne de données</param>
        /// <returns></returns>
        private static IEnumerable<ExchangeRate> ToExchangesRates(string[] lines)
        {
            return lines.Skip(2).Select(line => new ExchangeRate(line));
        }
    }
}
