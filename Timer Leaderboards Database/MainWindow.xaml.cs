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
using System.Diagnostics;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Drawing;

namespace Timer_Leaderboards_Database
{
 
    public partial class MainWindow : Window
    {

        Stopwatch stopwatch = new();

        
        SqlConnection con = new SqlConnection(@"DataSource=OLLIEPC\SQLEXPRESS; Initial Catalog=record;");
        SqlCommand com;

        public MainWindow()
        {
            InitializeComponent();
            
            stopwatch.Start();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            stopwatch.Stop();
            double duration = stopwatch.Elapsed.TotalSeconds;
            
        }

        private void SubmitScore_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            com
        }
    }
}
