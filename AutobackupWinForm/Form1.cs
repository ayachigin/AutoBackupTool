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
        const string SOURCE_PATH      = "SourcePath";
        const string DESTINATION_PATH = "DestinationPath";
        const string EXTENSIONS       = "Extensions";
        const string AUTOBACKUP       = "AutoBackup";

        private FolderBrowserDialog dialog;
        private string sourceFolder;
        private string destinationFolder;
        private string extensions;
        private string originalTextSourceLabel;
        private string originalTextDestLabel;
        private ToolTip tooltip;
        private FileSystemWatcherManager fswmanager;
        private ResourceManager rm;
        private System.Timers.Timer timer;


        public MainWindow()
        {
            InitializeComponent();
            tooltip = new ToolTip();
            dialog = new FolderBrowserDialog();

            rm = new ResourceManager("AutobackupWinForm.Resource", typeof(MainWindow).Assembly);

            timer = new System.Timers.Timer();
            timer.Enabled = true;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(OnElapsed);

            destinationFolder = Path.GetFullPath("./backup");
            Directory.CreateDirectory(destinationFolder);
        }


        /**
         * Check the source and destination folder existence
         * When the folders ain't exists then stop filesystemwatcher
         */
        private void OnElapsed(object source, System.Timers.ElapsedEventArgs e)
        {
            if (sourceFolder == null ||
                destinationFolder == null) return;

            if (!Directory.Exists(sourceFolder))
            {
                fswmanager.Enable = false;   
            }

            if (!Directory.Exists(destinationFolder))
            {
                fswmanager.Enable = false;
            }
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
                fswmanager == null)
            {
                Properties.Settings.Default[SOURCE_PATH] = sourceFolder;
                Properties.Settings.Default.Save();
                var exts = extensions.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

                fswmanager = new FileSystemWatcherManager(sourceFolder, destinationFolder, exts);
            }
        }

        private void DestFolderButton_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(destinationFolder)) dialog.SelectedPath = destinationFolder;
            var result = dialog.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                destinationFolder =  dialog.SelectedPath;
                SetTextAndTooltip(DestinationFolderLabel, destinationFolder);
                StartBackup();
                if (fswmanager != null)
                {
                    fswmanager.DestinationFolder = destinationFolder;
                }
            }
            else
            {
                if (!Directory.Exists(destinationFolder))
                {
                    SetTextAndTooltip(DestinationFolderLabel, originalTextDestLabel);
                    destinationFolder = null;
                }
            }

        }

        private void SourceFolderButton_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(sourceFolder)) dialog.SelectedPath = sourceFolder;
            var result = dialog.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                sourceFolder = dialog.SelectedPath;
                SetTextAndTooltip(SourceFolderLabel, sourceFolder);
                fswmanager.SourceFolder = sourceFolder;
                StartBackup();
                if (fswmanager != null)
                {
                    fswmanager.SourceFolder = sourceFolder;
                }
            }
            else
            {
                if (!Directory.Exists(sourceFolder))
                {
                    SetTextAndTooltip(SourceFolderLabel, originalTextSourceLabel);
                    sourceFolder = null;
                }
            }

        }

        private void textBoxExtensions_TextChanged(object sender, EventArgs e)
        {
            SetExtensions();
        }

        private void SetExtensions()
        {
            this.extensions = textBoxExtensions.Text;
            var extensionArr = extensions.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            if (fswmanager != null)
            {
                fswmanager.Extensions = extensionArr;
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

        private void MainWindow_Load(object sender, EventArgs e)
        {
            sourceFolder = (string)Properties.Settings.Default[SOURCE_PATH];
            destinationFolder = (string)Properties.Settings.Default[DESTINATION_PATH];
            textBoxExtensions.Text = (string)Properties.Settings.Default[EXTENSIONS];
            checkBoxAutobackup.Checked = (bool)Properties.Settings.Default[AUTOBACKUP];

            // set default source folder to My Picture
            if (!Directory.Exists(sourceFolder))
            {
                sourceFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures); 
            }

            if (!Directory.Exists(destinationFolder))
            {
                destinationFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                                    @"\" + rm.GetString("DestinationFolderName");
                if (!Directory.Exists(destinationFolder))
                {
                    Directory.CreateDirectory(destinationFolder);
                }
            }

            if (extensions == "**")
            {
                extensions = textBoxExtensions.Text;
            }
            else
            {
                textBoxExtensions.Text = (string)Properties.Settings.Default[EXTENSIONS];
            }

            originalTextSourceLabel = SourceFolderLabel.Text;
            originalTextDestLabel = DestinationFolderLabel.Text;

            SetTextAndTooltip(SourceFolderLabel, sourceFolder);
            SetTextAndTooltip(DestinationFolderLabel, destinationFolder);

            StartBackup();
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default[SOURCE_PATH] = sourceFolder;
            Properties.Settings.Default[DESTINATION_PATH] = destinationFolder;
            Properties.Settings.Default[AUTOBACKUP] = checkBoxAutobackup.Checked;
            Properties.Settings.Default[EXTENSIONS] = extensions;
            Properties.Settings.Default.Save();
        }

        private void checkBoxAutobackup_CheckedChanged(object sender, EventArgs e)
        {
            fswmanager.EnableAutoBackup = checkBoxAutobackup.Checked;
        }
    }
}
