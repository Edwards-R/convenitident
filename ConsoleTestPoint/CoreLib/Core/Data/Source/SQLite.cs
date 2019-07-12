using System;
using System.Collections.Generic;

using System.Data.SQLite;

namespace CoreLib.Core.Data.Source
{
    class SQLite:Base
    {
        SQLiteConnection connection;

        public SQLite(string connectionString)
        {
            connection = new SQLiteConnection(connectionString);
            connection.Open();
        }

        public override List<RecordSource> FetchRecordSources(bool activeOnly)
        {
            string commandText = @"SELECT RecordSourceType.RSTID, Description, RecordSourceID, Name, IsActive, ConnectionString, CacheLife, SharedSecret
FROM RecordSource
JOIN RecordSourceType on RecordSource.RSTID = RecordSourceType.RSTID";

            if (activeOnly)
            {
                commandText += " WHERE IsActive=1";
            }

            SQLiteCommand command = new SQLiteCommand(commandText, connection);

            SQLiteDataReader reader = command.ExecuteReader();

            List<RecordSource> sources = new List<RecordSource>();

            while (reader.Read())
            {
                RecordSourceType srcType = new RecordSourceType(reader.GetInt32(0), reader.GetString(1));
                sources.Add(new RecordSource(reader.GetInt32(2), srcType, reader.GetString(3), Convert.ToBoolean(reader.GetInt32(4)), reader.GetString(5), reader.GetInt32(6), reader.GetString(7)));
            }

            return sources;
        }

        public override List<AugTaxa> SelectImageTaxa()
        {
            SQLiteCommand command = new SQLiteCommand("SELECT TIK, Image, Audio, Video FROM AllowedTaxa WHERE Image=1", connection);
            SQLiteDataReader reader = command.ExecuteReader();

            List<AugTaxa> taxa = new List<AugTaxa>();

            while (reader.Read())
            {
                taxa.Add(new AugTaxa(reader.GetInt32(0), Convert.ToBoolean(reader.GetInt32(1)), Convert.ToBoolean(reader.GetInt32(2)), Convert.ToBoolean(reader.GetInt32(3))));
            }

            return taxa;
        }

        public override RecordCountCache FetchCountCache(RecordSource source, int tik)
        {
            SQLiteCommand command = new SQLiteCommand("SELECT RCCID, Count, TimeStamp, DateTime() FROM RecordCountCache WHERE TIK=@tik AND RSID=@rsid");
            command.Parameters.AddWithValue("@tik", tik);
            command.Parameters.AddWithValue("rsid", source.RSID);

            SQLiteDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();

                return new RecordCountCache(reader.GetInt32(0), source, reader.GetInt32(1), Convert.ToDateTime(reader.GetString(2)), Convert.ToDateTime(reader.GetString(3)));
            }
            else
            {
                //Need to create new count cache
            }

            return new RecordCountCache();
        }
    }
}
