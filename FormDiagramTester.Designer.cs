namespace ArashVisualDNNEditor_1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.diagramView = new MindFusion.Diagramming.WinForms.DiagramView();
            this.diagram = new MindFusion.Diagramming.Diagram();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // diagramView
            // 
            this.diagramView.AllowDrop = true;
            this.diagramView.Behavior = MindFusion.Diagramming.Behavior.DrawLinks;
            this.diagramView.Diagram = this.diagram;
            this.diagramView.LicenseKey = null;
            this.diagramView.Location = new System.Drawing.Point(12, 12);
            this.diagramView.Name = "diagramView";
            this.diagramView.Size = new System.Drawing.Size(1059, 619);
            this.diagramView.TabIndex = 8;
            this.diagramView.Text = "diagramView1";
            this.diagramView.DragDrop += new System.Windows.Forms.DragEventHandler(this.diagramView_DragDrop);
            this.diagramView.DragOver += new System.Windows.Forms.DragEventHandler(this.diagramView_DragOver);
            // 
            // diagram
            // 
            this.diagram.BackBrush = new MindFusion.Drawing.SolidBrush("#FF808080");
            this.diagram.GridColor = System.Drawing.Color.White;
            this.diagram.GridOffsetX = 0F;
            this.diagram.GridOffsetY = 0F;
            this.diagram.GridSizeX = 30F;
            this.diagram.GridSizeY = 30F;
            this.diagram.LinkBaseShapeSize = 12F;
            this.diagram.LinkHeadShapeSize = 12F;
            this.diagram.LinkIntermediateShapeSize = 12F;
            this.diagram.MeasureUnit = MindFusion.Diagramming.MeasureUnit.Pixel;
            this.diagram.RoutingOptions.GridSize = 16F;
            this.diagram.RoutingOptions.NodeVicinitySize = 48F;
            this.diagram.SelectAfterCreate = false;
            this.diagram.ShapeNodeStyle.Brush = new MindFusion.Drawing.SolidBrush("#FF00BFFF");
            this.diagram.ShowAnchors = MindFusion.Diagramming.ShowAnchors.Always;
            this.diagram.ShowGrid = true;
            this.diagram.TouchThreshold = 0F;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1182, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 83);
            this.button1.TabIndex = 9;
            this.button1.Text = "Conv";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1182, 176);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(166, 78);
            this.button2.TabIndex = 10;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 24;
            this.listBox1.Location = new System.Drawing.Point(1195, 353);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(239, 244);
            this.listBox1.TabIndex = 11;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1378, 39);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(161, 82);
            this.button3.TabIndex = 12;
            this.button3.Text = "Dense";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button3_MouseDown);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1591, 643);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.diagramView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private MindFusion.Diagramming.WinForms.DiagramView diagramView;
        private MindFusion.Diagramming.Diagram diagram;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button3;
    }
}