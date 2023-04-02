using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PracownicyMVP.Model
{
    public class PracownikList
    {
        public List<Pracownik> list = new List<Pracownik>();
        public void Serialize()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Plik XML|*.xml|Wszystkie pliki|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Pracownik>));
                {
                    using (FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        xml.Serialize(fileStream, list);
                    }
                }
            }
            else { }
        }
        public void Deserialize()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                list.Clear();
                XmlSerializer serializer = new XmlSerializer(typeof(List<Pracownik>), new XmlRootAttribute("ArrayOfPracownik"));
                using (Stream reader = new FileStream(openFileDialog.FileName, FileMode.Open))
                {
                    var x = (List<Pracownik>)serializer.Deserialize(reader);
                    foreach (Pracownik p in x)
                    {
                        list.Add(p);
                    }
                }
            }
            else { }
        }
        public PracownikList() { }
    }

}
