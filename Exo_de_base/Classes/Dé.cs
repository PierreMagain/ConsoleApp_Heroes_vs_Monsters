namespace Exo_de_base.Classes
{
    public class De
    {
        public const int Minimum = 1;

        private Random random = new Random();

        public int Lancer(int _maximum, int nbr_lancer, int nombre_meilleur_choix)
        {
            int[] tab = new int[nbr_lancer];
            int i;
            for (i = 0; i < nbr_lancer; i++)
            {
                tab[i] = random.Next(Minimum, _maximum + 1);
            }
            if (nbr_lancer > 1)
            {
                Array.Sort(tab);
                int somme_nombre_meilleur_choix = 0;
                for (i = nbr_lancer - 1 ; i >= nbr_lancer - nombre_meilleur_choix; i--)
                {
                    somme_nombre_meilleur_choix += tab[i];
                }
                return somme_nombre_meilleur_choix;
            }
            else
            {
                return tab[0];
            }
        }

    }
}
