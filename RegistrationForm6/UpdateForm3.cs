using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace RegistrationForm6
{
    public partial class UpdateForm3 : Form
    {
        public UpdateForm3()
        {
            InitializeComponent();
        }
        public static String id = "";


        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DI2RVTC\SQLEXPRESS;Initial Catalog=reFormSQL;Integrated Security=True");
        SqlCommand cmd;
        DataTable dt;


        private void UpdateForm3_Load(object sender, EventArgs e)
        {

            con.Open();
            cmd = new SqlCommand("SELECT * FROM reTable", con);
            cmd.ExecuteNonQuery();
            dt = new DataTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            con.Open();
            cmd.CommandText = "UPDATE * FROM reTable SET Username='" + txtUserName.Text + "',Email='" + txtEmail.Text + "'," +
                "Password='" + txtPassword.Text + "',Name='" + txtName.Text + "',Phone='" + txtPhone.Text + "',Status='" + txtStatus.Text + "'," +
                "Mobile='" + txtMobile.Text + "',BirthDate='" + BirthDatePicker.Text + "',BirthPlace='" + txtBirthPlace.Text + "'WHERE id " + id;
            
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                MessageBox.Show("Data is Updated");

            }
            else
            {
                MessageBox.Show("Data is not Updated");
            }
            con.Close();
        }
    }
}
  
