using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_concept.ViewModel;
using System.Collections.ObjectModel;
using Wpf_concept.BuiltItems;
using Wpf_concept.Enums;
using Wpf_concept.Domain.Common.ViewModel;

namespace Wpf_concept.Domain.TreeHiearchy.Model
{
    public class TreeModel : AbstractViewModel
    {
        private string _name;
        private EnumComponentType _type;
        //private object _choice;

        //todo private ComponentValue _choice;

        public TreeModel()
        {
            Childs = new ObservableCollection<TreeModel>();
            ComponentValues = new ObservableCollection<ComponentValue>();
        }
        public string Name
            { get {return _name;}
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            } }

        public EnumComponentType Type
        {
            get { return _type; }
            set
            {
                _type = value;
                OnPropertyChanged("Type");
            }
        }

        public ObservableCollection<TreeModel> Childs { get; set; }
        public ObservableCollection<ComponentValue> ComponentValues { get; set; }
    }
}
