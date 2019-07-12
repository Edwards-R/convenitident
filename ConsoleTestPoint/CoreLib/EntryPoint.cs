using System;
using System.Collections.Generic;

using CoreLib.Core;
namespace CoreLib
{
    class EntryPoint
    {
        public EntryPoint()
        {
            //Get the list of active sources
            List<RecordSource> activeSources = Factory.FetchRecordSources(true);
        }

        private void SelectImageTaxa()
        {

        }
    }
}
