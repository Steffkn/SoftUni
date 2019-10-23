using _00.DBConnections;
using System;
using System.Data;

namespace _02.VillainNames
{
    class Program
    {
        static void Main()
        {
            GetAllVilians();
        }

        private static void GetAllVilians()
        {
            string query = @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                FROM Villains AS v 
                                JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                            GROUP BY v.Id, v.Name 
                              HAVING COUNT(mv.VillainId) > 3
                            ORDER BY COUNT(mv.VillainId) DESC";

            SqlProvider sqlProvider = new SqlProvider();
            sqlProvider.ExecuteReader(query, ReadSingleRow);
        }

        private static void ReadSingleRow(IDataRecord record)
        {
            Console.WriteLine(string.Format("{0} - {1}", record[0], record[1]));
        }
    }
}
