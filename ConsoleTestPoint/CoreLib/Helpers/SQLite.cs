using System;
using System.Collections.Generic;

using System.Data.SQLite;

namespace CoreLib.Helpers
{
    static class SQLite
    {

        public static string GetStringSafe(this SQLiteDataReader reader, int index)
        {
            if (!reader.IsDBNull(index))
            {
                return reader.GetString(index);
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
