using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Threading.Tasks;
using Wpf_concept.Restriction;

namespace Wpf_concept
{
    public static class ParserConstraint
    {
        public static List<RestrictedData> Restriction { get { return _restriction; } }
        private static List<RestrictedData> _restriction = new List<RestrictedData>();
        public static void Parse ()
        {
            string url = @"..\..\\XMLfiles\Constraints.xml";
            XDocument contrainedDoc = XDocument.Load(url);
            var rootNode = contrainedDoc.Root;

            foreach (var node in rootNode.Elements())
            {
                var restriction = new RestrictedData(node);
                Restriction.Add(restriction);
            }
        }
    }
}
