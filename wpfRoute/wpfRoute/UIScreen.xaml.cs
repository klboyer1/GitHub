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
using System.Windows.Shapes;

namespace wpfRoute
{
    /// <summary>
    /// Interaction logic for UIScreen.xaml
    /// </summary>
    public partial class UIScreen : Window
    {
        public UIScreen()
        {
            InitializeComponent();
            SQLiteControl sss = new SQLiteControl();
            string qry = "select Housenum, Code, Unit, Delivery, Street, Path, Seq from route order by path, seq";
            sss.ExecQuery(qry);
            grid1.ItemsSource = sss.DT.DefaultView;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void grid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
