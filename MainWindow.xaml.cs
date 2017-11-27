using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf_concept.BuiltItems;
using Wpf_concept.Restriction;
using Wpf_concept.Domain.TreeHiearchy.ViewModel;
using Wpf_concept.Domain.TreeHiearchy.Model;
using Wpf_concept.Enums;
using System.Collections.ObjectModel;

namespace Wpf_concept
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Data access properties
        public List<Category> Categories { get; set; }
        public List<Component> Components { get; set; }
        public List<ComponentValue> CVs { get; set; }
        #endregion

        #region View model properties
        #endregion

        public ObservableCollection<ComponentValue> CompValuesAvail { get { return _compValuesAvail; } }

        public MainWindow()
        {

            //Categories = new List<string>();
            //Components = new List<string>();
            //CVs = new List<string>();

            //ParserDefinition.Parse();
            //ParserDefinition.CategoryList.ForEach(t => Categories.Add(t.Name));
            //ParserDefinition.ComponentList.ForEach(t => Components.Add(t.Name));
            //ParserDefinition.CVList.ForEach(t => CVs.Add(t.Value));
            InitializeComponent();
            ParserDefinition.Parse();
            ParserConstraint.Parse();

            #region Data Access
            Categories = new List<Category>();
            Components = new List<Component>();
            CVs = new List<ComponentValue>();

            Categories = ParserDefinition.CategoryList;
            Components = ParserDefinition.ComponentList;
            CVs = ParserDefinition.CVList;

            _restrictedList = ParserConstraint.Restriction;

            #endregion

            #region View Model (before)
            //CategoriesVM = new List<CategoryVM>();
            //Categories.ForEach(t => CategoriesVM.Add(new CategoryVM(t)));

            //ComponentsVM = new List<ComponentVM>();
            //foreach (var cat in CategoriesVM)
            //{
            //    ComponentsVM.AddRange(cat.Components);
            //}

            //CVsVM = new List<CV_VM>();
            //foreach (var comp in ComponentsVM)
            //{
            //    CVsVM.AddRange(comp.CVs_VM);

            //}
            #endregion

            var viewModel = new TreeViewModel();
            _previousAnsCollection = new ObservableCollection<PreviousAnsModel>();
            MainTreeView.DataContext = viewModel;

            _preAnsDict = new Dictionary<string, ComponentValue>();
            _modelItem = new TreeModel();
            MainTreeView.SelectedItemChanged += delegate (object sender, RoutedPropertyChangedEventArgs<object> e)
            {
                _modelItem = e.NewValue as TreeModel;
                if (!_modelItem.Type.Equals(EnumComponentType.Component) || _modelItem == null) return;
                viewModel.SelectedModel = _modelItem;

                var list = FIlterCV.Filter(viewModel.SelectedModel.Name, viewModel.ComponentValueChoices.ToList(), _restrictedList, _preAnsDict);
                _compValuesAvail = new ObservableCollection<ComponentValue>(list);

                ComboBox_CV.ItemsSource = _compValuesAvail;
                ComboBox_CVContent.Visibility = Visibility.Hidden;
            };
            ComboBox_CV.SelectionChanged += ComboBox_CV_SelectionChanged;
        }

        private void ComboBox_CV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox_CV.SelectedItem != null)
            {
                var cv = ComboBox_CV.SelectedItem as ComponentValue;
                _preAnsDict[_modelItem.Name] = cv;
                var newPreAnsDict = CheckValueConflict(_preAnsDict, new KeyValuePair<string, ComponentValue>(_modelItem.Name, cv));
                AddOrRemoveAnswerToCollection(newPreAnsDict);
                ShowCVContent(cv);
            }
        }

        private void ShowCVContent(ComponentValue cv)
        {
            if (cv.Content.ChoiceList.Count == 0) return;

            ComboBox_CVContent.Visibility = Visibility.Visible;
            ComboBox_CVContent.ItemsSource = cv.Content.ChoiceList;
        }

        private Dictionary<string, ComponentValue> CheckValueConflict(Dictionary<string, ComponentValue> preAnsDict, KeyValuePair<string, ComponentValue> item)
        {
            var list = preAnsDict.ToList();
            //var index = list.IndexOf(item);
            //if (index == list.Count-1) return preAnsDict;
            int index = -1;
            for (int i = index + 1; i < list.Count; i++ )
            {
                //var newAnsList = list.GetRange(0, i);
                //var newAnsDict = new Dictionary<string, ComponentValue>();
                //newAnsList.ForEach(t => newAnsDict.Add(t.Key, t.Value));
                //var avaiCompValues = FIlterCV.Filter(list[i].Key, CVs, _restrictedList, newAnsDict);
                var avaiCompValues = FIlterCV.Filter(list[i].Key, CVs, _restrictedList, preAnsDict);
                if (!avaiCompValues.Contains(list[i].Value))
                    preAnsDict.Remove(list[i].Key);
            }
            return preAnsDict;
            // find the index of current Commponent (in dict) (actually, why using index? Forget about performance, just scan through the whole list
            // check the values afterwards in dict (with larger index), if these values is in PossibleValueList?
                // foreach (var comp nam o phia sau)
                    // create newPreAnsDict, store values from this key to the start of dict.
                    // availableCompValues = FilterCV.Filter(key, CVs, restrictedList, newDict)
                    // if value correspond to that doesn't belong to the list => remove it
        }

        private void AddOrRemoveAnswerToCollection(Dictionary<string, ComponentValue> preAnsDict)
        {
            _previousAnsCollection.Clear();
            foreach (var ans in preAnsDict)
            {
                _previousAnsCollection.Add(new PreviousAnsModel { Component = ans.Key, ComponentValue = ans.Value });
            }
            lb_preAnsListRight.ItemsSource = _previousAnsCollection; //todo to move it and ComboBoxItemsource above
        }

        private List<RestrictedData> _restrictedList;
        private static Dictionary<string, ComponentValue> _preAnsDict;
        private TreeModel _modelItem;
        private ObservableCollection<ComponentValue> _compValuesAvail;
        private ObservableCollection<PreviousAnsModel> _previousAnsCollection;
    }
}
