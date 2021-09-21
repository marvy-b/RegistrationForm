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
    public partial class DataForm2 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DI2RVTC\SQLEXPRESS;Initial Catalog=reFormSQL;Integrated Security=True");
        SqlDataAdapter adpt;
        SqlCommand cmd;
        DataTable dt;

        int row = 0;
        public DataForm2()
        {
            InitializeComponent();
        }
      
        private void DataForm2_Load(object sender, EventArgs e)
        {
            con.Open();
            cmd= new SqlCommand("SELECT * FROM reTable", con);
            cmd.ExecuteNonQuery();
            dt = new DataTable();
            
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void txtDisplay_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            var query = "SELECT * FROM reTable WHERE Username like '" + txtDisplay.Text + "%' or Name like '" + txtDisplay.Text + "%'";
            cmd = new SqlCommand(query, con);
           cmd.ExecuteNonQuery();
            adpt= new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            String id = dataGridView1[0, row].Value.ToString();

            DialogResult r = MessageBox.Show("Delete", "Do you want to Delete the Record!",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
            {


                con.Open();
                cmd.CommandText = "DELETE * FROM reTable WHERE id=" + id;
                var i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    MessageBox.Show("Record is Deleted");
                    con.Open();
                    cmd = new SqlCommand("SELECT * FROM reTable", con);
                    cmd.ExecuteNonQuery();
                    con.Close();


                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Error Deleting Record");
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateForm3 update = new UpdateForm3();
            update.txtUserName.Text = dataGridView1[1, row].Value.ToString();
            update.txtEmail.Text = dataGridView1[2, row].Value.ToString();
            update.txtPassword.Text = dataGridView1[3, row].Value.ToString();
            update.txtName.Text = dataGridView1[4, row].Value.ToString();
            update.txtPhone.Text = dataGridView1[5, row].Value.ToString();
            update.txtStatus.Text = dataGridView1[6, row].Value.ToString();
            update.txtMobile.Text = dataGridView1[7, row].Value.ToString();
            update.BirthDatePicker.Text = dataGridView1[8, row].Value.ToString();
            update.txtBirthPlace.Text = dataGridView1[9, row].Value.ToString();
            UpdateForm3.id = dataGridView1[0, row].Value.ToString();
            DialogResult result = update.ShowDialog();
            if (result == DialogResult.OK)
            {

                MessageBox.Show("Data Updated");
                MessageBox.Show("Record is Deleted");
                con.Open();
                cmd = new SqlCommand("SELECT * FROM reTable", con);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            else {
                MessageBox.Show("Data not Updated");
            }
        
        }
    }
}
