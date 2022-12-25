using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Variant8
{
    public partial class Form2 : Form
    {
        int x1, y1, x2, y2;
        private Bitmap bmp;
        private Pen blackPen;
        int pen = 0;
        int k = 0;
        public Form2()
        {
            InitializeComponent();
            bmp = new Bitmap(800, 395);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            x2 = Convert.ToInt32(e.X); // координата по оси X
            y2 = Convert.ToInt32(e.Y); // координата по оси Y
        }

        private void Draw(Pen blackPen)
        {

            X2X2.Text = x2.ToString();
            Y2Y2.Text = y2.ToString();


            Graphics g = Graphics.FromImage(bmp);
            if (k > 0)
                g.DrawLine(blackPen, x1, y1, x2, y2);
            blackPen.Dispose();
            g.Dispose();
            pictureBox1.Image = bmp;
            pictureBox1.Invalidate();

            x1 = x2;
            y1 = y2;
            k++;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            SaveFileDialog savedialog = new SaveFileDialog();
            savedialog.Title = "Сохранить картинку как ...";
            savedialog.Filter =
                "Bitmap File(*.bmp)|*.bmp|" +
                "GIF File(*.gif)|*.gif|" +
                "JPEG File(*.jpg)|*.jpg|" +
                "TIF File(*.tif)|*.tif|" +
                "PNG File(*.png)|*.png";
            savedialog.ShowHelp = true;
            // If selected, save
            if (savedialog.ShowDialog() == DialogResult.OK)
            {
                // Get the user-selected file name
                string fileName = savedialog.FileName;
                // Get the extension
                string strFilExtn =
                    fileName.Remove(0, fileName.Length - 3);
                // Save file
                switch (strFilExtn)
                {
                    case "bmp":
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case "jpg":
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case "gif":
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                    case "tif":
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Tiff);
                        break;
                    case "png":
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    default:
                        break;
                }
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(800, 395);
            pictureBox1.Image = bmp;
            pictureBox1.Invalidate();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            toolStripComboBox1.SelectedIndex = 0;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            timer1.Start();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_dialog = new OpenFileDialog(); 
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            if (open_dialog.ShowDialog() == DialogResult.OK) 
            {
                try
                {
                    bmp = new Bitmap(open_dialog.FileName);
                    this.pictureBox1.Size = bmp.Size;
                    pictureBox1.Image = bmp;
                    pictureBox1.Invalidate();
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pen == 2)
            {
                blackPen = new Pen(Brushes.Red, toolStripComboBox1.SelectedIndex);
                Draw(blackPen);
            }
            if (pen == 3)
            {
                blackPen = new Pen(Brushes.Green, toolStripComboBox1.SelectedIndex);
                Draw(blackPen);
            }
            else
            {
                blackPen = new Pen(Brushes.Black, toolStripComboBox1.SelectedIndex);
                Draw(blackPen);
            }
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            blackPen = new Pen(Brushes.Red, toolStripComboBox1.SelectedIndex);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pen = 1;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            pen = 2;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            pen = 3;
        }
    }
}
