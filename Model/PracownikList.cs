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
        public void Serialize(String filename)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Pracownik>));
            using (FileStream fileStream = new FileStream(filename, FileMode.Create))
            {
                xml.Serialize(fileStream, list);
            }
        }
        public void Deserialize(String filename)
        {
            list.Clear();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Pracownik>), new XmlRootAttribute("ArrayOfPracownik"));
            using (Stream reader = new FileStream(filename, FileMode.Open))
            {
                var x = (List<Pracownik>)serializer.Deserialize(reader);
                foreach (Pracownik p in x)
                {
                    list.Add(p);
                }
            }
        }
        public PracownikList() { }
    }

}
