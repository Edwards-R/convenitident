using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib.Core
{
    class RecordSourceType
    {
        public int RSTID { get; }
        public string Description { get; }

        public RecordSourceType (int rstid, string description)
        {
            RSTID = rstid;
            Description = description;
        }
    }
}
