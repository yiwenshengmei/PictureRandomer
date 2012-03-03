using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace PictureRandomer {
	public partial class MainForm: Form {
		private Random m_randomer = new Random();
		private String m_imageFolder = @"D:\我的文档\My Pictures\人物\";
		private List<String> passed_real_path = new List<string>();
		private List<String> m_images = new List<String>();
		private int m_imageIndex = -1;
		private string m_outputFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

		public MainForm() {
			InitializeComponent();
			dlgPictureOutputSelector.RootFolder = Environment.SpecialFolder.Desktop;
			m_imageIndex = 0;
		}

		// ### 事件捕捉
		private void Form1_Load(object sender, EventArgs e) {
			lblMessage.Text = "正在加载图片......";
			loadPictureWorker.DoWork += (object worker, DoWorkEventArgs worker_e) => {
				RandomPicture2List();
			};
			loadPictureWorker.RunWorkerCompleted += (object worker, RunWorkerCompletedEventArgs worker_e) => {
				ClearText();
				SetPictureBox(m_images[m_imageIndex]);
			};
			loadPictureWorker.RunWorkerAsync();
		}
		private void pictureBox1_MouseClick(object sender, MouseEventArgs e) {
			if (e.Button == System.Windows.Forms.MouseButtons.Left) {
				GoNextPicture();
			} else if (e.Button == System.Windows.Forms.MouseButtons.Right) {
				// GoPreviousPicture();
			}
		}
		private void MainForm_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Right) {
				GoNextPicture();
			} else if (e.KeyCode == Keys.Left) {
				GoPreviousPicture();
			} else if (e.KeyCode == Keys.S && e.Control) {
				SaveAs();
			}
		}
		private void menuSaveAs_Click(object sender, EventArgs e) {
			SaveAs();
		}

		// ### 逻辑
		private void RandomPicture2List() {
			m_images = Directory.EnumerateFiles(m_imageFolder).Where(file_path => {
				String ext = file_path.Substring(file_path.LastIndexOf(".")).ToLower();
				return ext == ".jpg" || ext == ".bmp" || ext == ".gif";
			}).ToList();
			m_images.Sort((str1, str2) => {
				if (str1 == str2) return 0;
				return m_randomer.Next(0, 9) % 2 == 0 ? 1 : -1;
			});
		}

		private void SetPictureBox(String fileName) {
			this.pictureBox1.ImageLocation = fileName;
			SetText(fileName);
			Clipboard.SetText(fileName);
		}

		private void SetText(string text, Color color) {
			lblMessage.ForeColor = color;
			lblMessage.Text = (text == null ? string.Empty : text);
		}

		private void SetTextColor(Color color) {
			lblMessage.ForeColor = color;
		}

		private void SetText(string text) {
			SetText(text, Color.Black);
		}

		private void ClearText() {
			SetText(string.Empty);
		}

		private void GoNextPicture() {
			m_imageIndex = (++m_imageIndex == m_images.Count ? 0 : m_imageIndex);
			SetPictureBox(m_images[m_imageIndex]);
		}

		private void GoPreviousPicture() {
			m_imageIndex = (--m_imageIndex == -1 ? m_images.Count - 1 : m_imageIndex);
			SetPictureBox(m_images[m_imageIndex]);
		}

		private void SaveAs() {
			if (dlgPictureOutputSelector.ShowDialog() == DialogResult.OK) {
				FileInfo file = new FileInfo(m_images[m_imageIndex]);
				file.CopyTo(dlgPictureOutputSelector.SelectedPath + "\\" + file.Name);
				SetTextColor(Color.Blue);
			}
		}

	}
}
