using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using MindFusion.Diagramming.Layout;
using MindFusion.Diagramming;
using MindFusion.Drawing;

using MindFusion.Diagramming.Commands;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

using Telerik.WinControls.UI;

using System.Linq.Expressions;
namespace ArashVisualDNNEditor_1
{
    public partial class RadRibbonForm1 : Telerik.WinControls.UI.RadRibbonForm
    {
        private DiagramNode node;
        public RadRibbonForm1()
        {
            InitializeComponent();
        }
        private void radButton1_MouseDown(object sender, MouseEventArgs e)
        {
                        
            DoDragDrop(LayerType.CONV3D, DragDropEffects.Copy);
        }
        private void radButton2_MouseDown(object sender, MouseEventArgs e)
        {
            DoDragDrop(LayerType.DENSE, DragDropEffects.Copy);
        }
        private void diagramView_DragDrop(object sender, DragEventArgs e)
        {
            //Console.WriteLine("okokok");
            if (e.Data.GetDataPresent(typeof(Layer)))
            {

                object item = (object)e.Data.GetData(typeof(Layer));

                // Perform drag-and-drop, depending upon the effect.
                if (e.Effect == DragDropEffects.Copy ||
                    e.Effect == DragDropEffects.Move)
                {
                    //string str = (string)e.Data.GetData(typeof(string));
                    Point p = diagramView.PointToClient(new Point(e.X, e.Y));
                    PointF pt = diagramView.ClientToDoc(new Point(p.X, p.Y));
                    Layer l = (Layer)item;

                    ShapeNode b = diagram.Factory.CreateShapeNode(pt, new SizeF(l.nodeConfig.width, l.nodeConfig.height));
                    Color colorAnch = Color.Red;
                    List<AnchorPoint> anchors = new List<AnchorPoint>();
                    for (int i = 0; i < l.nodeConfig.incomingPorts.Count; i++)
                        anchors.Add(new AnchorPoint(0, (i + 1) * (100 / (l.nodeConfig.incomingPorts.Count + 1)), true, false, MarkStyle.Circle, colorAnch));
                    for (int i = 0; i < l.nodeConfig.outgoingPorts.Count; i++)
                        anchors.Add(new AnchorPoint(100, (i + 1) * (100 / (l.nodeConfig.outgoingPorts.Count + 1)), false, true, MarkStyle.Circle, colorAnch));
                    //AnchorPattern ap = new AnchorPattern(new AnchorPoint[]
                    //    {
                    //        new AnchorPoint(0, 50, true, false, MarkStyle.Circle, defAnch),
                    //        new AnchorPoint(100, 50, false, true, MarkStyle.Circle, defAnch)

                    //    });

                    b.Shape = Shape.FromId("RoundRectangle");
                    b.AnchorPattern = new AnchorPattern(anchors.ToArray());
                    b.HandlesStyle = HandlesStyle.DashFrame;

                    b.Text = l.class_name;
                    b.Tag = l;
                }
            }
        }
        public T Convert<T>(object o)
        {
            T one = (T)Enum.Parse(typeof(T), o.ToString());
            return one;
        }
        private void diagramView_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Layer)))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
        private void radButton3_Click(object sender, EventArgs e)
        {
            string text = System.IO.File.ReadAllText(@"model2.json");
            JObject rss = JObject.Parse(text);

            List<JToken> layer_list = rss["config"]["layers"].Children().ToList();//[0]["class_name"];
            foreach (JToken jlayer in layer_list)
            {
                Layer layer = jlayer.ToObject<Layer>();
                //listBox1.Items.Add(layer.name);
                switch (layer.class_name)
                {
                    case "Conv3D":
                        {
                            Conv3DConfig config = jlayer["config"].ToObject<Conv3DConfig>();
                            //listBox1.Items.Add(config.padding);
                            MessageBox.Show(config.padding);
                        }
                        break;
                    case "Conv1D":
                        {
                            Conv1DConfig config = jlayer["config"].ToObject<Conv1DConfig>();
                            //listBox1.Items.Add(config.padding);
                        }
                        break;
                    default:
                        break;
                }

            }
        }
        private void radButton5_MouseDown(object sender, MouseEventArgs e)
        {
            DoDragDrop(LayerType.INPUT, DragDropEffects.Copy);
        }
        public void ShowProperties(RadPropertyGrid pg, Layer.Config config)
        {
            for (int i = 0; i < pg.Items.Count; ++i)
            {
                PropertyGridItem prop = pg.Items[i] as PropertyGridItem;
                prop.Visible = false;
                try
                {
                    prop.Visible = config.visibleParams.Contains(prop.Name);
                }
                catch { }
            }

        }
        //static string GetVariableName<T>(Expression<Func<T>> expr)
        //{
        //    var body = (MemberExpression)expr.Body;

        //    return body.Member.Name;
        //}
        //private bool ShowItemProperty(string name)
        //{
        //    switch(name)
        //    {
        //        case ""
        //    }
        //    return false;
        //}
        private void diagram_NodeSelected(object sender, NodeEventArgs e)
        {
            node = e.Node;
            Layer layer = ((Layer)e.Node.Tag);
            radPropertyGrid1.SelectedObject = layer.config;
            ShowProperties(radPropertyGrid1, layer.config);
            
        }
        private void radButton4_Click(object sender, EventArgs e)
        {
            Layer layer = ((Layer)node.Tag);

            LayerSetting.SaveSetting((Layer)node.Tag, true);

            //Model test = new Model();
            //Layer layer1 = new Layer(LayerType.MAXPOOLING1D);
            ////layer1.config.batch_input_shape = new List<object> { null, 5, 5, 5, 1 };
            //layer1.class_name = "MaxPooling1D";
            //layer1.name = "max_pooling1d";
            //layer1.config.name = "max_pooling1d";
            //layer1.config.trainable = true;
            ////layer1.config.units = 50;
                        
            ////layer1.config.kernel_size = new List<object> { 2, 2 };
            //layer1.config.strides = new List<object> { 2 };
            //layer1.config.pool_size = new List<int> { 2 };
            //layer1.config.padding = "valid";
            
            
            //layer1.config.data_format = "channels_last";
            //layer1.config.dilation_rate = new List<object> { 1, 1 };
            //layer1.config.activation = "linear";
            //layer1.config.use_bias = true;
            //layer1.config.kernel_initializer.class_name = "VarianceScaling";
            //layer1.config.kernel_initializer.config.scale = 1.0f;
            //layer1.config.kernel_initializer.config.mode = "fan_avg";
            //layer1.config.kernel_initializer.config.distribution = "uniform";
            //layer1.config.kernel_initializer.config.seed = null;
            //layer1.config.bias_initializer.class_name = "Zeros";



            //string json_layer = JsonConvert.SerializeObject(layer1);
            //File.WriteAllText(@"./Layers/MaxPooling1D.json", json_layer);

            //Layer layer2 = new Layer(LayerType.CONV3D);
            ////radPropertyGrid1.SelectedObject = layer1;

            //test.config.layers.Add(layer1);
            //test.config.layers.Add(layer2);            

            //test.config.input_layers.Add(new List<object>{"null",0,0 });
            //test.config.input_layers.Add(new List<object> { "input1", 0, 0 });

            //test.config.output_layers.Add(new List<object> { "output1", 0, 0 });
            //string json = JsonConvert.SerializeObject(test);
            //File.WriteAllText(@"model1.json",json);
            //Console.Write(json);

            
        }
        private void radListView1_MouseDown(object sender, MouseEventArgs e)
        {
            
            
        }
        private void radListView1_RootElement_MouseDown(object sender, MouseEventArgs e)
        {
            
        }
        private void radListView1_ItemMouseDown(object sender, Telerik.WinControls.UI.ListViewItemMouseEventArgs e)
        {
            DoDragDrop(e.Item.Key, DragDropEffects.Copy);       
        }
        private void LoadLayers()
        {
            LayerSetting.LoadLayers();
            radListView1.Items.Clear();
            for (int i = 0; i < LayerSetting.layerClasses.Count; i++)
            {
                Layer l = LayerSetting.layerClasses[i];
                ListViewDataItem item = new ListViewDataItem();
                item.Text = l.class_name;
                item.Group = radListView1.Groups[0];
                item.Key = l;
                radListView1.Items.Add(item);
            }
        }
        private void RadRibbonForm1_Load(object sender, EventArgs e)
        {
            LoadLayers();
        }

        private void radButtonElement1_Click(object sender, EventArgs e)
        {
            ((Layer)node.Tag).nodeConfig = new Layer.NodeConfig();
            ((Layer)node.Tag).nodeConfig.incomingPorts.Add(new Layer.NodeConfig.Port());
            ((Layer)node.Tag).nodeConfig.incomingPorts.Add(new Layer.NodeConfig.Port());
        }
    }
}
