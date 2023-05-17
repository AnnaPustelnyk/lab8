namespace lab8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;

            Dictionary<string, int> sequence = new Dictionary<string, int>();

            for (int i = 0; i < input.Length - 3; i++)
            {
                string group = input.Substring(i, 4);


                if (sequence.ContainsKey(group))
                {
                    sequence[group]++;
                }
                else
                {
                    sequence[group] = 1;
                }
            }

            Form2 form2 = new Form2(sequence);
            form2.Show();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char keyPressed = e.KeyChar;

            if (keyPressed != 'C' && keyPressed != 'T' && keyPressed != 'G' && keyPressed != 'A')
            {
                e.Handled = true;
            }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}