namespace Exo_de_base.Classes
{
    public class Modificateur
    {
        public static int CalculerModificateur(int caractéristique)
        {
            switch (caractéristique)
            {
                case var n when n < 5:
                    return -1;
                case var n when n < 10:
                    return 0;
                case var n when n < 15:
                    return 1;
                default:
                    return 2;
            }
        }
    }
}

