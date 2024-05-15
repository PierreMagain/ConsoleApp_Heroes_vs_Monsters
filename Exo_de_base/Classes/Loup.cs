namespace Exo_de_base.Classes
{
    public class Loup : Personnage
    {
        private De de = new De();

        public Loup() // constructeur sa mere
        {

            Endurance = EnduranceBase;
            Force = ForceBase;
            PDVBase = Endurance + Modificateur.CalculerModificateur(Endurance);
            PDV = PDVBase;
            Or = 0;
            Cuir = de.Lancer(4,1,1);
            Lettre = 'L';
        }

        public override void Frapper(Personnage cible)
        {
            int degats = de.Lancer(4, 1, 1) + Modificateur.CalculerModificateur(Force);
            Console.WriteLine($"Dégat reçu par {cible.GetType().Name} : {degats}");
            cible.EnleverPDV(degats);
        }
    }
}
