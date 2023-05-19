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

L'installation du programme se divise en deux parties.

#### BDD
- Creer une base de données de test sur SQL Server
- En se réferrant au fichier schema.png, créer les tables d'entités ainsi que leurs liaisons

#### APPLICATION
- Dans le fichier appsettings.json à la racine du projet, Section ConnectionStrings, renseigner le nom du serveur et la base de données.
Voici un exemple de la section :
"ConnectionStrings": {
    "DefaultConnection": "Server=NOM_DU_SERVEUR;Database=NOM_DE_LA_BDD;Trusted_Connection=True;"
}

Une fois ces étapes réalisées, le projet est prêt à être lancé.
Il est à noter que le serveur IIs est paramétré sur une authentification Windows.

## Démarrage

En utilisant l'IDE Visual Studio, lancer le projet en mode debug pour le tester.

## Fabriqué avec

Entrez les programmes/logiciels/ressources que vous avez utilisé pour développer votre projet
* [CsvHelper] https://joshclose.github.io/CsvHelper/


