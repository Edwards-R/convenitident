using System;
using System.Collections.Generic;

namespace CoreLib.Core.Data.Source
{
    abstract class Base
    {
        public abstract List<RecordSource> FetchRecordSources(bool activeOnly);

        public abstract List<AugTaxa> SelectImageTaxa();

        public abstract RecordCountCache FetchCountCache(RecordSource source, int tik);

        public abstract DateTime UpdateCountCache(int rccid, int count);
    }
}
