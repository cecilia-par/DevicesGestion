using Autofac;
using DevicesGestion.Adapter;
using DevicesGestion.Models;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace DevicesGestion
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        /// <summary>
        /// Entrée du programme
        /// </summary>
        /// <param name="args">liste des arguments</param>
        static void Main(string[] args)
        {
#if DEBUG
            string filePath = @"C:\Users\Cecilia\Documents\GitHub\TestCase\TestCase.txt";
            args = new [] { filePath };
#endif
            if (IsValidArgument(args))
            {
                ServiceRegister.Register();
                ServiceRegister.Container.Resolve<ProgramAdapter>().Run(args[0]);               
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Fonction qui permet de vérifier s'il y a un fichier qui existe et s'il n'est pas vide.
        /// </summary>
        /// <param name="args">liste des aguments</param>
        /// <returns></returns>
        private static bool IsValidArgument(string[] args)
        {
            if (args.Length > 0)
            {
                var fileName = args[0];
                if (File.Exists(fileName) && new FileInfo(fileName).Length > 0)
                {
                    return true;
                }
            }
            Console.WriteLine(ErrorMessage.INVALID_ARGUMENT);
            return false;
        }
    }
}
