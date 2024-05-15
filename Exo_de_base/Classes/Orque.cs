namespace Exo_de_base.Classes
{
    public class Orque : Personnage
    {
        private De de = new De();

        public Orque() // constructeur sa mere
        {

            Endurance = EnduranceBase;
            Force = ForceBase + 1;
            PDVBase = Endurance + Modificateur.CalculerModificateur(Endurance);
            PDV = PDVBase;
            Or = de.Lancer(6, 1, 1); 
            Cuir = 0;
            Lettre = 'O';
        }

        public override void Frapper(Personnage cible)
        {
            int degats = de.Lancer(4, 1, 1) + Modificateur.CalculerModificateur(Force);
            Console.WriteLine($"Dégat reçu par {cible.GetType().Name} : {degats}");
            cible.EnleverPDV(degats);
        }
    }
}
