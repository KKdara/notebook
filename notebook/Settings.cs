using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace notebook
{
    public partial class Settings : Form
    {
        public int fontsize = 0;
        public System.Drawing.FontStyle fs = FontStyle.Regular;
        public System.Drawing.Color color = Color.Black;
        public Settings()
        {
            InitializeComponent();
            comboBox1.SelectedItem = comboBox1.Items[0];
            comboBox2.SelectedItem = comboBox2.Items[0];
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Examplelabel.Font = new Font(Examplelabel.Font.FontFamily, int.Parse(comboBox1.SelectedItem.ToString()), Examplelabel.Font.Style);
            fontsize = int.Parse(comboBox1.SelectedItem.ToString());
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedItem.ToString())
            {
                case "обычный":
                    Examplelabel.Font = new Font(Examplelabel.Font.FontFamily, int.Parse(comboBox1.SelectedItem.ToString()), FontStyle.Regular);
                    break;
                case "курсив":
                    Examplelabel.Font = new Font(Examplelabel.Font.FontFamily, int.Parse(comboBox1.SelectedItem.ToString()), FontStyle.Italic);
                    break;
                case "жирный":
                    Examplelabel.Font = new Font(Examplelabel.Font.FontFamily, int.Parse(comboBox1.SelectedItem.ToString()), FontStyle.Bold);
                    break;
                default:
                    Examplelabel.Font = new Font(Examplelabel.Font.FontFamily, int.Parse(comboBox1.SelectedItem.ToString()), FontStyle.Regular);
                    break;
            }
            fs = Examplelabel.Font.Style;
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox3.SelectedItem.ToString())
            {
                case "чёрный":
                    Examplelabel.ForeColor = Color.Black;
                    break;
                case "красный":
                    Examplelabel.ForeColor = Color.Red;
                    break;
                case "синий":
                    Examplelabel.ForeColor = Color.Blue;
                    break;
                case "зелёный":
                    Examplelabel.ForeColor = Color.Green;
                    break;
            }
            color = Examplelabel.ForeColor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
