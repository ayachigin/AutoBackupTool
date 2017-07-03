namespace AutobackupWinForm
{
    partial class MainWindow
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.SourceFolderButton = new System.Windows.Forms.Button();
            this.DestFolderButton = new System.Windows.Forms.Button();
            this.SourceFolderLabel = new System.Windows.Forms.Label();
            this.DestinationFolderLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxExtensions = new System.Windows.Forms.TextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxAutobackup = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // SourceFolderButton
            // 
            resources.ApplyResources(this.SourceFolderButton, "SourceFolderButton");
            this.SourceFolderButton.Name = "SourceFolderButton";
            this.SourceFolderButton.UseVisualStyleBackColor = true;
            this.SourceFolderButton.Click += new System.EventHandler(this.SourceFolderButton_Click);
            // 
            // DestFolderButton
            // 
            resources.ApplyResources(this.DestFolderButton, "DestFolderButton");
            this.DestFolderButton.Name = "DestFolderButton";
            this.DestFolderButton.UseVisualStyleBackColor = true;
            this.DestFolderButton.Click += new System.EventHandler(this.DestFolderButton_Click);
            // 
            // SourceFolderLabel
            // 
            this.SourceFolderLabel.AutoEllipsis = true;
            resources.ApplyResources(this.SourceFolderLabel, "SourceFolderLabel");
            this.SourceFolderLabel.Name = "SourceFolderLabel";
            // 
            // DestinationFolderLabel
            // 
            this.DestinationFolderLabel.AutoEllipsis = true;
            resources.ApplyResources(this.DestinationFolderLabel, "DestinationFolderLabel");
            this.DestinationFolderLabel.Name = "DestinationFolderLabel";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // textBoxExtensions
            // 
            resources.ApplyResources(this.textBoxExtensions, "textBoxExtensions");
            this.textBoxExtensions.Name = "textBoxExtensions";
            this.textBoxExtensions.TextChanged += new System.EventHandler(this.textBoxExtensions_TextChanged);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            resources.ApplyResources(this.notifyIcon1, "notifyIcon1");
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.textBox1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // checkBox2
            // 
            resources.ApplyResources(this.checkBox2, "checkBox2");
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxAutobackup);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.SourceFolderButton);
            this.groupBox2.Controls.Add(this.textBoxExtensions);
            this.groupBox2.Controls.Add(this.DestFolderButton);
            this.groupBox2.Controls.Add(this.SourceFolderLabel);
            this.groupBox2.Controls.Add(this.DestinationFolderLabel);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // checkBoxAutobackup
            // 
            resources.ApplyResources(this.checkBoxAutobackup, "checkBoxAutobackup");
            this.checkBoxAutobackup.Checked = true;
            this.checkBoxAutobackup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutobackup.Name = "checkBoxAutobackup";
            this.checkBoxAutobackup.UseVisualStyleBackColor = true;
            this.checkBoxAutobackup.CheckedChanged += new System.EventHandler(this.checkBoxAutobackup_CheckedChanged);
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainWindow";
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button SourceFolderButton;
        private System.Windows.Forms.Button DestFolderButton;
        private System.Windows.Forms.Label SourceFolderLabel;
        private System.Windows.Forms.Label DestinationFolderLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxExtensions;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxAutobackup;
    }
}

