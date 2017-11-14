using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Wpf_concept.BuiltItems
{
    public class Category
    {
        public string Name { get { return _name; }}
        public List<Component> ComponentList { get { return _componentList; } }
        public List<string> ComponentNameList { get { return _componentNameList; } }
        public int Order { get { return _order; } }

        private string _name;
        private List<Component> _componentList = new List<Component>();
        private List<string> _componentNameList = new List<string>();
        private int _order;

        public Category(XElement xElement)
        {
            _name = xElement.Attribute("name").Value;
            var listComp = xElement.Elements("Component");
            foreach(var comp in listComp)
            {
                //var newComp = new Component(comp);
                //newComp.GetCategoryName(this);
                //_componentList.Add(newComp);
                _componentNameList.Add(comp.Attribute("name").Value);
            }
        }
    }
}
