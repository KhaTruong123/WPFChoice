using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_concept.BuiltItems;
using Wpf_concept.Domain.TreeHiearchy.Model;

namespace Wpf_concept.Domain.TreeHiearchy.ViewModel
{
    public class PreviousAnsViewModel
    {
        public ObservableCollection<PreviousAnsModel> PreviousAns { get; set; }
    }
}
