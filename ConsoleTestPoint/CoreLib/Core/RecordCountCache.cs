using System;
using System.Collections.Generic;

namespace CoreLib.Core
{
    class RecordCountCache
    {
        public int RCCID { get; }
        public RecordSource Source { get; }
        public int Count { get; }
        public DateTime Timestamp { get; }

        public RecordCountCache(int rccid, RecordSource source, int count, DateTime stamp, DateTime now)
        {
            RCCID = rccid;
            Source = source;
            Count = count;
            Timestamp = stamp;

            CheckCache(now);
        }

        private void CheckCache(DateTime now)
        {

        }
    }
}
