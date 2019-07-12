using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib.Core
{
    class RecordSource
    {
        public int RSID { get; }
        public RecordSourceType SourceType { get; }
        public string Name { get; }
        public bool IsActive { get; }
        public string ConnectionString { get; }
        public int CacheLife { get; }
        public string Secret { get; }

        public RecordSource(int rsid, RecordSourceType sourceType, string name, bool isActive, string connectionString, int cacheLife, string secret)
        {
            RSID = rsid;
            SourceType = sourceType;
            Name = name;
            IsActive = isActive;
            ConnectionString = connectionString;
            CacheLife = cacheLife;
            Secret = secret;
        }
    }
}
