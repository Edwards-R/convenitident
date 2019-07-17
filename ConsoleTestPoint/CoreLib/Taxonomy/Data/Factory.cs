using CoreLib.Taxonomy.Data.Source;

namespace CoreLib.Taxonomy.Data
{
    static class Factory
    {

        private static Base connection = ResolveFactory();

        //'Constructor' for static class
        private static Base ResolveFactory()
        {
            //Environment should direct this what to load, this is shortcutting that for dev
            return new SQLite("Data Source=Databases/Taxonomy.db;Version=3;");
        }

        public static string FetchTaxaDetails(int tik)
        {
            return connection.FetchTaxaDetails(tik);
        }
    }
}
