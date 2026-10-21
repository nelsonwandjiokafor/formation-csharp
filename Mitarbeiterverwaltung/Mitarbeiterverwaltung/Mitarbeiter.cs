using System;
using System.Collections.Generic;
using System.Text;

namespace Mitarbeiterverwaltung
{
    internal class Mitarbeiter : Person, IAffichbar
    {
        public int MitarbeiterID;
       
        public int AbteilungID;
        public decimal Gehalt;
        public DateTime Eintrittsdatum;

        public Mitarbeiter(int mitarbeiterid, string vorname,string nachname,int abteilungID, decimal gehalt, DateTime eintrittsdatum ) : base (vorname, nachname)
        {
           MitarbeiterID = mitarbeiterid;         
           AbteilungID = abteilungID;
           Gehalt = gehalt;
           Eintrittsdatum = eintrittsdatum;
        }

        public override void Anzeigen() 
        {

            Console.WriteLine($"ID: {MitarbeiterID}, Vorname: {Vorname}, Nachname: {Nachname}, Abteilung: {AbteilungID}, Gehalt: {Gehalt}, Eintritt: {Eintrittsdatum.ToShortDateString()}");

        }

        public void Details()
        {
            Console.WriteLine("=== DÉTAILS MITARBEITER ===");
            Console.WriteLine($"Nom: {Nachname}, {Vorname}");
            Console.WriteLine($"Abteilung: {AbteilungID}");
            Console.WriteLine($"Gehalt: {Gehalt}");
            Console.WriteLine($"Eintrittsdatum: {Eintrittsdatum.ToShortDateString()}");
        }

    }

    

}
