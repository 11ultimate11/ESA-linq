using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESA_linq;

public class Artikel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Beschreibung { get; set; }
    public string? Groesse { get; set; }
    public string? Farbe { get; set; }
    public int Menge { get; set; }
    public float Preis { get; set; }
}
