namespace ResxAutoTranslator
{
    partial class MainForm
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
            this.lblSelectRootFolder = new System.Windows.Forms.Label();
            this.lblFromLanguage = new System.Windows.Forms.Label();
            this.lblToLanguage = new System.Windows.Forms.Label();
            this.lblAuthorizationKey = new System.Windows.Forms.Label();
            this.tbRootFolder = new System.Windows.Forms.TextBox();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.cbSourceLanguage = new System.Windows.Forms.ComboBox();
            this.cbDestinationLanguage = new System.Windows.Forms.ComboBox();
            this.tbKey = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.cxBUseFallbackResx = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblSelectRootFolder
            // 
            this.lblSelectRootFolder.AutoSize = true;
            this.lblSelectRootFolder.Location = new System.Drawing.Point(12, 26);
            this.lblSelectRootFolder.Name = "lblSelectRootFolder";
            this.lblSelectRootFolder.Size = new System.Drawing.Size(95, 13);
            this.lblSelectRootFolder.TabIndex = 0;
            this.lblSelectRootFolder.Text = "Select Root Folder";
            // 
            // lblFromLanguage
            // 
            this.lblFromLanguage.AutoSize = true;
            this.lblFromLanguage.Location = new System.Drawing.Point(12, 52);
            this.lblFromLanguage.Name = "lblFromLanguage";
            this.lblFromLanguage.Size = new System.Drawing.Size(81, 13);
            this.lblFromLanguage.TabIndex = 1;
            this.lblFromLanguage.Text = "From Language";
            // 
            // lblToLanguage
            // 
            this.lblToLanguage.AutoSize = true;
            this.lblToLanguage.Location = new System.Drawing.Point(12, 79);
            this.lblToLanguage.Name = "lblToLanguage";
            this.lblToLanguage.Size = new System.Drawing.Size(71, 13);
            this.lblToLanguage.TabIndex = 2;
            this.lblToLanguage.Text = "To Language";
            // 
            // lblAuthorizationKey
            // 
            this.lblAuthorizationKey.AutoSize = true;
            this.lblAuthorizationKey.Location = new System.Drawing.Point(12, 106);
            this.lblAuthorizationKey.Name = "lblAuthorizationKey";
            this.lblAuthorizationKey.Size = new System.Drawing.Size(89, 13);
            this.lblAuthorizationKey.TabIndex = 3;
            this.lblAuthorizationKey.Text = "Authorization Key";
            // 
            // tbRootFolder
            // 
            this.tbRootFolder.Location = new System.Drawing.Point(131, 23);
            this.tbRootFolder.Name = "tbRootFolder";
            this.tbRootFolder.Size = new System.Drawing.Size(112, 20);
            this.tbRootFolder.TabIndex = 4;
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Location = new System.Drawing.Point(249, 21);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(29, 23);
            this.btnSelectFolder.TabIndex = 5;
            this.btnSelectFolder.Text = "...";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // cbSourceLanguage
            // 
            this.cbSourceLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSourceLanguage.Location = new System.Drawing.Point(131, 49);
            this.cbSourceLanguage.Name = "cbSourceLanguage";
            this.cbSourceLanguage.Size = new System.Drawing.Size(147, 21);
            this.cbSourceLanguage.TabIndex = 6;
            // 
            // cbDestinationLanguage
            // 
            this.cbDestinationLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDestinationLanguage.FormattingEnabled = true;
            this.cbDestinationLanguage.Location = new System.Drawing.Point(131, 76);
            this.cbDestinationLanguage.Name = "cbDestinationLanguage";
            this.cbDestinationLanguage.Size = new System.Drawing.Size(147, 21);
            this.cbDestinationLanguage.TabIndex = 7;
            // 
            // tbKey
            // 
            this.tbKey.Location = new System.Drawing.Point(131, 103);
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(147, 20);
            this.tbKey.TabIndex = 8;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(131, 129);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(147, 23);
            this.btnStart.TabIndex = 9;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(300, 79);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(86, 13);
            this.labelName.TabIndex = 10;
            this.labelName.Text = "mustafaalioglu88";
            this.labelName.Click += new System.EventHandler(this.labelName_Click);
            // 
            // cxBUseFallbackResx
            // 
            this.cxBUseFallbackResx.AutoSize = true;
            this.cxBUseFallbackResx.Checked = true;
            this.cxBUseFallbackResx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cxBUseFallbackResx.Location = new System.Drawing.Point(15, 133);
            this.cxBUseFallbackResx.Name = "cxBUseFallbackResx";
            this.cxBUseFallbackResx.Size = new System.Drawing.Size(115, 17);
            this.cxBUseFallbackResx.TabIndex = 11;
            this.cxBUseFallbackResx.Text = "Use Fallback Resx";
            this.cxBUseFallbackResx.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 172);
            this.Controls.Add(this.cxBUseFallbackResx);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.tbKey);
            this.Controls.Add(this.cbDestinationLanguage);
            this.Controls.Add(this.cbSourceLanguage);
            this.Controls.Add(this.btnSelectFolder);
            this.Controls.Add(this.tbRootFolder);
            this.Controls.Add(this.lblAuthorizationKey);
            this.Controls.Add(this.lblToLanguage);
            this.Controls.Add(this.lblFromLanguage);
            this.Controls.Add(this.lblSelectRootFolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Resx Auto Translator";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDoubleClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSelectRootFolder;
        private System.Windows.Forms.Label lblFromLanguage;
        private System.Windows.Forms.Label lblToLanguage;
        private System.Windows.Forms.Label lblAuthorizationKey;
        private System.Windows.Forms.TextBox tbRootFolder;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.ComboBox cbSourceLanguage;
        private System.Windows.Forms.ComboBox cbDestinationLanguage;
        private System.Windows.Forms.TextBox tbKey;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.CheckBox cxBUseFallbackResx;

    }
}