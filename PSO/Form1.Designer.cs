namespace PSO
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
            components = new System.ComponentModel.Container();
            panelGraph = new Panel();
            btnStart = new Button();
            btnStop = new Button();
            btnReset = new Button();
            btnExport = new Button();
            numEntities = new NumericUpDown();
            numIterations = new NumericUpDown();
            numRI = new NumericUpDown();
            numRG = new NumericUpDown();
            numRL = new NumericUpDown();
            lblIterations = new Label();
            lblBestValue = new Label();
            lblBestPosition = new Label();
            timerPSO = new Label();
            label5 = new Label();
            timer = new System.Windows.Forms.Timer(components);
            lblEntitesCount = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)numEntities).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numIterations).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRI).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRG).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRL).BeginInit();
            SuspendLayout();
            // 
            // panelGraph
            // 
            panelGraph.Location = new System.Drawing.Point(207, 59);
            panelGraph.Name = "panelGraph";
            panelGraph.Size = new Size(200, 200);
            panelGraph.TabIndex = 0;
            // 
            // btnStart
            // 
            btnStart.Location = new System.Drawing.Point(26, 481);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 1;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            btnStop.Location = new System.Drawing.Point(113, 481);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(75, 23);
            btnStop.TabIndex = 2;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            btnReset.Location = new System.Drawing.Point(194, 481);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(75, 23);
            btnReset.TabIndex = 3;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            btnExport.Location = new System.Drawing.Point(275, 481);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(75, 23);
            btnExport.TabIndex = 4;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = false;
            // 
            // numEntities
            // 
            numEntities.Location = new System.Drawing.Point(22, 411);
            numEntities.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            numEntities.Name = "numEntities";
            numEntities.Size = new Size(60, 23);
            numEntities.TabIndex = 5;
            numEntities.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // numIterations
            // 
            numIterations.Location = new System.Drawing.Point(113, 411);
            numIterations.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numIterations.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numIterations.Name = "numIterations";
            numIterations.Size = new Size(60, 23);
            numIterations.TabIndex = 6;
            numIterations.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // numRI
            // 
            numRI.DecimalPlaces = 2;
            numRI.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numRI.Location = new System.Drawing.Point(207, 411);
            numRI.Name = "numRI";
            numRI.Size = new Size(60, 23);
            numRI.TabIndex = 7;
            numRI.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numRG
            // 
            numRG.DecimalPlaces = 2;
            numRG.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numRG.Location = new System.Drawing.Point(296, 411);
            numRG.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            numRG.Name = "numRG";
            numRG.Size = new Size(60, 23);
            numRG.TabIndex = 8;
            numRG.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numRL
            // 
            numRL.DecimalPlaces = 2;
            numRL.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numRL.Location = new System.Drawing.Point(388, 411);
            numRL.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            numRL.Name = "numRL";
            numRL.Size = new Size(60, 23);
            numRL.TabIndex = 9;
            numRL.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblIterations
            // 
            lblIterations.AutoSize = true;
            lblIterations.Location = new System.Drawing.Point(51, 106);
            lblIterations.Name = "lblIterations";
            lblIterations.Size = new Size(38, 15);
            lblIterations.TabIndex = 10;
            lblIterations.Text = "label1";
            // 
            // lblBestValue
            // 
            lblBestValue.AutoSize = true;
            lblBestValue.Location = new System.Drawing.Point(51, 145);
            lblBestValue.Name = "lblBestValue";
            lblBestValue.Size = new Size(38, 15);
            lblBestValue.TabIndex = 11;
            lblBestValue.Text = "label2";
            // 
            // lblBestPosition
            // 
            lblBestPosition.AutoSize = true;
            lblBestPosition.Location = new System.Drawing.Point(51, 186);
            lblBestPosition.Name = "lblBestPosition";
            lblBestPosition.Size = new Size(38, 15);
            lblBestPosition.TabIndex = 12;
            lblBestPosition.Text = "label3";
            // 
            // timerPSO
            // 
            timerPSO.AutoSize = true;
            timerPSO.Location = new System.Drawing.Point(51, 59);
            timerPSO.Name = "timerPSO";
            timerPSO.Size = new Size(38, 15);
            timerPSO.TabIndex = 13;
            timerPSO.Text = "label4";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(51, 214);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 14;
            label5.Text = "label5";
            // 
            // timer
            // 
            timer.Interval = 200;
            // 
            // lblEntitesCount
            // 
            lblEntitesCount.AutoSize = true;
            lblEntitesCount.Location = new System.Drawing.Point(22, 382);
            lblEntitesCount.Name = "lblEntitesCount";
            lblEntitesCount.Size = new Size(45, 15);
            lblEntitesCount.TabIndex = 15;
            lblEntitesCount.Text = "Entities";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(113, 382);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 16;
            label1.Text = "Iteracje";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(207, 382);
            label2.Name = "label2";
            label2.Size = new Size(17, 15);
            label2.TabIndex = 17;
            label2.Text = "RI";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(296, 382);
            label3.Name = "label3";
            label3.Size = new Size(22, 15);
            label3.TabIndex = 18;
            label3.Text = "RG";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(388, 382);
            label4.Name = "label4";
            label4.Size = new Size(20, 15);
            label4.TabIndex = 19;
            label4.Text = "RL";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 525);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblEntitesCount);
            Controls.Add(label5);
            Controls.Add(timerPSO);
            Controls.Add(lblBestPosition);
            Controls.Add(lblBestValue);
            Controls.Add(lblIterations);
            Controls.Add(numRL);
            Controls.Add(numRG);
            Controls.Add(numRI);
            Controls.Add(numIterations);
            Controls.Add(numEntities);
            Controls.Add(btnExport);
            Controls.Add(btnReset);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(panelGraph);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numEntities).EndInit();
            ((System.ComponentModel.ISupportInitialize)numIterations).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRI).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRG).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRL).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelGraph;
        private Button btnStart;
        private Button btnStop;
        private Button btnReset;
        private Button btnExport;
        private NumericUpDown numEntities;
        private NumericUpDown numIterations;
        private NumericUpDown numRI;
        private NumericUpDown numRG;
        private NumericUpDown numRL;
        private Label lblIterations;
        private Label lblBestValue;
        private Label lblBestPosition;
        private Label timerPSO;
        private Label label5;
        private System.Windows.Forms.Timer timer;
        private Label lblEntitesCount;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
