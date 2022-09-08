using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows;

namespace Timer_Leaderboards_Database
{

    public partial class MainWindow : Window
    {

        Stopwatch stopwatch = new();
        double duration;


        SqlConnection con = new SqlConnection(@"Data Source=OLLIEPC\SQLEXPRESS;Initial Catalog=Timer;Integrated Security=True;");
        SqlCommand com;
        SqlDataReader rd;

        public MainWindow()
        {
            InitializeComponent();

            stopwatch.Start();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {


            stopwatch.Stop();
            duration = stopwatch.Elapsed.TotalSeconds;
            duration = Math.Round(duration, 2);


        }

        private void SubmitScore_Click(object sender, RoutedEventArgs e)
        {

            con.Open();
            com = new SqlCommand("insert into TimerLeaderboards values('" + Enter_Name.Text.ToUpper() + "','" + duration + "')", con);
            com.ExecuteNonQuery();
            MessageBox.Show("Data saved in database");
            con.Close();


        }

        private void Retrieve_Scores_Click(object sender, RoutedEventArgs e)//retrieves particular player info
        {
            /*  con.Open();
              com = new SqlCommand("select PlayerID, UName, Score from TimerLeaderboards order by Score DESC;", con);

              com.Parameters.AddWithValue("PlayerID", usernames.Text);
              SqlDataReader reader;
              reader = com.ExecuteReader();
              if(reader.Read())
              {
                  usernames.Text = reader["UName"].ToString();
                  scores.Text = reader["Score"].ToString();
              }
              else
              {
                  MessageBox.Show("No Data Found");
              }

              //com.ExecuteNonQuery();
              con.Close();*/

            string sql = ("select * from TimerLeaderboards order by Score DESC");//select from the timerleaderboards table and order by score (high to low)

            con.Open();
            com = new SqlCommand(sql, con);
            rd = com.ExecuteReader();

            while (rd.Read())
            {
                MessageBox.Show(rd.GetValue(1) + "-" + rd.GetValue(2));//numbers refer to columns
            }
            con.Close();



        }



    }
}
