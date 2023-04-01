


namespace PracownicyMVP.Model
{
    public class Pracownik
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime Data_urodzenia { get; set; }
        public decimal Pensja { get; set; }
        public string Stanowisko { get; set; }
        public string Umowa { get; set; }


        public override string ToString()
        {
            return Imie + "," + Nazwisko + "," + Data_urodzenia.ToShortDateString() + "," + Pensja + "," + Stanowisko + "," + Umowa;
        }
        public Pracownik(string imie, string nazwisko, DateTime data_urodzenia, decimal pensja, string stanowisko, string umowa)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Data_urodzenia = data_urodzenia;
            Pensja = pensja;
            Stanowisko = stanowisko;
            Umowa = umowa;
        }
        public Pracownik() { }
    }
}
