namespace MapProgress
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
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.KMLFile = new System.Windows.Forms.Button();
            this.InspectedFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.Check = new System.Windows.Forms.Button();
            this.ZoomIn = new System.Windows.Forms.Button();
            this.ZoomOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gMapControl1
            // 
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemmory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(240, 22);
            this.gMapControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 18;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomEnabled = true;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(614, 446);
            this.gMapControl1.TabIndex = 0;
            this.gMapControl1.Zoom = 7D;
            // 
            // KMLFile
            // 
            this.KMLFile.Location = new System.Drawing.Point(38, 39);
            this.KMLFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.KMLFile.Name = "KMLFile";
            this.KMLFile.Size = new System.Drawing.Size(78, 22);
            this.KMLFile.TabIndex = 1;
            this.KMLFile.Text = "GeoJSON File";
            this.KMLFile.UseVisualStyleBackColor = true;
            this.KMLFile.Click += new System.EventHandler(this.KMLFile_Click);
            // 
            // InspectedFile
            // 
            this.InspectedFile.Location = new System.Drawing.Point(38, 77);
            this.InspectedFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.InspectedFile.Name = "InspectedFile";
            this.InspectedFile.Size = new System.Drawing.Size(78, 23);
            this.InspectedFile.TabIndex = 2;
            this.InspectedFile.Text = "Inspected";
            this.InspectedFile.UseVisualStyleBackColor = true;
            this.InspectedFile.Click += new System.EventHandler(this.InspectedFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // Check
            // 
            this.Check.Location = new System.Drawing.Point(38, 160);
            this.Check.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Check.Name = "Check";
            this.Check.Size = new System.Drawing.Size(56, 19);
            this.Check.TabIndex = 3;
            this.Check.Text = "Check";
            this.Check.UseVisualStyleBackColor = true;
            this.Check.Click += new System.EventHandler(this.Check_Click);
            // 
            // ZoomIn
            // 
            this.ZoomIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.ZoomIn.Location = new System.Drawing.Point(804, 28);
            this.ZoomIn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ZoomIn.Name = "ZoomIn";
            this.ZoomIn.Size = new System.Drawing.Size(38, 33);
            this.ZoomIn.TabIndex = 4;
            this.ZoomIn.Text = "+";
            this.ZoomIn.UseVisualStyleBackColor = true;
            this.ZoomIn.Click += new System.EventHandler(this.ZoomIn_Click);
            // 
            // ZoomOut
            // 
            this.ZoomOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.ZoomOut.Location = new System.Drawing.Point(804, 67);
            this.ZoomOut.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ZoomOut.Name = "ZoomOut";
            this.ZoomOut.Size = new System.Drawing.Size(38, 33);
            this.ZoomOut.TabIndex = 5;
            this.ZoomOut.Text = "-";
            this.ZoomOut.UseVisualStyleBackColor = true;
            this.ZoomOut.Click += new System.EventHandler(this.ZoomOut_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 492);
            this.Controls.Add(this.ZoomOut);
            this.Controls.Add(this.ZoomIn);
            this.Controls.Add(this.Check);
            this.Controls.Add(this.InspectedFile);
            this.Controls.Add(this.KMLFile);
            this.Controls.Add(this.gMapControl1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Map Progress";
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.Button KMLFile;
        private System.Windows.Forms.Button InspectedFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Button Check;
        private System.Windows.Forms.Button ZoomIn;
        private System.Windows.Forms.Button ZoomOut;
    }
}

