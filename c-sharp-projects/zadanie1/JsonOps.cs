using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie1
{
    class JsonOps
    {
        public taskArr[] tasks;

        public class taskInfo
        {
            public string title { get; set; }
            public string type { get; set; }
            public string source { get; set; }
            public string copyDestination { get; set; }
            public string encryptionPassword { get; set; }
            public bool verify { get; set; }
            public string datetime { get; set; }
        }
        public class taskArr
        {
            public taskInfo task { get; set; }
        }
    }
}
