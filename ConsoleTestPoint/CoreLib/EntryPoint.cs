using System;
using System.Collections.Generic;

using CoreLib.Core;
namespace CoreLib
{
    public class EntryPoint
    {
        public EntryPoint()
        {
            //Get the list of active sources
            List<RecordSource> activeSources = Factory.FetchRecordSources(true);

            List<AugTaxa> tax = Factory.SelectImageTaxa();

            foreach (AugTaxa aTax in tax)
            {
                Console.WriteLine("TIK: {0}  Name: {1}", aTax.Taxa.TIK, aTax.Taxa.Name);

                List<RecordCountCache> countCache = aTax.FetchRecordCache(activeSources);

                foreach (RecordCountCache rcc in countCache)
                {
                    Console.WriteLine(rcc.Count);
                }
            }
        }
    }
}
