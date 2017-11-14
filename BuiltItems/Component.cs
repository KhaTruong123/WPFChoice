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
        public string CategoryName { get { return _categoryName; } }
        public List<ComponentValue> CVList { get { return _cvList; } }
        public List<string> CVNameList { get { return _cvNameList; } }
        public int order { get; set; }
        public int ID { get; set; }

        private string _name;
        private Category _category;
        private string _categoryName;
        private List<ComponentValue> _cvList = new List<ComponentValue>();
        private List<string> _cvNameList = new List<string>();
        public Component(XElement compElement)
        {
            _name = compElement.Attribute("name").Value;
            var listCV = compElement.Elements("CompValue");
            foreach (var CV in listCV)
            {
                //var newCV = new ComponentValue(CV);
                //newCV.GetComponentName(this);
                //_cvList.Add(newCV);
                _cvNameList.Add(CV.Attribute("value").Value);
            }
            _categoryName = compElement.Parent.Attribute("name").Value;
        }

        public void GetCategoryName(Category category)
        {
            _category = category;
        }
    }
}
