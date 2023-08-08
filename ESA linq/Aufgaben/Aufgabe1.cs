using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESA_linq;

public class Aufgabe1
{
    /// <summary>
    /// Den Enumerator aus einer IEnumerable abrufen
    /// </summary>
    public void Run()
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
        var enumerator = numbers.GetEnumerator();
        Console.WriteLine($"Extension method GetEnumerator wurde aufgerufen\n" +
            $"Bei der Definition einer Erweiterungsmehtode ist wichtig , dass die Methode als static erstellt wird und dass sie sich in eine " +
            $"statische Klasse befindet.Weiter muss das parameter typ nach dem keyword \'this\' geschrieben werden");
    }
}
