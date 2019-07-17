using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CoreLib.Taxonomy;

namespace CoreLib.Core
{
    class AugTaxa
    {
        public TaxonomicObject Taxa { get; }
        public bool AllowedImage { get; }
        public bool AllowedAudio { get; }
        public bool AllowedVideo { get; }

        //Cache
        public bool CacheChecked { get; private set; }

        public AugTaxa(int tik, bool image, bool audio, bool video)
        {
            Taxa = new TaxonomicObject(tik);
            AllowedImage = image;
            AllowedAudio = audio;
            AllowedVideo = video;

            CacheChecked = false;
        }

        public List<RecordCountCache> FetchRecordCache(List<RecordSource> sources)
        {
            List<RecordCountCache> caches = new List<RecordCountCache>();

            foreach(RecordSource rs in sources)
            {
                caches.Add(Factory.FetchCountCache(rs, Taxa.TIK));
            }

            return caches;
        }
    }
}