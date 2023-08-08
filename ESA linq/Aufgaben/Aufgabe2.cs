using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESA_linq;

public class Aufgabe2
{
    private Dictionary<string,int> dic = new()
    {
        { "Bank1" , 1 },
        { "Bank2" , 2 },
        { "Bank3" , 3 },
        { "Bank4" , 4 },
        { "Bank5" , 5 },
    };
    /// <summary>
    /// This method use the foreach statement to loop throw the items of the dictionry
    /// </summary>
    public void PrintBankleitzahlenForEach()
    {
        Console.WriteLine($"Mit for each-Schleife zum Schleifenwerfen des Wörterbuchs {Environment.NewLine}");
        foreach (var item in dic)
        {
            Console.WriteLine($"{item.Key} - {item.Value}");
        }
    }
    /// <summary>
    /// Diese Methode ermittelt den IEnumerator der IEnumerable und verwendet dann die while-Anweisung, um von Element zu Element zu gehen. The MoveNext() Methode gibt 
    /// false oder true zurück, je nachdem, ob ein nächstes Element verfügbar ist. Bei false wird die while-Schleife abgebrochen.
    /// </summary>
    public void PrintBankleitzahlenEnumerator()
    {
        Console.WriteLine($"Enumerator verwenden, um das Wörterbuch in einer Schleife zu durchlaufen {Environment.NewLine}");
        var enumerator = dic.GetEnumerator();
        while ( enumerator.MoveNext() )
        {
            Console.WriteLine($"{enumerator.Current.Key} - {enumerator.Current.Value}");
        }
    }
}
