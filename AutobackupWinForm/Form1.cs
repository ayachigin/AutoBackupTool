using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Resources;

namespace AutobackupWinForm
{

    public partial class MainWindow : Form
    {
        const string SOURCE_PATH = "SourcePath";
        const string EXTENSIONS = "Extensions";

        private FolderBrowserDialog dialog;
        private string sourceFolder;
        private string destinationFolder;
        private string extensions;
        private string originalTextSourceLabel;
        private string originalTextDestLabel;
        private ToolTip tooltip;
        private AutoBackup autobackup;
        private ResourceManager rm;


        public MainWindow()
        {
            InitializeComponent();
            tooltip = new ToolTip();
            dialog = new FolderBrowserDialog();

            rm = new ResourceManager("AutobackupWinForm.Resource", typeof(MainWindow).Assembly);

            // set default source folder to My Picture
            if ((string)Properties.Settings.Default[SOURCE_PATH] == "**")
            {
                var myPicture = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                Properties.Settings.Default[SOURCE_PATH] = myPicture;
                Properties.Settings.Default.Save();
            }

            if ((string)Properties.Settings.Default[EXTENSIONS] == "**")
            {
                Properties.Settings.Default[EXTENSIONS] = textBoxExtensions.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
                textBoxExtensions.Text = (string)Properties.Settings.Default[EXTENSIONS];
            }


            sourceFolder = (string)Properties.Settings.Default[SOURCE_PATH];

            destinationFolder = Path.GetFullPath("./backup");
            Directory.CreateDirectory(destinationFolder);

            originalTextSourceLabel = SourceFolderLabel.Text;
            originalTextDestLabel = DestinationFolderLabel.Text;

            SetTextAndTooltip(SourceFolderLabel, sourceFolder);
            SetTextAndTooltip(DestinationFolderLabel, destinationFolder);

            SetExtensions();

            StartBackup();
        }

        private void SetTextAndTooltip(Control target, string text)
        {
            target.Text = text;
            tooltip.SetToolTip(target, text);
        }

        private void StartBackup()
        {
            if (Directory.Exists(sourceFolder) &&
                Directory.Exists(destinationFolder) &&
                extensions != null &&
                autobackup == null)
            {
                Properties.Settings.Default[SOURCE_PATH] = sourceFolder;
                Properties.Settings.Default.Save();
                var exts = extensions.Split('\n');

                autobackup = new AutoBackup(sourceFolder, destinationFolder, exts);
            }
        }

        private void DestFolderButton_Click(object sender, EventArgs e)
        {
            var result = dialog.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                destinationFolder =  dialog.SelectedPath;
                SetTextAndTooltip(DestinationFolderLabel, destinationFolder);
                StartBackup();
            }
            else
            {
                SetTextAndTooltip(DestinationFolderLabel, originalTextDestLabel);
                destinationFolder = null;
            }

        }

        private void SourceFolderButton_Click(object sender, EventArgs e)
        {
            var result = dialog.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                sourceFolder = dialog.SelectedPath;
                SetTextAndTooltip(SourceFolderLabel, sourceFolder);
                autobackup.SetPath(sourceFolder);
                StartBackup();
            }
            else
            {
                SetTextAndTooltip(SourceFolderLabel, originalTextSourceLabel);
            }

        }

        private void textBoxExtensions_TextChanged(object sender, EventArgs e)
        {
            SetExtensions();
        }

        private void SetExtensions()
        {
            this.extensions = textBoxExtensions.Text;
            var extensionArr = extensions.Split('\n');
            var stringCollection = new StringCollection();
            stringCollection.AddRange(extensionArr);
            Properties.Settings.Default[EXTENSIONS] = this.extensions;
            Properties.Settings.Default.Save();

            if (autobackup != null)
            {
                autobackup.SetExtensions(extensionArr);
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }
            else
            {
                WindowState = FormWindowState.Minimized;
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(rm.GetString("MessageOnWindowClose"),
                                rm.GetString("WindowTitle"),
                                MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
