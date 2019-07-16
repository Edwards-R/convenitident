using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace CoreLib.Records.Data.Source
{
    class SQLite:Base
    {
        private SQLiteConnection connection;

        public SQLite(string connectionString)
        {
            connection = new SQLiteConnection(connectionString);
            connection.Open();
        }

        public override int FetchTestRecordCount(int tik)
        {
            SQLiteCommand command = new SQLiteCommand("SELECT Count() FROM RecordFeed JOIN Record on Record.RecordID=RecordFeed.RecordID WHERE TIK=@tik AND RCID=3");
            command.Parameters.AddWithValue("@tik", tik);

            int x = (int)command.ExecuteScalar();

            return x;
        }
    }
}
