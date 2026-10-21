using System;
using System.Collections.Generic;
using System.Text;

namespace Mitarbeiterverwaltung
{
    abstract class Person
    {

        public string  Vorname;
        public string Nachname;

        public Person (string vorname, string nachname) 
            
        {
            Vorname = vorname;
            Nachname = nachname; 
        
        
        }

        public abstract void Anzeigen();

              

    }
}
