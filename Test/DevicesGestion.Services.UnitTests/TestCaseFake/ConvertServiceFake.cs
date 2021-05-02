using DevicesGestion.Models;
using System.Collections.Generic;

namespace DevicesGestion.Services.UnitTests.TestCaseFake
{
    /// <summary>
    /// Classe qui regroupe le jeux de test pour le service de convertion
    /// </summary>
    public static class ConvertServiceFake
    {        
        public static List<ExchangeRate> CorrectExchangeRates = new()
        {
            new ExchangeRate("AUD;CHF;0.9661"),
            new ExchangeRate("JPY;KRW;13.1151"),
            new ExchangeRate("EUR;CHF;1.2053"),
            new ExchangeRate("AUD;JPY;86.0305"),
            new ExchangeRate("EUR;USD;1.2989"),
            new ExchangeRate("JPY;INR;0.6571")
        };

        public static List<ExchangeRate> WrongExchangeRates = new()
        {
            new ExchangeRate("AUD;CHF;0.9661"),
            new ExchangeRate("JPY;KRW;13.1151"),
            new ExchangeRate("EUR;CHF;1.2053"),
            new ExchangeRate("AUD;JPY;86.0305"),
            new ExchangeRate("EUR;USD;1.2989"),
            new ExchangeRate("JPY;TOT;0.6571")
        };
    }
}
