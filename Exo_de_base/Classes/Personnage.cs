namespace Exo_de_base.Classes
{
    public class Personnage
    {
        De de = new De();

        public int EnduranceBase { get; protected set; }
        public int ForceBase { get; protected set; }
        public virtual int PDVBase { get; protected set; }

        public virtual int Endurance { get; protected set; }
        public virtual int PDV { get; set; }
        public virtual int Force { get; protected set; }

        public Personnage()
        {
            EnduranceBase = de.Lancer(6, 4, 3);
            ForceBase = de.Lancer(6, 4, 3);
        }

        public virtual void Frapper(Personnage cible) { }

        public void EnleverPDV(int degats)
        {
            PDV -= degats;
        }
        public virtual char Lettre {  get; protected set; }
        public virtual int Cuir {  get; set; }
        public virtual int Or { get;  set; }
    }
}
