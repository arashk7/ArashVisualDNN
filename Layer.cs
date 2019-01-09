using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.IO;
//using System.Reflection;
using System.Drawing;
using System.ComponentModel;
namespace ArashVisualDNNEditor_1
{
    public enum LayerType { INPUT, CONV1D, CONV2D, CONV3D, DENSE, MAXPOOLING1D, MAXPOOLING2D, MAXPOOLING3D, FLATTEN, ADD };
    public abstract class LayerSetting
    {
        public static Dictionary<int, string> layerClassNames { get; set; } = new Dictionary<int, string>();
        public static Dictionary<int, Layer> layerClasses { get; set; } = new Dictionary<int, Layer>();
        public static void LoadLayers()
        {
            DirectoryInfo d = new DirectoryInfo(layerDir);
            FileInfo[] Files = d.GetFiles("*.json"); 
            int id = 0;
            foreach (FileInfo file in Files)
            {
                string text = System.IO.File.ReadAllText(layerDir +file.Name);
                Layer layer = JsonConvert.DeserializeObject<Layer>(text);
                layerClasses.Add(id, layer);
                layerClassNames.Add(id, layer.class_name);
                id++;
            }
        }
        public static string layerDir { get; set; } = "./Layers/";
        public static Layer LoadDefaultSetting(Layer l)
        {
            string text = System.IO.File.ReadAllText(layerDir + l.class_name + ".json");
            return JsonConvert.DeserializeObject<Layer>(text);
        }
        public static void SaveSetting(Layer layer, bool showNodeConfig = false)
        {
            layer.show_nodeConfig = showNodeConfig;
            string json_layer = JsonConvert.SerializeObject(layer);
            File.WriteAllText(layerDir + layer.class_name + ".json", json_layer);
        }
    }
    
    public class Layer
    {
        public Layer()
        {
            config = new Config(this);
            inbound_nodes = new List<object>();
            nodeConfig = new NodeConfig();
            

        }
        public string name{ get; set;}
        public string class_name{get; set;}
        public List<object> inbound_nodes { get; set; }
        public Config config { get; set; }

        public class Config 
        {
            
            #region Config params
            //Common parameters

            public string name { get; set; }
            //[Category("JSON"), Description("Config Json file to show shape data")]
            //public bool show_name { get; set; } = false;
            public bool ShouldSerializename() { return visibleParams.Contains("name"); }
            //public bool ShouldSerializeshow_name() { return _parent.show_nodeConfig; }

            //INPUT
            public bool sparse { get; set; }
            //[Category("JSON"), Description("Config Json file to show shape data")]
            //public bool show_sparse { get; set; } = false;
            public bool ShouldSerializesparse() { return visibleParams.Contains("sparse"); }
            //public bool ShouldSerializeshow_sparse() { return _parent.show_nodeConfig; }

            public string dtype { get; set; }
            //[Category("JSON"), Description("Config Json file to show shape data")]
            //public bool show_dtype { get; set; } = false;
            public bool ShouldSerializedtype() { return visibleParams.Contains("dtype"); }
            //public bool ShouldSerializeshow_dtype() { return _parent.show_nodeConfig; }

            public List<object> batch_input_shape { get; set; }
            //public bool show_batch_input_shape { get; set; } = false;
            public bool ShouldSerializebatch_input_shape() { return visibleParams.Contains("batch_input_shape"); }
            //public bool ShouldSerializeshow_batch_input_shape() { return _parent.show_nodeConfig; }

            //Dense
            public int units { get; set; }
            //[Category("JSON"), Description("Config Json file to show shape data")]
            //public bool show_units { get; set; } = false;
            public bool ShouldSerializeunits() { return visibleParams.Contains("units"); }
            //public bool ShouldSerializeshow_units() { return _parent.show_nodeConfig; }

            //CONV3D
            public bool trainable { get; set; }
            //[Category("JSON"), Description("Config Json file to show shape data")]
            //public bool show_trainable { get; set; } = false;
            public bool ShouldSerializetrainable() { return visibleParams.Contains("trainable"); }
            //public bool ShouldSerializeshow_trainable() { return _parent.show_nodeConfig; }

            public int filters { get; set; }
            //[Category("JSON"), Description("Config Json file to show shape data")]
            //public bool show_filters { get; set; } = false;
            public bool ShouldSerializefilters() { return visibleParams.Contains("filters"); }
            //public bool ShouldSerializeshow_filters() { return _parent.show_nodeConfig; }

            public List<object> kernel_size { get; set; }
            //[Category("JSON"), Description("Config Json file to show shape data")]
            //public bool show_kernel_size { get; set; } = false;
            public bool ShouldSerializekernel_size() { return visibleParams.Contains("kernel_size"); }
            //public bool ShouldSerializeshow_kernel_size() { return _parent.show_nodeConfig; }

            public List<object> strides { get; set; }
            //[Category("JSON"), Description("Config Json file to show shape data")]
            //public bool show_strides { get; set; } = false;
            public bool ShouldSerializestrides() { return visibleParams.Contains("strides"); }
            //public bool ShouldSerializeshow_strides() { return _parent.show_nodeConfig; }

            public string padding { get; set; }
            //[Category("JSON"), Description("Config Json file to show shape data")]
            //public bool show_padding { get; set; } = false;
            public bool ShouldSerializepadding() { return visibleParams.Contains("padding"); }
            //public bool ShouldSerializeshow_padding() { return _parent.show_nodeConfig; }

            public string data_format { get; set; }
            //[Category("JSON"), Description("Config Json file to show shape data")]
            //public bool show_data_format { get; set; } = false;
            public bool ShouldSerializedata_format() { return visibleParams.Contains("data_format"); }
            //public bool ShouldSerializeshow_data_format() { return _parent.show_nodeConfig; }

            public List<object> dilation_rate { get; set; }
            //[Category("JSON"), Description("Config Json file to show shape data")]
            //public bool show_dilation_rate { get; set; } = false;
            public bool ShouldSerializedilation_rate() { return visibleParams.Contains("dilation_rate"); }
            //public bool ShouldSerializeshow_dilation_rate() { return _parent.show_nodeConfig; }

            public string activation { get; set; }
            //[Category("JSON"), Description("Config Json file to show shape data")]
            //public bool show_activation { get; set; } = false;
            public bool ShouldSerializeactivation() { return visibleParams.Contains("activation"); }
            //public bool ShouldSerializeshow_activation() { return _parent.show_nodeConfig; }

            public bool use_bias { get; set; }
            //[Category("JSON"), Description("Config Json file to show shape data")]
            //public bool show_use_bias { get; set; } = false;
            public bool ShouldSerializeuse_bias() { return visibleParams.Contains("use_bias"); }
            //public bool ShouldSerializeshow_use_bias() { return _parent.show_nodeConfig; }

            public Kernel_initializer kernel_initializer { get; set; }
            public class Kernel_initializer
            {
                public Kernel_initializer()
                {
                    config = new Config();
                }
                public string class_name { get; set; }
                public Config config { get; set; }
                public class Config
                {
                    public float scale { get; set; }
                    public string mode { get; set; }
                    public string distribution { get; set; }
                    public string seed { get; set; }

                }
                
            }
            //[Category("JSON"), Description("Config Json file to show shape data")]
            //public bool show_kernel_initializer { get; set; } = false;
            public bool ShouldSerializekernel_initializer() { return visibleParams.Contains("kernel_initializer"); }
            //public bool ShouldSerializeshow_kernel_initializer() { return _parent.show_nodeConfig; }

            public Bias_initializer bias_initializer { get; set; }
            public class Bias_initializer
            {
                public Bias_initializer()
                {
                    
                }
                public string class_name { get; set; }
                public Config config { get; set; }
                public class Config
                {
                    public float scale { get; set; }
                    public string mode { get; set; }
                    public string distribution { get; set; }
                    public string seed { get; set; }

                }
            }
            //[Category("JSON"), Description("Config Json file to show shape data")]
            //public bool show_bias_initializer { get; set; } = false;
            public bool ShouldSerializebias_initializer() { return visibleParams.Contains("bias_initializer"); }
            //public bool ShouldSerializeshow_bias_initializer() { return _parent.show_nodeConfig; }

            public string kernel_regularizer { get; set; }
            //[Category("JSON"), Description("Config Json file to show shape data")]
            //public bool show_kernel_regularizer { get; set; } = false;
            public bool ShouldSerializekernel_regularizer() { return visibleParams.Contains("kernel_regularizer"); }
            //public bool ShouldSerializeshow_kernel_regularizer() { return _parent.show_nodeConfig; }

            public string bias_regularizer { get; set; }
            //[Category("JSON"), Description("Config Json file to show shape data")]
            //public bool show_bias_regularizer { get; set; } = false;
            public bool ShouldSerializebias_regularizer() { return visibleParams.Contains("bias_regularizer"); }
            //public bool ShouldSerializeshow_bias_regularizer() { return _parent.show_nodeConfig; }

            public string activity_regularizer { get; set; }
            //[Category("JSON"), Description("Config Json file to show shape data")]
            //public bool show_activity_regularizer { get; set; } = false;
            public bool ShouldSerializeactivity_regularizer() { return visibleParams.Contains("activity_regularizer"); }
            //public bool ShouldSerializeshow_activity_regularizer() { return _parent.show_nodeConfig; }

            public string kernel_constraint { get; set; }
            //[Category("JSON"), Description("Config Json file to show shape data")]
            //public bool show_kernel_constraint { get; set; } = false;
            public bool ShouldSerializekernel_constraint() { return visibleParams.Contains("kernel_constraint"); }
            //public bool ShouldSerializeshow_kernel_constraint() { return _parent.show_nodeConfig; }

            public string bias_constraint { get; set; }
            //[Category("JSON"), Description("Config Json file to show shape data")]
            //public bool show_bias_constraint { get; set; } = false;
            public bool ShouldSerializebias_constraint() { return visibleParams.Contains("bias_constraint"); }
            //public bool ShouldSerializeshow_bias_constraint() { return _parent.show_nodeConfig; }

            //MaxPooling
            public List<int> pool_size { get; set; }
            //[Category("JSON"), Description("Config Json file to show shape data")]
            //public bool show_pool_size { get; set; } = false;
            public bool ShouldSerializepool_size() { return visibleParams.Contains("pool_size"); }
            //public bool ShouldSerializeshow_pool_size() { return _parent.show_nodeConfig; }
            #endregion

            [JsonIgnore]
            private Layer _parent;
            
            public Config( Layer l)
            {
                
                _parent = l;
                batch_input_shape = new List<object>();
                kernel_size = new List<object>();
                strides = new List<object>();
                dilation_rate = new List<object>();
                bias_initializer = new Bias_initializer();
                kernel_initializer = new Kernel_initializer();
                pool_size = new List<int>();

            }

            public List<string> visibleParams = new List<string>();
            public bool ShouldSerializevisibleParams() { return _parent.show_nodeConfig; }

        }


        public NodeConfig nodeConfig { get; set; }
        [JsonIgnore]
        public bool show_nodeConfig { get; set; } = false;
        public bool ShouldSerializenodeConfig() { return show_nodeConfig; }

        
        public class NodeConfig
        {
            public float width { get; set; } = 100;
            public float height { get; set; } = 100;
            public List<Port> incomingPorts { set; get; } = new List<Port>();
            public List<Port> outgoingPorts { set; get; } = new List<Port>();
            public class Port
            {
                public string name { set; get; } = "";
            }
        }

    }

    public class CopyOfLayer
    {
        public CopyOfLayer()
        {
            config = new Config(this);
            inbound_nodes = new List<object>();
            nodeConfig = new NodeConfig();


        }
        public string name { get; set; }
        public string class_name { get; set; }
        public List<object> inbound_nodes { get; set; }
        public Config config { get; set; }

        public class Config
        {

            #region Config params
            //Common parameters

            public string name { get; set; }
            //[Category("JSON"), Description("Config Json file to show shape data")]
            //public bool show_name { get; set; } = false;
            public bool ShouldSerializename() { return visibleParams.Contains("name"); }
            //public bool ShouldSerializeshow_name() { return _parent.show_nodeConfig; }

            //INPUT
            public bool sparse { get; set; }
            //[Category("JSON"), Description("Config Json file to show shape data")]
            //public bool show_sparse { get; set; } = false;
            public bool ShouldSerializesparse() { return visibleParams.Contains("sparse"); }
            //public bool ShouldSerializeshow_sparse() { return _parent.show_nodeConfig; }

            public string dtype { get; set; }
            //[Category("JSON"), Description("Config Json file to show shape data")]
            //public bool show_dtype { get; set; } = false;
            public bool ShouldSerializedtype() { return visibleParams.Contains("dtype"); }
            //public bool ShouldSerializeshow_dtype() { return _parent.show_nodeConfig; }

            public List<object> batch_input_shape { get; set; }
            //public bool show_batch_input_shape { get; set; } = false;
            public bool ShouldSerializebatch_input_shape() { return visibleParams.Contains("batch_input_shape"); }
            //public bool ShouldSerializeshow_batch_input_shape() { return _parent.show_nodeConfig; }

            //Dense
            public int units { get; set; }
            //[Category("JSON"), Description("Config Json file to show shape data")]
            //public bool show_units { get; set; } = false;
            public bool ShouldSerializeunits() { return visibleParams.Contains("units"); }
            //public bool ShouldSerializeshow_units() { return _parent.show_nodeConfig; }

            //CONV3D
            public bool trainable { get; set; }
            //[Category("JSON"), Description("Config Json file to show shape data")]
            //public bool show_trainable { get; set; } = false;
            public bool ShouldSerializetrainable() { return visibleParams.Contains("trainable"); }
            //public bool ShouldSerializeshow_trainable() { return _parent.show_nodeConfig; }

            public int filters { get; set; }
            //[Category("JSON"), Description("Config Json file to show shape data")]
            //public bool show_filters { get; set; } = false;
            public bool ShouldSerializefilters() { return visibleParams.Contains("filters"); }
            //public bool ShouldSerializeshow_filters() { return _parent.show_nodeConfig; }

            public List<object> kernel_size { get; set; }
            //[Category("JSON"), Description("Config Json file to show shape data")]
            //public bool show_kernel_size { get; set; } = false;
            public bool ShouldSerializekernel_size() { return visibleParams.Contains("kernel_size"); }
            //public bool ShouldSerializeshow_kernel_size() { return _parent.show_nodeConfig; }

            public List<object> strides { get; set; }
            //[Category("JSON"), Description("Config Json file to show shape data")]
            //public bool show_strides { get; set; } = false;
            public bool ShouldSerializestrides() { return visibleParams.Contains("strides"); }
            //public bool ShouldSerializeshow_strides() { return _parent.show_nodeConfig; }

            public string padding { get; set; }
            //[Category("JSON"), Description("Config Json file to show shape data")]
            //public bool show_padding { get; set; } = false;
            public bool ShouldSerializepadding() { return visibleParams.Contains("padding"); }
            //public bool ShouldSerializeshow_padding() { return _parent.show_nodeConfig; }

            public string data_format { get; set; }
            //[Category("JSON"), Description("Config Json file to show shape data")]
            //public bool show_data_format { get; set; } = false;
            public bool ShouldSerializedata_format() { return visibleParams.Contains("data_format"); }
            //public bool ShouldSerializeshow_data_format() { return _parent.show_nodeConfig; }

            public List<object> dilation_rate { get; set; }
            //[Category("JSON"), Description("Config Json file to show shape data")]
            //public bool show_dilation_rate { get; set; } = false;
            public bool ShouldSerializedilation_rate() { return visibleParams.Contains("dilation_rate"); }
            //public bool ShouldSerializeshow_dilation_rate() { return _parent.show_nodeConfig; }

            public string activation { get; set; }
            //[Category("JSON"), Description("Config Json file to show shape data")]
            //public bool show_activation { get; set; } = false;
            public bool ShouldSerializeactivation() { return visibleParams.Contains("activation"); }
            //public bool ShouldSerializeshow_activation() { return _parent.show_nodeConfig; }

            public bool use_bias { get; set; }
            //[Category("JSON"), Description("Config Json file to show shape data")]
            //public bool show_use_bias { get; set; } = false;
            public bool ShouldSerializeuse_bias() { return visibleParams.Contains("use_bias"); }
            //public bool ShouldSerializeshow_use_bias() { return _parent.show_nodeConfig; }

            public Kernel_initializer kernel_initializer { get; set; }
            public class Kernel_initializer
            {
                public Kernel_initializer()
                {
                    config = new Config();
                }
                public string class_name { get; set; }
                public Config config { get; set; }
                public class Config
                {
                    public float scale { get; set; }
                    public string mode { get; set; }
                    public string distribution { get; set; }
                    public string seed { get; set; }

                }

            }
            //[Category("JSON"), Description("Config Json file to show shape data")]
            //public bool show_kernel_initializer { get; set; } = false;
            public bool ShouldSerializekernel_initializer() { return visibleParams.Contains("kernel_initializer"); }
            //public bool ShouldSerializeshow_kernel_initializer() { return _parent.show_nodeConfig; }

            public Bias_initializer bias_initializer { get; set; }
            public class Bias_initializer
            {
                public Bias_initializer()
                {

                }
                public string class_name { get; set; }
                public Config config { get; set; }
                public class Config
                {
                    public float scale { get; set; }
                    public string mode { get; set; }
                    public string distribution { get; set; }
                    public string seed { get; set; }

                }
            }
            //[Category("JSON"), Description("Config Json file to show shape data")]
            //public bool show_bias_initializer { get; set; } = false;
            public bool ShouldSerializebias_initializer() { return visibleParams.Contains("bias_initializer"); }
            //public bool ShouldSerializeshow_bias_initializer() { return _parent.show_nodeConfig; }

            public string kernel_regularizer { get; set; }
            //[Category("JSON"), Description("Config Json file to show shape data")]
            //public bool show_kernel_regularizer { get; set; } = false;
            public bool ShouldSerializekernel_regularizer() { return visibleParams.Contains("kernel_regularizer"); }
            //public bool ShouldSerializeshow_kernel_regularizer() { return _parent.show_nodeConfig; }

            public string bias_regularizer { get; set; }
            //[Category("JSON"), Description("Config Json file to show shape data")]
            //public bool show_bias_regularizer { get; set; } = false;
            public bool ShouldSerializebias_regularizer() { return visibleParams.Contains("bias_regularizer"); }
            //public bool ShouldSerializeshow_bias_regularizer() { return _parent.show_nodeConfig; }

            public string activity_regularizer { get; set; }
            //[Category("JSON"), Description("Config Json file to show shape data")]
            //public bool show_activity_regularizer { get; set; } = false;
            public bool ShouldSerializeactivity_regularizer() { return visibleParams.Contains("activity_regularizer"); }
            //public bool ShouldSerializeshow_activity_regularizer() { return _parent.show_nodeConfig; }

            public string kernel_constraint { get; set; }
            //[Category("JSON"), Description("Config Json file to show shape data")]
            //public bool show_kernel_constraint { get; set; } = false;
            public bool ShouldSerializekernel_constraint() { return visibleParams.Contains("kernel_constraint"); }
            //public bool ShouldSerializeshow_kernel_constraint() { return _parent.show_nodeConfig; }

            public string bias_constraint { get; set; }
            //[Category("JSON"), Description("Config Json file to show shape data")]
            //public bool show_bias_constraint { get; set; } = false;
            public bool ShouldSerializebias_constraint() { return visibleParams.Contains("bias_constraint"); }
            //public bool ShouldSerializeshow_bias_constraint() { return _parent.show_nodeConfig; }

            //MaxPooling
            public List<int> pool_size { get; set; }
            //[Category("JSON"), Description("Config Json file to show shape data")]
            //public bool show_pool_size { get; set; } = false;
            public bool ShouldSerializepool_size() { return visibleParams.Contains("pool_size"); }
            //public bool ShouldSerializeshow_pool_size() { return _parent.show_nodeConfig; }
            #endregion

            [JsonIgnore]
            private CopyOfLayer _parent;

            public Config(CopyOfLayer l)
            {

                _parent = l;
                batch_input_shape = new List<object>();
                kernel_size = new List<object>();
                strides = new List<object>();
                dilation_rate = new List<object>();
                bias_initializer = new Bias_initializer();
                kernel_initializer = new Kernel_initializer();
                pool_size = new List<int>();

            }

            public List<string> visibleParams = new List<string>();
            public bool ShouldSerializevisibleParams() { return _parent.show_nodeConfig; }

        }


        public NodeConfig nodeConfig { get; set; }
        [JsonIgnore]
        public bool show_nodeConfig { get; set; } = false;
        public bool ShouldSerializenodeConfig() { return show_nodeConfig; }


        public class NodeConfig
        {
            public float width { get; set; } = 100;
            public float height { get; set; } = 100;
            public List<Port> incomingPorts { set; get; } = new List<Port>();
            public List<Port> outgoingPorts { set; get; } = new List<Port>();
            public class Port
            {
                public string name { set; get; } = "";
            }
        }

    }
}