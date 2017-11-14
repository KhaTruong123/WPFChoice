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

namespace Wpf_concept
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IEnumerable<string> RobotList { get; set; }
        public List<string> Categories { get; set; }
        public List<string> Component { get; set; }
        public List<string> CV { get; set; }

        public MainWindow()
        {
            var parser = new Parser();
            Categories = new List<string>();
            Component = new List<string>();
            CV = new List<string>();

            parser.CategoryList.ForEach(t => Categories.Add(t.Name));
            parser.ComponentList.ForEach(t => Component.Add(t.Name));
            parser.CVList.ForEach(t => CV.Add(t.Value));

            //RobotList = parser.NameList;

            InitializeComponent();
            this.DataContext = this;

        }
    }
}
