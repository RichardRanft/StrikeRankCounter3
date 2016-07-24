namespace SRC3
{
    partial class FOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FOptions));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxResetSnd = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nudRankPerRnd = new System.Windows.Forms.NumericUpDown();
            this.ofdResetOpen = new System.Windows.Forms.OpenFileDialog();
            this.btnBrowseBasePath = new System.Windows.Forms.Button();
            this.tbxBaseSoundPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fbdBrowse = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.nudRankPerRnd)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(235, 137);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(154, 137);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Reset Sound";
            // 
            // tbxResetSnd
            // 
            this.tbxResetSnd.Location = new System.Drawing.Point(12, 66);
            this.tbxResetSnd.Name = "tbxResetSnd";
            this.tbxResetSnd.Size = new System.Drawing.Size(217, 20);
            this.tbxResetSnd.TabIndex = 5;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(235, 64);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 6;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Ranks per Round";
            // 
            // nudRankPerRnd
            // 
            this.nudRankPerRnd.Location = new System.Drawing.Point(12, 106);
            this.nudRankPerRnd.Name = "nudRankPerRnd";
            this.nudRankPerRnd.Size = new System.Drawing.Size(54, 20);
            this.nudRankPerRnd.TabIndex = 8;
            // 
            // btnBrowseBasePath
            // 
            this.btnBrowseBasePath.Location = new System.Drawing.Point(236, 24);
            this.btnBrowseBasePath.Name = "btnBrowseBasePath";
            this.btnBrowseBasePath.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseBasePath.TabIndex = 11;
            this.btnBrowseBasePath.Text = "Browse";
            this.btnBrowseBasePath.UseVisualStyleBackColor = true;
            this.btnBrowseBasePath.Click += new System.EventHandler(this.btnBrowseBasePath_Click);
            // 
            // tbxBaseSoundPath
            // 
            this.tbxBaseSoundPath.Location = new System.Drawing.Point(13, 26);
            this.tbxBaseSoundPath.Name = "tbxBaseSoundPath";
            this.tbxBaseSoundPath.Size = new System.Drawing.Size(217, 20);
            this.tbxBaseSoundPath.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Base Audio Path";
            // 
            // FOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 170);
            this.ControlBox = false;
            this.Controls.Add(this.btnBrowseBasePath);
            this.Controls.Add(this.tbxBaseSoundPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudRankPerRnd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.tbxResetSnd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FOptions";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.FOptions_Load);
            this.VisibleChanged += new System.EventHandler(this.FOptions_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.nudRankPerRnd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxResetSnd;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudRankPerRnd;
        private System.Windows.Forms.OpenFileDialog ofdResetOpen;
        private System.Windows.Forms.Button btnBrowseBasePath;
        private System.Windows.Forms.TextBox tbxBaseSoundPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog fbdBrowse;
    }
}