namespace Photo_Separator
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.FromTextBox = new System.Windows.Forms.TextBox();
            this.ToTextBox = new System.Windows.Forms.TextBox();
            this.Control = new System.Windows.Forms.Button();
            this.State = new System.Windows.Forms.ProgressBar();
            this.FromButton = new System.Windows.Forms.Button();
            this.ToButton = new System.Windows.Forms.Button();
            this.FromLabel = new System.Windows.Forms.Label();
            this.ToLabel = new System.Windows.Forms.Label();
            this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // FromTextBox
            // 
            this.FromTextBox.AllowDrop = true;
            this.FromTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FromTextBox.Location = new System.Drawing.Point(47, 12);
            this.FromTextBox.Name = "FromTextBox";
            this.FromTextBox.Size = new System.Drawing.Size(367, 19);
            this.FromTextBox.TabIndex = 0;
            this.FromTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.FromTextBox_DragDrop);
            this.FromTextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.FromTextBox_DragEnter);
            // 
            // ToTextBox
            // 
            this.ToTextBox.AllowDrop = true;
            this.ToTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ToTextBox.Location = new System.Drawing.Point(47, 37);
            this.ToTextBox.Name = "ToTextBox";
            this.ToTextBox.Size = new System.Drawing.Size(367, 19);
            this.ToTextBox.TabIndex = 1;
            this.ToTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.ToTextBox_DragDrop);
            this.ToTextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.ToTextBox_DragEnter);
            // 
            // Control
            // 
            this.Control.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Control.Location = new System.Drawing.Point(420, 62);
            this.Control.Name = "Control";
            this.Control.Size = new System.Drawing.Size(75, 23);
            this.Control.TabIndex = 2;
            this.Control.Text = "スタート";
            this.Control.UseVisualStyleBackColor = true;
            this.Control.Click += new System.EventHandler(this.Control_Click);
            // 
            // State
            // 
            this.State.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.State.Location = new System.Drawing.Point(12, 62);
            this.State.Name = "State";
            this.State.Size = new System.Drawing.Size(402, 23);
            this.State.TabIndex = 3;
            // 
            // FromButton
            // 
            this.FromButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FromButton.Location = new System.Drawing.Point(420, 12);
            this.FromButton.Name = "FromButton";
            this.FromButton.Size = new System.Drawing.Size(75, 19);
            this.FromButton.TabIndex = 4;
            this.FromButton.Text = "参照";
            this.FromButton.UseVisualStyleBackColor = true;
            this.FromButton.Click += new System.EventHandler(this.FromButton_Click);
            // 
            // ToButton
            // 
            this.ToButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ToButton.Location = new System.Drawing.Point(420, 37);
            this.ToButton.Name = "ToButton";
            this.ToButton.Size = new System.Drawing.Size(75, 19);
            this.ToButton.TabIndex = 5;
            this.ToButton.Text = "参照";
            this.ToButton.UseVisualStyleBackColor = true;
            this.ToButton.Click += new System.EventHandler(this.ToButton_Click);
            // 
            // FromLabel
            // 
            this.FromLabel.AutoSize = true;
            this.FromLabel.Location = new System.Drawing.Point(10, 15);
            this.FromLabel.Name = "FromLabel";
            this.FromLabel.Size = new System.Drawing.Size(31, 12);
            this.FromLabel.TabIndex = 6;
            this.FromLabel.Text = "From";
            // 
            // ToLabel
            // 
            this.ToLabel.AutoSize = true;
            this.ToLabel.Location = new System.Drawing.Point(12, 40);
            this.ToLabel.Name = "ToLabel";
            this.ToLabel.Size = new System.Drawing.Size(18, 12);
            this.ToLabel.TabIndex = 7;
            this.ToLabel.Text = "To";
            // 
            // FolderBrowserDialog
            // 
            this.FolderBrowserDialog.Description = "ディレクトリを選択してください。";
            // 
            // SaveFileDialog
            // 
            this.SaveFileDialog.Filter = "|*.txt";
            this.SaveFileDialog.InitialDirectory = "Desktop";
            this.SaveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveFileDialog_FileOk);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 92);
            this.Controls.Add(this.ToLabel);
            this.Controls.Add(this.FromLabel);
            this.Controls.Add(this.ToButton);
            this.Controls.Add(this.FromButton);
            this.Controls.Add(this.State);
            this.Controls.Add(this.Control);
            this.Controls.Add(this.ToTextBox);
            this.Controls.Add(this.FromTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1000, 131);
            this.MinimumSize = new System.Drawing.Size(235, 131);
            this.Name = "MainForm";
            this.Text = "Photo Separator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FromTextBox;
        private System.Windows.Forms.TextBox ToTextBox;
        private System.Windows.Forms.Button Control;
        private System.Windows.Forms.ProgressBar State;
        private System.Windows.Forms.Button FromButton;
        private System.Windows.Forms.Button ToButton;
        private System.Windows.Forms.Label FromLabel;
        private System.Windows.Forms.Label ToLabel;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
    }
}

