namespace Exo_de_base.Classes
{
    public class Combat
    {
        public void Duel(Personnage attaquant,Personnage defenseur)//Toujousr l'humain ou le nain l'attaquant !
        {
            Personnage vainqueur = null;
            Personnage vaincu = null;
            bool verif_boucle = true;

            Console.WriteLine("Déroulement du combat :\n");

            while (verif_boucle) { // boucle où il se tappe à mort
                attaquant.Frapper(defenseur);
                if (defenseur.PDV <= 0) 
                {
                    Console.WriteLine($"{defenseur.GetType().Name} est mort");
                    vainqueur = attaquant;
                    vaincu = defenseur;
                    break;          
                }
                defenseur.Frapper(attaquant);
                if (attaquant.PDV <= 0)
                {
                    Console.WriteLine($"{attaquant.GetType().Name} est mort");
                    break;
                }
            }

            if (vainqueur != null && vaincu != null) //regen + trabsfert d'or&cuivre aores le combat
            {
                RegenPDV(vainqueur);
                Depouillage_Or_Cu(vainqueur, vaincu);
            }


        }

        private void RegenPDV(Personnage Vainqueur)
        {
            Vainqueur.PDV = Vainqueur.PDVBase;
        }

        private void Depouillage_Or_Cu(Personnage Vainqueur,Personnage Vaincu) 
        {
            Vainqueur.Or += Vaincu.Or;
            Vainqueur.Cuir += Vaincu.Cuir;
        }
        
    }
}
