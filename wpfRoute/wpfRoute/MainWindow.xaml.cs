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
using System.Data.SQLite;

namespace wpfRoute
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        public MainWindow()
        {
            InitializeComponent();

        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            SQLiteControl sss = new SQLiteControl();
            string qry = "select Housenum, Code, Unit, Delivery, Street, Path, Seq from route order by path, seq";
            sss.ExecQuery(qry);
            Grid1.ItemsSource =  sss.DT.DefaultView;

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Grid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnOpenUI_Click(object sender, RoutedEventArgs e)
        {
            UIScreen UIS = new UIScreen();
            UIS.ShowDialog();
        }
    }
}
