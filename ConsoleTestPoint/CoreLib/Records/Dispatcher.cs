using System;
using System.Collections.Generic;

using CoreLib.Core;
using CoreLib.Records.Data;

namespace CoreLib.Records
{
    class Dispatcher
    {
        public RecordSource Source{get;}
        private Records.Data.Factory factory;

        public Dispatcher(RecordSource source)
        {
            Source = source;
            factory = new Data.Factory(source);
        }

        public int FetchTestRecordCount(int tik)
        {
            return factory.FetchTestRecordCount(tik);
        }
    }
}
