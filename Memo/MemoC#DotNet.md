# MEMO

## Maîtriser le vocabulaire lié à l'environnement

## Expliquer la création d'un code exécutable à partir du code source

## Le language C

- Language orienté objet, mixte entre **C++** et **JAVA**.
- Langage pour **Microsoft**
- Framework **.NET**
- fichier sous extension **.cs**

### importation de librairie :

`using System;`

### les propriétés :

```c++
private string myName;
public string Name
   {
       get
       {
          return myName;
       }
       set
       {
          myName = value;
       }
   }
```

Permet d'utiliser comme accesseurs les variables de membre privé.

### LINQ (Language Integrated Query)

Ensemble de fonctionnalités introduites dans Visual Studio 2008 qui étend les fonctions de requête puissantes à la syntaxe des langages C#

```c++
   private string myName;
   public string Name(List<String> list)
      {
        return list.First();
      }
```

`.First()` permet de récupérer le premier élement.

### Convention de nommages

`private string myString;` ou `private string _strMyString;` pour les Attributs.

public MyString() pour les propriétés ou méthodes

## Schéma Compliation

<div style="text-align:center">
  <img src="./Compilation C#dotNet Complete.png">
  <p>
  <em>Compilation d'un projet C#</em>
</p>
</div>

## Framework .NET

Framework incluant une bibliothèque de méthode.
