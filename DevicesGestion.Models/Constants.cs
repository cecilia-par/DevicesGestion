namespace DevicesGestion.Models
{
    /// <summary>
    /// Classe qui regroupe les différents constantes utilisées par l'application
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Regex qui permet de tester le format de la ligne qui contient la requête
        /// </summary>
        public const string REQUEST_LINE_REGEX = @"^[a-zA-Z]{3};[0-9]+;[a-zA-Z]{3}$";

        /// <summary>
        /// Regex qui permet de tester le format de la ligne qui contient le nombre de ligne de taux
        /// </summary>
        public const string EXCHANGE_RATE_COUNT_LINE_REGEX = @"^[0-9]+$";

        /// <summary>
        /// Regex qui permet de tester le format des lignes de taux de change
        /// </summary>
        public const string EXCHANGE_RATE_LINE_REGEX = @"[a-zA-Z]{3};[a-zA-Z]{3};[0-9]+\.[0-9]{4}$";

        /// <summary>
        /// Séparteur des données dans le fichier
        /// </summary>
        public const char SEPARATOR = ';';

        /// <summary>
        /// Nombre de valeur à extraire par ligne 
        /// </summary>
        public const int SEPARATOR_NUMBER = 3;

        /// <summary>
        /// Nombre de ligne minimum que la liste de donnée doit avoir
        /// </summary>
        public const int MIN_LINES_INPUT_FILE = 3;
    }
}
