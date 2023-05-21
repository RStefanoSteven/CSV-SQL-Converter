# CSV SQL Converter

CSV SQL Conerter est un outil permettant à un utilisateur de manipuler de la données
(CRUD), à l'aide de fichiers CSV.

## Pour commencer

Ce projet a été développé en C#.NET Core 3.1.

### Pré-requis

- IDE Microsoft Visual Studio prennant en charge .NET Core 3.1
- Une base de données Sql Server
- Serveur IIs
- etc...

### Installation

L'installation du programme se divise en trois parties.

#### BDD
- Creer une base de données de test sur SQL Server
- En se réferrant au fichier schema.png, créer les tables d'entités ainsi que leurs liaisons

#### APPLICATION
- Dans le fichier appsettings.json à la racine du projet, Section ConnectionStrings, renseigner le nom du serveur et la base de données.
Voici un exemple de la section :
"ConnectionStrings": {
    "DefaultConnection": "Server=NOM_DU_SERVEUR;Database=NOM_DE_LA_BDD;Trusted_Connection=True;"
}

#### Chemin de fichiers
- Dans le fichier appsettings.json à la racine du projet, sur la section CheminFichierCsv, rajouter les fichiers CSV à tester.
Voici un exemple de la section :

"CheminFichierCsv": {
    "Country": "C:\\Users\\stefa\\source\\repos\\CSV SQL Converter\\Ressources\\COUNTRY_20230321.csv",
    "Shop": "C:\\Users\\stefa\\source\\repos\\CSV SQL Converter\\Ressources\\SHOP_20230321.csv",
    "Site": "C:\\Users\\stefa\\source\\repos\\CSV SQL Converter\\Ressources\\SITE_20230321.csv",
    "Properties": "C:\\Users\\stefa\\source\\repos\\CSV SQL Converter\\Ressources\\ZONE_20230321.csv"
}

Une fois ces étapes réalisées, le projet est prêt à être lancé.
Il est à noter que le serveur IIs est paramétré sur une authentification Windows.

## Démarrage

En utilisant l'IDE Visual Studio, lancer le projet en mode debug pour le tester.

## Fabriqué avec

Entrez les programmes/logiciels/ressources que vous avez utilisé pour développer votre projet
* [CsvHelper] https://joshclose.github.io/CsvHelper/

## Difficultés

- Aucune difficultés majeure au point de m'empêcher de dévolopper les fonctionnalitées demandées n'a été relevé, y compris la partie BONUS dont j'ai une bonne idée.
- Mon seul soucis c'est que je suis en période d'éxamen du coup je n'ai pas pu vous le rendre à la date convenue, ni à m'y consacrer à 100% de mes capacités.
- Je suis vraiment désolé, mais bref voici ce que j'ai pu faire avec toutes mes années d'experimention en autonomie dans le dev :) .
- Je ne sais que théoriquement comment mettre en place des tests unitaires telles que sur le framework NUnit, mais tout s'apprend.

J'ai donc décidé par soucis de durée du test de ne pas mettre en place les tests unitaires.

- La fonction CsvImporter dans tout les Controlleurs permet l'importation du fichier CSV. Il fonctionne pour CountriesController, le reste est à tester.

Rassurez vous, j'ai passé environ 4 heures pour ce test, mais j'ai pris beaucoup de pauses entre temps, voir meme une journée.






