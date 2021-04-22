using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie1
{
    class JsonOps
    {
        public taskInfo task { get; set; }
        public string date { get; set; }
        public string time { get; set; }

        public class taskInfo
        {
            public string type { get; set; }
            public bool isFolder { get; set; }
            public string source { get; set; }
            public string destination { get; set; }
            public bool toEncrypt { get; set; }
        }
    }
}
