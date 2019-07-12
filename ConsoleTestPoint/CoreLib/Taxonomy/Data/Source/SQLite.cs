using System.Data.SQLite;

namespace CoreLib.Taxonomy.Data.Source
{
    class SQLite : Base
    {
        SQLiteConnection connection;

        public SQLite(string conString)
        {
            connection = new SQLiteConnection(conString);
            connection.Open();
        }

        public override string FetchTaxaDetails(int tik)
        {
            SQLiteCommand command = new SQLiteCommand("SELECT Name FROM Entity WHERE TIK = @tik", connection);
            command.Parameters.AddWithValue("@tik", tik);

            SQLiteDataReader reader = command.ExecuteReader();
            reader.Read();

            string returnvalue = reader.GetString(0);

            reader.Close();

            return returnvalue;
        }
    }
}
