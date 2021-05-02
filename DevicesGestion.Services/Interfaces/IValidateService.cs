namespace DevicesGestion.Services
{
    /// <summary>
    /// Interface générique qui permet de valider un type de donnée
    /// </summary>
    /// <typeparam name="T">type de donnée</typeparam>
    public interface IValidateService<T>
    {
        /// <summary>
        ///  Renvoie un boolean qui permet de savoir si la donnée est valide (true = valide)
        /// </summary>
        /// <param name="data">donnée d'entrée à valider</param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        bool IsValid(T data, out string errorMessage);
    }
}
