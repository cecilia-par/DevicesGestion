namespace DevicesGestion.Models
{
    /// <summary>
    /// Classe qui contient la requête d'entrée
    /// </summary>
    public class Request
    {
        /// <summary>
        /// Devise source (device d'entrée)
        /// </summary>
        public string SourceCurrency { get; }

        /// <summary>
        /// Montant à convertir dans la device de sortie
        /// </summary>
        public int Amount { get; }

        /// <summary>
        /// Device cible (device de sortie souhaitée)
        /// </summary>
        public string TargetCurrency { get; }

        /// <summary>
        /// Construteur
        /// </summary>
        /// <param name="line">ligne de donnée</param>
        public Request(string line)
        {
            SourceCurrency = line.Substring(0, Constants.SEPARATOR_NUMBER);
            TargetCurrency = line.Substring(line.LastIndexOf(Constants.SEPARATOR) + 1, Constants.SEPARATOR_NUMBER);
            bool isValid = int.TryParse(line.Substring(line.IndexOf(Constants.SEPARATOR) + 1,
                                   line.LastIndexOf(Constants.SEPARATOR) - line.IndexOf(Constants.SEPARATOR) - 1), out int amount);
            Amount = isValid ? amount : 0;
        }
    }
}
