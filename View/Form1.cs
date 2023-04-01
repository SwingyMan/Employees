using PracownicyMVP.Model;
using System.Xml.Serialization;

namespace PracownicyMVP.View
{
    public partial class Form1 : Form
    {
        PracownikList pracownikList = new PracownikList();
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 1;
        }

        #region Public interface of view
        public event Action AddEmployee;
        #endregion



        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || numericUpDown1.Value <= 0 || String.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Puste pola");
            }
            else
            {
                string radioValue = "";
                if (radioButton1.Checked)
                {
                    radioValue = radioButton1.Text;
                }
                if (radioButton2.Checked)
                {
                    radioValue = radioButton2.Text;
                }
                if (radioButton3.Checked)
                {
                    radioValue = radioButton3.Text;
                }
                Pracownik pracownik = new Pracownik(textBox1.Text, textBox2.Text, dateTimePicker1.Value, numericUpDown1.Value, comboBox1.Text, radioValue);
                pracownikList.list.Add(pracownik);
                listBox1.Items.Add(pracownik.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog(this);
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            pracownikList.Serialize(saveFileDialog1.FileName);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pracownik pracownicy = pracownikList.list.ElementAt(listBox1.SelectedIndex);
            textBox1.Text = pracownicy.Imie;
            textBox2.Text = pracownicy.Nazwisko;
            dateTimePicker1.Value = pracownicy.Data_urodzenia;
            numericUpDown1.Value = pracownicy.Pensja;
            comboBox1.Text = pracownicy.Stanowisko;
            if (radioButton1.Text == pracownicy.Umowa)
            {
                radioButton1.Checked = true;6
                radioButton2.Checked = false;
                radioButton3.Checked = false;
            }
            if (radioButton2.Text == pracownicy.Umowa)
            {
                radioButton2.Checked = true;
                radioButton3.Checked = false;
                radioButton1.Checked = false;
            }
            if (radioButton3.Text == pracownicy.Umowa)
            {
                radioButton3.Checked = true;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
            }
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            listBox1.Items.Clear();
            pracownikList.Deserialize(openFileDialog1.FileName);
            foreach(var x in  pracownikList.list) {
            listBox1.Items.Add(x);
            }
        }
    }
}