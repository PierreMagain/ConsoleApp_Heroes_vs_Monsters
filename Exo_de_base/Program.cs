using Exo_de_base.Classes;
using System;

Console.WriteLine("Bienvenue dans le Heroes Versus Monster\n");
Console.WriteLine("Choisissez votre Héros : \n");
Console.WriteLine("Tapez 1 pour l'Humain, 2 pour le Nain : ");

bool numero_Hero = false;

while (!numero_Hero) {
    if (int.TryParse(Console.ReadLine(), out int value) && (value >= 1 && value <= 2)) //Sécurité
    {   
        Personnage Hero = new Personnage();
        if (value == 1)
        {
            Humain humain = new Humain();
            Hero = humain;

        }
        else
        {
            Nain nain = new Nain();
            Hero = nain;
        }
        Console.WriteLine($"Voici les caractéristiques de votre Hero {Hero.GetType().Name}\n ");
 
        Console.WriteLine($"Endurance :{Hero.Endurance}");
        Console.WriteLine($"PDV :{Hero.PDV}");
        Console.WriteLine($"Force :{Hero.Force}");
        Console.WriteLine($"Or : {Hero.Or}");
        Console.WriteLine($"Cuir : {Hero.Cuir}\n");
        Game jeu = new Game();
        int a = jeu.BeginGame(Hero);


        numero_Hero = true;
    }
    else 
    {
        Console.WriteLine("1 OU 2 SPECE DE BATARD !!!");
    }
}