using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics.Eventing.Reader;

namespace notebook
{
    public partial class Form1 : Form
    {
        protected string Filename;
        public bool IsFileChanged;
        public Settings settings;
        public int fontsize = 0;
        public System.Drawing.FontStyle fs = FontStyle.Regular;
        public System.Drawing.Color color = Color.Black;

        public Form1()
        {
            InitializeComponent();
            Initialize();
        }
        public void Initialize()
        {
            Filename = "";
            IsFileChanged = false;
            UpdateTextWithTitle();
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveUnsavedFile();
            textBox1.Text = "";
            Filename = "";
            IsFileChanged = false;
            UpdateTextWithTitle();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            SaveUnsavedFile();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = File.ReadAllText(openFileDialog.FileName);
                try
                {
                    StreamReader reader = new StreamReader(openFileDialog.FileName);
                    textBox1.Text = reader.ReadToEnd();
                    reader.Close();
                    Filename = openFileDialog.FileName;
                    IsFileChanged = false;
                }
                catch
                {
                    MessageBox.Show("Невозможно открыть файл!");
                }
            }
            UpdateTextWithTitle();
        }
        private void SaveFile(string file)
        {
            if (file == "")
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    file = saveFileDialog.FileName;
                }
            }
            try
            {
                StreamWriter writer = new StreamWriter(file + ".txt");
                writer.Write(textBox1.Text);
                writer.Close();
                Filename = file;
                IsFileChanged = false;
            }
            catch
            {
                MessageBox.Show("Не удалось открыть файл!");
            }
            UpdateTextWithTitle();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile(Filename);
        }
        private void UpdateTextWithTitle()
        {
            if (Filename != "")
            {
                this.Text = Filename + " - Блокнот";
            }
            else
            {
                this.Text = "Безымянный - Блокнот";
            }
        }
        private void SaveUnsavedFile()
        {
            if (IsFileChanged == false)
            {
                DialogResult result = MessageBox.Show("Сохранить изменения в файле?", "Сохранение файла", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    SaveFile(Filename);
                }
            }
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.SelectedText);
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.SelectedText);
            textBox1.Text = textBox1.Text.Remove(textBox1.SelectionStart, textBox1.SelectionLength);
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Substring(0, textBox1.SelectionStart) + Clipboard.GetText() + textBox1.Text.Substring(textBox1.SelectionStart, textBox1.TextLength - textBox1.SelectionStart);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        { if (textBox1.Text.Length > 0)
            {
                SaveUnsavedFile();
                this.Close();
            }
           else
            {
                this.Close();
            }
        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings = new Settings();
            settings.Show();
        }

        private void OnFocus(object sender, EventArgs e)
        {
            if (settings != null)
            {
                fontsize = settings.fontsize;
                fs = settings.fs;
                color = settings.color;
                textBox1.Font = new Font(textBox1.Font.FontFamily, fontsize, fs);
                textBox1.ForeColor = color;
                settings.Close();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(textBox1.Text, new Font("Times New Roman", fontsize, fs), Brushes.Black, new Point(100, 100));
        }

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About info = new About();
            info.Show();
        }
    }
}
