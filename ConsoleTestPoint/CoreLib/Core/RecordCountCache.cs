using System;
using System.Collections.Generic;

namespace CoreLib.Core
{
    class RecordCountCache
    {
        public int RCCID { get; }
        private int tik; //Shouldn't be exposed??
        public RecordSource Source { get; }
        public int Count { get; private set; }
        public DateTime Timestamp { get; private set; }

        public RecordCountCache(int rccid, int tik, RecordSource source, int count, DateTime stamp, DateTime now)
        {
            RCCID = rccid;
            this.tik = tik;
            Source = source;
            Count = count;
            Timestamp = stamp;

            CheckCache(now);
        }

        private void CheckCache(DateTime now)
        {
            //Check to see if the cache needs updating
            if (Timestamp.Subtract(now).TotalHours > Source.CacheLife)
            {
                //Update the cache:
                //Make a dispatcher to get the new count
                Records.Dispatcher dispatcher = new Records.Dispatcher(Source);
                Count = dispatcher.FetchTestRecordCount(tik);
                //Now update the cache
                Timestamp = Factory.UpdateCountCache(RCCID, Count);
            }
        }
    }
}
