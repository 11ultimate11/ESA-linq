using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESA_linq;

public class ODBC : IODBC
{
    readonly OdbcConnection connection;
    readonly string connectionString = "Driver={MySQL ODBC 8.0 ANSI Driver};Server=localhost;Port=3306;Database=dbdemo2;User=demo-user;";
    public ODBC()
    {
        this.connection = new OdbcConnection(connectionString);
    }
    public async Task<List<Person>> LoadPersonsFromDbo()
    {
        string query = "select * from dbdemo2.personen;";
        using OdbcCommand command = new(query, connection);
        List<Person> output = new();
        try
        {
            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                output.Add(new Person()
                {
                    id = reader.GetInt32(0),
                    vorname = reader.GetString(1),
                    nachname = reader.GetString(2),
                    strasse = reader.GetString(3),
                    hausnummer = reader.GetInt32(4),
                    ort = reader.GetString(5),
                    land = reader.GetString(6),
                    plz = reader.GetInt32(7),
                    telefon = reader.GetInt32(8)
                });
            }
        }
        catch (Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.Message);
            return null!;
        }
        finally
        {
            await connection.CloseAsync();
        }
        return output;
    }
    public async Task<List<Artikel>> LoadArtikelsFromDbo()
    {
        string query = "select * from dbdemo2.artikel";
        using OdbcCommand command = new (query, connection);
        try
        {
            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();
            List<Artikel> output = new();
            while (await reader.ReadAsync())
            {
                output.Add(new()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Beschreibung = reader.GetString(2),
                    Groesse = reader.GetString(3),
                    Farbe = reader.GetString(4),
                    Menge = reader.GetInt32(5),
                    Preis = reader.GetFloat(6)
                });
            }
            return output;
        }
        catch (Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.Message);
        }
        finally
        {
            await connection.CloseAsync();
        }
        return null!;
    }
}
