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
            this.SuspendLayout();
            // 
            // SourceFolderButton
            // 
            this.SourceFolderButton.Location = new System.Drawing.Point(13, 13);
            this.SourceFolderButton.Name = "SourceFolderButton";
            this.SourceFolderButton.Size = new System.Drawing.Size(24, 23);
            this.SourceFolderButton.TabIndex = 0;
            this.SourceFolderButton.Text = "...";
            this.SourceFolderButton.UseVisualStyleBackColor = true;
            this.SourceFolderButton.Click += new System.EventHandler(this.SourceFolderButton_Click);
            // 
            // DestFolderButton
            // 
            this.DestFolderButton.Location = new System.Drawing.Point(13, 43);
            this.DestFolderButton.Name = "DestFolderButton";
            this.DestFolderButton.Size = new System.Drawing.Size(24, 23);
            this.DestFolderButton.TabIndex = 1;
            this.DestFolderButton.Text = "...";
            this.DestFolderButton.UseVisualStyleBackColor = true;
            this.DestFolderButton.Click += new System.EventHandler(this.DestFolderButton_Click);
            // 
            // SourceFolderLabel
            // 
            this.SourceFolderLabel.AutoSize = true;
            this.SourceFolderLabel.Location = new System.Drawing.Point(43, 24);
            this.SourceFolderLabel.Name = "SourceFolderLabel";
            this.SourceFolderLabel.Size = new System.Drawing.Size(108, 12);
            this.SourceFolderLabel.TabIndex = 2;
            this.SourceFolderLabel.Text = "Select source folder";
            // 
            // DestinationFolderLabel
            // 
            this.DestinationFolderLabel.AutoSize = true;
            this.DestinationFolderLabel.Location = new System.Drawing.Point(45, 53);
            this.DestinationFolderLabel.Name = "DestinationFolderLabel";
            this.DestinationFolderLabel.Size = new System.Drawing.Size(130, 12);
            this.DestinationFolderLabel.TabIndex = 3;
            this.DestinationFolderLabel.Text = "Select destination folder";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Extension of the file to backup.";
            // 
            // textBoxExtensions
            // 
            this.textBoxExtensions.Location = new System.Drawing.Point(13, 88);
            this.textBoxExtensions.Multiline = true;
            this.textBoxExtensions.Name = "textBoxExtensions";
            this.textBoxExtensions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxExtensions.Size = new System.Drawing.Size(162, 161);
            this.textBoxExtensions.TabIndex = 5;
            this.textBoxExtensions.Text = "sai\r\nsai2\r\nlip\r\nclip\r\njpg\r\npng";
            this.textBoxExtensions.TextChanged += new System.EventHandler(this.textBoxExtensions_TextChanged);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Auto backup tool";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 261);
            this.Controls.Add(this.textBoxExtensions);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DestinationFolderLabel);
            this.Controls.Add(this.SourceFolderLabel);
            this.Controls.Add(this.DestFolderButton);
            this.Controls.Add(this.SourceFolderButton);
            this.Name = "MainWindow";
            this.ShowInTaskbar = false;
            this.Text = "Auto backup tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button SourceFolderButton;
        private System.Windows.Forms.Button DestFolderButton;
        private System.Windows.Forms.Label SourceFolderLabel;
        private System.Windows.Forms.Label DestinationFolderLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxExtensions;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

