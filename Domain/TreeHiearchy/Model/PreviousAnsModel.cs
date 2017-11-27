using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_concept.BuiltItems;

namespace Wpf_concept.Domain.TreeHiearchy.Model
{
    public class PreviousAnsModel
    {
        public string Component { get; set; }
        public ComponentValue ComponentValue { get; set; }

        public override string ToString()
        {
            return Component + " " + ComponentValue.Value;
        }
    }
}
