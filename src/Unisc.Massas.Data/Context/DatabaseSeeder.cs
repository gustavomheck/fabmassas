using System.IO;

namespace Unisc.Massas.Data.Context
{
    public class DatabaseSeeder
    {
        public DatabaseSeeder()
        {
        }

        public static void Seed()
        {
            string path = Path.Combine(Path.GetFullPath(@"..\..\..\..\"), "Solution Items");
            string truncate = File.ReadAllText(Path.Combine(path, "truncate.sql"));
            string insert = File.ReadAllText(Path.Combine(path, "seed.sql"));

            using (var ctx = new MassasContext())
            {
                ctx.Database.ExecuteSqlCommand(truncate);
                ctx.Database.ExecuteSqlCommand(insert);
            }
        }
    }
}
