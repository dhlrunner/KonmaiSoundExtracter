namespace KonmaiSoundExtracter
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.index = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.audioname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.audiosize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.audiotype = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.openaudiobutton = new System.Windows.Forms.Button();
            this.filepathtextBox = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.extractbutton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.index,
            this.audioname,
            this.audiotype,
            this.audiosize});
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 78);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(622, 428);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // index
            // 
            this.index.Text = "Index";
            this.index.Width = 62;
            // 
            // audioname
            // 
            this.audioname.Text = "Name";
            this.audioname.Width = 190;
            // 
            // audiosize
            // 
            this.audiosize.Text = "Size";
            this.audiosize.Width = 145;
            // 
            // audiotype
            // 
            this.audiotype.Text = "Type";
            this.audiotype.Width = 77;
            // 
            // openaudiobutton
            // 
            this.openaudiobutton.Location = new System.Drawing.Point(13, 15);
            this.openaudiobutton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.openaudiobutton.Name = "openaudiobutton";
            this.openaudiobutton.Size = new System.Drawing.Size(75, 24);
            this.openaudiobutton.TabIndex = 1;
            this.openaudiobutton.Text = "Open";
            this.openaudiobutton.UseVisualStyleBackColor = true;
            this.openaudiobutton.Click += new System.EventHandler(this.openaudiobutton_Click);
            // 
            // filepathtextBox
            // 
            this.filepathtextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filepathtextBox.Location = new System.Drawing.Point(95, 16);
            this.filepathtextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.filepathtextBox.Name = "filepathtextBox";
            this.filepathtextBox.ReadOnly = true;
            this.filepathtextBox.Size = new System.Drawing.Size(539, 23);
            this.filepathtextBox.TabIndex = 2;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "s3p file|*.s3p|All Files|*.*";
            // 
            // extractbutton
            // 
            this.extractbutton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.extractbutton.Enabled = false;
            this.extractbutton.Location = new System.Drawing.Point(13, 47);
            this.extractbutton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.extractbutton.Name = "extractbutton";
            this.extractbutton.Size = new System.Drawing.Size(621, 23);
            this.extractbutton.TabIndex = 3;
            this.extractbutton.Text = "Extract All";
            this.extractbutton.UseVisualStyleBackColor = true;
            this.extractbutton.Click += new System.EventHandler(this.extractbutton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 516);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(646, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel1.Text = "Ready";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 538);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.extractbutton);
            this.Controls.Add(this.filepathtextBox);
            this.Controls.Add(this.openaudiobutton);
            this.Controls.Add(this.listView1);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "KonmaiSoundExtracter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader index;
        private System.Windows.Forms.ColumnHeader audioname;
        private System.Windows.Forms.ColumnHeader audiosize;
        private System.Windows.Forms.ColumnHeader audiotype;
        private System.Windows.Forms.Button openaudiobutton;
        private System.Windows.Forms.TextBox filepathtextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button extractbutton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

