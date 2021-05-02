using System.Collections.Generic;

namespace DevicesGestion.Services.UnitTests.TestCaseFake
{
    /// <summary>
    /// Classe qui regroupe le jeux de test pour le service de validation des données
    /// </summary>
    public static class ValidateServiceFake
    {
        public static List<string> CorrectFile = new()
        {
            "EUR;550;JPY",
            "6",
            "AUD;CHF;0.9661",
            "JPY;KRW;13.1151",
            "EUR;CHF;1.2053",
            "AUD;JPY;86.0305",
            "EUR;USD;1.2989",
            "JPY;INR;0.6571"
        };

        public static List<string> WrongFileWithEmptyFile = new()
        {
            
        };

        public static List<string> WrongFileWithIncorrectConvertRequestLine = new()
        {
            "EU;550;JPY;",
            "6",
            "AUD;CHF;0.9661",
            "JPY;KRW;13.1151",
            "EUR;CHF;1.2053",
            "AUD;JPY;86.0305",
            "EUR;USD;1.2989",
            "JPY;INR;0.6571"
        };

        public static List<string> WrongFileWithIncorrectExchangeRateCountLine = new()
        {
            "EUR;550;JPY",
            "C",
            "AUD;CHF;0.9661",
            "JPY;KRW;13.1151",
            "EUR;CHF;1.2053",
            "AUD;JPY;86.0305",
            "EUR;USD;1.2989",
            "JPY;INR;0.6571"
        };

        public static List<string> WrongFileWithIncorrectExchangeRateLine = new List<string>
        {
            "EUR;550;JPY",
            "6",
            "AUD;CHF;",
            "JPY;KRW;13.1151",
            "EUR;CHF;1.2053",
            "AUD;JPY;86.0305",
            "EUR;USD;1.2989",
            "JPY;INR;0.6571"
        };

        public static List<string> WrongFileWithLessThan3Lines = new List<string>
        {
            "EUR;550;JPY",
            "6"
        };

        public static List<string> WrongFileWithDeclaredCountAndRealCountNotMatch = new List<string>
        {
            "EUR;550;JPY",
            "6",
            "AUD;CHF;0.9661",
            "JPY;KRW;13.1151",
            "EUR;CHF;1.2053",
            "AUD;JPY;86.0305",
            "EUR;USD;1.2989"
        };

        public static List<string> WrongFileWithExchangeRateContainingDuplicateCurrency = new()
        {
            "EUR;550;JPY",
            "6",
            "AUD;CHF;0.9661",
            "JPY;KRW;13.1151",
            "EUR;CHF;1.2053",
            "AUD;JPY;86.0305",
            "EUR;USD;1.2989",
            "CHF;CHF;0.6571"
        };

        public static List<string> WrongFileWithNoExchangeRateContainingSourceCurrency = new()
        {
            "EUR;550;JPY",
            "4",
            "AUD;CHF;0.9661",
            "JPY;KRW;13.1151",
            "AUD;JPY;86.0305",
            "JPY;INR;0.6571"
        };

        public static List<string> WrongFileWithNoExchangeRateContainingTargetCurrency = new List<string>
        {
            "EUR;550;JPY",
            "3",
            "AUD;CHF;0.9661",
            "EUR;CHF;1.2053",
            "EUR;USD;1.2989",
        };
    }
}
