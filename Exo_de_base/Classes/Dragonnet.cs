namespace Exo_de_base.Classes
{
    public class Dragonnet : Personnage
    {
        private De de = new De();

        public Dragonnet() // constructeur sa mere
        {

            Endurance = EnduranceBase + 1;
            Force = ForceBase;
            PDVBase = Endurance + Modificateur.CalculerModificateur(Endurance);
            PDV = PDVBase;
            Or = de.Lancer(6,1,1);
            Cuir = de.Lancer(4, 1, 1);
            Lettre = 'D';
        }

        public override void Frapper(Personnage cible)
        {
            int degats = de.Lancer(4, 1, 1) + Modificateur.CalculerModificateur(Force);
            Console.WriteLine($"Dégat reçu par {cible.GetType().Name} : {degats}");
            cible.EnleverPDV(degats);
        }
    }
}
