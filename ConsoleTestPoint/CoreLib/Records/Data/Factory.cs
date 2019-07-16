using System;
using System.Collections.Generic;

using CoreLib.Core;
using CoreLib.Records.Data.Source;

namespace CoreLib.Records.Data
{
    class Factory
    {
        private Base connection;

        public Factory(RecordSource source)
        {
            switch (source.SourceType.RSTID)
            {
                case 1:
                    connection = new SQLite(source.ConnectionString);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}