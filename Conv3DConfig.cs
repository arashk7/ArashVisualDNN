using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArashVisualDNNEditor_1
{
    public class Conv3DConfig
    {
        public int filters
        {
            get; set;
        }
        //public string _padding;
        public string padding
        {
            get; set;
        }
    }

    public class Conv1DConfig
    {
        public int filters
        {
            get; set;
        }
        public string padding
        {
            get; set;
        }
    }
}