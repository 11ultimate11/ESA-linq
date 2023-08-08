using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESA_linq;

public class Aufgabe4
{
    private readonly IODBC oDBC;
    public Aufgabe4(IODBC oDBC)
    {
        this.oDBC = oDBC;
    }
    public async Task<Artikel> GetMostExpensiveItem()
    {
        var artikel = await oDBC.LoadArtikelsFromDbo();
        //First option
        var most1 = artikel.FirstOrDefault(x => x.Preis == artikel.Max(x => x.Preis));
        await Console.Out.WriteLineAsync("Variant 1 : var most1 = artikel.FirstOrDefault(x => x.Preis == artikel.Max(x => x.Preis))");
        //Second Option
        var most2 = artikel.OrderByDescending(x => x.Preis).FirstOrDefault();
        await Console.Out.WriteLineAsync("Variant 2 : var most2 = artikel.OrderByDescending(x => x.Preis).FirstOrDefault()");
        //Third option
        var most3 = (from a in artikel orderby a.Preis descending select a).FirstOrDefault();
        await Console.Out.WriteLineAsync("Variant 3 : var most3 = (from a in artikel orderby a.Preis descending select a).FirstOrDefault()");

        await Console.Out.WriteLineAsync($"Most expensive Artikel is {most1?.Name} - {most1?.Preis} euro");
        return most1!;
    }
}
