namespace PictureRandomer {
	partial class MainForm {
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
			this.lblMessage = new System.Windows.Forms.Label();
			this.dlgPictureOutputSelector = new System.Windows.Forms.FolderBrowserDialog();
			this.loadPictureWorker = new System.ComponentModel.BackgroundWorker();
			((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
			this.pictureContextMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.ContextMenuStrip = this.pictureContextMenu;
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(334, 452);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
			// 
			// pictureContextMenu
			// 
			this.pictureContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSaveAs});
			this.pictureContextMenu.Name = "pcitureContextMenu";
			this.pictureContextMenu.Size = new System.Drawing.Size(153, 48);
			// 
			// menuSaveAs
			// 
			this.menuSaveAs.Name = "menuSaveAs";
			this.menuSaveAs.Size = new System.Drawing.Size(152, 22);
			this.menuSaveAs.Text = "另存为...(&S)";
			this.menuSaveAs.Click += new System.EventHandler(this.menuSaveAs_Click);
			// 
			// lblMessage
			// 
			this.lblMessage.AutoSize = true;
			this.lblMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lblMessage.Location = new System.Drawing.Point(0, 435);
			this.lblMessage.Name = "lblMessage";
			this.lblMessage.Size = new System.Drawing.Size(43, 17);
			this.lblMessage.TabIndex = 1;
			this.lblMessage.Text = "label1";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(334, 452);
			this.Controls.Add(this.lblMessage);
			this.Controls.Add(this.pictureBox1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (134)));
			this.Name = "MainForm";
			this.Text = "随机图片";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
			((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
			this.pictureContextMenu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label lblMessage;
		private System.Windows.Forms.FolderBrowserDialog dlgPictureOutputSelector;
		private System.Windows.Forms.ContextMenuStrip pictureContextMenu;
		private System.Windows.Forms.ToolStripMenuItem menuSaveAs;
		private System.ComponentModel.BackgroundWorker loadPictureWorker;
	}
}

