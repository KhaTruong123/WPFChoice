using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Wpf_concept.BuiltItems
{
    public class Component 
    {
        public string Name { get { return _name; } }
        public Category Category { get { return _category; } }
        public List<ComponentValue> CVList { get { return _cvList; } }
        //public List<string> CVNameList { get { return _cvNameList; } }
        //public int Order { get; set; }
        //public int ID { get; set; }

        private string _name;
        private Category _category;
        private List<ComponentValue> _cvList = new List<ComponentValue>();
        public Component(XElement compElement)
        {
            _name = compElement.Attribute("name").Value;
        }

        public Component(Category category, XElement compElement)
        {
            _name = compElement.Attribute("name").Value;
            _category = category;
            GetCV(compElement);
        }

        public override string ToString()
        {
            return Name;
        }

        private void GetCV(XElement xElement)
        {
            List<XElement> CVs = xElement.Elements().ToList();
            foreach (var cv in CVs)
            {
                _cvList.Add(new ComponentValue(cv,this));
            }

            //CVs.ForEach(t => _cvList.Add(new ComponentValue(xElement, this)));
        }
    }
}
