using PracownicyMVP.Model;
using System.Xml.Serialization;

namespace PracownicyMVP.View
{
    public partial class Form1 : Form
    {
        public PracownikList pracownikList = new PracownikList();
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 1;
        }

        #region Public interface of view
        public event Action AddEmployee;
        #endregion

        public event Action AddPerson;
        public event Action SerializeList;
        public event Action DeserializeList;
        public event Action<int> SelectEmployee;
        public ListBox.ObjectCollection DisplayEmployees
        {
            get
            {
                return listBox1.Items;
            }
        }

        void selectEmployee(object sender,EventArgs e){
            var listbox = sender as ListBox;
            int index = listbox.SelectedIndex;
            SelectEmployee?.Invoke(index);
        }
        public void addToListBox(Pracownik p)
        {
            listBox1.Items.Add(p);
        }
        private void addPerson(object sender, EventArgs e)
        {
            AddPerson?.Invoke();
            
        }

        private void serialize_list(object sender, EventArgs e)
        {
            pracownikList.Serialize();
        }

        private void deserialize_list(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            pracownikList.Deserialize();
            foreach (var x in pracownikList.list)
            {
                listBox1.Items.Add(x);
            }
        }
        public void setFormValues(string name, string surname, DateTime date, decimal salary, int position, string umowa)
        {
            textBox1.Text = name;
            textBox2.Text = surname;
            dateTimePicker1.Value = date;
            numericUpDown1.Value = salary;
            comboBox1.SelectedIndex = position;
            if (radioButton1.Text == umowa)
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
            }
            if (radioButton2.Text == umowa)
            {
                radioButton2.Checked = true;
                radioButton3.Checked = false;
                radioButton1.Checked = false;
            }
            if (radioButton3.Text == umowa)
            { 
                radioButton3.Checked = true;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
            }
        }
       
    }
}