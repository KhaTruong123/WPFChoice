using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Wpf_concept.BuiltItems;

namespace Wpf_concept
{
    public class Parser
    {
        public IEnumerable<string> NameList
        {
            get { return _nameList; }
            set { _nameList = value; }
        }
        private IEnumerable<string> _nameList;

        private XDocument XFile;

        public List<Category> CategoryList { get { return _categoryList; } }
        public List<Component> ComponentList { get { return _componentList; } }
        public List<ComponentValue> CVList { get { return _cvList; } }
        
        private List<Category> _categoryList = new List<Category>();
        private List<Component> _componentList = new List<Component>();
        private List<ComponentValue> _cvList = new List<ComponentValue>();


        public Parser()
        {
            string url = "..\\..\\..\\XMLfolder\\Kha'ss\\DefCommponent_ver1.xml";
            XFile = XDocument.Load(url);
            var rootNode = XFile.Element("FlexSpot");

            var catElements = from c in rootNode.Descendants("Category") select c;
            foreach (var catElement in catElements)
            {
                var newCat = new Category(catElement);
                _categoryList.Add(newCat);
            }

            var compElements = from c in rootNode.Descendants("Component")
                               select c;
            foreach (var comp in compElements)
            {
                var newComp = new Component(comp);
                _componentList.Add(newComp);
            }

            var CVElements = from c in rootNode.Descendants("CompValue")
                               select c;
            foreach (var CV in CVElements)
            {
                var newCV = new ComponentValue(CV);
                _cvList.Add(newCV);
            }

            // show robot list
            #region testing WPF
            _nameList = (
                from firstNode in XFile.Element("FlexSpot").Elements("Category").Elements("Component")
                where firstNode.Attribute("name").Value == "Robot"
                from robotNode in firstNode.Elements("CompValue")
                select robotNode.Attribute("value").Value);
            #endregion
        }
    }
}