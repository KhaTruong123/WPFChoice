using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using Wpf_concept.Domain.TreeHiearchy.Model;
using Wpf_concept.Domain.Common.ViewModel;
using Wpf_concept.Enums;
using Wpf_concept.BuiltItems;
using Wpf_concept.Restriction;

namespace Wpf_concept.Domain.TreeHiearchy.ViewModel
{
    public class TreeViewModel : AbstractViewModel
    {
        private TreeModel _selectedComponentValue;
        private TreeModel _selecteModel;

        public TreeViewModel()
        {
            Intialize();
        }

        private void Intialize()
        {
            TreeItemsColletions = new ObservableCollection<TreeModel>();
            //ComponentValueItems = new ObservableCollection<TreeModel>();
            ComponentValueChoices = new ObservableCollection<ComponentValue>();

            foreach (var category in ParserDefinition.CategoryList)
            {
                var catModel = new TreeModel();
                catModel.Name = category.Name;
                catModel.Type = Enums.EnumComponentType.Category;

                foreach(var component in category.Components)
                {
                    var compModel = new TreeModel();
                    compModel.Name = component.Name;
                    compModel.Type = Enums.EnumComponentType.Component;
                    foreach (var componentValue in component.CVList)
                    {
                        compModel.ComponentValues.Add(componentValue);
                    }
                    catModel.Childs.Add(compModel);

                    //foreach (var componentValue in component.CVList)
                    //{
                    //    var componentChild = new TreeModel();
                    //    componentChild.Name = componentValue.Value;
                    //    componentChild.Type = Enums.EnumComponentType.ComepentValue;
                    //    child.Childs.Add(componentChild);
                    //}
                }
                TreeItemsColletions.Add(catModel);
            }
        }

        public ObservableCollection<TreeModel> TreeItemsColletions { get; set; }

        //public ObservableCollection<TreeModel> ComponentValueItems { get; set; }
        public ObservableCollection<ComponentValue> ComponentValueChoices { get; set; }

        //public TreeModel SelectedComponentValue
        //{
        //    get { return _selectedComponentValue; }
        //    set
        //    {
        //        _selectedComponentValue = value;
        //        OnPropertyChanged("SelectedComponentValue");
                
        //    }
        //}
        public TreeModel SelectedModel
        {
            get { return _selecteModel; }
            set
            {
                _selecteModel = value;
                OnPropertyChanged("SelectedModel");

                //LoadComboBox(_selecteModel);
                PreLoadComboBox2(_selecteModel);
            }
        }

        //private void LoadComboBox(TreeModel _selectedModel)
        //{
            
        //    ComponentValueItems.Clear();
        //    if (_selectedModel == null) return;
        //    if (!_selectedModel.Type.Equals(EnumComponentType.Component)) return;
        //    foreach (var componentValue in _selectedModel.Childs)
        //    {
        //        ComponentValueItems.Add(componentValue);
        //    }
        //}

        private void PreLoadComboBox2(TreeModel _seletedModel)
        {
            ComponentValueChoices.Clear();
            if (_selecteModel ==null || !_selecteModel.Type.Equals(EnumComponentType.Component)) return;
            //var posCompValues = compValueConstraint(_seletedModel);
            foreach (var componentValue in _seletedModel.ComponentValues)
            {
                ComponentValueChoices.Add(componentValue);
            }
            //foreach (var componentValue in posCompValues)
            //{
            //    ComponentValueChoices.Add(componentValue);
            //}
        }

        //private List<ComponentValue> compValueConstraint(TreeModel comp)
        //{
        //    var compValueList = new List<ComponentValue>();
        //    var mainWin = new MainWindow();
        //    var compVals = comp.ComponentValues.ToList();
        //    FIlterCV.Filter(comp.Name, compVals, ParserConstraint.Restriction, mainWin.PreAnsList);

        //    return compValueList;
        //}
    }
}
