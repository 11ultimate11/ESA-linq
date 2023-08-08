using System.Data.Odbc;

namespace ESA_linq
{
    public interface IODBC
    {
        Task<List<Person>> LoadPersonsFromDbo();
        Task<List<Artikel>> LoadArtikelsFromDbo();
    }
}