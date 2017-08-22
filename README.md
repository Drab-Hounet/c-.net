# Projet C# .Net Transports en commun

## Sujet
Ce projet a pour but de vous faire découvrir la programmation avec le langage orienté objet C#                                
et les outils proposés par le framework .Net. Le but de ce projet est de créer une application                                  
pour Windows permettant de collecter et d’afficher des données provenant d’un OpenData                      
public. Nous utiliserons les données de transports publics de l’agglomération Grenobloise pour                      
afficher et détailler les lignes de transports proches d’une localisation géographique. Ce projet                        
se découpera en trois itérations obligatoires et une quatrième optionnelle selon l’avancement.

## Spécifications
### Itération 1 :
La première itération est indépendante et fait office d’introduction au langage et aux outils de                            
développement. Elle vous permettra de mettre en œuvre les notions de projet/solution,                      
classes/méthodes ainsi que les opérateurs de base du langage. Cette première itération vous                        
permettra également de vous familiariser avec les classes et outils programmatiques fournis par                        
le framework .Net. Chaque classe du framework est documentée en ligne et la plupart du temps                              
expliquée à l’aide d’un exemple de code.
* Créez un projet « Helloworld » de type console application dans Visual Studio.
* Implémentez la boucle principale (la fonction Main) de votre programme afin qu’elle                      
affiche le message « Bonjour » dans la console. Compiler et démarrer votre application.
* Modifiez l’application pour qu’elle affiche un message contenant le nom de l’utilisateur                      
de l’ordinateur : « Bonjour <nom_de_l’utilisateur> ». 
* Note: Il existe un moyen simple et rapide de récupérer le nom de l’utilisateur grâce au                              
framework .Net …
*  On veut maintenant modifier le message affiché en fonction du jour et de l’heure :
    *   « Bonjour <nom_de_l’utilisateur> » pour la tranche horaire 8h <-> 13h, les lundi,
mardi, mercredi, jeudi et vendredi
    *  « Bon après-midi <nom_de_l’utilisateur> » pour la tranche 13h <-> 18h
    *  « Bonsoir <nom_de_l’utilisateur> » pour la tranche horaire 18h <-> 9h, les lundi,
mardi, mercredi, jeudi
    *  « Bon week-end <nom_de_l’utilisateur> » pour la tranche horaire vendredi 18h
<-> lundi 9h
* Note : Il conviendra d’utiliser le type DateTime​ du framework .Net pour manipuler les
jours et les heures, ainsi que pour récupérer l’heure à un instant T.
* Créez une nouvelle classe « Message » contenant une propriété « GetHelloMessage »                          
qui retourne le message approprié, et utilisez une instance de cette classe dans la                          
boucle principale pour récupérer le message à afficher.
* Faire évoluer la classe « Message » en lui ajoutant un constructeur qui prend en                            
paramètre les valeurs des tranches horaires (8,13,18 par défaut) à utiliser pour la                        
construction du message à afficher.
* En l’état, l’application affiche une fois le message et se termine. Modifiez la boucle                          
principale afin qu’elle affiche le message à chaque fois que l’utilisateur appuie sur la                          
touche Entrée, et que le programme se termine si l’utilisateur tape « exit » et appuie sur                                
la touche Entrée.

### Itération 2:
Cette seconde itération a pour but de mettre en place la base de votre application de collection                                
de données via l’OpenData. Pour ce faire, vous devrez utiliser l’API fournit par la Métro                            
https://metromobilite.fr/pages/opendata/OpenDataApi.html, trouvez les requêtes nécessaires        
dans la documentation, et utiliser les objets du Framework .Net pour effectuer des requêtes sur                            
ce service Web.
* Créez une nouvelle solution avec un nouveau projet de type application console.
* Utilisez les classes WebRequest et WebResponse du Framework pour envoyer une                    
requête au service Web permettant de connaître toutes les lignes de transports se                        
trouvant dans un rayon de XX autour de votre salle de cours. Affichez le résultat de la                                  
requête dans la console.
* Note : Afin d’éviter les erreurs de communication, veuillez rajouter cette ligne de code                          
en premier dans votre programme :
ServicePointManager.SecurityProtocol=SecurityProtocolType.Tls12|SecurityProtocolTyp
e.Tls11 | SecurityProtocolType.Tls;
* En l’état, le retour brut de la requête (au format JSON) n’est pas intelligible facilement                            
pour un utilisateur. Ajoutez à votre projet, via le gestionnaire de paquet Nuget, une                          
référence au projet Json.Net permettant de convertir le flux JSON en objets C#.
* Construire la structure de données nécessaires pour contenir le retour de la requête et                          
utilisez les classes fournies par Json.Net pour interpréter le JSON et remplir votre jeu de                            
données. Modifiez l’affichage pour afficher la liste des arrêts et les lignes de transports                          
associées.
* Construire la structure de données nécessaires pour contenir le retour de la requête et                          
utilisez les classes fournies par Json.Net pour interpréter le JSON et remplir votre jeu de                            
données. Modifiez l’affichage pour afficher la liste des arrêts et les lignes de transports                          
associées.
* Vous remarquez qu’il y a des doublons dans l’affichage au niveau des arrêts et des                            
lignes de transport listées. Modifiez votre code afin de n’affichez qu’une seule fois                        
chaque arrêt et ses lignes associées sans doublons, et trouvez une solution pour                        
collecter et afficher plus de détails sur les lignes de transport listées (nom explicite, type                            
de ligne, etc...)
* En prévision de la prochaine itération, nous souhaitons pouvoir réutiliser le code                        
permettant de récolter les données du service Web. Ajoutez un projet de type Class                          
Library à votre solution, et créez un classe qui exposera les méthodes permettant                        
d’effectuer les requêtes et de récolter les données. Modifiez votre projet console afin de                          
référencer et d’utiliser les méthodes contenues dans la dll précédemment créée pour                      
afficher vos données collectées.

### Itération 3:
L’itération 2 nous a permis de construire une dll réutilisable contenant des méthodes permettant                          
de faire des requêtes sur le service Web de la Métro et de récupérer les données attendues.                                
Nous allons maintenant nous focaliser sur l’affichage de ces données en passant d’une                        
application console à une application possédant une interface graphique codée en WPF. Cette                        
itération a pour but de vous faire découvrir le langage XAML pour définir vos composants                            
graphiques et le modèle de conception MVVM (Model-View-ViewModel).
* Créez une application WPF qui affiche la liste des arrêts et les lignes de transports se                              
trouvant à une distance donnée d’une localisation selon les contraintes suivantes :
    *  Implémentez votre programme en utilisant le modèle MVVM.
    *  Réutilisez la dll précédemment créée pour collecter les données du service Web.
    * L’utilisateur doit pouvoir entrez la position GPS et le rayon pour la recherche de                          
lignes de transport. 
    * La recherche doit s’effectuer lorsque l’utilisateur clique sur un bouton.
    * La manière dont s’affiche les données est laissée au libre choix des élèves,                        
soyez créatifs !

### Itération 4 (facultative):
Améliorez l’affichage des données en utilisant un contrôle permettant l’affichage d’une carte.                      
https://msdn.microsoft.com/fr-fr/library/hh830431.aspx
La localisation pourrait être choisie via la carte et les données affichées directement sur la carte                              
en surimpression.
Note: Créez une nouvelle application ou une nouvelle vue pour ne pas perdre le travail de                              
l’itération précédente. Attention, si vous êtes amenés à modifier votre dll qui collecte les                          
données sur le service Web, vous devez veillez à ne pas casser le fonctionnement des                            
itérations passées.

### Modalités
* Le travail se fera en îlot de 2 à 4 personnes.
* Le code source sera archivé sur github

### Livrable
* Le code source.
* Les différents mémos demandés (voir compétences ci-dessous).
* Démonstration de 10 minutes le Vendredi 01/09.

### Ressources
* C#: Le C# est un langage orienté objet (proche du Java et du C++), introduit par                              
Microsoft pour développer des applications sur la plateforme .Net.                
https://docs.microsoft.com/fr-fr/dotnet/csharp/csharp
https://docs.microsoft.com/fr-fr/dotnet/framework/
* WPF/XAML: Windows Presentation Foundation (WPF) est la spécification graphique de                  
Microsoft .Net. Il intègre le langage descriptif XAML qui permet de l'utiliser d'une manière                          
proche d'une page HTML pour les développeurs.
https://msdn.microsoft.com/fr-fr/library/aa970268(v=vs.110).aspx
* MVVM: Le Model-View-ViewModel​ ​​(MVVM) est un modèle d’archietctire logicielle introduit
par Microsoft pour faciliter le développement d’application avec WPF, et comme pour le
modèle MVC, de séparer la vue de la logique et de l'accès aux données.
https://blogs.msdn.microsoft.com/msgulfcommunity/2013/03/13/understanding-the-basic
s-of-mvvm-design-pattern/
https://www.tutorialspoint.com/mvvm/mvvm_first_application.htm
* JsonNet: Cette librairie open source vous sera utile pour convertir le flux json provenant                          
du service web en objet C#. La documentation est assez fournies, appuyez vous sur la                            
section “Samples” pour trouver l’exemple adéquat à votre cas d’utilisation.                  
http://www.newtonsoft.com/json/help/html/Samples.htm
* Json2csharp: Cet outil en ligne permet de trouver la structure de données à utiliser
pour convertir un flux json en objet C#. http://json2csharp.com/

Compétences
C# .Net:
* Démarrer avec Visual Studio : Création d’un projet console et de sa solution associée.
* Maîtriser le vocabulaire lié à l’environnement: Mémo rédigé définissant les principaux termes de                        
vocabulaire liés à C# .Net.
* Expliquer la création d’un code exécutable à partir du code source: Mémo rédigé expliquant le                            
déroulement des différentes opérations conduisant à la création du code exécutable.
* Créer un librairie (dll): La librairie existe et on peut en afficher les détails.
* Utiliser une librairie ajoutée manuellement: La solution utilisant la librairie fonctionne.
* Utiliser une librairie en utilisant le gestionnaire de package de visual studio: La solution utilisant                            
la librairie fonctionne.
* Appeler un service distant: L’application effectue des requête et récupère des données via un                          
service Web.
* Créer une interface graphique avec WPF: l’application se lance et l’utilisateur peut interagir avec                          
l’application.
* Mettre en oeuvre le modèle MVVM: L’élève est capable d’expliquer le fonctionnement de                        
l’architecture et les différences avec le modèle MVC.
https://docs.google.com/spreadsheets/d/197rXhhFlL6oEIijatyRpKJa8iCgIOfJc193mEFmyacI/edi
t 
