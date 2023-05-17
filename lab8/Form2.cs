using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab8
{
    public partial class Form2 : Form
    {
        private Dictionary<string, int> sequence;
        public Form2(Dictionary<string, int> sequence)
        {
            InitializeComponent();
            this.sequence = sequence;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Pliki CSV (*.csv)|*.csv";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("Czwórka,Wystąpienia");

                    foreach (KeyValuePair<string, int> kvp in sequence)
                    {
                        string row = $"{kvp.Key},{kvp.Value}";
                        writer.WriteLine(row);
                    }
                }

                MessageBox.Show("Dane zostały zapisane");
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;

            listView1.Columns.Add("Czwórka", 100);
            listView1.Columns.Add("Liczba wystąpień", 100);

            foreach (var temp in sequence)
            {
                ListViewItem item = new ListViewItem(temp.Key);
                item.SubItems.Add(temp.Value.ToString());
                listView1.Items.Add(item);
            }
        }
    }
}
