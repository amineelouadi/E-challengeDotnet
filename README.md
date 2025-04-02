# Système de Gestion Scolaire

## Description
Ce projet est un Système de Gestion Scolaire construit en C# et avec Entity Framework Core. Il permet la gestion des étudiants, des enseignants, des matières et des classes au sein d'une base de données scolaire.

## Fonctionnalités
- Créer et gérer des matières
- Ajouter et gérer des enseignants et des étudiants
- Inscrire des étudiants dans des classes
- Afficher des statistiques sur la base de données (nombre d'enseignants, d'étudiants, de classes et d'inscriptions)
- Fonctionnalités de requête pour récupérer des informations spécifiques sur les étudiants et les enseignants

## Technologies Utilisées
- C#
- .NET Core
- Entity Framework Core
- SQL Server

## Structure du Projet
SqliTp/
├── Models/
│ ├── Class.cs
│ ├── Enrollment.cs
│ ├── Person.cs
│ ├── Student.cs
│ ├── Subject.cs
│ └── Teacher.cs
├── Program.cs
├── MyContext.cs
└── appsettings.json

## Instructions d'Installation

1. **Cloner le dépôt :**
   ```bash
   git clone https://github.com/amineelouadi/E-challengeDotnet.git
   cd SqliTp
   ```

2. **Installer les dépendances :**
   Assurez-vous d'avoir le SDK .NET installé. Vous pouvez installer les packages requis en utilisant :
   ```bash
   dotnet restore
   ```

3. **Configurer la connexion à la base de données :**
   Mettez à jour le fichier `appsettings.json` avec votre chaîne de connexion SQL Server.

4. **Créer la base de données :**
   Exécutez l'application pour créer la base de données et la peupler avec des données initiales :
   ```bash
   dotnet run
   ```

5. **Exécuter l'application :**
   Après la création de la base de données, vous pouvez exécuter à nouveau l'application pour voir la sortie et interagir avec la base de données.

## Utilisation
- L'application créera une base de données scolaire et la peuplera avec des données d'exemple.
- Elle affichera le nombre d'enseignants, d'étudiants, de classes et d'inscriptions.
- Vous pouvez modifier le code dans `Program.cs` pour ajouter plus de fonctionnalités ou de requêtes selon vos besoins.