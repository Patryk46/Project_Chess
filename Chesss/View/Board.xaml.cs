using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Chesss.View
{
    /// <summary>
    /// Logika interakcji dla klasy Board.xaml
    /// </summary>
    public partial class Board : UserControl
    {
        public Board()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty FieldProperty =
            DependencyProperty.Register(
                nameof(Field),
                typeof(ObservableCollection<string>),
                typeof(Board));
        public ObservableCollection<string> Field
        {
            get { return (ObservableCollection<string>)GetValue(FieldProperty); }
            set { SetValue(FieldProperty, value); }
        }
        
    }
}
