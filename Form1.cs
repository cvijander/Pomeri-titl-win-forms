namespace Pomeri_titl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void odaberiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Tekstualni dokument (*.txt) |*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(ofd.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sek = int.Parse(textBox1.Text);
            string odgovor = "";
            string[] Redovi = richTextBox1.Text.Split('\n');
            foreach (string x in Redovi)
            {
                string[] niz = x.Split(' ');
                odgovor += TimeSpan.Parse(niz[0]).Add(new TimeSpan(0, 0, 0, sek, 0));
                for (int i = 1; i < niz.Length; i++)
                {
                    odgovor += " " + niz[i];
                }
                odgovor += "\n";
            }
            richTextBox1.Text = odgovor.Substring(0, odgovor.Length - 1);
        }

        private void snimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Tekstualni dokument (*.txt) |*.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, richTextBox1.Text);
                MessageBox.Show("Novi titl je uspesno sacuvan");
            }
        }
    }
}