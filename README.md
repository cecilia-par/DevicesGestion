# DevicesGestion

Un petit programme permettant de convertir automatiquement des montants
dans une devise souhaitée. 

## Pour commencer

Télécharger le projet

### Installation

- Avoir .NET 5.0 installer 

- Ouvrir le projet dans Visual Studio

Pour le projet DevicesGestion: 
- Aller dans les nuget package manager: 
- Installer Autofac Version 6.2.0

Pour les projets DevicesGestion.Infrastructure.UnitTests et DevicesGestion.Services.UnitTests: 
- Aller dans les nuget package manager: 
- Installer FluentAssertions Version 5.9.0
- Installer Microsoft.NET.Test.Sdk Version 16.5.0
- Installer Moq Version 4.16.1
- Installer NUnit Version 3.12.0
- Installer NUnit3TestAdapter Version 3.16.1

## Démarrage

- Ouvrir une invite de commande
- Aller à la racine du projet /bin/Release/net5.0 (commande cd + Path)
- Entrer la commande ```LuccaDevises <chemin vers le fichier> ```

## Exemple de fichier 

  ```
  EUR;550;JPY
  6
  AUD;CHF;0.9661
  JPY;KRW;13.1151
  EUR;CHF;1.2053
  AUD;JPY;86.0305
  EUR;USD;1.2989
  JPY;INR;0.6571
  ```

## Fabriqué avec

- Architecture tiers

- Design Pattern Adapter

- [Autofac](https://autofac.org/) -  Inversion of Control container

Pour les tests unitaires :
- [NUnit](https://docs.microsoft.com/fr-fr/dotnet/core/testing/unit-testing-with-nunit) 
- [FluentAssertions](https://fluentassertions.com/) 

## Versions

**Dernière version :** 1.0.0.0

## Auteur

- **Cecilia Parlant** _alias_ [@cecilia-par](https://github.com/cecilia-par)

## License

Ce projet est sous licence `GNU Lesser General Public License (LGPL), version 3`
