# MEMO

## Maîtriser le vocabulaire lié à l'environnement

## Expliquer la création d'un code exécutable à partir du code source

## Le language C

- Language orienté objet, mixte entre **C++** et **JAVA**.
- Langage pour **Microsoft**
- Framework **.NET**
- fichier sous extension **.cs**

**importation de librairie :**

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

_Permet d'utiliser comme accesseurs les variables de membre privé._

### LINQ (Language Integrated Query)

Ensemble de fonctionnalités introduites dans Visual Studio 2008 qui étend les fonctions de requête puissantes à la syntaxe des langages C#

```c++
   private string myName;
   public string Name(List<String> list)
      {
        return list.First();
      }
```

```c++
.First()
```

_Permet de récupérer le premier élement._

### Convention de nommages

`private string myString;` ou `private string _strMyString;` pour les Attributs.

public MyString() pour les propriétés ou méthodes

## Framework .NET

Framework incluant une bibliothèque de méthode.

### WPF (Windows Presentation Foundation)

Fournit un modèle de programmation pour créer des applications.

#### Pattern

Le pattern conseillé pour créer l'application est le **MVVM** (_Modèle - Vue - Vue Modèle_)

![MVVM](https://i-msdn.sec.s-msft.com/dynimg/IC564167.png)

Le transfert de la Vue avec le Vue - Modèle est appelé le _DataBinding_ est permet de transmettre les données dans les données dans les deux sens.

#### Le langage d'interface XAML

**XAML** est un langage d'interface utilisateur graphique universel pour les applications Web riches (RIA) et les logiciels de bureau. Il utilise un format **XML** facile à éditer et à réutiliser.

##### Exemple
```xml
<windows
    Width="600" Height="480" Text="Mon Programme">
  <FlowPanel>
    <Label Name="Montexte" FontSize="20">
        Mon application
    </label>
    <Button Width="80" Click="BoutonClic">
         Fermer
    </Button>
  </FlowPanel>
</windows> ```

#### Le test unitaire

Utilisation de la librairie nMock

[Liste des Fonctions de nMock](https://www.google.fr/url?sa=t&rct=j&q=&esrc=s&source=web&cd=1&cad=rja&uact=8&ved=0ahUKEwj61IrSyYPWAhUFWxQKHQohA80QFggtMAA&url=http%3A%2F%2Fcouvertstesting.blob.core.windows.net%2Fmenukaarten%2F2012%2F10%2F25%2F420679ec94ff810d88942155fa2f788e-NMock3CheatSheet.pdf&usg=AFQjCNGDIbvI9lQt1zMTEx35NuTCahZYFA)



![sMVVM](https://image.slidesharecdn.com/ravikumaronlinehotelbooking-140628072246-phpapp02/95/ravi-rana-hotel-management-ppt-7-638.jpg?cb=1403941005)
