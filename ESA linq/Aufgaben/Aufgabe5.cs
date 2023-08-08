using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ESA_linq.Aufgaben;

public class Aufgabe5
{
    private readonly IODBC oDBC;
    public Aufgabe5(IODBC oDBC)
    {
        this.oDBC = oDBC;
    }
    public async Task GetPersonsInTheCity(string city)
    {
        var persons = await oDBC.LoadPersonsFromDbo();
        var sorted = persons.GroupBy(x => x.ort).Where(x => x.Key == city && x.Count() > 3).SelectMany(x => x).ToList();
        Console.WriteLine($"{sorted.Count} Personen wohnen in {city} : ");
        sorted.ForEach(x => Console.WriteLine($"\t{x.nachname} {x.vorname} in {x.ort}"));
    }
}
