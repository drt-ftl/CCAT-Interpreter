namespace CCAT_Interpreter_Form
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
            this.OpenButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.UpperReadoutLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.UpDown_PointsPerSample = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown_PointsPerSample)).BeginInit();
            this.SuspendLayout();
            // 
            // OpenButton
            // 
            this.OpenButton.Location = new System.Drawing.Point(13, 13);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(75, 23);
            this.OpenButton.TabIndex = 0;
            this.OpenButton.Text = "Open File";
            this.OpenButton.UseVisualStyleBackColor = true;
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Comma Separated Values (*.csv)|*.csv";
            this.openFileDialog1.InitialDirectory = "C:\\Users\\David\\Dropbox (FTL Labs Corporation)\\FTL General\\VAME";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // UpperReadoutLabel
            // 
            this.UpperReadoutLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UpperReadoutLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.UpperReadoutLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UpperReadoutLabel.Location = new System.Drawing.Point(103, 13);
            this.UpperReadoutLabel.Name = "UpperReadoutLabel";
            this.UpperReadoutLabel.Size = new System.Drawing.Size(335, 101);
            this.UpperReadoutLabel.TabIndex = 3;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(13, 89);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 5;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // UpDown_PointsPerSample
            // 
            this.UpDown_PointsPerSample.Location = new System.Drawing.Point(13, 54);
            this.UpDown_PointsPerSample.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UpDown_PointsPerSample.Name = "UpDown_PointsPerSample";
            this.UpDown_PointsPerSample.Size = new System.Drawing.Size(75, 20);
            this.UpDown_PointsPerSample.TabIndex = 6;
            this.UpDown_PointsPerSample.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.UpDown_PointsPerSample.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UpDown_PointsPerSample.ValueChanged += new System.EventHandler(this.UpDown_PointsPerSample_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 123);
            this.Controls.Add(this.UpDown_PointsPerSample);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.UpperReadoutLabel);
            this.Controls.Add(this.OpenButton);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.UpDown_PointsPerSample)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label UpperReadoutLabel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.NumericUpDown UpDown_PointsPerSample;
    }
}

