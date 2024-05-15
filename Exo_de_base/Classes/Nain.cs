namespace Exo_de_base.Classes
{
    public class Nain : Personnage
    {
        private De de = new De();

        public Nain() // constructeur sa mere
        {

            Endurance = EnduranceBase + 2 ;
            Force = ForceBase;
            PDVBase = Endurance + Modificateur.CalculerModificateur(Endurance);
            PDV = PDVBase;
            Or = 0;
            Cuir = 0;
            Lettre = 'N';
        }

        public override void Frapper(Personnage cible)
        {
            int degats = de.Lancer(4, 1, 1) + Modificateur.CalculerModificateur(Force);
            Console.WriteLine($"Dégat reçu par {cible.GetType().Name} : {degats}");
            cible.EnleverPDV(degats);
        }
    }
}
