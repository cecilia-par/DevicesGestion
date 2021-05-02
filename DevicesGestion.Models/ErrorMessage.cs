namespace DevicesGestion.Models
{
    /// <summary>
    /// Classe regroupant les différentes erreurs remonter à l'utilisateur
    /// </summary>
    public static class ErrorMessage
    {
        public const string INVALID_ARGUMENT = "Invalid argument. The program expect a valid file path or a not empty file.";
        public const string WRONG_FILE_CONTENT = "The file {0} is corrupted.";
        public const string WRONG_REQUEST = "The request line is incorrect.";
        public const string WRONG_EXCHANGE_RATE_COUNT = "The exchange rate count line is incorrect.";
        public const string WRONG_EXCHANGE_RATE = "The exchange rate lines are incorrect.";
        public const string WRONG_EXCHANGE_RATE_AND_COUNT = "The number of exchange rate lines does not correspond to the exchange rate count.";
        public const string WRONG_SOURCE_OR_TARGET_CURRENCY = "The source currency or the target currency of the request is the same or they are not exists in the exchanges rates.";
        public const string WRONG_RESULT_REQUEST = "Conversion impossible. No result between source currency and target currency";
    }
}
