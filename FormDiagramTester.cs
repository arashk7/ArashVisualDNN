using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MindFusion.Diagramming.Layout;
using MindFusion.Diagramming;
using MindFusion.Drawing;
using MindFusion.Diagramming.Commands;

using Newtonsoft.Json.Linq;
namespace ArashVisualDNNEditor_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public enum LayerType { CONV1D, CONV2D, CONV3D, DENSE, FLATTEN, CONCAT, CUSTOM};
       
        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            DoDragDrop("Conv", DragDropEffects.Copy);
            Console.WriteLine("mousedown");
        }

        private void diagramView_DragDrop(object sender, DragEventArgs e)
        {
            //Console.WriteLine("okokok");
            if (e.Data.GetDataPresent(typeof(string)))
            {
                
                Object item = (object)e.Data.GetData(typeof(string));

                // Perform drag-and-drop, depending upon the effect.
                if (e.Effect == DragDropEffects.Copy ||
                    e.Effect == DragDropEffects.Move)
                {
                    //string str = (string)e.Data.GetData(typeof(string));
                    Point p = diagramView.PointToClient(new Point(e.X, e.Y));
                    PointF pt = diagramView.ClientToDoc(new Point(p.X, p.Y));
                    
                    ShapeNode b = diagram.Factory.CreateShapeNode(pt, new SizeF(60, 60));
                    Color defAnch = Color.Red;
                    AnchorPattern ap = new AnchorPattern(new AnchorPoint[]
                        {
                            new AnchorPoint(0, 50, true, false, MarkStyle.Circle, defAnch),
                            new AnchorPoint(100, 50, false, true, MarkStyle.Circle, defAnch)
                            
                        });
                    b.Shape = Shape.FromId("RoundRectangle");
                    b.AnchorPattern = ap;
                    b.HandlesStyle = HandlesStyle.DashFrame;
                    b.Text = (string)item;
                }
            }
            
        }

        private void diagramView_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(string)))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            string text = System.IO.File.ReadAllText(@"model2.json");
            JObject rss = JObject.Parse(text);

            List<JToken> layer_list = rss["config"]["layers"].Children().ToList();//[0]["class_name"];
            foreach(JToken jlayer in layer_list)
            {
                Layer layer = jlayer.ToObject<Layer>();
                listBox1.Items.Add(layer.name);
                switch (layer.class_name)
                {
                    case "Conv3D":
                        {
                            Conv3DConfig config = jlayer["config"].ToObject<Conv3DConfig>();
                            listBox1.Items.Add(config.padding);
                        }
                        break;
                    case "Conv1D":
                        {
                            Conv1DConfig config = jlayer["config"].ToObject<Conv1DConfig>();
                            listBox1.Items.Add(config.padding);
                        }
                        break;
                    default:
                        break;
                }
               
            }
            
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            DoDragDrop("Dense", DragDropEffects.Copy);
        }
        private class Node
        {
            public Node(AnchorPattern anchor,
                Shape template, string name)
            {
                _anchor = anchor;
                _template = template;
                _name = name;
            }

            public AnchorPattern Anchor
            {
                get { return _anchor; }
            }

            public Shape Template
            {
                get { return _template; }
            }

            public string Name
            {
                get { return _name; }
            }

            private AnchorPattern _anchor;
            private Shape _template;
            private string _name;
        }

    }

}
