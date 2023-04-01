namespace PracownicyMVP.Presenter
{
    class MainPresenter
    {
        private View.Form1 _view;
        private Model.Pracownik _model;
        public MainPresenter(View.Form1 view, Model.Pracownik model)
        {
            _view = view;
            _model = model;

            _view.AddEmployee += _view_AddEmployee;
        }

        private void _view_AddEmployee()
        {


        }


    }
}
