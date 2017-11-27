using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace Wpf_concept.BuiltItems
{
    public class CVContent
    {
        //public int ID { get; }
        //public int CompValueID { get; }
        public string PreviewPath { get; }
        public List<Static> StaticList { get; }
        public List<Choice> ChoiceList { get; }

        public CVContent(XElement CVElement)
        {
            PreviewPath = CVElement.Element("Preview")?.Attribute("path")?.Value;

            StaticList = GetStaticValue(CVElement);
            ChoiceList = GetChoiceValue(CVElement);
        }

        private List<Choice> GetChoiceValue(XElement cVElement)
        {
            var list = new List<Choice>();
            foreach (var choiceElement in cVElement.Elements("Choice"))
            {
                var choiceItem = new Choice
                {
                    Name = choiceElement.Attribute("name").Value,
                    Value = choiceElement.Attribute("value").Value,
                    Path = choiceElement.Attribute("path")?.Value,
                    Statics = new List<Static>()
                };
                choiceItem.Statics = GetStaticValue(choiceElement);
                list.Add(choiceItem);
            }
            return list;
        }

        private List<Static> GetStaticValue(XElement parentNode)
        {
            var staticList = new List<Static>();
            foreach (var staticElement in parentNode.Elements("Static"))
            {
                var staticItem = new Static
                {
                    Name = staticElement.Attribute("name").Value,
                    Value = staticElement.Attribute("value").Value
                };
                staticList.Add(staticItem);
            }
            return staticList;
        }

        public class Choice
        {
            public List<Static> Statics { get; set; }
            public string Path { get; set; }
            public string Name { get; set; }
            public string Value { get; set; }
        }

        public class Static
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }
    }
}

