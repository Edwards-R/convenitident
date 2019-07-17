using System;
using System.Collections.Generic;

using CoreLib.Core.Data.Source;

namespace CoreLib.Core
{

    //Make class static to avoid having a connection per taxonomic identity
    static class Factory
    {
        private static Base connection = ResolveFactory();

        public static Base ResolveFactory()
        {
            return new SQLite("Data Source=Databases/Core.db;Version=3");
        }

        public static List<RecordSource> FetchRecordSources(bool activeOnly)
        {
            return connection.FetchRecordSources(activeOnly);
        }

        //Dev build to only select image taxa
        public static List<AugTaxa> SelectImageTaxa()
        {
            return connection.SelectImageTaxa();
        }

        public static RecordCountCache FetchCountCache(RecordSource source, int tik)
        {
            return connection.FetchCountCache(source, tik);
        }

        public static DateTime UpdateCountCache(int rccid, int count)
        {
            return connection.UpdateCountCache(rccid, count);
        }
    }
}
