using System;
using System.Collections.Generic;
using System.Text;

namespace Mitarbeiterverwaltung
{
    internal class Manager : Person
    {

        public decimal Bonus;

        public Manager (decimal bonus, string vorname, string nachname ) : base( vorname, nachname)

        {
            Bonus = bonus;

        }

        public override void Anzeigen()
        {

            Console.WriteLine($"Nachname:{Nachname}, Vorname: {Vorname}, Bonus : {Bonus}");

        }

    }
}
