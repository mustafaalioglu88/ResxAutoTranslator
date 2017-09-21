namespace ResxAutoTranslator
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using ResxAutoTranslator.Source;
    using ResxAutoTranslator.Source.Utilities;

    public partial class MainForm : Form
    {
        public MainForm()
        {
            this.InitializeComponent();
            this.InitializeConfiguration();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void StartExecution()
        {
            var sourceLang = (Language)this.cbSourceLanguage.SelectedItem;
            var destinationLang = (Language)this.cbDestinationLanguage.SelectedItem;
            var translator = new MicrosoftTranslator(sourceLang, destinationLang);

            // Get AuthorizationKey from https://account.azure.com/ Translate Text service
            translator.AuthorizationKey = this.tbKey.Text;
            var executor = new ResxTranslator(this.tbRootFolder.Text, translator);
            executor.Start(this.cxBUseFallbackResx.Checked);
        }

        private void InitializeConfiguration()
        {
            this.Text += " v." + System.Reflection.Assembly.GetExecutingAssembly()
                                           .GetName()
                                           .Version;
            
            this.cbSourceLanguage.ValueMember = "Value";
            this.cbSourceLanguage.DisplayMember = "Key";
            this.cbSourceLanguage.DataSource = new List<Language>(Languages.LanguageList);
            this.cbDestinationLanguage.ValueMember = "Value";
            this.cbDestinationLanguage.DisplayMember = "Key";
            this.cbDestinationLanguage.DataSource = new List<Language>(Languages.LanguageList);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.StartExecution();
        }

        private void MainForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Size = new Size(408, this.Size.Height);
        }

        private void labelName_Click(object sender, EventArgs e)
        {
            this.Size = new Size(306, this.Size.Height);
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog.ShowDialog();
            this.tbRootFolder.Text = this.folderBrowserDialog.SelectedPath;
        }
    }
}