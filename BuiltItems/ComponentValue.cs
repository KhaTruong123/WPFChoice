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
        public string Value { get; set; }
        public string Path { get; }
        public CVContent Content { get; }
        public Component Component { get; }


        public ComponentValue(XElement xElement, Component comp)
        {
            Value = xElement.Attribute("value").Value;
            Path = xElement.Attribute("path")?.Value;
            Content = new CVContent(xElement);
            Component = comp;
        }

        public override string ToString()
        {
            return this.Value; 
        }

        //private void GetStaticValue(XElement parentNode, List<Static> staticList)
        //{
        //    foreach (var staticElement in parentNode.Elements("Static"))
        //    {
        //        var staticItem = new Static
        //        {
        //            Name = staticElement.Attribute("name").Value,
        //            Value = staticElement.Attribute("value").Value
        //        };
        //        staticList.Add(staticItem);
        //    }
        //}
    }




}
