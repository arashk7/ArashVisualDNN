using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArashVisualDNNEditor_1
{
    public class Model
    {
        public Model()
        {
            config = new Config();
        }
        public Config config { get; set; } 

        public string class_name{ get; set; }

        public string keras_version{ get; set; }

        public string backend{get; set;}
        public class Config
        {
            public Config()
            {
                name = "null";
                layers = new List<Layer>();
                input_layers = new List<List<object>>();
                output_layers = new List<List<object>>();
            }
            public string name { get; set; }
            public List<Layer> layers { get; set; }
            public List<List<object>> input_layers { get; set; }
            public List<List<object>> output_layers { get; set; }

        }
    }
    
}