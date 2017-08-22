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
using System.Data.SQLite;

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
            string qry = "select Street, Housenum, Code, Unit, Delivery, Path, Seq from route order by path, seq";
            sss.ExecQuery(qry);
            grid1.ItemsSource = sss.DT.DefaultView;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void grid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.txtStreet.Text = " "; 
        }

       

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SQLiteControl sss = new SQLiteControl();
                int houseNum = Convert.ToInt32(this.txtHouseNum.Text);
                String query = "insert into route (Street, Housenum, Code, Unit, Delivery) " +
                    "Values " +
                    "('" + this.txtStreet.Text + "','" + houseNum + "','" + this.cboCode.Text + "','" + this.txtUnit.Text + "','" + this.txtDelivery.Text + "')";

                sss.ExecNonQuery(query);
                MessageBox.Show("Customer added successfully...");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                throw;
            }
        }

    }
}
