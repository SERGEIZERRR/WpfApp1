using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static ПервоеDLL.Class1;
using System.Data;
using System.Linq;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Table.xaml
    /// </summary>
    public partial class Table : Window
    {
        public Table()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string query = "select * from Cylindr_Head";
            if (!string.IsNullOrEmpty(TextBox1.Text))
            {
                query += "where Cylindr_Head= '" + TextBox1.Text + "'";
            }
            var list = DBConnectionService.SendQueryToSqlServer(query);
            dataGridView1.Columns.Clear();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string ID = null;
            string num_detail = null;
            string naim_detail = null;
            string gost = null;
            try
            {
                ID = ID1.Text;
                num_detail = num_detail1.Text;
                naim_detail = naim_detail1.Text;
                gost = gost1.Text;
            }
            catch (Exception)
            {
                MessageBox.Show("Пошел НАХУЙ");
                return;
            }
            string query = "INSERT INTO Cylindr_Head(ID,num_detail,naim_detail,gost)" + "values(" + $"'{ID}','{num_detail}','{naim_detail}','{gost}'" + ")";
            int? result = DBConnectionService.SendCommandToSqlServer(query);
            if (result != null && result > 0)
            {
                MessageBox.Show("Заебись, четко!");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string ID = null;
            string num_detail = null;
            string naim_detail = null;
            string gost = null;
            try
            {
                ID = ID1.Text;
                num_detail = num_detail1.Text;
                naim_detail = naim_detail1.Text;
                gost = gost1.Text;
            }
            catch (Exception)
            {
                MessageBox.Show("Пошел НАХУЙ");
                return;
            }
            string query = "Update dbo.Cylindr_Head set ID = '" + ID + "','" + num_detail + "','" + naim_detail + "','" + gost + "'";
            int? result = DBConnectionService.SendCommandToSqlServer(query);
            if (result != null && result > 0)
            {
                MessageBox.Show("Заебись, четко!");
            }

        }

        private class IdentityItem
        {
            private string v1;
            private string v2;

            public IdentityItem(string v1, string v2)
            {
                this.v1 = v1;
                this.v2 = v2;
            }
        }
    }
}
