using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESA_linq;

public class Aufgabe3
{
    private readonly IODBC oDBC;
    private List<Person>? persons;

    public Aufgabe3(IODBC oDBC)
    {
        this.oDBC = oDBC;
    }


    public async Task ExecuteLINQ()
    {
        persons ??= await oDBC.LoadPersonsFromDbo();
        AufgabeA();
        AufgabeB();
        AufgabeC();
    }
    public void AufgabeA()
    {
        var people = from p in persons
                     where p.vorname == "John" && p.ort == "Burlington"
                     orderby p.nachname
                     select new { p.vorname, p.nachname, p.ort };
        Console.WriteLine($"Es wurden in Datenbank {people.Count()} Menschen wo der Vorname = John und in Burlington wohnen");
    }
    public void AufgabeB()
    {
        var people = from p in persons
                     where p.vorname == "Cara" || p.nachname == "Lull"
                     orderby p.nachname
                     select new { p.vorname, p.nachname, p.ort };
        Console.WriteLine($"Es wurden in Datenbank {people.Count()} Menschen wo der Vorname = Cara oder der Nachname = Lull");
    }
    public void AufgabeC()
    {
        var people = from p in persons where p.ort == "Belmont" || p.ort == "Powell" select p;
        Console.WriteLine($"Es wurden in Datenbank {people.Count()} Menschen die entweder in Belmont oder Powell wohnen");
    }
}
