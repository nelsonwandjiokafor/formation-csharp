# formation-csharp

Dieses Repository dokumentiert mein strukturiertes Eigenstudium in **C# / .NET**. Es enthält kleine, thematisch sortierte Übungsprojekte, mit denen ich die Grundlagen der objektorientierten Programmierung, den Umgang mit Datenbanken (ADO.NET / SQL Server) sowie typische Konzepte der Anwendungsentwicklung praktisch vertiefe.

Ich bin **Fachinformatiker für Anwendungsentwicklung (IHK-Abschluss Juli 2026)** und baue meine Kenntnisse in C#/.NET täglich weiter aus.

---

## Hauptprojekt: Mitarbeiterverwaltung

Das umfangreichste Projekt dieses Repositorys: eine **Konsolenanwendung zur Verwaltung von Mitarbeitern** mit Anbindung an eine SQL-Server-Datenbank.

**Technik & Konzepte:**
- Datenzugriff über **ADO.NET** (`Microsoft.Data.SqlClient`)
- **Objektorientierung:** Vererbung, abstrakte Basisklasse und Interfaces
- **Repository Pattern** zur Trennung von Datenzugriff und Programmlogik
- Vollständige **CRUD-Operationen** (Anlegen, Lesen, Ändern, Löschen)
- Eingabevalidierung über `try/catch`
- Statistikfunktionen (Durchschnitt, Minimum, Maximum)

Ordner: [`Mitarbeiterverwaltung`](./Mitarbeiterverwaltung)

---

## Weitere Übungen nach Themen

### Objektorientierung
- **classObjekt** – Klassen, Objekte und Methoden
- **KapselungProdukt** – Kapselung, Eigenschaften (Properties)
- **VererbungAufgabe** / **VererbungKapselung** – Vererbung und abgeleitete Klassen
- **AbstraktKlasse** – abstrakte Klassen und Methoden
- **InterfaceList** – Interfaces und ihre Implementierung

### Datenbanken
- **adoNetVerbindung** – Datenbankverbindung mit ADO.NET
- **DatenbankTest** – Abfragen und Datenzugriff gegen SQL Server

### Fehlerbehandlung
- **tryCatchFinallyAufgabe** – Ausnahmebehandlung mit `try` / `catch` / `finally`

### Kleine Anwendungen
- **Rechner** – einfacher Taschenrechner
- **Einkaufsliste** – Verwaltung einer Einkaufsliste mit Datei-Persistenz
- **Notenverwaltung** – Verwaltung von Noten

---

## Verwendete Technologien

| Bereich        | Technologien                                   |
|----------------|------------------------------------------------|
| Sprache        | C#                                             |
| Plattform      | .NET                                           |
| Datenbank      | Microsoft SQL Server, ADO.NET                  |
| Werkzeuge      | Visual Studio, Git                             |

---

## Zielsetzung

Dieses Repository wächst kontinuierlich und zeigt meinen praktischen Lernfortschritt auf dem Weg zum **Junior-Softwareentwickler C#/.NET**.
