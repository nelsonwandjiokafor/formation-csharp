# Mitarbeiterverwaltung

Eine Konsolenanwendung zur Verwaltung von Mitarbeitern mit Anbindung an eine SQL Server Datenbank. Das Projekt demonstriert objektorientierte Programmierung mit C# und Datenbankzugriff über ADO.NET.

## Technologien

- C# / .NET 10
- Microsoft SQL Server Express
- ADO.NET (Microsoft.Data.SqlClient)

## Funktionen

- Alle Mitarbeiter anzeigen
- Mitarbeiter suchen (nach Vorname)
- Neuen Mitarbeiter hinzufügen
- Mitarbeiter bearbeiten
- Mitarbeiter löschen (mit Überprüfung ob ID existiert)
- Statistiken anzeigen (Anzahl, Durchschnittsgehalt, Min/Max)
- Eingabevalidierung mit try/catch
- Farbige Konsolenausgabe (Cyan, Grün, Rot)

## Architektur

| Klasse | Beschreibung |
|--------|-------------|
| `Person` | Abstrakte Basisklasse mit Vorname, Nachname und abstrakter Methode `Anzeigen()` |
| `Mitarbeiter` | Erbt von Person, implementiert IAffichbar, enthält MitarbeiterID, AbteilungID, Gehalt, Eintrittsdatum |
| `Manager` | Erbt von Person, enthält Bonus |
| `IAffichbar` | Interface mit Methode `Details()` |
| `MitarbeiterRepository` | Data Access Layer — CRUD-Operationen mit ADO.NET (GetAll, Add, Update, Delete) |

Das Projekt verwendet das **Repository Pattern** zur Trennung von Datenzugriff und Programmlogik.

## Voraussetzungen

- .NET 10 SDK
- SQL Server Express (localhost\SQLEXPRESS)
- Datenbank `Formation` mit Tabellen `Mitarbeiter` und `Abteilung`

## Starten

```bash
dotnet run --project Mitarbeiterverwaltung/Mitarbeiterverwaltung
```