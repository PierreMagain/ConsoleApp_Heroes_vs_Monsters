namespace Exo_de_base.Classes
{
    public class Game
    {
        Grid grille = new Grid();
        public int BeginGame(Personnage Hero) {
            Console.WriteLine("Appuyez sur Enter pour continuer...");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
            int dimension = 15 + 2;// 15 = dimension demandée, +2 pour les bordures
            Grid grille = new Grid();
            char[,] grid = new char[dimension,dimension];
            grid = grille.InitializeGrid(dimension,dimension);
            grille.Deplacement(dimension, dimension, grid, Hero);

            return 1;
        }
        

        
    }
}
