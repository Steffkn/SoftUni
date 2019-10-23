using _00.DBConnections;
using System;
using System.Data;

namespace _03.MinionNames
{
    class Program
    {

        static void Main()
        {
            Console.Write("Vilian Id: ");
            string villianId = Console.ReadLine();
            GetVilianName(villianId);
            GetMinians(villianId);
        }

        private static void GetVilianName(string villianId)
        {
            string query = @"SELECT Name FROM Villains WHERE Id = @Id";
            SqlProvider sqlProvider = new SqlProvider();
            Tuple<string, object> parameters = new Tuple<string, object>("Id", villianId);
            var villianName = sqlProvider.ExecuteScalar(query, parameters);
            Console.WriteLine(string.Format("Villain: {0}", villianName));
        }
        private static void GetMinians(string villianId)
        {
            string query = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";
            SqlProvider sqlProvider = new SqlProvider();
            Tuple<string, object> parameters = new Tuple<string, object>("Id", villianId);
            sqlProvider.ExecuteReader(query, ReadMinianNames, parameters);
        }

        private static void ReadMinianNames(IDataRecord record)
        {
            Console.WriteLine(string.Format("{0}. {1} {2}", record[0], record[1], record[2]));
        }
    }
}
