using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Wpf_concept.BuiltItems
{
    public class ComponentValue
    {
        public string PreviewPath { get { return _previewPath; } }
        public List<Choice> ChoiceList { get { return _choiceList; } }
        public List<Static> StaticList { get { return _staticList; } }
        public string Value { get { return _value; } }
        public string FilePath { get { return _filePath; } }
        public Component Component { get { return _component; } }
        public int ComponentID { get { return Component.ID; } }
        public string ComponentName { get { return _componentName; } }
        public string CategoryName { get { return _categoryName; } }


        private string _previewPath;
        private string _value;
        private string _filePath;
        private List<Static> _staticList = new List<Static>();
        private List<Choice> _choiceList = new List<Choice>();
        private Component _component;
        private string _componentName;
        private string _categoryName;


        public ComponentValue(XElement CVElement)
        {
            _value = CVElement.Attribute("value").Value;
            _filePath = CVElement.Attribute("path")?.Value;
            _previewPath = CVElement.Element("Preview")?.Attribute("path")?.Value;

            GetStaticValue(CVElement, _staticList);

            foreach (var choiceElement in CVElement.Elements("Choice"))
            {
                var choiceItem = new Choice
                {
                    Name = choiceElement.Attribute("name").Value,
                    Value = choiceElement.Attribute("value").Value,
                    Path = choiceElement.Attribute("path")?.Value,
                    Statics = new List<Static>()
                };
                GetStaticValue(choiceElement, choiceItem.Statics);
                _choiceList.Add(choiceItem);
            }

            _componentName = CVElement.Parent.Attribute("name").Value;
            _categoryName = CVElement.Parent.Parent.Attribute("name").Value;

        }

        private void GetStaticValue(XElement parentNode, List<Static> staticList)
        {
            foreach (var staticElement in parentNode.Elements("Static"))
            {
                var staticItem = new Static
                {
                    Name = staticElement.Attribute("name").Value,
                    Value = staticElement.Attribute("value").Value
                };
                staticList.Add(staticItem);
            }
        }

        public void GetComponentName(Component component)
        {
            _component = component;
        }
    }
}
