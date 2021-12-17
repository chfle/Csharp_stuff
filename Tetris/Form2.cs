using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Tetris
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            scoreBoardPos.Text = " ";
            ScoreBoardScore.Text = "";
            ScoreBoardName.Text = "";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
             try
            {
                 string cs = @"server=192.168.55.8;user id=tetris;password=pqjerPCgChu2wvyJvYuXkZxxjHv6RbfE7mqebecz33mURUEv8K!123;database=tetris";

                var conn = new MySqlConnection(cs);
                var cmd = new MySqlCommand();

                cmd.Connection = conn;

                conn.Open();

                // read user data
                try
                {
                    cmd.CommandText = "Select * from score ORDER BY Score DESC;";

                    var reader = cmd.ExecuteReader();

                    // go over every item

                    var count = 1;
                    while (reader.Read())
                    {
                        scoreBoardPos.Text += $"{count++}\n";
                        ScoreBoardName.Text += $"{reader["Name"]}\n";
                        ScoreBoardScore.Text += $"{reader["Score"]}\n";
                    }

                } catch
                {
                    MessageBox.Show("Can't show users");
                }
            } catch (Exception ex)
            {
                MessageBox.Show($"Something went wrong\n Error: {ex.Message}");
                return;
            }

        }
    }
}
