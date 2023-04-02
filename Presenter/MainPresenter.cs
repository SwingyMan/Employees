using PracownicyMVP.Model;

namespace PracownicyMVP.Presenter
{
    class MainPresenter
    {
        private View.Form1 _view;
        private Model.PracownikList _model;
        public MainPresenter(View.Form1 view, Model.PracownikList model)
        {
            _view = view;
            _model = model;
            _view.AddPerson += _view_AddPerson;
            _view.SelectEmployee += _view_SelectEmployee;
        }
        private void _view_AddPerson()
        {
            if (String.IsNullOrEmpty(_view.textBox1.Text) || String.IsNullOrEmpty(_view.textBox2.Text) || _view.numericUpDown1.Value <= 0 || String.IsNullOrEmpty(_view.comboBox1.Text))
            {
                MessageBox.Show("Puste pola");
            }
            else
            {
                string radioValue = "";
                if (_view.radioButton1.Checked)
                {
                    radioValue = _view.radioButton1.Text;
                }
                if (_view.radioButton2.Checked)
                {
                    radioValue = _view.radioButton2.Text;
                }
                if (_view.radioButton3.Checked)
                {
                    radioValue = _view.radioButton3.Text;
                }
                Pracownik pracownik = new Pracownik(_view.textBox1.Text, _view.textBox2.Text, _view.dateTimePicker1.Value, _view.numericUpDown1.Value, _view.comboBox1.Text, radioValue);
                _view.pracownikList.list.Add(pracownik);
                _view.addToListBox(pracownik);
            }
        }
        private void _view_SelectEmployee(int index)
        {
           var pracownik = _view.pracownikList.list.ElementAt(index);
            int stanowisko = 0;
            if (pracownik.Stanowisko== "Inżynier")
                stanowisko = 0;
            if(pracownik.Stanowisko =="Młodszy Programista")
                stanowisko = 1;
            if(pracownik.Stanowisko =="Projektant")
                stanowisko = 2;
            if(pracownik.Stanowisko =="Starszy Programista")
                stanowisko=3;
                if(pracownik.Stanowisko =="Tester")
                stanowisko = 4;
            _view.setFormValues(pracownik.Imie, pracownik.Nazwisko, pracownik.Data_urodzenia, pracownik.Pensja, stanowisko, pracownik.Umowa);
        }

    }
}
