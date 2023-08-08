

using ESA_linq;
using ESA_linq.Aufgaben;
using System.Globalization;

IODBC oDBC = new ODBC();



Console.WriteLine("Wählen Sie aus welche Aufgabe Sie aufrufen möchten\nBeispiel : 1 - wird die Aufgabe 1 aufrufen");

while (true)
{
    var key = Console.ReadLine();
    var parse = int.TryParse(key, out var value);
    if (parse)
    {
        Console.WriteLine($"Sie haben die Aufgabe {value} ausgewählt");
        switch (value)
        {
            case 1:
                Aufgabe1 aufgabe1 = new();
                aufgabe1.Run();
                break;
            case 2:
                Aufgabe2 aufgabe2 = new();
                aufgabe2.PrintBankleitzahlenForEach();
                aufgabe2.PrintBankleitzahlenEnumerator();
                break;
            case 3:
                Aufgabe3 aufgabe3 = new Aufgabe3(oDBC);
                await aufgabe3.ExecuteLINQ();
                break;
            case 4:
                Aufgabe4 aufgabe4 = new(oDBC);
                _ = await aufgabe4.GetMostExpensiveItem();
                break;
            case 5:
                Aufgabe5 aufgabe5 = new(oDBC);
                await aufgabe5.GetPersonsInTheCity("Bedford");
                break;
        }
    }
}









