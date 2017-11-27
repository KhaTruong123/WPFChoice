using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Xml.Linq;

namespace Wpf_concept.BuiltItems
{
    public class Category
    {
        public string Name { get { return _name; }}
        public List<Component> Components { get { return _components; } }
        //public List<string> ComponentNameList { get { return _componentNameList; } }
        //public int ID { get { return _order; } }

        private string _name;
        private List<Component> _components = new List<Component>();
        //private List<string> _componentNameList = new List<string>();
        //private int _order;
        //public IList Children
        //{
        //    get
        //    {
        //        return new CompositeCollection()
        //    {
        //        new CollectionContainer() { Collection = Components },
        //        //new CollectionContainer() { Collection = Categories }
        //    };
        //    }
        //}
        public Category(XElement xElement)
        {
            _name = xElement.Attribute("name").Value;
            GetComponents(xElement);
            #region MyRegion
            //var listComp = xElement.Elements("Component");
            //foreach(var comp in listComp)
            //{
            //    //var newComp = new Component(comp);
            //    //newComp.GetCategoryName(this);
            //    //_componentList.Add(newComp);
            //    _componentNameList.Add(comp.Attribute("name").Value);
            //} 
            #endregion
        }

        private void GetComponents(XElement xElement)
        {
            //var noOfComp = xElement.Elements().Count();
            //for (int i = 0; i < noOfComp; i++)
            //{
            //    _components.Add(new Component(this));
            //}
            List<XElement> comps = xElement.Elements().ToList();
            foreach (var comp in comps)
            {
                _components.Add(new Component(this, comp));
            }

            //comps.ForEach(t => _components.Add(new Component(this, t)));
        }

        public override string ToString()
        {
            return Name;
        }

        //public void AddComponents(List<Component> compList)
        //{
        //    foreach (var comp in compList)
        //    {
        //        _componentList.add
        //    }
        //}
    }
}
