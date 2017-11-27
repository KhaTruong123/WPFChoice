using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Wpf_concept.BuiltItems;

namespace Wpf_concept
{
    public static class ParserDefinition
    {
        //public IEnumerable<string> NameList
        //{
        //    get { return _nameList; }
        //    set { _nameList = value; }
        //}
        //private IEnumerable<string> _nameList;

        public static List<Category> CategoryList { get { return _categoryList; } }
        public static List<Component> ComponentList { get { return _componentList; } }
        public static List<ComponentValue> CVList { get { return _cvList; } }
        
        private static List<Category> _categoryList = new List<Category>();
        private static List<Component> _componentList = new List<Component>();
        private static List<ComponentValue> _cvList = new List<ComponentValue>();


        public static void Parse()
        {
            string url = @"..\..\XMLfiles\DefCommponent_ver1.xml";
            var XFile = XDocument.Load(url);
            var rootNode = XFile.Root;

            var catElements = from c in rootNode.Descendants("Category") select c;
            foreach (var catElement in catElements)
            {
                var newCat = new Category(catElement);
                _categoryList.Add(newCat);
            }
            #region Replace by nesting objects
            //var compElements = from c in rootNode.Descendants("Component")
            //                   select c;

            //foreach (var comp in compElements)
            //{
            //    var newComp = new Component(comp);
            //    _componentList.Add(newComp);
            //}

            //var CVElements = from c in rootNode.Descendants("CompValue")
            //                   select c;
            //foreach (var CV in CVElements)
            //{
            //    var newCV = new ComponentValue(CV);
            //    _cvList.Add(newCV);
            //}
            #endregion
            _categoryList.ForEach(t => _componentList.AddRange(t.Components));
            _componentList.ForEach(t => _cvList.AddRange(t.CVList));
            // show robot list
            #region testing WPF
            //_nameList = (
            //    from firstNode in XFile.Element("FlexSpot").Elements("Category").Elements("Component")
            //    where firstNode.Attribute("name").Value == "Robot"
            //    from robotNode in firstNode.Elements("CompValue")
            //    select robotNode.Attribute("value").Value);
            #endregion

        }
    }
}