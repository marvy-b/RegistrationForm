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
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                txtUserName.Text = "Username";
                txtUserName.ForeColor = Color.Silver;
            }
        }

        private void txtUserName_Enter(object sender, EventArgs e)
        {
            if (txtUserName.Text == "Username")
            {
                txtUserName.Text = "";
                txtUserName.ForeColor = Color.Black;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "Email";
                txtEmail.ForeColor = Color.Silver;
            }
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Email")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.Black;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.Silver;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
            }
        }

        private void txtConfirmPassword_Leave(object sender, EventArgs e)
        {
            if (txtConfirmPassword.Text == "")
            {
                txtConfirmPassword.Text = "Confirm Password";
                txtConfirmPassword.ForeColor = Color.Silver;
            }
        }

        private void txtConfirmPassword_Enter(object sender, EventArgs e)
        {
            if (txtConfirmPassword.Text == "Confirm Password")
            {
                txtConfirmPassword.Text = "";
                txtConfirmPassword.ForeColor = Color.Black;
            }

        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                txtName.Text = "Name";
                txtName.ForeColor = Color.Silver;
            }
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            if (txtName.Text == "Name")
            {
                txtName.Text = "";
                txtName.ForeColor = Color.Black;
            }
        }

        private void txtStatus_Leave(object sender, EventArgs e)
        {
            if (txtStatus.Text == "")
            {
                txtStatus.Text = "Status";
                txtStatus.ForeColor = Color.Silver;
            }
        }

        private void txtStatus_Enter(object sender, EventArgs e)
        {
            if (txtStatus.Text == "Status")
            {
                txtStatus.Text = "";
                txtStatus.ForeColor = Color.Black;
            }
        }

        private void txtPhone_Leave(object sender, EventArgs e)
        {
            if (txtPhone.Text == "")
            {
                txtPhone.Text = "Phone";
                txtPhone.ForeColor = Color.Silver;
            }
        }

        private void txtPhone_Enter(object sender, EventArgs e)
        {
            if (txtPhone.Text == "Phone")
            {
                txtPhone.Text = "";
                txtPhone.ForeColor = Color.Black;
            }
        }

        private void txtMobile_Leave(object sender, EventArgs e)
        {
            if (txtMobile.Text == "")
            {
                txtMobile.Text = "Mobile";
                txtMobile.ForeColor = Color.Silver;
            }
        }

        private void txtMobile_Enter(object sender, EventArgs e)
        {
            if (txtMobile.Text == "Mobile")
            {
                txtMobile.Text = "";
                txtMobile.ForeColor = Color.Black;
            }
        }

        private void txtBirthPlace_Leave(object sender, EventArgs e)
        {
            if (txtBirthPlace.Text == "")
            {
                txtBirthPlace.Text = "Birth Place";
                txtBirthPlace.ForeColor = Color.Silver;
            }
        }

        private void txtBirthPlace_Enter(object sender, EventArgs e)
        {
            if (txtBirthPlace.Text == "Birth Place")
            {
                txtBirthPlace.Text = "";
                txtBirthPlace.ForeColor = Color.Black;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "Username"; txtUserName.ForeColor = Color.Silver;
            txtEmail.Text = "Email"; txtEmail.ForeColor = Color.Silver;
            txtConfirmPassword.Text = "Confirm Password"; txtConfirmPassword.ForeColor = Color.Silver;
            txtPassword.Text = "Password"; txtPassword.ForeColor = Color.Silver;
            txtName.Text = "Name"; txtName.ForeColor = Color.Silver;
            txtPhone.Text = "Phone"; txtPhone.ForeColor = Color.Silver;
            txtStatus.Text = "Status"; txtStatus.ForeColor = Color.Silver;
            txtMobile.Text = "Mobile"; txtMobile.ForeColor = Color.Silver;
            txtBirthPlace.Text = "Birth Place"; txtBirthPlace.ForeColor = Color.Silver;
        }

        private void btnShowData_Click(object sender, EventArgs e)
        {
            Hide();
            DataForm2 form = new DataForm2();
            form.ShowDialog();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == txtConfirmPassword.Text)
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DI2RVTC\SQLEXPRESS;Initial Catalog=reFormSQL;Integrated Security=True");
                con.Open();
                var sa = BirthDatePicker.Value;
                var query = $"INSERT INTO  reTable (Username,Email,Password,Name,Phone,Status,Mobile,BirthDate,BirthPlace) VALUES('{txtUserName.Text}','{txtEmail.Text}','{txtPassword.Text}','{txtName.Text}','{txtPhone.Text}','{txtStatus.Text}','{txtMobile.Text}','{sa}','{txtBirthPlace.Text}')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Saved");
            }
            else
            {
                MessageBox.Show("Confirm your Password. Error saving data");
            }
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }
    }
}
