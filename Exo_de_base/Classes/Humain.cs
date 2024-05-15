namespace Exo_de_base.Classes
{
    public class Humain : Personnage
    {
        private De de = new De();

        public Humain() // constructeur sa mere
        {            
            Endurance = EnduranceBase + 1; 
            Force = ForceBase + 1;            
            PDVBase = Endurance + Modificateur.CalculerModificateur(Endurance);
            PDV = PDVBase;
            Or = 0;
            Cuir = 0;
            Lettre = 'H';
        }
        
        public override void Frapper(Personnage cible)
        {
            int degats = de.Lancer(4, 1, 1) + Modificateur.CalculerModificateur(Force);
            Console.WriteLine($"Dégat reçu par {cible.GetType().Name} : {degats}");
            cible.EnleverPDV(degats);
        }
    }
}
