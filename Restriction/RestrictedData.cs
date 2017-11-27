using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace Wpf_concept.Restriction
{
    public class RestrictedData
    {
        public string ParentName { get; }
        public string ParentValue { get; }
        public string ChildName { get; }
        public string ChildValue { get; }
        public string Choice { get; }
        public RestrictedData(XElement xElement)
        {
            ParentName = xElement.Attribute("parentName").Value;
            ParentValue = xElement.Attribute("parentValue").Value;
            ChildName = xElement.Attribute("childName").Value;
            ChildValue = xElement.Attribute("childValue").Value;
            Choice = xElement.Attribute("choice")?.Value;
        }
    }
}
