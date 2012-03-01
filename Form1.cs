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
	public partial class Form1: Form {
		private Random m_randomer = new Random();
		private String m_imageFolder = @"D:\我的文档\My Pictures\人物\";
		private List<String> passed_real_path = new List<string>();
		private List<String> m_images = new List<String>();
		private int imageIndex = -1;

		public Form1() {
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e) {
			RandomPicture2List();
			imageIndex = 0;
			SetPictureBox(m_images[imageIndex]);
		}

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

		private void RandomPictureAndSave() { 
			var image_enum = Directory.EnumerateFiles(m_imageFolder).Where(file_path => {
				String ext = file_path.Substring(file_path.LastIndexOf(".")).ToLower();
				return ext == ".jpg" || ext == ".bmp" || ext == ".gif";
			});
			int random_index = m_randomer.Next(0, image_enum.Count());
			String real_path = image_enum.ElementAt(random_index);
			this.pictureBox1.ImageLocation = real_path;
			this.label1.Text = real_path;
			Clipboard.SetText(real_path);
			//passed_real_path.Add(real_path);
		}

		private void SetPictureBox(String fileName) {
			this.pictureBox1.ImageLocation = fileName;
			this.label1.Text = fileName;
			Clipboard.SetText(fileName);
		}

		private void pictureBox1_MouseClick(object sender, MouseEventArgs e) {
			if (e.Button == System.Windows.Forms.MouseButtons.Left) {
				imageIndex = (++imageIndex == m_images.Count ? 0 : imageIndex);
			} else if (e.Button == System.Windows.Forms.MouseButtons.Right) {
				imageIndex = (--imageIndex == -1 ? m_images.Count - 1 : imageIndex);
			}
			SetPictureBox(m_images[imageIndex]);
		}
	}
}
