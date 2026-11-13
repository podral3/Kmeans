namespace Kmeans
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            picChart = new PictureBox();
            cmbDistance = new ComboBox();
            numClusters = new NumericUpDown();
            numIterations = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            btnStart = new Button();
            btnRun = new Button();
            btnSave = new Button();
            lblIteration = new Label();
            txtReport = new TextBox();
            ((System.ComponentModel.ISupportInitialize)picChart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numClusters).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numIterations).BeginInit();
            SuspendLayout();
            // 
            // picChart
            // 
            picChart.Location = new Point(368, 41);
            picChart.Name = "picChart";
            picChart.Size = new Size(500, 500);
            picChart.TabIndex = 0;
            picChart.TabStop = false;
            // 
            // cmbDistance
            // 
            cmbDistance.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDistance.FormattingEnabled = true;
            cmbDistance.Location = new Point(91, 64);
            cmbDistance.Name = "cmbDistance";
            cmbDistance.Size = new Size(121, 23);
            cmbDistance.TabIndex = 1;
            // 
            // numClusters
            // 
            numClusters.Location = new Point(91, 157);
            numClusters.Maximum = new decimal(new int[] { 8, 0, 0, 0 });
            numClusters.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numClusters.Name = "numClusters";
            numClusters.Size = new Size(44, 23);
            numClusters.TabIndex = 2;
            numClusters.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numIterations
            // 
            numIterations.Location = new Point(163, 157);
            numIterations.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numIterations.Name = "numIterations";
            numIterations.Size = new Size(49, 23);
            numIterations.TabIndex = 3;
            numIterations.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(163, 139);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 4;
            label1.Text = "Iteracje";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(91, 139);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 5;
            label2.Text = "Klastry";
            // 
            // btnStart
            // 
            btnStart.Location = new Point(91, 274);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 6;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnRun
            // 
            btnRun.Location = new Point(181, 274);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(75, 23);
            btnRun.TabIndex = 7;
            btnRun.Text = "Run";
            btnRun.UseVisualStyleBackColor = true;
            btnRun.Click += btnRun_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(272, 274);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lblIteration
            // 
            lblIteration.AutoSize = true;
            lblIteration.Location = new Point(95, 360);
            lblIteration.Name = "lblIteration";
            lblIteration.Size = new Size(60, 15);
            lblIteration.TabIndex = 9;
            lblIteration.Text = "Iteration:0";
            // 
            // txtReport
            // 
            txtReport.Location = new Point(46, 417);
            txtReport.Multiline = true;
            txtReport.Name = "txtReport";
            txtReport.Size = new Size(301, 124);
            txtReport.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(912, 601);
            Controls.Add(txtReport);
            Controls.Add(lblIteration);
            Controls.Add(btnSave);
            Controls.Add(btnRun);
            Controls.Add(btnStart);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(numIterations);
            Controls.Add(numClusters);
            Controls.Add(cmbDistance);
            Controls.Add(picChart);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)picChart).EndInit();
            ((System.ComponentModel.ISupportInitialize)numClusters).EndInit();
            ((System.ComponentModel.ISupportInitialize)numIterations).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picChart;
        private ComboBox cmbDistance;
        private NumericUpDown numClusters;
        private NumericUpDown numIterations;
        private Label label1;
        private Label label2;
        private Button btnStart;
        private Button btnRun;
        private Button btnSave;
        private Label lblIteration;
        private TextBox txtReport;
    }
}
