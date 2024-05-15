namespace Exo_de_base.Classes
{
    public class Grid
    {
        public void Deplacement(int rows, int cols, char[,] grid, Personnage Hero)
        {
            
            
            int currentRow = rows - 2;
            int currentCol = 1;
            int pastRow = currentRow, pastCol = currentCol;
            char playerChar = Hero.Lettre;

            ConsoleKeyInfo keyInfo;
            grid[currentRow, currentCol] = playerChar;
            int nbr_monstres_restants;
            do
            {
                Console.Clear();
                PrintGrid(grid,Hero);
                keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (currentCol > 1)
                        {
                            pastRow = currentRow;
                            pastCol = currentCol;
                            currentCol--;
                            CombatGrid(grid, currentRow, currentCol, Hero);
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (currentCol < cols - 2)
                        {
                            pastRow = currentRow;
                            pastCol = currentCol;
                            currentCol++;
                            CombatGrid(grid, currentRow, currentCol, Hero);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (currentRow > 1)
                        {
                            pastRow = currentRow;
                            pastCol = currentCol;
                            currentRow--;
                            CombatGrid(grid, currentRow, currentCol, Hero);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (currentRow < rows - 2)
                        {
                            pastRow = currentRow;
                            pastCol = currentCol;
                            currentRow++;
                            CombatGrid(grid, currentRow,currentCol, Hero);
                        }
                        break;
                    default:
                        break;
                }

                grid[currentRow, currentCol] = playerChar;
                grid[pastRow, pastCol] = ' ';

                InfoMonstre(grid, currentRow, currentCol, Hero);
                nbr_monstres_restants = NombreMonstresRestants(grid);

                if (Hero.PDV <= 0)
                {
                    Console.WriteLine("\nPerdu\n");
                    break;
                }
                if (nbr_monstres_restants == 0)
                {
                    Console.WriteLine("\nGagné !\n");

                    Console.WriteLine($"{Hero.GetType().Name}\n");
                    Console.WriteLine($"Endurance :{Hero.Endurance}");
                    Console.WriteLine($"PDV :{Hero.PDV}");
                    Console.WriteLine($"Force :{Hero.Force}");
                    Console.WriteLine($"Or : {Hero.Or}");
                    Console.WriteLine($"Cuir : {Hero.Cuir}\n");

                    break;
                }

            } while (Hero.PDV >= 0 && nbr_monstres_restants > 0 && (keyInfo.Key != ConsoleKey.Escape));

        }

        private Random random = new Random();

        internal char[,] InitializeGrid(int rows, int cols)
        {
            char[,] grid = new char[rows, cols];

            // Initialise la grille avec des espaces et des bordures
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j] = ' ';
                }
            }

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                grid[i, 0] = '=';
                grid[i, grid.GetLength(1) - 1] = '=';
            }

            for (int j = 0; j < grid.GetLength(1); j++)
            {
                grid[0, j] = '=';
                grid[grid.GetLength(0) - 1, j] = '=';
            }

            // Place 10 monstres dans la grille
            PlaceMonstres(grid);

            return grid;
        }

        private void PlaceMonstres(char[,] grid)
        {
            int nbr_monster = 10; // definit arbitrairement le nombre de monstres
            for (int i = 0; i < nbr_monster; i++)
            {
                int row = random.Next(2, grid.GetLength(0) - 2); // Génère une ligne aléatoire (en évitant les bordures)
                int col = random.Next(2, grid.GetLength(1) - 2); // Génère une colonne aléatoire (en évitant les bordures)

                // Vérifie si une case est déjà occupée par un monstre ou se trouve dans un carré de 3x3 autour d'un monstre
                bool caseOccupee = false;
                for (int x = row - 2; x <= row + 2; x++)
                {
                    for (int y = col - 2; y <= col + 2; y++)
                    {
                        if (grid[x, y] != ' ' && grid[x,y] != '=')
                        {
                            caseOccupee = true;
                            break;
                        }
                    }
                }

                if (!caseOccupee)
                {
                    grid[row, col] = GetRandomMonstre();
                }
                else
                {
                    i--; // place un monstre sur une case non occupée
                }
            }
        }

        private char GetRandomMonstre()
        {
            char[] monstres = { 'L', 'O', 'D' }; // Les monstres possibles (Loup, Orque, Dragonnet)
            return monstres[random.Next(monstres.Length)]; // Choisit aléatoirement un monstre parmi ceux disponibles
        }
        public int NombreMonstresRestants(char[,] grid)
        {
            int count = 0;

            for (int i = 1; i < grid.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < grid.GetLength(1) - 1; j++)
                {
                    if (grid[i, j] != ' ' && grid[i, j] != '=' && grid[i, j] != 'H' && grid[i, j] != 'N')
                    {
                        count++;
                    }
                }
            }

            return count;
        }
        static void PrintGrid(char[,] grid, Personnage Hero) // affiche le tableau ( met des espaces volontairements entre les lignes et les colonnes pour plus de clarté)
        {
            int i, j;
            for ( i = 0; i < grid.GetLength(0); i++)
            {
                for ( j = 0; j < grid.GetLength(1); j++)
                {
                    Console.Write(grid[i, j] + " ");
                }
                Console.WriteLine();
            }
            i = (grid.GetLength(0))*2 +5 ;
            j = grid.GetLength(1);

            Console.SetCursorPosition(i, 0);
            Console.WriteLine("Caractéristique de votre héro :\n");
            Console.SetCursorPosition(i, 1);
            Console.WriteLine($"Endurance :{Hero.Endurance}");
            Console.SetCursorPosition(i, 2);
            Console.WriteLine($"PDV :{Hero.PDV}");
            Console.SetCursorPosition(i, 3);
            Console.WriteLine($"Force :{Hero.Force}");
            Console.SetCursorPosition(i, 4);
            Console.WriteLine($"Or : {Hero.Or}");
            Console.SetCursorPosition(i, 5);
            Console.WriteLine($"Cuir : {Hero.Cuir}\n");
            Console.SetCursorPosition(0, j);
        }
        static void CombatGrid(char[,] grid, int currentRow, int currentCol, Personnage Hero)
        {
            Combat combat = new Combat();
            Personnage monstre = null;

            // Vérifiez si un monstre est présent à côté du héros (au-dessus, en dessous, à droite ou à gauche)
            if (grid[currentRow, currentCol] != ' ' && grid[currentRow, currentCol] != Hero.Lettre && grid[currentRow, currentCol] != '=')
            {
                monstre = GetCharacterFromLetter(grid[currentRow, currentCol]);
            }
            if (monstre != null)
            {
                Console.Clear();
                PrintGrid(grid,Hero); // Réaffichez la grille avant le combat
                combat.Duel(Hero, monstre);
                Console.WriteLine("\nAppuyez sur Enter pour continuer...\n");
                while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
            }
        }

        static void InfoMonstre(char[,] grid, int currentRow, int currentCol, Personnage Hero)
        {
            Combat combat = new Combat();
            Personnage monstre = null;

            // Vérifiez si un monstre est présent à côté du héros (au-dessus, en dessous, à droite ou à gauche)
            if (grid[currentRow + 1, currentCol] != ' ' && grid[currentRow + 1, currentCol] != Hero.Lettre && grid[currentRow + 1, currentCol] != '=')
            {
                monstre = GetCharacterFromLetter(grid[currentRow + 1, currentCol]);
            }
            else if (grid[currentRow - 1, currentCol] != ' ' && grid[currentRow - 1, currentCol] != Hero.Lettre && grid[currentRow - 1, currentCol] != '=')
            {
                monstre = GetCharacterFromLetter(grid[currentRow - 1, currentCol]);
            }
            else if (grid[currentRow, currentCol + 1] != ' ' && grid[currentRow, currentCol + 1] != Hero.Lettre && grid[currentRow, currentCol + 1] != '=')
            {
                monstre = GetCharacterFromLetter(grid[currentRow, currentCol + 1]);
            }
            else if (grid[currentRow, currentCol - 1] != ' ' && grid[currentRow, currentCol - 1] != Hero.Lettre && grid[currentRow, currentCol - 1] != '=')
            {
                monstre = GetCharacterFromLetter(grid[currentRow, currentCol - 1]);
            }

            if (monstre != null)
            {
                Console.Clear();
                PrintGrid(grid,Hero); // Réaffichez la grille avant le combat
                Console.WriteLine("Information sur le monstre à votre proxymité : ");
                Console.WriteLine($"Type :{monstre.GetType().Name}\n");
                Console.WriteLine($"Endurance :{monstre.Endurance}");
                Console.WriteLine($"PDV :{monstre.PDV}");
                Console.WriteLine($"Force :{monstre.Force}");
                Console.WriteLine($"Or : {monstre.Or}");
                Console.WriteLine($"Cuir : {monstre.Cuir}\n");
                Console.WriteLine("Appuyez sur n'importe quelle touche pour continuer...");
                while (!Console.KeyAvailable) ;
                Console.ReadKey(true);
            }
        }

        static Personnage GetCharacterFromLetter(char letter)
        {
            switch (letter)
            {
                case 'L':
                    return new Loup();
                case 'O':
                    return new Orque();
                case 'D':
                    return new Dragonnet();
                default:
                    return null; // Retourne null si la lettre ne correspond à aucun monstre connu
            }
        }

    }

}

